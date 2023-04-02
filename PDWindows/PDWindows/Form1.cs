using Shared;
using Soulseek;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography;
using System.Data;
using Microsoft.VisualBasic.FileIO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net;
using System.ComponentModel;

namespace PDWindows
{
    public partial class Form1 : Form
    {
        clsGlobal zclsGlobal = new clsGlobal();
        List<object> zTransfers = new List<object>();
        //  ListBox zlistBox = new ListBox();

        Thread zthreadGUI;
        private Object thisLock = new Object();
        bool gui_threadMustRun = false;

        DataTable zProgress = new DataTable();

        public Form1()
        {
            InitializeComponent();

            dgView1.DataSource = zclsGlobal.zSearchDTValid;

            zProgress.Columns.Add("zSearch");
            zProgress.Columns.Add("zSearchWords");
            zProgress.Columns.Add("zQueueLength");
            zProgress.Columns.Add("zUploadSpeed");
            zProgress.Columns.Add("zBitRate");
            zProgress.Columns.Add("zSize");
            zProgress.Columns.Add("zLength");
            zProgress.Columns.Add("zExtention");
            zProgress.Columns.Add("zFilename");
            zProgress.Columns.Add("zUsername");
            zProgress.Columns.Add("zSelected");
            zProgress.Columns.Add("zProgressPerc");


            dgView4.DataSource = zProgress;
            //zlistBox.SelectedIndexChanged += Ddd_TextChanged;

            zthreadGUI = new Thread(new ThreadStart(StartGUIThread));
            zthreadGUI.Start();
        }

        private async void StartGUIThread()
        {
            try
            {
                while (gui_threadMustRun)
                {
                    lock (thisLock)
                    {
                        foreach (Task<Transfer> aaa in zTransfers)
                        {
                            lblStatus.Invoke((MethodInvoker)delegate
                            {
                                lblStatus.Text = aaa.Result.BytesTransferred.ToString();
                            });
                        }
                    }

                    Thread.Sleep(100);
                }
            }
            catch
            {

            }
        }

        public bool ControlInvokeRequired(Control c, Action a)
        {
            if (c.InvokeRequired) c.Invoke(new MethodInvoker(delegate { a(); }));
            else return false;

            return true;
        }

        public void UpdateMemo(String text)
        {
            //Check if invoke requied if so return - as i will be recalled in correct thread
            if (ControlInvokeRequired(memLog, () => UpdateMemo(text))) return;
            memLog.Text = memLog.Text + text;
            memLog.SelectionStart = memLog.TextLength;
            memLog.ScrollToCaret();
        }
        public void UpdateGrid(DataTable xdataTable)
        {
            //Check if invoke requied if so return - as i will be recalled in correct thread
            if (ControlInvokeRequired(dgView4, () => UpdateGrid(xdataTable))) return;
            dgView4.DataSource = null;
            dgView4.DataSource = xdataTable.Copy();
            //dgView4.SelectAll();
        }
        private void ZSSClient_StateChanged(object? sender, Soulseek.SoulseekClientStateChangedEventArgs e)
        {
            UpdateMemo("< 002 - clsGlobal.zSSClient state changed to " + zclsGlobal.zSSClient.State.ToString() + Environment.NewLine);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            UpdateMemo("+ 001 - Connecting to soulseek..." + Environment.NewLine);

            try
            {
                await zclsGlobal.zSSClient.ConnectAsync(edtUN.Text, edtPW.Text);
                zclsGlobal.zSSClient.StateChanged += ZSSClient_StateChanged;
                timer1.Enabled = true;

            }
            catch (Exception ex)
            {
                UpdateMemo("< 001 - Error: " + ex.Message + Environment.NewLine);
            }

            UpdateMemo("- 001 - Connecting to soulseek done" + Environment.NewLine);
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            UpdateMemo("+ 003 - Timer start..." + Environment.NewLine);


            try
            {




                UpdateMemo("< 003 - clsGlobal.zSSClient state is : " + zclsGlobal.zSSClient.State.ToString() + Environment.NewLine);
                UpdateMemo("< 003 - Selected file is             : " + edtFilename.Text + Environment.NewLine);

                await zclsGlobal.zSSClient.ConnectAsync(edtUN.Text, edtPW.Text);
                //UpdateGrid((dgView4.DataSource as DataTable).Copy());

            }
            catch (Exception ex)
            {

            }

            UpdateMemo("- 003 - Timer done" + Environment.NewLine);



            timer1.Enabled = true;
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            UpdateMemo("+ 004 - Selecting file..." + Environment.NewLine);

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    edtFilename.Text = openFileDialog1.FileName;
                }
            }
            catch
            {
                UpdateMemo("< 004 - Error" + Environment.NewLine);
            }

