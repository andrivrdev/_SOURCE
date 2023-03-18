using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Updater.Properties;

namespace devUpdater
{
    public delegate void UpdatesCompleted(int numbrOfFilesUpdated);
    public delegate void UpdatesErrors(string errorMessage);
    public delegate void UpdatesProgressPercentage(int percentage);

    public partial class Main : Form
    {
        /// <summary>
        ///
        ///
        ///
        ///
        /// </summary>
        public RunMode Mode { get; set; }
        public UpdateMode UpdateType { get; set; }

        Timer sLoadTiemr;
        Timer sCloseTimer;
        private bool ManagerInit = false;

        private double sTotDlSize = 0;
        private double sTotDlSizeDone = 0;

        public event UpdatesCompleted onUpdatesCompleted;
        public event UpdatesErrors onUpdatesErrors;
        public event UpdatesProgressPercentage onUpdatesProgressPercentage;

        public Main()
        {
            InitializeComponent();

            btnCheckForUpdates.Visible = false;
            btnCreateUpdatesFile.Visible = false;

            if (Mode == RunMode.Hidden)
            {
                SendToBack();
                ShowInTaskbar = false;
                Visible = false;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (Mode == RunMode.StandAlone)
            {
                ManagerInit = true;
                Opacity = 100;
            }
            else
            {
                if (Mode == RunMode.Normal)
                    Opacity = 100;

                if (Manager.InitComplete)
                {
                    ManagerInit = true;
                }
                else
                {
                    Manager.ThrowErr("Error 1: Can not start Updater without Initializing it 1st. Run Manager.Init.");
                }
            }
        }
        private void Main_Shown(object sender, EventArgs e)
        {
            if (Mode == RunMode.Hidden)
            {
                SendToBack();
                Visible = false;
            }

            if (ManagerInit)
            {
                sLoadTiemr = new Timer();
                sLoadTiemr.Interval = 200;
                sLoadTiemr.Tick += new EventHandler(sLoadTiemr_Tick);
                sLoadTiemr.Start();
            }
            else
            {
                Visible = false;
                Close();
            }
        }

        void sLoadTiemr_Tick(object sender, EventArgs e)
        {
            sLoadTiemr.Stop();

            try
            {
                sLoadTiemr.Dispose();
            }
            catch (Exception ex)
            {

            }

            AppStart();
        }

        private void AppStart()
        {
            Manager.onUpdateError += new UpdateError(Manager_onUpdateError);
            Manager.onUpdateListReceived += new UpdateListReceived(Manager_onUpdateListReceived);

            Manager.onReadingLocalFilesDone += new ReadingLocalFiles(Manager_onReadingLocalFilesDone);

            Manager.onDownloadStarted += new DownloadStarted(Manager_onDownloadStarted);
            Manager.onDownloadFileName += new DownloadFileName(Manager_onDownloadFileName);
            Manager.onDownloadProgress += new DownloadProgress(Manager_onDownloadProgress);
            Manager.onDownloadProgressBytes += new DownloadProgressBytes(Manager_onDownloadProgressBytes);
            Manager.onDownloadFileComplete += new DownloadFileComplete(Manager_onDownloadFileComplete);
            Manager.onAllFilesDownloaded += new AllFilesDownloaded(Manager_onAllFilesDownloaded);

            #region StandAlone
            if (Mode == RunMode.StandAlone)
            {
                Settings.Init();
                Settings.LoadSettings();
                Settings.AppPath = Directory.GetCurrentDirectory() + "\\";

                Manager.Init(Settings.WebPath, Settings.LocalPath);

                #region Read use local from settings
                if (Settings.UseLocalPath != null && Settings.UseLocalPath != "")
                {
                    try
                    {
                        bool wUseLocal = Convert.ToBoolean(Settings.UseLocalPath);
                        if (wUseLocal)
                            UpdateType = UpdateMode.Local;
                        else
                            UpdateType = UpdateMode.Online;
                    }
                    catch (Exception exx)
                    {
                        Manager.ThrowErr("Exception: Main: AppStart: InnerException: " + exx.Message);
                    }
                }
                #endregion

                bool werr = true;
                if (UpdateType == UpdateMode.Local && Settings.LocalPath.Length > 0)
                {
                    btnCheckForUpdates.Visible = true;
                    btnCreateUpdatesFile.Visible = true;
                    werr = false;
                }

                if (UpdateType == UpdateMode.Online && Settings.WebPath.Length > 0)
                {
                    btnCheckForUpdates.Visible = true;
                    btnCreateUpdatesFile.Visible = true;
                    werr = false;
                }

                if (werr)
                    Manager.ThrowErr("Error 2: UpdaterSettings.txt File not configured.");
            }
            #endregion
            #region Normal
            if (Mode == RunMode.Normal)
            {
                BringToFront();

                if (UpdateType == UpdateMode.Local)
                    Settings.UseLocalPath = "true";
                if (UpdateType == UpdateMode.Online)
                    Settings.UseLocalPath = "false";

                Settings.SaveSettings();

                if (Settings.WebPath.Length > 0 && Settings.LocalPath.Length > 0)
                {
                    //Manager.ThrowErr("### AppStart: PathSettings: " + Settings.WebPath);

                    DisableButtons();
                    StartCreateUpdFile();
                }
                else
                {
                    Manager.ThrowErr("Error 3: Not Enough Parameters sent to SetUpdatePaths.");
                }
            }
            #endregion
            #region Hidden
            if (Mode == RunMode.Hidden)
            {
                Visible = false;

                if (UpdateType == UpdateMode.Local)
                    Settings.UseLocalPath = "true";
                if (UpdateType == UpdateMode.Online)
                    Settings.UseLocalPath = "false";

                Settings.SaveSettings();

                if (Settings.WebPath.Length > 0 && Settings.LocalPath.Length > 0)
                {
                    DisableButtons();
                    StartCreateUpdFile();
                }
                else
                {
                    Manager.ThrowErr("Error 4: Not Enough Parameters sent to SetUpdatePaths.");
                }
            }
            #endregion

        }

        #region Stand Alone

        private void btnCheckForUpdates_Click(object sender, EventArgs e)
        {
            DisableButtons();
            StartCreateUpdFile();
        }

        private void DisableButtons()
        {
            btnCheckForUpdates.Enabled = false;
            btnCreateUpdatesFile.Enabled = false;
            Application.DoEvents();
        }
        private void StartCreateUpdFile()
        {
            pb1.Image = Resources.Loader;
            //part 1
            System.Threading.Thread t1 = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Manager.CreateUpdatesFile));
            t1.Start(true);
        }

