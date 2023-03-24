using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using DevExpress.DataAccess;
using DevExpress.DataAccess.Excel;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraPrinting.Native;
using Soulseek;

namespace DXApplication1
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        SoulseekClient zSSClient = new SoulseekClient();
        public Form1()
        {
            InitializeComponent();

            var xConnected = zSSClient.ConnectAsync("andrivr@gmail.com", "passNEWm.3");
            xConnected.Wait();
        }

        public class TextFileData
        {
            public TextFileData(string Search,
                int QueueLength,
                int UploadSpeed,
                int BitRate,
                long Size,
                int Length,
                string Extention,
                string Filename)
            {

                colSearch = Search;
            }

            public string colSearch { get; set; }
            public string colSearchWords { get; set; }
            public int colQueueLength { get; set; }
            public int colUploadSpeed { get; set; }
            public int? colBitRate { get; set; }
            public long colSize { get; set; }
            public int? colLength { get; set; }
            public string colExtention { get; set; }
            public string colFilename { get; set; }
        }

        public BindingList<TextFileData> Read(string path)
        {
            var list = new BindingList<TextFileData>();

            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    String line = sr.ReadLine();
                    string[] columns = line.Split('\t');

                    list.Add(new TextFileData(line, 0, 0, 0, 0, 0, "", ""));
                }
            }

            return list;
        }

        private static List<string> GetRandomWords(string data, int x)
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
                catch {

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
            //return string.Join(" ", words2);

            if (!(words2.Count < 5))
            {
                Random random = new Random();
                var start = random.Next(0, words.Length - x);
                // Select the words.
                var selectedWords = words.Skip(start).Take(x);
            //    return string.Join(" ", selectedWords);
            }
            // Find a random place to start, at least x words back.
           // return data;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var xLines = Read(openFileDialog1.FileName);
                BindingList<TextFileData> xLines2 = new BindingList<TextFileData>();

                foreach (var aRec in xLines)
                {
                    SearchOptions searchOptions = new SearchOptions(10000, 10, true, 1, 500, 0, 25000, true);

                    List<string> xWords = GetRandomWords(aRec.colSearch, 5);

                    if (xWords.Count > 0)
                    {

                        aRec.colSearchWords = string.Join(" ", xWords);
                        var responses = zSSClient.SearchAsync(SearchQuery.FromText(aRec.colSearchWords), null, null, searchOptions);
                        responses.Wait();

                        while ((responses.Result.Responses.Count == 0) &&
                                (xWords.Count > 1))
                        {
                            xWords.RemoveAt(0);
                            aRec.colSearchWords = string.Join(" ", xWords);
                            responses = zSSClient.SearchAsync(SearchQuery.FromText(aRec.colSearchWords), null, null, searchOptions);
                            responses.Wait();
                        }

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













                                gridControl1.DataSource = xLines2;

                                using (StreamWriter sr = new StreamWriter(@"C:\data.dat"))
                                {
                                    foreach (var ALine in xLines2)
                                    {

                                        //
                                    }

                                    
                                }
                            }
                        }
                    }

                }
//                gridControl1.DataSource = xLines2;
            }



            // ...
            //Dashboard dashboard = new Dashboard();
            //        var csvDataSource = new ExcelDataSource();
            //          csvDataSource.FileName = openFileDialog1.FileName;
            //            csvDataSource.SourceOptions = new CsvSourceOptions();
            //              csvDataSource.Fill();

            //                gridControl1.DataSource = csvDataSource;
        }

    }
}

