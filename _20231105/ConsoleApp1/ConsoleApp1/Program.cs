// See https://aka.ms/new-console-template for more information



using Moq;
using Soulseek;
using System.Collections.Immutable;
using System.Data;

int zCurrentUsernamePassword = 0 ;

List<string> zUserNames = new List<string>();
List<string> zPasswords = new List<string>();

zUserNames.Add("aaa");
zPasswords.Add("aaa");
zUserNames.Add("bbb");
zPasswords.Add("bbb");
zUserNames.Add("ccc");
zPasswords.Add("ccc");
zUserNames.Add("ddd");
zPasswords.Add("ddd");



DataTable dtSearchQue = new DataTable();
dtSearchQue.Columns.Add("zLine");
dtSearchQue.Columns.Add("zUsableWords");
dtSearchQue.Columns.Add("zNoDupWords");
dtSearchQue.Columns.Add("zComboWords");
dtSearchQue.Columns.Add("zWordCount");
dtSearchQue.Columns.Add("zQueueLength");
dtSearchQue.Columns.Add("zUploadSpeed");
dtSearchQue.Columns.Add("zBitRate");
dtSearchQue.Columns.Add("zSize");
dtSearchQue.Columns.Add("zLength");
dtSearchQue.Columns.Add("zExtention");
dtSearchQue.Columns.Add("zFilename");
dtSearchQue.Columns.Add("zUsername");
dtSearchQue.Columns.Add("zSelected");
dtSearchQue.Columns.Add("zProgressPerc");

FileSystemWatcher watcher = new FileSystemWatcher();
watcher.Path = "C:\\_files";
watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                       | NotifyFilters.FileName | NotifyFilters.DirectoryName;
watcher.Filter = "*.*";

// Add event handlers.
watcher.Created += Watcher_Created;
//watcher.Changed += Watcher_Created;
watcher.Renamed += Watcher_Renamed;
watcher.Deleted += Watcher_Deleted;

// Begin watching.
watcher.EnableRaisingEvents = true;

List<List<string>> GetAllCombinations(List<string> inputList)
{
    List<List<string>> result = new List<List<string>>();
    int combinationsCount = (int)Math.Pow(2, inputList.Count);

    for (int i = 0; i < combinationsCount; i++)
    {
        List<string> combination = new List<string>();
        for (int j = 0; j < inputList.Count; j++)
        {
            if ((i & (1 << j)) != 0)
            {
                combination.Add(inputList[j]);
            }
        }
        result.Add(combination);
    }

    return result;
}



