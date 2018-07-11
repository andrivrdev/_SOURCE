using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Globalization;

namespace devUpdater
{
    public delegate void UpdateError(string errorMessage);
    public delegate void UpdateListReceived(List<UpdFile> updList);

    public delegate void ReadingLocalFiles();

    public delegate void DownloadStarted();
    public delegate void DownloadFileName(string fname);
    public delegate void DownloadProgress(int per);
    public delegate void DownloadProgressBytes(long bytes);
    public delegate void DownloadFileComplete(string fname);
    public delegate void AllFilesDownloaded();

    public static class Manager
    {
        public static bool AppStillOpen { get; set; }

        private static string UpdateWebPath = "";

        private static string UpdateFileWebPath = "";
        private static string UpdateFileLocalPath = "";

        private static string LocalUpdatesFolder = "";
        private static string LocalUpdatesFolderZips = "";
        private static string LocalUpdatesInProgressFolder = "";
        private static string LocalUpdatesInProgressFolderZips = "";

        private static string LocalUpdateFileName = "";
        private static string OnlineUpdateFileName = "";

        private static string AppPath = "";


        public static event UpdateError onUpdateError;
        public static event UpdateListReceived onUpdateListReceived;

        public static event ReadingLocalFiles onReadingLocalFilesDone;

        public static event DownloadStarted onDownloadStarted;
        public static event DownloadFileName onDownloadFileName;
        public static event DownloadProgress onDownloadProgress;
        public static event DownloadProgressBytes onDownloadProgressBytes;
        public static event DownloadFileComplete onDownloadFileComplete;
        public static event AllFilesDownloaded onAllFilesDownloaded;



        public static bool InitComplete = false;

        public static void Init(string xUpdateWebFilePath, string xUpdateFileLocalPath, string xAppPath)
        {
            try
            {
                string wAppPath = xAppPath;

                if (wAppPath.Length > 3)
                {
                    string wLast1 = wAppPath.Substring(wAppPath.Length - 1, 1);
                    if (wLast1 != "\\")
                    {
                        wAppPath += "\\";
                    }
                }

                Settings.AppPath = xAppPath;
                Init(xUpdateWebFilePath, xUpdateFileLocalPath);
            }
            catch (Exception ex)
            {
                InitComplete = false;
                ThrowErr("Exception: Manager: Init2: " + ex.Message);
            }
        }

        public static void Init(string xUpdateWebFilePath, string xUpdateFileLocalPath)
        {
            try
            {
                AppStillOpen = true;

                string wAppPath = Settings.AppPath;
                if (wAppPath.Length > 3)
                {
                    string wLast1 = wAppPath.Substring(wAppPath.Length - 1, 1);
                    if (wLast1 != "\\")
                    {
                        wAppPath += "\\";
                    }
                }

                AppPath = wAppPath; // Directory.GetCurrentDirectory() + "\\";

                LocalUpdatesFolder = AppPath + "Updates\\";
                LocalUpdatesFolderZips = LocalUpdatesFolder + "Zips\\";

                LocalUpdatesInProgressFolder = AppPath + "Updates\\Busy\\";
                LocalUpdatesInProgressFolderZips = LocalUpdatesInProgressFolder + "Zips\\";

                LocalUpdateFileName = AppPath + "UpdaterFiles.txt";
                OnlineUpdateFileName = LocalUpdatesInProgressFolder + "UpdaterFiles.txt";

                UpdateWebPath = xUpdateWebFilePath;

                #region Confirm Last Forward slash in Web Path
                if (xUpdateWebFilePath.Length > 3)
                {
                    string wLast1 = xUpdateWebFilePath.Substring(xUpdateWebFilePath.Length - 1, 1);
                    if (wLast1 != "/")
                    {
                        UpdateFileLocalPath += "/";
                    }
                }
                #endregion

                UpdateFileWebPath = xUpdateWebFilePath + "UpdaterFiles.txt";
                UpdateFileLocalPath = xUpdateFileLocalPath;

                #region Confirm Last Slash in Dir Path
                if (UpdateFileLocalPath.Length > 3)
                {
                    string wLast2 = UpdateFileLocalPath.Substring(UpdateFileLocalPath.Length - 1, 1);
                    if (wLast2 != "\\")
                    {
                        UpdateFileLocalPath += "\\";
                    }
                }
                #endregion

                #region Confirm Directories
                if (!Directory.Exists(LocalUpdatesFolder))
                {
                    Directory.CreateDirectory(LocalUpdatesFolder);
                }
                if (!Directory.Exists(LocalUpdatesFolderZips))
                {
                    Directory.CreateDirectory(LocalUpdatesFolderZips);
                }
                if (!Directory.Exists(LocalUpdatesInProgressFolder))
                {
                    Directory.CreateDirectory(LocalUpdatesInProgressFolder);
                }
                if (!Directory.Exists(LocalUpdatesInProgressFolderZips))
                {
                    Directory.CreateDirectory(LocalUpdatesInProgressFolderZips);
                }
                #endregion

                RemoveOldFiles();

                Settings.WebPath = UpdateWebPath;
                Settings.LocalPath = UpdateFileLocalPath;
                Settings.UseLocalPath = "false";
                Settings.SaveSettings();

                InitComplete = true;

                //Manager.ThrowErr("### Init: AppPath = " + AppPath);
                //Manager.ThrowErr("### Init: LocalUpdatesFolder = " + LocalUpdatesFolder);
                //Manager.ThrowErr("### Init: LocalUpdatesFolderZips = " + LocalUpdatesFolderZips);
                //Manager.ThrowErr("### Init: LocalUpdatesInProgressFolder = " + LocalUpdatesInProgressFolder);
                //Manager.ThrowErr("### Init: LocalUpdatesInProgressFolderZips = " + LocalUpdatesInProgressFolderZips);
                //Manager.ThrowErr("### Init: LocalUpdateFileName = " + LocalUpdateFileName);
                //Manager.ThrowErr("### Init: OnlineUpdateFileName = " + OnlineUpdateFileName);
                //Manager.ThrowErr("### Init: UpdateWebPath = " + UpdateWebPath);
            }
            catch (Exception ex)
            {
                InitComplete = false;
                ThrowErr("Exception: Manager: Init: " + ex.Message);
            }
        }