        void Manager_onReadingLocalFilesDone()
        {
            pb1.Image = Resources.GREEN;
            StartReadUpdFile();
        }

        private void StartReadUpdFile()
        {
            // part 2            
            ReadUpdatesIndexFile();
        }

        private void ReadUpdatesIndexFile()
        {
            try
            {
                if (UpdateType == UpdateMode.Online)
                {
                    pb2.Image = Resources.Loader;

                    System.Threading.Thread t1 = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Manager.GetOnlineUpdateFile));
                    t1.Start(null);
                }
                if (UpdateType == UpdateMode.Local)
                {
                    System.Threading.Thread t1 = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Manager.GetLocalUpdateFile));
                    t1.Start(null);
                }
            }
            catch (Exception ex)
            {
                Manager.ThrowErr("Exception: Main: ReadUpdatesIndexFile: " + ex.Message);
            }
        }

        void Manager_onUpdateListReceived(List<UpdFile> updList)
        {
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    lbUpdateFiles.Items.Clear();

                    double wTotSize = 0;
                    foreach (UpdFile updFile in updList)
                    {
                        lbUpdateFiles.Items.Add(updFile.FileName);
                        try
                        {
                            wTotSize += Convert.ToDouble(updFile.FileSize.Trim());
                        }
                        catch (Exception ex)
                        {
                            Manager.ThrowErr("Exception: Main: Manager_onUpdateListReceived: Convertion Error: " + ex.Message);
                        }
                    }

                    sTotDlSize = wTotSize;
                    lblTotalSizeCnt.Text = "0 / " + sTotDlSize;

                    pb2.Image = Resources.GREEN;
                }));
            }
            catch (Exception exx)
            {

            }
        }

        #endregion

        #region Mode Normal / Hidden : Stand Alone

        public void SetUpdatePaths(string xWebPath, string xLocalPath)
        {
            devUpdater.Manager.Init(xWebPath, xLocalPath);
        }
        public void SetUpdatePaths(string xWebPath, string xLocalPath, string xAppPath)
        {
            devUpdater.Manager.Init(xWebPath, xLocalPath, xAppPath);
        }

        #endregion

        #region Manager Events

        void Manager_onDownloadStarted()
        {
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    pb3.Image = Resources.Loader;
                }));
            }
            catch (Exception exx)
            {

            }
        }
        void Manager_onDownloadFileName(string fname)
        {
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    lblDlFileName.Text = fname;
                }));
            }
            catch (Exception exx)
            {

            }
        }
        void Manager_onDownloadProgress(int per)
        {
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    DlPer.Text = per.ToString() + "%";
                    Application.DoEvents();
                }));
            }
            catch (Exception exx)
            {

            }
        }
        int dlFileCnt = 0;
        int prevDlFileCnt = 0;
        double sSizeRunningTot = 0;
        void Manager_onDownloadProgressBytes(long bytes)
        {
            try
            {
                if (dlFileCnt == prevDlFileCnt)
                {
                    sTotDlSizeDone = sSizeRunningTot + Convert.ToDouble(bytes);
                }
                else
                {
                    prevDlFileCnt++;
                    sSizeRunningTot = sTotDlSizeDone + Convert.ToDouble(bytes);
                    sTotDlSizeDone = sSizeRunningTot;
                }
                Invoke(new MethodInvoker(() =>
                {
                    lblTotalSizeCnt.Text = Math.Round(sTotDlSizeDone / (double)1024 / (double)1024, 3) + " / " + Math.Round(sTotDlSize / (double)1024 / (double)1024, 3) + "  MB";
                    Application.DoEvents();

                    if (onUpdatesProgressPercentage != null)
                    {
                        int wwPer = Convert.ToInt32(Math.Round((sTotDlSizeDone / sTotDlSize * (double)100), 0));
                        if (wwPer > 100)
                            wwPer = 100;
                        onUpdatesProgressPercentage(wwPer);
                    }
                }));
            }
            catch (Exception exx)
            {

            }
        }
        void Manager_onDownloadFileComplete(string fname)
        {
            try
            {
                dlFileCnt++;
                Invoke(new MethodInvoker(() =>
                {
                    if (lbUpdateFiles.Items.Contains(fname))
                        lbUpdateFiles.Items.Remove(fname);
                    Application.DoEvents();
                }));
            }
            catch (Exception exx)
            {

            }
        }
        void Manager_onAllFilesDownloaded()
        {
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    pb3.Image = Resources.GREEN;
                    Application.DoEvents();

                    if (Mode == RunMode.StandAlone)
                    {
                        UpgradeFiles();

                        sCloseTimer = new Timer();
                        sCloseTimer.Interval = 1100;
                        sCloseTimer.Tick += new EventHandler(sCloseTimer_Tick);
                        sCloseTimer.Start();
                    }
                    if (Mode == RunMode.Normal || Mode == RunMode.Hidden)
                    {
                        UpgradeFiles();

                        if (onUpdatesCompleted != null)
                        {
                            onUpdatesCompleted(dlFileCnt);
                        }

                        sCloseTimer = new Timer();
                        sCloseTimer.Interval = 1100;
                        sCloseTimer.Tick += new EventHandler(sCloseTimer_Tick);
                        sCloseTimer.Start();
                    }
                }));
            }
            catch (Exception exx)
            {

            }
        }
        private void MessAdd(string mess)
        {
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    lbMessages.Items.Insert(0, mess);
                    Application.DoEvents();
                }));
            }
            catch (Exception exx)
            {

            }
        }
        void Manager_onUpdateError(string errorMessage)
        {
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    MessAdd(errorMessage);

                    if (onUpdatesErrors != null)
                        onUpdatesErrors(errorMessage);
                }));
            }
            catch (Exception exx)
            {

            }
        }

        #endregion

        void sCloseTimer_Tick(object sender, EventArgs e)
        {
            sCloseTimer.Stop();
            Close();
        }

        #region MoveFiles To Be Upgraded
        private void UpgradeFiles()
        {
            try
            {
                string UpdateDir = Settings.AppPath + "\\Updates\\"; //Application.StartupPath + "\\Updates\\";
                string RootDir = Settings.AppPath + "\\"; //Application.StartupPath + "\\";

                string[] updateFiles = Directory.GetFiles(UpdateDir);

                foreach (string file in updateFiles)
                {
                    FileInfo fii = new FileInfo(file);
                    string rootFile = RootDir + fii.Name;
                    if (File.Exists(rootFile + ".old"))
                    {
                        File.Delete(rootFile + ".old");
                    }
                    if (File.Exists(rootFile))
                    {
                        File.Move(rootFile, rootFile + ".old");
                    }
                    File.Copy(file, rootFile);
                }
            }
            catch (Exception ex)
            {
                Manager.ThrowErr("Exception: Main: UpgradeFiles: " + ex.Message);
            }
        }
        #endregion

        private void btnCreateUpdatesFile_Click(object sender, EventArgs e)
        {
            btnCreateUpdatesFile.Enabled = false;
            Application.DoEvents();

            Manager.CreateUpdatesFile(false);
            MessAdd("UpdatesFile Created");
        }

        public enum RunMode
        {
            StandAlone,
            Normal,
            Hidden
        }
        public enum UpdateMode
        {
            Online,
            Local
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Manager.AppStillOpen = false;

            // unhook the static events
            Manager.onUpdateError -= new UpdateError(Manager_onUpdateError);
            Manager.onUpdateListReceived -= new UpdateListReceived(Manager_onUpdateListReceived);

            Manager.onReadingLocalFilesDone -= new ReadingLocalFiles(Manager_onReadingLocalFilesDone);

            Manager.onDownloadStarted -= new DownloadStarted(Manager_onDownloadStarted);
            Manager.onDownloadFileName -= new DownloadFileName(Manager_onDownloadFileName);
            Manager.onDownloadProgress -= new DownloadProgress(Manager_onDownloadProgress);
            Manager.onDownloadProgressBytes -= new DownloadProgressBytes(Manager_onDownloadProgressBytes);
            Manager.onDownloadFileComplete -= new DownloadFileComplete(Manager_onDownloadFileComplete);
            Manager.onAllFilesDownloaded -= new AllFilesDownloaded(Manager_onAllFilesDownloaded);
        }

    }


}
