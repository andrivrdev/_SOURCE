using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp4
{
    public class clsTextFileData
    {
        public clsTextFileData(

        string Search,
        int QueueLength,
        int UploadSpeed,
        int BitRate,
        long Size,
        int Length,
        string Extention,
        string Filename,
        string Username
        )
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
        public string colUsername { get; set; }


    }
}