async void Watcher_Created(object sender, FileSystemEventArgs e)
{

    Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

    DataTable dtFileLines = new DataTable();
    DataTable dtFileLinesAllCombos = new DataTable();
    


    dtFileLines.Columns.Add("zLine");
    dtFileLines.Columns.Add("zUsableWords");
    dtFileLines.Columns.Add("zNoDupWords");
    dtFileLines.Columns.Add("zComboWords");
    dtFileLines.Columns.Add("zWordCount");
    dtFileLines.Columns.Add("zQueueLength");
    dtFileLines.Columns.Add("zUploadSpeed");
    dtFileLines.Columns.Add("zBitRate");
    dtFileLines.Columns.Add("zSize");
    dtFileLines.Columns.Add("zLength");
    dtFileLines.Columns.Add("zExtention");
    dtFileLines.Columns.Add("zFilename");
    dtFileLines.Columns.Add("zUsername");
    dtFileLines.Columns.Add("zSelected");
    dtFileLines.Columns.Add("zProgressPerc");

    dtFileLinesAllCombos.Columns.Add("zLine");
    dtFileLinesAllCombos.Columns.Add("zUsableWords");
    dtFileLinesAllCombos.Columns.Add("zNoDupWords");
    dtFileLinesAllCombos.Columns.Add("zComboWords");
    dtFileLinesAllCombos.Columns.Add("zWordCount");
    dtFileLinesAllCombos.Columns.Add("zQueueLength");
    dtFileLinesAllCombos.Columns.Add("zUploadSpeed");
    dtFileLinesAllCombos.Columns.Add("zBitRate");
    dtFileLinesAllCombos.Columns.Add("zSize");
    dtFileLinesAllCombos.Columns.Add("zLength");
    dtFileLinesAllCombos.Columns.Add("zExtention");
    dtFileLinesAllCombos.Columns.Add("zFilename");
    dtFileLinesAllCombos.Columns.Add("zUsername");
    dtFileLinesAllCombos.Columns.Add("zSelected");
    dtFileLinesAllCombos.Columns.Add("zProgressPerc");

    

    //Load the file
    try
    {
        using (StreamReader sr = new StreamReader(e.FullPath))
        {
            while (sr.Peek() >= 0)
            {
                String line = sr.ReadLine();
                string[] columns = line.Split('\t', StringSplitOptions.RemoveEmptyEntries);

                //                dtFileLines.Rows.Add(line, "", 0, 0, 0, 0, 0, "", "", "usablewords", "noduplicatescombo");
                dtFileLines.Rows.Add(line, "", 0, 0, 0, 0, 0, "", "", "", "");

            }
        }
    }
    catch (Exception ex) { }

    //Clean the lines
    foreach (DataRow aRec in dtFileLines.Rows)
    {
        string optimizedRec = aRec["zLine"].ToString();

        optimizedRec = optimizedRec.ToLower();
        optimizedRec = optimizedRec.Replace(",", " ");
        optimizedRec = optimizedRec.Replace("-", " ");
        optimizedRec = optimizedRec.Replace("(", " ");
        optimizedRec = optimizedRec.Replace(")", " ");
        optimizedRec = optimizedRec.Replace("'", " ");
        optimizedRec = optimizedRec.Replace(":", " ");
        optimizedRec = optimizedRec.Replace("_", " ");
        optimizedRec = optimizedRec.Replace(@"/", " ");
        optimizedRec = optimizedRec.Replace(@"\", " ");
        optimizedRec = optimizedRec.Replace(@".", " ");
        optimizedRec = optimizedRec.Replace(@"]", " ");
        optimizedRec = optimizedRec.Replace(@"[", " ");
        optimizedRec = optimizedRec.Replace(@"%20", " ");
        optimizedRec = optimizedRec.Replace(@"mp3", " ");
        optimizedRec = optimizedRec.Replace(@"flac", " ");
        optimizedRec = optimizedRec.Replace(@"can t", " ");
        optimizedRec = optimizedRec.Replace(@"#extinf", " ");
        optimizedRec = optimizedRec.Replace(@"#extm3u", " ");

        //Further clean each word on the line
        string[] xAllWords = optimizedRec.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, string> xFilteredWords = new Dictionary<string, string>();

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
                                    if (xFilteredWords.ContainsKey(bRec) == false)
                                    {
                                        xFilteredWords.Add(bRec, bRec);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        if (xFilteredWords.Count >= 3)
        {
            aRec[1] = "";
            foreach (var bRec in xFilteredWords)
            {
                aRec[1] = aRec[1].ToString() + " " + bRec.Value;
            }

            //Remove duplicate words
            var xxx = (aRec[1].ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray());
            //Sort Alphabetically
            Array.Sort(xxx);

            aRec[2] = string.Join(" ", xxx);

            //Find all possible combinations



            List<string> Combos = new List<string>();
            var allCombos = GetAllCombinations(aRec[2].ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList<string>());

            foreach (var bRec in allCombos)
            {
                

                Combos.Add(String.Join(" ", bRec.ToArray<string>()));
            }

            string a = "a";


            /*
            foreach (string comboRec in aRec[10].ToString().Split(' ').ToArray())
            {
                string mtemp = "";
                for (int i = 0; i < aRec[10].ToString().Split(' ').ToArray().Length; i++)
                {
                    mtemp = mtemp + " " + comboRec;
                }

                Combos.Add(mtemp);

            }*/








            //Now we have many more lines generated from combos
            foreach (var bRec in Combos)
            {
                var cRec = aRec;
                cRec[3] = bRec.ToString();
                cRec[4] = cRec[3].ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries).Length.ToString();

                dtFileLinesAllCombos.Rows.Add(cRec[0], cRec[1], cRec[2], cRec[3], cRec[4], cRec[5], cRec[6], cRec[7], cRec[8], cRec[9], cRec[10], cRec[11]);
            }
        }
    }

    //Add lines generated to search queue
    

    dtFileLinesAllCombos.DefaultView.Sort = "zWordCount ASC";
    dtFileLinesAllCombos = dtFileLinesAllCombos.DefaultView.ToTable();


    foreach (DataRow row in dtFileLinesAllCombos.Rows)
    {
        dtSearchQue.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12], row[13]);
    }



    using (StreamWriter writer = new StreamWriter("c:\\output.txt"))
    {
        foreach (DataRow row in dtFileLinesAllCombos.Rows)
        {
            foreach (object item in row.ItemArray)
            {
                writer.Write(item.ToString() + "|");

            }
            writer.WriteLine();
        }
    }

    //Move the file
    try
    {
        string sourceFile = e.FullPath;
        string destinationFolder = "C:\\_files\\old";

        // To move a file to another folder, use the File.Move method.
        System.IO.File.Move(sourceFile, Path.Combine(destinationFolder, DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Microsecond.ToString() + Path.GetFileName(sourceFile)), true);
    }
    catch (Exception ex) { }
}




       

 



    





 

