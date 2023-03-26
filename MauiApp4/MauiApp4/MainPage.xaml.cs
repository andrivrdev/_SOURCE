using Soulseek;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using File = System.IO.File;

namespace MauiApp4;

public partial class MainPage : ContentPage
{
    string zFullPath = "";
    SoulseekClient zSSClient = new SoulseekClient();

    public MainPage()
    {
        InitializeComponent();

        var xConnected = zSSClient.ConnectAsync("andrivr@gmail.com", "passNEWm.3");
        xConnected.Wait();

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

                list.Add(new clsTextFileData(line, 0, 0, 0, 0, 0, "", ""));
            }
        }

        return list;
    }


    private async  void OnSearchClicked(object sender, EventArgs e)
    {
        Dictionary<string, clsTextFileData> xAll = new Dictionary<string, clsTextFileData>();
        Dictionary<string, clsTextFileData> xBest = new Dictionary<string, clsTextFileData>();

        lblAll.Text = "";
        lblBest.Text = "";

        var xLines = Read(zFullPath);
        ObservableCollection<clsTextFileData> xLines2 = new ObservableCollection<clsTextFileData>();


        int xTotCount = 0;
        foreach (var aRec in xLines)
        {
            //            Application.Current.Dispatcher.Dispatch(() =>
            //          {
            await pb.ProgressTo(0.75, 500, Easing.Linear);
           lblStatus.Text = "Searching Next Line...";
                xTotCount++;
                lblTotal.Text = xTotCount.ToString() + " of " + xLines.Count.ToString();

    //        });


            SearchOptions searchOptions = new SearchOptions(3000, 10, true, 1, 500, 0, 25000, true);

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
                    await pb.ProgressTo(0.75, 500, Easing.Linear);
                    lblStatus.Text = "Searching Sub Words...";
                        xSubCount++;
                        lblSubwords.Text = xSubCount.ToString() + " of " + xSubCountTot.ToString();
                //    });

                    xWords.RemoveAt(0);
                    aRec.colSearchWords = string.Join(" ", xWords);
                    responses = zSSClient.SearchAsync(SearchQuery.FromText(aRec.colSearchWords), null, null, searchOptions);
                    responses.Wait();
                }

                await pb.ProgressTo(0.75, 500, Easing.Linear);
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



                        bool doadd = true;
                        foreach (var Arecc in xLines2)
                        {
                            if (!(Arecc.colSearch == aRec.colSearch)
                                && (Arecc.colFilename == aRec.colFilename)
                                    )
                            {
                                {
                                    doadd = false;

                                }
                            }
                        }

                        if (doadd)
                        {
                            xLines2.Add(aRec);
                        }


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

        }

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

    }
}

