﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using devGeneric.devClasses.devDynamic;
using devGeneric.devClasses.devStatic;
using System.IO;
using devGeneric.devData;
using System.Diagnostics;
using DevExpress.XtraEditors;
using devGeneric.devForms;

namespace devGeneric.devMainForms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        devSE SE;

        string zMainFormTitle = "";
        string zStatusbarMessage = "";
        bool zAlreadyRunning = false;
        bool zMustDoSecurity = false;

        public frmMain(string xDBName, string xProgramName, string xMainFormTitle, string xStatusbarMessage)
        {
            InitializeComponent();

            sbMain.pbDoShowVer();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            ribbonMain.ApplicationIcon = Icon.ExtractAssociatedIcon(Application.ExecutablePath).ToBitmap();

            devLoading1.Dock = DockStyle.Fill;
            devLoading1.Visible = true;
            Application.DoEvents();

            SE = new devSE();
            SE.LoadSkin();
            
            //Set Vars
            devGlobals.gProgramName = xProgramName;
            devGlobals.gDBName = xDBName;
            devGlobals.gDB = Application.StartupPath + "\\Data\\" + devGlobals.gDBName + ".dat";

            zMainFormTitle = xMainFormTitle;
            zStatusbarMessage = xStatusbarMessage;

            this.Text = zMainFormTitle;

            SE.onDoLabelHide += new devSE_LabelHide(frmMain_onDoHideLabel);

            timLoad.Start();
        }

        private void timLoad_Tick(object sender, EventArgs e)
        {
            SE.WriteLog("Timer Tick", "frmMain", "timLoad_Tick");
            timLoad.Stop();
            SE.WriteLog("Timer Stopped", "frmMain", "timLoad_Tick");

            this.Enabled = false;

            /////////////// STEP 1 - Check for updates /////////////////

            string LocalPath = @"K:\" + devGlobals.gProgramName + @"\Updates\Zips\";

            //Local or Web?
            bool UseLocal = false;
            if (Directory.Exists(LocalPath))
            {
                UseLocal = true;
            }


            devUpdater.Main MyUpdate = new devUpdater.Main();
            MyUpdate.Mode = devUpdater.Main.RunMode.Hidden;

            if (UseLocal)
            {
                MyUpdate.UpdateType = devUpdater.Main.UpdateMode.Local;
                SE.WriteLog("Checking updates from local path", "frmMain", "timLoad_Tick");

            }
            else
            {
                MyUpdate.UpdateType = devUpdater.Main.UpdateMode.Online;
                SE.WriteLog("Checking updates from web path", "frmMain", "timLoad_Tick");
            }

            try
            {
                MyUpdate.onUpdatesCompleted += new devUpdater.UpdatesCompleted(frmMain_onUpdatesCompleted);
                MyUpdate.onUpdatesProgressPercentage += new devUpdater.UpdatesProgressPercentage(frmMain_onUpdatesProgressPercentage);
                MyUpdate.onUpdatesErrors += new devUpdater.UpdatesErrors(frmMain_onUpdatesErrors);

                MyUpdate.SetUpdatePaths("http://www.xxx/appreleases/" + devGlobals.gProgramName + "/Updates/Zips/", LocalPath, Application.StartupPath + "\\");

                SE.WriteLog("Paths set to: " + Environment.NewLine + Environment.NewLine +
                            "(WEB:) http://www.xxx/appreleases/" + devGlobals.gProgramName + "/Updates/Zips/" + Environment.NewLine + Environment.NewLine +
                            "(LOCAL:) " + LocalPath, "frmMain", "timLoad_Tick");

                SE.WriteLog("Just before starting updates", "frmMain", "timLoad_Tick");
                MyUpdate.Show();
                SE.WriteLog("Just after starting updates", "frmMain", "timLoad_Tick");
            }
            catch (Exception Ex)
            {
                //

                SE.WriteLog("Updater Must Get Upgraded: " + Ex.Message, "frmMain", "timLoad_Tick");

                // If there was an error here, then Updater.exe might be old or not working
                // so we delete the Updater.exe, and with the next start of this app, it will dl again.
                string wLocalFile = Application.StartupPath + "\\devUpdater.exe";
                if (File.Exists(wLocalFile))
                {
                    File.Delete(wLocalFile);
                }

                timRestartApp.Start();
            }
        }

        void frmMain_onUpdatesCompleted(int xCompletedFileCount)
        {
            DoProgressCheck(xCompletedFileCount);
        }

        void DoProgressCheck(int xCompletedFileCount)
        {
            /////// UPDATES COMPLETE LETS LOAD THE APP

            SE.WriteLog("Updates Complete", "frmMain", "frmMain_onUpdatesCompleted");

            if (!zAlreadyRunning)
            {
                zAlreadyRunning = true;
                if (xCompletedFileCount == 0)
                {
                    devLoading1.devCaption1 = "Simply Smart Software Coming Online";
                    devLoading1.devCaption2 = "Loading ...";
                    Application.DoEvents();

                    this.BringToFront();

                    //We are up to date already
                    SE.onDoProgress1 += new devSE_Progress1(frmMain_onDoProgress1);
                    SE.onDoProgressText1 += new devSE_ProgressText1(frmMain_onDoProgressText1);
                    SE.onDoProgress2 += new devSE_Progress2(frmMain_onDoProgress2);
                    SE.onDoProgressText2 += new devSE_ProgressText2(frmMain_onDoProgressText2);

                    SE.onDoProgressHide += new devSE_ProgressHide(frmMain_onDoProgressHide);

                    sbMain.SetText("Please wait...");
                    sbMain.SetPBText(0, "Initializing...");

                    //Setup and Login
                    int MyResult = 999;

                    MyResult = SE.DoSettingsIni();

                    while (
                            (MyResult != 0) &&
                            (MyResult != 999)
                          )
                    {
                        MyResult = SE.DoSettingsIni();

                        sbMain.pbDoHide(1, 0);
                        sbMain.pbDoHide(1, 1);

                        sbMain.SetPBText(0, "Ready");
                        sbMain.pbDoFinal(0);
                    }

                    sbMain.pbDoHide(1, 0);
                    sbMain.pbDoHide(1, 1);

                    sbMain.SetPBText(0, "Ready");
                    sbMain.pbDoFinal(0);

                    if (MyResult == 999)
                    {
                        //Terminate app
                        timEndApp.Enabled = true;
                    }
                    else
                    {
                        //User is now logged in. Apply access rights
                        ApplyRights(devGlobals.gUsername, ribbonMain, true);
                        zMustDoSecurity = true;

                        //tblDatabaseConnections MytblDatabaseConnections1 = new tblDatabaseConnections();
                        //MytblDatabaseConnections1 = MytblDatabaseConnections1.GetConnectionDetails(SE.GetSetting("DEFAULTCONN"));

                        timSecurity.Start();
                        timKickUser.Start();
                        timResetKick.Start();
                    }

                    sbMain.pbDoHide(1, 0);
                    sbMain.pbDoHide(1, 1);

                    sbMain.SetPBText(0, "Ready");
                    sbMain.pbDoFinal(0);

                    ribbonMain.Visible = true;

                    if (devGlobals.gShowBulletinBoard)
                    {
                        tblBulletinBoard BulletinBoard = new tblBulletinBoard();

                        labelControl1.Text = BulletinBoard.GetData();

                        if (labelControl1.Text != "")
                        {
                            gbBulletin.Visible = true;
                        }
                    }
                    else
                    {
                        gbBulletin.Visible = false;
                    }

                    ribbonMain.SelectedPage = rpMaintain;

                    sbMain.SetText(zStatusbarMessage);

                    this.Enabled = true;
                }
                else
                {
                    devLoading1.Visible = false;
                    timRestartApp.Start();
                }
            }
        }

        void frmMain_onUpdatesProgressPercentage(int xCompletedFileCount)
        {
            DoProgressCheck(xCompletedFileCount);
        }

        void frmMain_onUpdatesErrors(string xError)
        {
            SE.WriteLog(xError, "frmMain", "frmMain_onUpdatesErrors");

            if (!xError.StartsWith("###"))
            {
                if (!zAlreadyRunning)
                {
                    frmMain_onUpdatesCompleted(0);
                }
            }
        }

        void frmMain_onDoProgress1(int Max, int Progress)
        {
            sbMain.pbDoProgress(0, Max, Progress);
            Application.DoEvents();
        }

        void frmMain_onDoHideLabel()
        {
            devLoading1.Visible = false;
        }

        void frmMain_onDoProgressText1(string xMessage)
        {
            sbMain.SetPBText(0, xMessage);
            Application.DoEvents();
        }

        void frmMain_onDoProgress2(int Max, int Progress)
        {
            sbMain.pbDoProgress(1, Max, Progress);
            Application.DoEvents();
        }

        void frmMain_onDoProgressText2(string xMessage)
        {
            //sbMain.SetPBText(1, xMessage);
            Application.DoEvents();
        }

        void frmMain_onDoProgressHide(int MyProgressBar, int xZeroIsBarOneIsText)
        {
            //sbMain.pbDoHide(MyProgressBar, xZeroIsBarOneIsText);
            Application.DoEvents();
        }

        private void timEndApp_Tick(object sender, EventArgs e)
        {
            SE.WriteLog("Timer Tick", "frmMain", "timEndApp_Tick");
            timEndApp.Enabled = false;
            SE.WriteLog("Timer Stopped", "frmMain", "timEndApp_Tick");
            Close();
        }

        private void timSecurity_Tick(object sender, EventArgs e)
        {
            timSecurity.Stop();

            //Security in a thread
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(SecInThread));
            t.Start(null);

            timSecurity.Start();
        }

        public void SecInThread(object xInput)
        {
            try
            {
                if ((zMustDoSecurity) && Application.OpenForms.Count == 2)
                {
                    ApplyRights(devGlobals.gUsername, ribbonMain, false);
                }
            }
            catch
            {
            }
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (Application.OpenForms.Count == 1)
            //{
            ApplyRights(devGlobals.gUsername, ribbonMain, false);

            devGlobals.gEndApp = false;

            frmSystemDefaults MyForm;

            MyForm = new frmSystemDefaults();

            MyForm.ShowDialog();

            if (devGlobals.gEndApp)
            {
                timRestartApp.Start();
            }
            //}
            //else
            //{
            //    XtraMessageBox.Show("You can not change the System Defaults while other screens are open.", "No No No !!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
        }

        private void timRestartApp_Tick(object sender, EventArgs e)
        {
            SE.WriteLog("Timer Tick", "frmMain", "timRestartApp_Tick");
            timRestartApp.Stop();
            SE.WriteLog("Timer Stop", "frmMain", "timRestartApp_Tick");

            try
            {
                //Update DB (Log out user)
                List<string> fFields = new List<string>();
                List<string> vValues = new List<string>();

                fFields.Add("LoggedIn");

                vValues.Add(SE.Encrypt("0"));

                SE.UpdateRec("tblUsers", fFields, vValues, "[Username] = '" + devGlobals.gEncUsername + "'");

                SE.CreateDBAntiTamper(devGlobals.gDB, devGlobals.gTamperTableList);
            }
            catch (Exception Ex)
            {
                SE.WriteLog(Ex.Message, "frmMain", "timRestartApp_Tick");
            }

            string currentFile = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

            Process app = new Process();
            app.StartInfo.FileName = currentFile;
            app.Start();

            SE.WriteLog("Before Exit", "frmMain", "timRestartApp_Tick");

            Application.Exit();
        }

        private void timKickUser_Tick(object sender, EventArgs e)
        {
            timKickUser.Stop();

            //Security in a thread
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(KickInThread));
            t.Start(null);

            timKickUser.Start();
        }

        public void KickInThread(object xInput)
        {
            try
            {
                //Update Login
                List<string> fFields = new List<string>();
                List<string> vValues = new List<string>();

                fFields.Add("LoggedIn");

                vValues.Add(SE.Encrypt("1"));

                SE.UpdateRec("tblUsers", fFields, vValues, "[Username] = '" + (devGlobals.gEncUsername) + "'");

                Invoke(new MethodInvoker(() =>
                {
                    if (SE.MustKickUser())
                    {
                        timKickUser.Stop();

                        XtraMessageBox.Show("Someone has used your login at another terminal." + Environment.NewLine + Environment.NewLine +
                                            "DO NOT SHARE YOUR USER INFORMATION!!!" + Environment.NewLine + Environment.NewLine +
                                            "Click [OK] to close the application.", "MULTI USER LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        //Update DB
                        fFields = new List<string>();
                        vValues = new List<string>();

                        fFields.Add("KickUser");

                        vValues.Add("0");

                        SE.UpdateRec("tblUsers", fFields, vValues, "[Username] = '" + (devGlobals.gEncUsername) + "'");

                        //avrGlobals.gDoLogout = false;

                        timEndApp.Start();
                    }
                }));
            }
            catch
            {
            }
        }

        private void timResetKick_Tick(object sender, EventArgs e)
        {
            if (devGlobals.gSkipKickUser)
            {
                devGlobals.gSkipKickUser = false;
            }
        }

        public void ApplyRights(string xUser, DevExpress.XtraBars.Ribbon.RibbonControl xMyRibbon, bool xDoHide)
        {
            //Apply rights to ribbon control
            try
            {
                int TheTag;

                DevExpress.XtraBars.Ribbon.RibbonControl TheRibbon = new DevExpress.XtraBars.Ribbon.RibbonControl();

                //Prepare data for fast processing
                bool tmpIsAdmin = false;
                if (SE.CheckUserRegistration(SE.Encrypt(xUser), SE.GetEncUserPCID(SE.Encrypt(xUser), SE.GetPCID())) == 2)
                {
                    tmpIsAdmin = true;
                }

                List<string> MyAccessList = new List<string>();
                MyAccessList = SE.GetUserAccessTagList(SE.GetEncUsername(xUser));


                //Loop ribbon items
                TheRibbon = xMyRibbon as DevExpress.XtraBars.Ribbon.RibbonControl;

                //Security
                for (int C2 = 0; C2 < TheRibbon.Items.Count; C2++)
                {
                    try
                    {
                        TheTag = Convert.ToInt32(TheRibbon.Items[C2].Tag);
                    }
                    catch
                    {
                        TheTag = 0;
                    }

                    if (TheTag >= 1000)
                    {
                        if (TheTag == 1024)
                        {
                            TheTag = TheTag;
                        }


                        bool tmpSecure = false;

                        //Check if the user is an admin user
                        if (tmpIsAdmin)
                        {
                            tmpSecure = true;
                        }


                        foreach (string MyTag in MyAccessList)
                        {
                            if (Convert.ToInt32(MyTag) == TheTag)
                            {
                                tmpSecure = true;
                            }
                        }


                        if (tmpSecure)
                        {
                            Invoke(new MethodInvoker(() =>
                            {
                                TheRibbon.Items[C2].Enabled = true;
                            }));

                        }
                        else
                        {
                            Invoke(new MethodInvoker(() =>
                            {
                                TheRibbon.Items[C2].Enabled = false;
                            }));

                        }
                    }
                }

                if (xDoHide)
                {
                    //Hide show app menu
                    foreach (DevExpress.XtraBars.Ribbon.RibbonPage MyPage in TheRibbon.Pages)
                    {
                        MyPage.Visible = false;
                        foreach (DevExpress.XtraBars.Ribbon.RibbonPageGroup MyPageGroup in MyPage.Groups)
                        {
                            MyPageGroup.Visible = false;

                            //Get tags for group
                            List<string> MyList = new List<string>();
                            MyList = SE.BreakUpString(MyPageGroup.Tag.ToString(), "|");

                            //See each button in this tag list
                            foreach (string MyListItem in MyList)
                            {
                                foreach (BarButtonItem MyButton in MyPageGroup.Ribbon.Items)
                                {
                                    try
                                    {
                                        TheTag = Convert.ToInt32(MyButton.Tag);
                                    }
                                    catch
                                    {
                                        TheTag = 0;
                                    }

                                    if (TheTag >= 1000)
                                    {
                                        if (MyListItem == TheTag.ToString())
                                        {
                                            Invoke(new MethodInvoker(() =>
                                            {
                                                MyButton.Visibility = BarItemVisibility.Never;
                                            }));

                                            try
                                            {
                                                TheTag = Convert.ToInt32(MyButton.Tag);
                                            }
                                            catch
                                            {
                                                TheTag = 0;
                                            }

                                            if (TheTag >= 1000)
                                            {
                                                if (!SE.HideControl(TheTag))
                                                {
                                                    Invoke(new MethodInvoker(() =>
                                                    {
                                                        MyButton.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                                        MyPageGroup.Visible = true;
                                                        MyPage.Visible = true;
                                                    }));
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void gbBulletin_ClientSizeChanged(object sender, EventArgs e)
        {
            //if (labelControl1.Height <= 460)
            //{
            //    pnlBullet.Height = 495;
            //}
            //else
            //{
                if (labelControl1.Height + 38 > gbBulletin.Height - 24)
                {
                    pnlBullet.Height = labelControl1.Height + 38;
                }
                else
                {
                    if (pnlBullet.Height < gbBulletin.Height - 24)
                    {
                        pnlBullet.Height = gbBulletin.Height - 24;
                    }
                }
            //}
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            gbBulletin.Visible = false;
            devGlobals.gShowBulletinBoard = false;

            //Update DB
            List<string> fFields = new List<string>();
            List<string> vValues = new List<string>();

            fFields.Add("ShowBulletin");

            vValues.Add("0");

            SE.UpdateRec("tblUsers", fFields, vValues, "[Username] = '" + (devGlobals.gEncUsername) + "'");
        }

        private void panelControl2_DoubleClick(object sender, EventArgs e)
        {
            tblBulletinBoard BulletinBoard = new tblBulletinBoard();

            labelControl1.Text = BulletinBoard.GetData();

            if (labelControl1.Text != "")
            {
                gbBulletin.Visible = true;
                devGlobals.gShowBulletinBoard = true;
            }

            //Update DB
            List<string> fFields = new List<string>();
            List<string> vValues = new List<string>();

            fFields.Add("ShowBulletin");

            vValues.Add("1");

            SE.UpdateRec("tblUsers", fFields, vValues, "[Username] = '" + (devGlobals.gEncUsername) + "'");
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMaintainUser MyForm;

            MyForm = new frmMaintainUser();

            MyForm.Show();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmKeyGenerator MyForm;

            //MyForm = new frmKeyGenerator();

            //MyForm.Show();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMaintainDatabaseConnection MyForm;

            MyForm = new frmMaintainDatabaseConnection();

            MyForm.Show();
        }
    }
}