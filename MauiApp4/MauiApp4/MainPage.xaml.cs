using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Soulseek;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Threading;
using System.Xml.Linq;
using Path = System.IO.Path;

namespace MauiApp4;

public partial class MainPage : ContentPage
{
    string zFullPath = "";
    SoulseekClient zSSClient = new SoulseekClient();
    Dictionary<string, clsTextFileData> zBest = new Dictionary<string, clsTextFileData>();
    Dictionary<string, Transfer> zTracker = new Dictionary<string, Transfer>();
    private string _lastUpdated;
    Label lastUpdated = new() { HorizontalTextAlignment = TextAlignment.End };

    public MainPage()
    {
        InitializeComponent();

        var xConnected = zSSClient.ConnectAsync("andrivr@gmail.com", "passNEWm.3");
        xConnected.Wait();


    }

    private async void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        try
        {
            lblUN.Text = zTracker.ElementAt(0).Value.BytesTransferred.ToString();
            //const long tot = zTracker.ElementAt(0).Value.Size;
            Random rand = new Random();
            int xx = rand.Next(0, 100); //returns random number between 0-99
            var yy = await pb2.ProgressTo(zTracker.ElementAt(0).Value.BytesRemaining / zTracker.ElementAt(0).Value.Size, 100, Easing.Linear);
            while (!yy)
            {
                Thread.Sleep(1000);
            }
        }
        catch { }
        
    }

    public async Task<FileResult> PickAndShow(PickOptions options)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                using var stream = await result.OpenReadAsync();
            }

            return result;
        }
        catch (Exception ex)
        {
            // The user canceled or something went wrong
        }

        return null;
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        var xR = await PickAndShow(new PickOptions { });

        lblFullPath.Text = xR.FullPath;
        zFullPath = xR.FullPath;
    }

    public static List<string> GetRandomWords(string data, int x)
    {
        // Split data into words.
        data = data.ToLower();
        data = data.Replace(",", " ");
        data = data.Replace("-", " ");
        data = data.Replace("(", " ");
        data = data.Replace(")", " ");
        data = data.Replace("'", " ");
        data = data.Replace(":", " ");
        data = data.Replace("_", " ");
        data = data.Replace(@"/", " ");
        data = data.Replace(@"\", " ");
        data = data.Replace(@".", " ");
        data = data.Replace(@"]", " ");
        data = data.Replace(@"[", " ");
        data = data.Replace(@"%20", " ");
        data = data.Replace(@"mp3", " ");
        data = data.Replace(@"#extinf", " ");
        data = data.Replace(@"#extm3u", " ");

        var words = data.Split(' ');

        List<string> words2 = new List<string>();

        foreach (var ARec in words)
        {
            try
            {
                var xtest = Convert.ToInt32(ARec);
            }
            catch
            {

                if (ARec != "")
                {
                    if (ARec.Length != 1)
                    {
                        if (ARec.Contains("%") != true)
                        {
                            if (ARec.Contains("com") != true)
                            {
                                if (ARec.Contains("clapcrate") != true)
                                {
                                    words2.Add(ARec);
                                }
                            }
                        }
                    }
                };

            }
        }

        return words2;
    }

    public BindingList<clsTextFileData> Read(string path)
    {
        var list = new BindingList<clsTextFileData>();

        using (StreamReader sr = new StreamReader(path))
        {
            while (sr.Peek() >= 0)
            {
                String line = sr.ReadLine();
                string[] columns = line.Split('\t');

                list.Add(new clsTextFileData(line, 0, 0, 0, 0, 0, "", "",""));
            }
        }

        return list;
    }

    private DataTable toDataTable(List<clsTextFileData> xData)
    {
        DataTable result = new DataTable();



    result.Columns.Add("colSearch");
    result.Columns.Add("colSearchWords");
    result.Columns.Add("colQueueLength");
    result.Columns.Add("colUploadSpeed");
    result.Columns.Add("colBitRate");
    result.Columns.Add("colSize");
    result.Columns.Add("colLength");
    result.Columns.Add("colExtention");
    result.Columns.Add("colFilename");

        foreach (var row in xData)
        {
            DataRow newrow = result.NewRow();

            newrow[0] = row.colSearch;
            newrow[1] = row.colSearchWords;
            newrow[2] = row.colQueueLength;
            newrow[3] = row.colUploadSpeed;
            newrow[4] = row.colBitRate;
            newrow[5] = row.colSize;
            newrow[6] = row.colLength;
            newrow[7] = row.colExtention;
            newrow[8] = row.colFilename;


            result.Rows.Add(newrow);
        }
        return result;
    }

    private async  void OnSearchClicked(object sender, EventArgs e)
    {
        DataTable xDT = new DataTable();

        xDT.Columns.Add("colSearch");
        xDT.Columns.Add("colSearchWords");
        xDT.Columns.Add("colQueueLength");
        xDT.Columns.Add("colUploadSpeed");
        xDT.Columns.Add("colBitRate");
        xDT.Columns.Add("colSize");
        xDT.Columns.Add("colLength");
        xDT.Columns.Add("colExtention");
        xDT.Columns.Add("colFilename");

        Dictionary<string, clsTextFileData> xAll = new Dictionary<string, clsTextFileData>();
        Dictionary<string, clsTextFileData> xBest = new Dictionary<string, clsTextFileData>();
        zBest = new Dictionary<string, clsTextFileData>();

        lblAll.Text = "";
        lblBest.Text = "";

        var xLines = Read(zFullPath);
        ObservableCollection<clsTextFileData> xLines2 = new ObservableCollection<clsTextFileData>();


        int xTotCount = 0;
        foreach (var aRec in xLines)
        {
            //            Application.Current.Dispatcher.Dispatch(() =>
            //          {
           lblStatus.Text = "Searching Next Line...";
                xTotCount++;
                lblTotal.Text = xTotCount.ToString() + " of " + xLines.Count.ToString();
            
           //pb1.Progress = 
            await pb1.ProgressTo(xTotCount * 100, 100, Easing.Linear);

            //        });


//            SearchOptions searchOptions = new SearchOptions(2000, 10, true, 1, 0, 500000, 10, true);
            SearchOptions searchOptions = new SearchOptions(1000, 10, true, 1, 0, 0, 25000, true);

            List<string> xWords = GetRandomWords(aRec.colSearch, 5);

            if (xWords.Count > 0)
            {

                aRec.colSearchWords = string.Join(" ", xWords);
                var responses = zSSClient.SearchAsync(SearchQuery.FromText(aRec.colSearchWords), null, null, searchOptions);
                responses.Wait();

                int xSubCountTot = xWords.Count;
                int xSubCount = 0;
                while ((responses.Result.Responses.Count == 0) &&
                        (xWords.Count > 1))
                {
                    //        Application.Current.Dispatcher.Dispatch(() =>
                    //        {
                    lblStatus.Text = "Searching Sub Words...";
                        xSubCount++;
                    searchOptions = new SearchOptions(3000, 100, true, 1, 1 + xSubCount, 0, 25000, true);
                    lblSubwords.Text = xSubCount.ToString() + " of " + xSubCountTot.ToString();
                    await pb2.ProgressTo(xSubCount / xSubCountTot, 500, Easing.Linear);
                    //    });

                    xWords.RemoveAt(0);
                    aRec.colSearchWords = string.Join(" ", xWords);
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

                        xDT.Rows.Add(aRec);

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
            }
        }

        //Draw Results On Screen
         /*
        lblAll.Text = lblAll.Text + "ALL RESULTS" + Environment.NewLine;
        foreach (var ARec in xAll)
        {
            lblAll.Text = lblAll.Text + "colSearch: " + ARec.Value.colSearch.ToString() + Environment.NewLine;
            lblAll.Text = lblAll.Text + "colSearchWords: " + ARec.Value.colSearchWords.ToString() + Environment.NewLine;
            lblAll.Text = lblAll.Text + "colQueueLength: " + ARec.Value.colQueueLength.ToString() + Environment.NewLine;
            lblAll.Text = lblAll.Text + "colUploadSpeed: " + ARec.Value.colUploadSpeed.ToString() + Environment.NewLine;
            lblAll.Text = lblAll.Text + "colBitRate: " + ARec.Value.colBitRate.ToString() + Environment.NewLine;
            lblAll.Text = lblAll.Text + "colSize: " + ARec.Value.colSize.ToString() + Environment.NewLine;
            lblAll.Text = lblAll.Text + "colLength: " + ARec.Value.colLength.ToString() + Environment.NewLine;
            lblAll.Text = lblAll.Text + "colExtention: " + ARec.Value.colExtention.ToString() + Environment.NewLine;
            lblAll.Text = lblAll.Text + "colFilename: " + ARec.Value.colFilename.ToString() + Environment.NewLine;
            lblAll.Text = lblAll.Text + "==================" + Environment.NewLine;

        }*/

        lblBest.Text = lblBest.Text + "BEST RESULTS" + Environment.NewLine;
        foreach (var ARec in xBest)
        {
            lblBest.Text = lblBest.Text + "colSearch: " + ARec.Value.colSearch.ToString() + Environment.NewLine;
            lblBest.Text = lblBest.Text + "colSearchWords: " + ARec.Value.colSearchWords.ToString() + Environment.NewLine;
            lblBest.Text = lblBest.Text + "colQueueLength: " + ARec.Value.colQueueLength.ToString() + Environment.NewLine;
            lblBest.Text = lblBest.Text + "colUploadSpeed: " + ARec.Value.colUploadSpeed.ToString() + Environment.NewLine;
            lblBest.Text = lblBest.Text + "colBitRate: " + ARec.Value.colBitRate.ToString() + Environment.NewLine;
            lblBest.Text = lblBest.Text + "colSize: " + ARec.Value.colSize.ToString() + Environment.NewLine;
            lblBest.Text = lblBest.Text + "colLength: " + ARec.Value.colLength.ToString() + Environment.NewLine;
            lblBest.Text = lblBest.Text + "colExtention: " + ARec.Value.colExtention.ToString() + Environment.NewLine;
            lblBest.Text = lblBest.Text + "colFilename: " + ARec.Value.colFilename.ToString() + Environment.NewLine;
            lblBest.Text = lblBest.Text + "==================" + Environment.NewLine;

        }


        /*
        foreach (DataRow ARec in xDT.Rows)
        {
            dgGridLines.Add(new Label { Text = ARec[0].ToString() });
            dgGridLines.Add(new Label { Text = ARec[1].ToString() });
            dgGridLines.Add(new Label { Text = ARec[2].ToString() });
            dgGridLines.Add(new Label { Text = ARec[3].ToString() });
            dgGridLines.Add(new Label { Text = ARec[4].ToString() });
            dgGridLines.Add(new Label { Text = ARec[5].ToString() });
            dgGridLines.Add(new Label { Text = ARec[6].ToString() });
            dgGridLines.Add(new Label { Text = ARec[7].ToString() });
            dgGridLines.Add(new Label { Text = ARec[8].ToString() });
        }
        */



    }

    public async void Enqueue(string SearchWords, string username, string filename, long xSize)
    {
        try
        {
            var waitUntilEnqueue = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var stream = clsGlobal.GetLocalFileStream(filename, "c:\\sss");
            var cts = new CancellationTokenSource();

            if (!zTracker.ContainsKey(SearchWords))
            {
                var downloadTask = await zSSClient.DownloadAsync(username, filename, () => Task.FromResult((Stream)stream), xSize, 0, null, new TransferOptions(disposeOutputStreamOnCompletion: true, stateChanged: (e) =>
                {
                //zTracker.Add(SearchWords, e.Transfer);

                /*
                if (e.Transfer.State.HasFlag(TransferStates.Queued) || e.Transfer.State == TransferStates.Initializing)
                {
                    waitUntilEnqueue.TrySetResult(true);
                }*/
                }, progressUpdated: (e) => UpdateToken(SearchWords, e.Transfer)));
            }

        }
        catch
        {
        }
    }

    public void UpdateToken(string SearchWords, Transfer xTransfer)
    {
        try
        {
            zTracker[SearchWords] = xTransfer;

        }
        catch { }
    }

    public string LastUpdated
    {
        get => _lastUpdated;
        set
        {
            _lastUpdated = value;
            OnPropertyChanged(nameof(LastUpdated));
        }
    }
    private void OnDownloadClick(object sender, EventArgs e)
    {

        int xCount = 0;
        foreach (var ARec in zBest)
        {

            xCount++;
            zTracker.Add(ARec.Key, null);
            Enqueue(ARec.Key, ARec.Value.colUsername, ARec.Value.colFilename, ARec.Value.colSize);
            Thread.Sleep(1000);
        }

        System.Timers.Timer timer1 = new System.Timers.Timer
        {
            Interval = 500
        };
        timer1.Enabled = true;
        timer1.Elapsed += Timer1_Elapsed;

        lastUpdated.BindingContext = this;
        lastUpdated.SetBinding(Label.TextProperty, zTracker.ElementAt(0).Value.BytesTransferred.ToString());



        /*
        int xCount = 0;
        foreach (var ARec in zBest)
        {
            xCount++;   



            var cts = new CancellationTokenSource();


            string xPath = System.IO.Path.GetDirectoryName(lblFullPath.Text);



            Stream xFileStream;
            xFileStream = new FileStream(xPath + @"/" +  xCount.ToString().PadLeft(3, '0') + " - " + ARec.Value.colSearchWords + System.IO.Path.GetExtension(ARec.Value.colFilename), FileMode.Create);



            var completedTransfer = await zSSClient.DownloadAsync(

            username: ARec.Value.colUsername,
            remoteFilename: ARec.Value.colFilename,
            outputStreamFactory: () => Task.FromResult(clsGlobal.GetLocalFileStream(ARec.Value.colFilename, @"C:\ssf\")),
            size: ARec.Value.colSize,
            startOffset: 0,
            token: null,
            cancellationToken: cts.Token
            );

            int xC = 0;
            while ((completedTransfer.State == TransferStates.InProgress))
            {
                xC++;
                lblDownload.Text = xCount.ToString() + " of " + zBest.Keys.Count.ToString() + "(" + completedTransfer.BytesTransferred.ToString() + " bytes of " + completedTransfer.BytesRemaining.ToString() +
                     " at " + completedTransfer.AverageSpeed.ToString() + ")";
                //pb1.Progress = 

                var done = await pbDownload.ProgressTo(xC, 1000, Easing.Linear);

                Thread.Sleep(1000);
            }

            int ddd = 0;
        }
        */
    }
}