void Watcher_Renamed(object sender, RenamedEventArgs e)
{
    Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
}

void Watcher_Deleted(object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"File: {e.FullPath} deleted");
}

var xClient = new SoulseekClient();
await xClient.ConnectAsync("andrivr001@gmail.com", "passNEWm.3");


while (true)
{
    //Pick up a new file



    Console.WriteLine("Hello, World!");

    Thread.Sleep(6000);

    foreach (DataRow aRec in dtSearchQue.Rows)
    {
        Console.WriteLine(aRec["zComboWords"]);
        if (Convert.ToInt32(aRec["zWordCount"]) >= 3)

        {
            while (!xClient.State.HasFlag(SoulseekClientStates.LoggedIn))
            {
                try
                {
                    await xClient.ConnectAsync(zUserNames[zCurrentUsernamePassword], zPasswords[zCurrentUsernamePassword]);


                }
                catch (Exception ex)
                {
                }

                Thread.Sleep(10000);

                zCurrentUsernamePassword++;
                if (zCurrentUsernamePassword > zUserNames.Count - 1)
                {
                    zCurrentUsernamePassword = 0;

                }
            }






            SearchOptions searchOptions = new SearchOptions(5000, 10, true, 1, 5, 0, 20, true);
            var c = new Mock<IMessageConnection>();



            var responses = await xClient.SearchAsync(SearchQuery.FromText(aRec["zComboWords"].ToString()), null, null, searchOptions);
            var sortedres = responses.Responses.OrderByDescending(r => r.HasFreeUploadSlot).ThenByDescending(r => r.UploadSpeed);

            Soulseek.File selFile = null;
            if (sortedres.Count() > 0)
            {
                if (sortedres.FirstOrDefault().Files.Count() > 0)
                {
                    selFile = sortedres.FirstOrDefault().Files.FirstOrDefault();
                }
            }

            foreach (var xxx in sortedres)
            {
                foreach (var yyy in xxx.Files)
                {
                    if ((yyy.BitRate > selFile.BitRate) && (yyy.Length > selFile.Length))
                    {
                        selFile = yyy;

                        aRec["zQueueLength"] = xxx.QueueLength;
                        aRec["zUploadSpeed"] = xxx.UploadSpeed;
                        aRec["zBitRate"] = selFile.BitRate; ;
                        aRec["zSize"] = selFile.Size;
                        aRec["zLength"] = selFile.Length;
                        aRec["zExtention"] = selFile.Extension;
                        aRec["zFilename"] = selFile.Filename;
                        aRec["zUsername"] = xxx.Username;

                    }
                }
            }

            if (selFile != null)
            {
                var x = 1;
            }
        }
    }

}