            UpdateMemo("- 004 - Selecting file done" + Environment.NewLine);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateMemo("+ 005 - Searching file content..." + Environment.NewLine);

            zclsGlobal.zSearchDT.Rows.Clear();
            zclsGlobal.zSearchDTAllCombo.Rows.Clear();

            try
            {
                using (StreamReader sr = new StreamReader(edtFilename.Text))
                {
                    while (sr.Peek() >= 0)
                    {
                        String line = sr.ReadLine();
                        string[] columns = line.Split('\t');

                        zclsGlobal.zSearchDT.Rows.Add(line, "", 0, 0, 0, 0, 0, "", "");
                    }
                }

                int xC1 = 1;
                foreach (DataRow aRec in zclsGlobal.zSearchDT.Rows)
                {
                    UpdateMemo("< 005 - Searching line " + xC1.ToString() + " of " + zclsGlobal.zSearchDT.Rows.Count.ToString() + Environment.NewLine);


                    string xCleanedString = aRec["zSearch"].ToString();

                    xCleanedString = xCleanedString.ToLower();
                    xCleanedString = xCleanedString.Replace(",", " ");
                    xCleanedString = xCleanedString.Replace("-", " ");
                    xCleanedString = xCleanedString.Replace("(", " ");
                    xCleanedString = xCleanedString.Replace(")", " ");
                    xCleanedString = xCleanedString.Replace("'", " ");
                    xCleanedString = xCleanedString.Replace(":", " ");
                    xCleanedString = xCleanedString.Replace("_", " ");
                    xCleanedString = xCleanedString.Replace(@"/", " ");
                    xCleanedString = xCleanedString.Replace(@"\", " ");
                    xCleanedString = xCleanedString.Replace(@".", " ");
                    xCleanedString = xCleanedString.Replace(@"]", " ");
                    xCleanedString = xCleanedString.Replace(@"[", " ");
                    xCleanedString = xCleanedString.Replace(@"%20", " ");
                    xCleanedString = xCleanedString.Replace(@"mp3", " ");
                    xCleanedString = xCleanedString.Replace(@"flac", " ");
                    xCleanedString = xCleanedString.Replace(@"can t", " ");
                    xCleanedString = xCleanedString.Replace(@"#extinf", " ");
                    xCleanedString = xCleanedString.Replace(@"#extm3u", " ");

                    string[] xAllWords = xCleanedString.Split(' ');
                    List<string> xFilteredWords = new List<string>();

                    foreach (var bRec in xAllWords)
                    {
                        try
                        {
                            var xtest = Convert.ToInt32(bRec);
                        }
                        catch
                        {

                            if (bRec != "")
                            {
                                if (bRec.Length != 1)
                                {
                                    if (bRec.Contains("%") != true)
                                    {
                                        if (bRec.Contains("com") != true)
                                        {
                                            if (bRec.Contains("clapcrate") != true)
                                            {
                                                xFilteredWords.Add(bRec);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (xFilteredWords.Count > 0)
                    {
                        for (int i = 0; i < xFilteredWords.Count - 1; i++)
                        {
                            string xSW = xFilteredWords[i];

                            for (int j = i + 1; j < xFilteredWords.Count; j++)
                            {
                                xSW = xSW + " " + xFilteredWords[j];
                            }

                            zclsGlobal.zSearchDTAllCombo.Rows.Add(aRec["zSearch"], xSW, 0, 0, 0, 0, 0, "", "");
                        }

                        for (int i = xFilteredWords.Count - 1; i >= 0; i--)
                        {
                            string xSW = xFilteredWords[i];

                            for (int j = i - 1; j >= 0; j--)
                            {
                                xSW = xSW + " " + xFilteredWords[j];
                            }

                            zclsGlobal.zSearchDTAllCombo.Rows.Add(aRec["zSearch"], xSW, 0, 0, 0, 0, 0, "", "");
                        }
                    }


                    //DataColumn dataColumn = new DataColumn();
                    //                    dataColumn.DataType =   typeof(string);
                    //dataColumn.ColumnName = "colSelected";
                    //                    zclsGlobal.zSearchDTValid.Columns.Add("A");

                    /*
                        var responses = zSSClient.SearchAsync(SearchQuery.FromText(aRec.colSearchWords), null, null, searchOptions);
                        responses.Wait();

                        int xSubCountTot = xFilteredWords.Count;
                        int xSubCount = 0;
                        while ((responses.Result.Responses.Count == 0) &&
                                (xFilteredWords.Count > 1))
                        {
                            //        Application.Current.Dispatcher.Dispatch(() =>
                            //        {
                            lblStatus.Text = "Searching Sub Words...";
                            xSubCount++;
                            searchOptions = new SearchOptions(3000, 100, true, 1, 1 + xSubCount, 0, 25000, true);
                            lblSubwords.Text = xSubCount.ToString() + " of " + xSubCountTot.ToString();
                            await pb2.ProgressTo(xSubCount / xSubCountTot, 500, Easing.Linear);
                            //    });

                            xFilteredWords.RemoveAt(0);
                            aRec.colSearchWords = string.Join(" ", xFilteredWords);
                            responses = zSSClient.SearchAsync(SearchQuery.FromText(aRec.colSearchWords), null, null, searchOptions);
                            responses.Wait();
                        }

                        await pb2.ProgressTo(1, 500, Easing.Linear);
                        lblStatus.Text = "Searching Sub Words...";
                        lblSubwords.Text = "";



                        int xCount = 0;
                        foreach (var r in responses.Result.Responses)
                        {
                            foreach (var f in r.Files)
                            {
                                aRec.colQueueLength = r.QueueLength;
                                aRec.colUploadSpeed = r.UploadSpeed;
                                aRec.colBitRate = f.BitRate;
                                aRec.colSize = f.Size;
                                aRec.colLength = f.Length;
                                aRec.colExtention = f.Extension;
                                aRec.colFilename = f.Filename;
                                aRec.colUsername = r.Username;

                                zSearchDT.Rows.Add(aRec);

                                try
                                {
                                    xAll.Add(xCount.ToString(), aRec);
                                }
                                catch
                                {

                                }

                                try
                                {
                                    xBest.Add(aRec.colSearchWords, aRec);
                                    zBest.Add(aRec.colSearchWords, aRec);
                                }
                                catch
                                {

                                }

                                xCount = xCount + 1;
                            }
                        }

                    */

                    xC1 = xC1 + 1;
                }


                foreach (DataRow eRec in zclsGlobal.zSearchDTAllCombo.Rows)
                {
                    var xWords = eRec["zSearchWords"].ToString().Split(' ');
                    if (xWords.Length > 3)
                    {
                        Array.Sort(xWords);

                        var query = (from x in zclsGlobal.zSearchDTValid.Rows.OfType<DataRow>()
                                     where x.Field<string>("zSearchWords") == String.Join(" ", xWords)
                                     select x).ToList();

                        if (query.Count == 0)
                        {
                            zclsGlobal.zSearchDTValid.Rows.Add(eRec["zSearch"], String.Join(" ", xWords), 0, 0, 0, 0, 0, "", "", "", "Y");
                        }
                    }
                }




            }
            catch
            {
                UpdateMemo("< 005 - Error" + Environment.NewLine);
            }

            UpdateMemo("- 005 - Searching file content done" + Environment.NewLine);

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //     List<object> searchResponses = new List<object>();

            //            SearchOptions searchOptions = new SearchOptions(2000, 10, true, 1, 0, 500000, 10, true);
            SearchOptions searchOptions = new SearchOptions(2000, 100, true, 1, 1000, 0, 25000, true);

            int xC1 = 0;
            for (int i = 0; i < zclsGlobal.zSearchDTValid.Rows.Count; i++)
            {
                var aRec = zclsGlobal.zSearchDTValid.Rows[i];

                while (!zclsGlobal.zSSClient.State.HasFlag(SoulseekClientStates.LoggedIn))
                {
                    try
                    {
                        await zclsGlobal.zSSClient.ConnectAsync(edtUN.Text, edtPW.Text);
                    }
                    catch (Exception ex)
                    {
                    }

                    Thread.Sleep(10000);
                }

                try
                {
                    var responses = await zclsGlobal.zSSClient.SearchAsync(SearchQuery.FromText(aRec["zSearchWords"].ToString()), null, null, searchOptions);
                    //                searchResponses.Add(responses);

                    foreach (var r in responses.Responses)
                    {
                        foreach (var f in r.Files)
                        {
                            aRec["zQueueLength"] = r.QueueLength;
                            aRec["zUploadSpeed"] = r.UploadSpeed;
                            aRec["zBitRate"] = f.BitRate;
                            aRec["zSize"] = f.Size;
                            aRec["zLength"] = f.Length;
                            aRec["zExtention"] = f.Extension;
                            aRec["zFilename"] = f.Filename;
                            aRec["zUsername"] = r.Username;

                            zclsGlobal.zResultDT.Rows.Add(aRec[0], aRec[1], aRec[2], aRec[3], aRec[4], aRec[5], aRec[6], aRec[7], aRec[8], aRec[9], aRec[10]);

                        }

                    }

                    xC1++;
                }
                catch (Exception ex) { UpdateMemo(ex.Message + Environment.NewLine); }

                lblStatus.Text = (i + 1).ToString() + " of " + zclsGlobal.zSearchDTValid.Rows.Count.ToString();
            }

            dgView2.DataSource = zclsGlobal.zResultDT;

            Dictionary<string, DataTable> xdicFinal = new Dictionary<string, DataTable>();



            for (int i = 0; i < zclsGlobal.zResultDT.Rows.Count; i++)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("zSearch");
                dt.Columns.Add("zSearchWords");
                dt.Columns.Add("zQueueLength");
                dt.Columns.Add("zUploadSpeed");
                dt.Columns.Add("zBitRate");
                dt.Columns.Add("zSize");
                dt.Columns.Add("zLength");
                dt.Columns.Add("zExtention");
                dt.Columns.Add("zFilename");
                dt.Columns.Add("zUsername");
                dt.Columns.Add("zSelected");



                foreach (DataRow dr in zclsGlobal.zResultDT.Rows)
                {
                    if (dr[1] == zclsGlobal.zResultDT.Rows[i][1])
                    {


                        if (dr[4].ToString() == "")
                        {
                            dr[4] = 0;
                        }
                        if (dr[6].ToString() == "")
                        {
                            dr[6] = 0;
                        }

                        if (Convert.ToInt32(dr[2].ToString()) <= 5)
                        {
                            //if (dr[9].ToString().EndsWith(".mp3"))
                            //{
                            dt.Rows.Add(dr[0].ToString(), dr[1].ToString(), Convert.ToInt32(dr[2].ToString()), Convert.ToInt32(dr[3].ToString()),
                                Convert.ToInt32(dr[4].ToString()), Convert.ToInt32(dr[5].ToString()), Convert.ToInt32(dr[6].ToString()),
                                dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString());
                            //}
                        }
                    }
                }

                xdicFinal.TryAdd(zclsGlobal.zResultDT.Rows[i][1].ToString(), dt.Copy());
            }


            Dictionary<string, DataTable> xdicFinalBest = new Dictionary<string, DataTable>();

            foreach (var item in xdicFinal.Values)
            {
                item.DefaultView.Sort = "zUploadSpeed";






            }

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("zSearch");
            dt2.Columns.Add("zSearchWords");
            dt2.Columns.Add("zQueueLength");
            dt2.Columns.Add("zUploadSpeed");
            dt2.Columns.Add("zBitRate");
            dt2.Columns.Add("zSize");
            dt2.Columns.Add("zLength");
            dt2.Columns.Add("zExtention");
            dt2.Columns.Add("zFilename");
            dt2.Columns.Add("zUsername");
            dt2.Columns.Add("zSelected");

            List<string> xUList = new List<string>();
            List<string> xUList2 = new List<string>();
            foreach (var item in xdicFinal.Values)
            {
                if (item.Rows.Count > 0)
                {
                    DataRow dr = item.Rows[0];


                    if (!xUList.Contains(dr[8].ToString()))
                    {

                        if (!xUList2.Contains(dr[0].ToString()))
                        {

                            dt2.Rows.Add(dr[0].ToString(), dr[1].ToString(), Convert.ToInt32(dr[2].ToString()), Convert.ToInt32(dr[3].ToString()),
                    Convert.ToInt32(dr[4].ToString()), Convert.ToInt32(dr[5].ToString()), Convert.ToInt32(dr[6].ToString()),
                    dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString());

                            xUList.Add(dr[8].ToString());
                            xUList2.Add(dr[0].ToString());
                        }
                    }
                }

                dgView3.DataSource = dt2.Copy();
            }
        }

        public string LocalizePath(string path)
        {
            return path.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar);
        }

        public string ReplaceInvalidFileNameCharacters(string path, char replacement = '_')
        {
            var sanitized = path;

            foreach (var c in Path.GetInvalidFileNameChars())
            {
                sanitized = sanitized.Replace(c, replacement);
            }

            return sanitized;
        }

        public string ToLocalRelativeFilename(string remoteFilename)
        {
            if (string.IsNullOrWhiteSpace(remoteFilename))
            {
                throw new ArgumentException($"Invalid remote filename; expected a non-whitespace value, received '{remoteFilename}'", nameof(remoteFilename));
            }

            // normalize path separators
            var localizedRemoteFilename = LocalizePath(remoteFilename);

            var parts = localizedRemoteFilename.Split(Path.DirectorySeparatorChar);

            if (parts.Length == 1)
            {
                return ReplaceInvalidFileNameCharacters(parts.First());
            }

            var file = ReplaceInvalidFileNameCharacters(parts.Last());
            var directory = ReplaceInvalidFileNameCharacters(parts.Reverse().Skip(1).Take(1).Single());

            return Path.Combine(directory, file);
        }

        public string ToLocalFilename(string remoteFilename, string baseDirectory)
        {
            return Path.Combine(baseDirectory, ToLocalRelativeFilename(remoteFilename));
        }
        public Stream GetLocalFileStream(string remoteFilename, string saveDirectory)
        {
            var localFilename = ToLocalFilename(remoteFilename, baseDirectory: saveDirectory);
            var path = Path.GetDirectoryName(localFilename);

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            return new FileStream(localFilename, FileMode.Create);
        }

        /*
        public BackgroundWorker DoIt(DataRow x)
        {
            var stream = GetLocalFileStream(Path.GetFullPath(x[8].ToString()), @"c:\sss");
            var cts = new CancellationTokenSource();
            var downloadTask = zclsGlobal.zSSClient.DownloadAsync(x[9].ToString(), x[8].ToString(), () => Task.FromResult((Stream)stream), Convert.ToInt32(x[5]), 0, null, new TransferOptions(disposeOutputStreamOnCompletion: true));
            return downloadTask

        }
        */





        private async void button3_Click(object sender, EventArgs e)
        {
            foreach (DataRow x in ((dgView3.DataSource as DataTable).Rows))



            {
                try
                {
                    zTransfers.Add(zclsGlobal.zSSClient.DownloadAsync(x[9].ToString(), x[8].ToString(), () => Task.FromResult((Stream)GetLocalFileStream(Path.GetFullPath(x[8].ToString()), @"c:\sss")), Convert.ToInt32(x[5]), 0, null, new TransferOptions(progressUpdated: gggg, disposeOutputStreamOnCompletion: true)));
                    zProgress.Rows.Add(x[0], x[1], x[2], x[3], x[4], x[5], x[6], x[7], x[8], x[9], x[10], 0);
                }
                catch (Exception ex)
                { }

            }
            /*
                        foreach (DataRow x in ((dgView3.DataSource as DataTable).Rows))
                        {
                            zlistBox.Items.Add(zclsGlobal.zSSClient.DownloadAsync(x[9].ToString(), x[8].ToString(), () => Task.FromResult((Stream)GetLocalFileStream(Path.GetFullPath(x[8].ToString()), @"c:\sss")), Convert.ToInt32(x[5]), 0, null, new TransferOptions(disposeOutputStreamOnCompletion: true)));
                        }*/



            // zTransfers = delaaa(zTransfers);

            //   delaaa(zTransfers);              //DoIt(x);
            //var waitUntilEnqueue = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);







            /*                    if (downloadTask.Result.State.HasFlag(TransferStates.Queued) || downloadTask.Result.State == TransferStates.Initializing)
                                {
                                    waitUntilEnqueue.TrySetResult(true);
                                }

                            */


        }

        private void gggg((long PreviousBytesTransferred, Transfer Transfer) obj)
        {
            foreach (DataRow x in ((zProgress.Rows)))
            {
                if (x[8] == obj.Transfer.Filename)
                {
                    x[11] = obj.Transfer.PercentComplete;
                }
            }

            //            UpdateMemo(obj.Transfer.Filename + ":" + obj.Transfer.PercentComplete.ToString() + Environment.NewLine);
            UpdateGrid(zProgress.Copy());
            //            throw new NotImplementedException();
        }

        private void Ddd_TextChanged(object? sender, EventArgs e)
        {
            try
            {
                UpdateMemo("===" + Environment.NewLine);

                for (int i = 0; i < (sender as ListBox).Items.Count; i++)
                {
                    //Transfer transfer = (zlistBox.Items[(sender as ListBox).Items[i]] as Transfer);
                    //UpdateMemo(transfer.BytesTransferred.ToString() + Environment.NewLine);

                    //UpdateMemo(((sender as ListBox).Items[i] as Task<Transfer>).Id Result.BytesRemaining.ToString() + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }



        private void XBW_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            //   = Convert.ToInt32(((sender as BackgroundWorker).Container.Components[2] as Task<Transfer>).Result.BytesTransferred / ((sender as BackgroundWorker).Container.Components[2] as Task<Transfer>).Result.Size * 100);

        }

        private void UpdateToken(string SearchWords, int xTransfer)
        {
            try
            {
                zclsGlobal.zTracker[SearchWords] = xTransfer;

                DataTable table = new DataTable();

                foreach (KeyValuePair<string, int> entry in zclsGlobal.zTracker)
                {
                    if (!table.Columns.Contains(entry.Key.ToString()))
                    {
                        table.Rows.Add(SearchWords, xTransfer);
                    }
                }


                dgView4.DataSource = table;
                dgView4.Invalidate();

            }
            catch { }

            //return "";
        }



    }
}