        private static bool HasInit()
        {
            if (InitComplete)
            {
                return InitComplete;
            }
            else
            {
                ThrowErr("Error 1: Can not start Updater without Initializing it 1st. Run Manager.Init.");
                return InitComplete;
            }
        }

        public static void ThrowErr(string err)
        {
            if (onUpdateError != null)
                onUpdateError(err);
        }

        #region Create UpdatesFile.txt and ZipFiles / Decompress Zipz
        public static void CreateUpdatesFile(object xob)
        {
            if (!HasInit())
            {
                return;
            }

            try
            {
                CreateZipFiles();

                string wFilename = LocalUpdateFileName;

                string[] files = Directory.GetFiles(AppPath);

                using (FileStream stream = new FileStream(wFilename, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(stream))
                    {
                        foreach (string file in files)
                        {
                            FileInfo fii = new FileInfo(file);

                            string wDateMod = fii.LastWriteTime.ToString("yyyy/MM/dd") + " " + fii.LastWriteTime.ToString("T");
                            //string wTTDateMod = fii.LastWriteTime.ToString("yyyy/MM/dd") + " " + fii.LastWriteTime.ToString("h:mm:ss"); // TEST
                            //string wTTDateMod = fii.LastWriteTime.ToString("yyyy/MM/dd") + " " + fii.LastWriteTime.ToString("hh:mm:ss tt"); // TEST
                            string wFileSize = fii.Length.ToString();

                            string zipFile = LocalUpdatesFolderZips + fii.Name + ".gz";
                            if (File.Exists(zipFile))
                            {
                                FileInfo fiZip = new FileInfo(zipFile);
                                wFileSize = fiZip.Length.ToString();
                            }

                            string line = fii.Name + "|" + wDateMod + "|" + wFileSize;

                            //Manager.ThrowErr("### CreateUpdatesFile: Added Line: " + line + " --- test date format --- " + wTTDateMod);

                            if (fii.Name != null && fii.Name.Length > 0 && wDateMod.Length > 0 && wFileSize.Length > 0)
                            {
                                sw.WriteLine(line);
                            }
                        }
                    }
                }

                if (File.Exists(AppPath + "UpdaterFiles.txt"))
                {
                    File.Copy(AppPath + "UpdaterFiles.txt", LocalUpdatesFolderZips + "UpdaterFiles.txt");
                }

                bool wContinue = Convert.ToBoolean(xob);
                if (wContinue)
                {
                    if (onReadingLocalFilesDone != null)
                        onReadingLocalFilesDone();
                }
            }
            catch (Exception ex)
            {
                ThrowErr("Exception: Manager: CreateUpdatesFile: " + ex.Message);
            }
        }
        public static void CreateZipFiles()
        {
            if (!HasInit())
            {
                return;
            }

            try
            {
                // Clear Old Zip Files
                string[] zipFiles = Directory.GetFiles(LocalUpdatesFolderZips);
                foreach (string file in zipFiles)
                {
                    File.Delete(file);
                }

                string[] files = Directory.GetFiles(AppPath);

                foreach (string file in files)
                {
                    FileInfo fii = new FileInfo(file);
                    if (fii.Name != "UpdaterFiles.txt")
                        Compress(fii, LocalUpdatesFolderZips);
                }
            }
            catch (Exception ex)
            {
                ThrowErr("Exception: Manager: CreateZipFiles: " + ex.Message);
            }
        }
        public static void Compress(FileInfo fileToCompress, string xCompressTo)
        {
            try
            {
                using (FileStream originalFileStream = fileToCompress.OpenRead())
                {
                    if ((File.GetAttributes(fileToCompress.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                    {
                        using (FileStream compressedFileStream = File.Create(xCompressTo + fileToCompress.Name + ".gz"))
                        {
                            using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                            {
                                originalFileStream.CopyTo(compressionStream);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ThrowErr("Exception: Manager: Compress: " + ex.Message);
            }
        }
        public static void Decompress(FileInfo fileToDecompress, string xDescompressTo)
        {
            try
            {
                using (FileStream originalFileStream = fileToDecompress.OpenRead())
                {
                    string currentFileName = fileToDecompress.FullName;
                    string newFileName = xDescompressTo + fileToDecompress.Name.Remove(fileToDecompress.Name.Length - fileToDecompress.Extension.Length);

                    using (FileStream decompressedFileStream = File.Create(newFileName))
                    {
                        using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                        {
                            decompressionStream.CopyTo(decompressedFileStream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ThrowErr("Exception: Manager: Decompress: " + ex.Message);
            }
        }
        #endregion

        #region Get Online Update File and Compare
        public static void GetOnlineUpdateFile(object xOb)
        {
            try
            {
                if (AppStillOpen)
                {
                    string UpdateFileSave = OnlineUpdateFileName + ".saving";

                    using (WebClient wcUpdatesFile = new WebClient())
                    {
                        wcUpdatesFile.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(wcUpdatesFile_DownloadFileCompleted);
                        wcUpdatesFile.DownloadFileAsync(new Uri(UpdateFileWebPath), UpdateFileSave);
                    }
                }
            }
            catch (Exception ex)
            {
                ThrowErr("Exception: Manager: GetOnlineUpdateFile: " + ex.Message);
            }
        }
        static void wcUpdatesFile_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    if (e.Error.Message != null)
                    {

                        if (e.Error.InnerException != null && e.Error.InnerException.Message != null)
                        {
                            Manager.ThrowErr("Manager: wcUpdatesFile_DownloadFileCompleted: " + e.Error.Message + ": " + e.Error.InnerException.Message);
                        }
                        else
                        {
                            Manager.ThrowErr("Manager: wcUpdatesFile_DownloadFileCompleted: " + e.Error.Message);
                        }
                    }

                    Manager.ThrowErr("Manager: wcUpdatesFile_DownloadFileCompleted: " + e.Error.ToString());
                }
                else
                {
                    if (AppStillOpen)
                    {
                        try
                        {
                            string wFilename = OnlineUpdateFileName + ".saving";
                            string wFile = OnlineUpdateFileName;

                            if (File.Exists(wFile))
                            {
                                File.Delete(wFile);
                            }
                            if (File.Exists(wFilename))
                            {
                                File.Move(wFilename, wFile);
                            }

                            ReadUpdateFiles(false);
                        }
                        catch (Exception ex)
                        {
                            ThrowErr("Exception: Manager: wcUpdatesFile_DownloadFileCompleted: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ThrowErr("Exception: Manager: wcUpdatesFile_DownloadFileCompleted: " + ex.Message);
            }
        }
        private static void ReadUpdateFiles(bool xLocal)
        {
            try
            {
                if (File.Exists(OnlineUpdateFileName) && File.Exists(LocalUpdateFileName))
                {
                    List<string> LinesLocal = new List<string>();
                    using (FileStream stream = new FileStream(LocalUpdateFileName, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader sr = new StreamReader(stream))
                        {
                            string line = "";
                            while ((line = sr.ReadLine()) != null)
                            {
                                LinesLocal.Add(line.Trim());
                            }
                        }
                    }

                    List<string> LinesOnline = new List<string>();
                    using (FileStream stream = new FileStream(OnlineUpdateFileName, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader sr = new StreamReader(stream))
                        {
                            string line = "";
                            while ((line = sr.ReadLine()) != null)
                            {
                                LinesOnline.Add(line.Trim());
                            }
                        }
                    }

                    Dictionary<string, UpdFile> LocalUfiles = new Dictionary<string, UpdFile>();
                    Dictionary<string, UpdFile> OnlineUfiles = new Dictionary<string, UpdFile>();

                    char[] splitter = { '|' };

                    foreach (string line in LinesLocal)
                    {
                        if (line.Contains("|"))
                        {
                            string[] frags = line.Split(splitter);

                            UpdFile ufile = new UpdFile();
                            ufile.FileName = frags[0];
                            ufile.DateMod = Convert.ToDateTime(frags[1]);
                            ufile.FileSize = frags[2];

                            if (!LocalUfiles.ContainsKey(ufile.FileName))
                            {
                                LocalUfiles.Add(ufile.FileName, ufile);
                            }
                        }
                    }

                    foreach (string line in LinesOnline)
                    {
                        if (line.Contains("|"))
                        {
                            string[] frags = line.Split(splitter);

                            UpdFile ufile = new UpdFile();
                            ufile.FileName = frags[0];
                            ufile.DateMod = Convert.ToDateTime(frags[1]);
                            ufile.FileSize = frags[2];

                            if (!OnlineUfiles.ContainsKey(ufile.FileName))
                            {
                                OnlineUfiles.Add(ufile.FileName, ufile);
                            }
                        }
                    }

                    List<UpdFile> filesRequired = CompareUpdateFiles(LocalUfiles, OnlineUfiles);
                    if (onUpdateListReceived != null)
                        onUpdateListReceived(filesRequired);

                    if (xLocal)
                    {
                        CopyRequiredFiles(filesRequired);
                    }
                    else
                    {
                        DownloadRequiredFiles(filesRequired);
                    }
                }
            }
            catch (Exception ex)
            {
                ThrowErr("Exception: Manager: ReadUpdateFile: " + ex.Message);
            }
        }
        private static List<UpdFile> CompareUpdateFiles(Dictionary<string, UpdFile> xLocalUfiles, Dictionary<string, UpdFile> xOnlineUfiles)
        {
            List<UpdFile> DlFiles = new List<UpdFile>();

            try
            {
                //Manager.ThrowErr("### CompareUpdateFiles: LocalFile Count = " + xLocalUfiles.Count);
                //Manager.ThrowErr("### CompareUpdateFiles: OnlineFileCount = " + xOnlineUfiles.Count);

                foreach (string filename in xOnlineUfiles.Keys)
                {
                    UpdFile wOnlFile = xOnlineUfiles[filename];

                    if (xLocalUfiles.ContainsKey(filename))
                    {
                        //Manager.ThrowErr("### CompareUpdateFiles: File = " + filename + " : LocalFile = " + xLocalUfiles[filename].DateMod + "  <  OnlineFile = " + xOnlineUfiles[filename].DateMod);
                        if (filename != "UpdaterFiles.txt" && filename != "UpdaterSettings.txt")
                        {
                            if (xLocalUfiles[filename].DateMod < xOnlineUfiles[filename].DateMod)
                            {
                                DlFiles.Add(wOnlFile);
                            }
                        }
                    }
                    else
                    {
                        //Manager.ThrowErr("### CompareUpdateFiles: File = " + filename + " added coz Local List Does Not Have it");
                        DlFiles.Add(wOnlFile);
                    }
                }
            }
            catch (Exception ex)
            {
                ThrowErr("Exception: Manager: CompareUpdateFiles: " + ex.Message);
            }

            return DlFiles;
        }
        #endregion

        #region Read Local Files
        public static void GetLocalUpdateFile(object xOb)
        {
            try
            {
                if (AppStillOpen)
                {
                    string UpdateFileSave = OnlineUpdateFileName + ".saving";
                    string copyFrom = Settings.LocalPath + "UpdaterFiles.txt";
                    if (File.Exists(UpdateFileSave))
                    {
                        File.Delete(UpdateFileSave);
                    }
                    if (File.Exists(OnlineUpdateFileName))
                    {
                        File.Delete(OnlineUpdateFileName);
                    }

                    File.Copy(copyFrom, UpdateFileSave);

                    File.Move(UpdateFileSave, OnlineUpdateFileName);

                    ReadUpdateFiles(true);
                }
            }
            catch (Exception ex)
            {
                ThrowErr("Exception: Manager: GetLocalUpdateFile: " + ex.Message);
            }
        }


        private static void CopyRequiredFiles(List<UpdFile> xFiles)
        {
            if (xFiles.Count > 0)
            {
                try
                {
                    if (AppStillOpen)
                    {
                        RemoveOldFiles();

                        if (onDownloadStarted != null)
                            onDownloadStarted();

                        double wTotFiles = xFiles.Count;
                        double wDoneFileCnt = 0;

                        foreach (UpdFile uFile in xFiles)
                        {
                            try
                            {
                                wDoneFileCnt++;

                                sDlFileName = LocalUpdatesInProgressFolderZips + uFile.FileName + ".gz";
                                string UpdateFileSave = LocalUpdatesInProgressFolderZips + uFile.FileName + ".gz.saving";
                                string wWebFileName = UpdateFileLocalPath + uFile.FileName + ".gz";
                                sWebFileName = wWebFileName;

                                if (onDownloadFileName != null)
                                    onDownloadFileName(uFile.FileName);

                                //(wWebFileName), UpdateFileSave);

                                string wFile = LocalUpdatesInProgressFolderZips + uFile.FileName;

                                #region Clean Up File Names Before Use
                                if (File.Exists(UpdateFileSave))
                                {
                                    File.Delete(UpdateFileSave);
                                }
                                if (File.Exists(sDlFileName))
                                {
                                    File.Delete(sDlFileName);
                                }
                                #endregion

                                File.Copy(wWebFileName, UpdateFileSave); // Copy from local network to .saving

                                File.Move(UpdateFileSave, sDlFileName); // Rename .saving to zip

                                FileInfo fii = new FileInfo(sDlFileName);
                                Decompress(fii, LocalUpdatesInProgressFolder);


                                int wper = Convert.ToInt32(Math.Floor((wDoneFileCnt / wTotFiles * 100)));

                                if (onDownloadProgress != null)
                                    onDownloadProgress(wper);

                                if (onDownloadProgressBytes != null)
                                    onDownloadProgressBytes(fii.Length);


                                if (onDownloadFileComplete != null)
                                    onDownloadFileComplete(fii.Name.Remove(fii.Name.Length - fii.Extension.Length));

                            }
                            catch (Exception exx)
                            {
                                ThrowErr("Exception: Manager: CopyRequiredFiles: InnerException: " + exx.Message);
                            }
                        }

                        // Done
                        MoveAllCompletedFiles();

                        if (onAllFilesDownloaded != null)
                            onAllFilesDownloaded();
                    }
                }
                catch (Exception ex)
                {
                    ThrowErr("Exception: Manager: CopyRequiredFiles: " + ex.Message);
                }
            }
            else
            {
                if (AppStillOpen)
                {
                    RemoveOldFiles();

                    if (onAllFilesDownloaded != null)
                        onAllFilesDownloaded();
                }
            }
        }
        #endregion

        #region Clean Up
        private static void RemoveOldFiles()
        {
            try
            {
                // Clear Old UnZips
                string[] UnzipFiles = Directory.GetFiles(LocalUpdatesInProgressFolder);
                foreach (string file in UnzipFiles)
                {
                    File.Delete(file);
                }

                // Clear Updates Folder
                string[] UpdateFiles = Directory.GetFiles(LocalUpdatesFolder);
                foreach (string file in UpdateFiles)
                {
                    File.Delete(file);
                }

                // Clear .old files in root
                string[] DotOldFiles = Directory.GetFiles(AppPath);
                foreach (string file in DotOldFiles)
                {
                    FileInfo fii = new FileInfo(file);
                    if (fii.Extension == ".old")
                    {
                        File.Delete(file);
                    }
                }
            }
            catch (Exception ex)
            {
                ThrowErr("Exception: Manager: RemoveOldFiles: " + ex.Message);
            }
        }
        #endregion

        #region Download The Zip Files

        private static void DownloadRequiredFiles(List<UpdFile> xFiles)
        {
            try
            {
                if (xFiles.Count > 0)
                {
                    try
                    {
                        if (AppStillOpen)
                        {
                            RemoveOldFiles();

                            if (onDownloadStarted != null)
                                onDownloadStarted();

                            sIndexDl = 0;
                            sDlFiles = xFiles;
                            DownloadOneFile();
                        }
                    }
                    catch (Exception ex)
                    {
                        ThrowErr("InnerException: Manager: DownloadRequiredFiles: " + ex.Message);
                    }
                }
                else
                {
                    if (AppStillOpen)
                    {
                        RemoveOldFiles();

                        if (onAllFilesDownloaded != null)
                            onAllFilesDownloaded();
                    }
                }
            }
            catch (Exception ex)
            {
                ThrowErr("Exception: Manager: DownloadRequiredFiles: " + ex.Message);
            }
        }

        private static int sIndexDl = 0;
        private static List<UpdFile> sDlFiles = new List<UpdFile>();
        private static string sDlFileName = "";
        private static string sWebFileName = "";

        private static void DownloadOneFile()
        {
            try
            {
                if (sIndexDl < sDlFiles.Count)
                {
                    sDlFileName = LocalUpdatesInProgressFolderZips + sDlFiles[sIndexDl].FileName + ".gz";
                    string UpdateFileSave = LocalUpdatesInProgressFolderZips + sDlFiles[sIndexDl].FileName + ".gz.saving";
                    string wWebFileName = UpdateWebPath + sDlFiles[sIndexDl].FileName + ".gz";
                    sWebFileName = wWebFileName;

                    if (onDownloadFileName != null)
                        onDownloadFileName(sDlFiles[sIndexDl].FileName);

                    using (WebClient wcZipFile = new WebClient())
                    {
                        wcZipFile.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wcZipFile_DownloadProgressChanged);
                        wcZipFile.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(wcZipFile_DownloadFileCompleted);
                        wcZipFile.DownloadFileAsync(new Uri(wWebFileName), UpdateFileSave);
                    }
                }
                else
                {
                    // All Files Downloaded or Attempted to be Downloaded - Now Move Them to Updates Folder
                    MoveAllCompletedFiles();

                    if (onAllFilesDownloaded != null)
                        onAllFilesDownloaded();
                }
            }
            catch (Exception ex)
            {
                ThrowErr("Exception: Manager: DownloadOneFile: " + ex.Message);
            }
        }

        static void wcZipFile_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                string weMess = "Manager: wcZipFile_DownloadStringCompleted: " + sWebFileName;
                if (e.Error.Message != null)
                    weMess += ": " + e.Error.Message;
                if (e.Error.InnerException != null)
                {
                    if (e.Error.InnerException.Message != null)
                        weMess += ": " + e.Error.InnerException.Message;
                }

                Manager.ThrowErr(weMess);
            }
            else
            {
                if (AppStillOpen)
                {
                    try
                    {
                        string wFilename = sDlFileName + ".saving";
                        string wFile = sDlFileName;

                        if (File.Exists(wFile))
                        {
                            File.Delete(wFile);
                        }
                        if (File.Exists(wFilename))
                        {
                            File.Move(wFilename, wFile);
                        }

                        FileInfo fii = new FileInfo(wFile);
                        Decompress(fii, LocalUpdatesInProgressFolder);

                        if (onDownloadFileComplete != null)
                            onDownloadFileComplete(fii.Name.Remove(fii.Name.Length - fii.Extension.Length));
                    }
                    catch (Exception ex)
                    {
                        ThrowErr("Exception: Manager: wcUpdatesFile_DownloadFileCompleted: " + ex.Message);
                    }
                }
            }

            sIndexDl++;
            DownloadOneFile();
        }
        static void wcZipFile_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (onDownloadProgress != null)
                onDownloadProgress(e.ProgressPercentage);

            if (onDownloadProgressBytes != null)
                onDownloadProgressBytes(e.BytesReceived);
        }

        #endregion

        #region Move Completed Files
        private static void MoveAllCompletedFiles()
        {
            try
            {
                string[] UnZippedFiles = Directory.GetFiles(LocalUpdatesInProgressFolder);

                foreach (string file in UnZippedFiles)
                {
                    FileInfo fii = new FileInfo(file);
                    string moveTo = LocalUpdatesFolder + fii.Name;
                    File.Move(file, moveTo);
                }
            }
            catch (Exception ex)
            {
                ThrowErr("Exception: Manager: MoveAllCompletedFiles: " + ex.Message);
            }
        }
        #endregion
    }
}
