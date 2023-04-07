using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class clsData
    {
        public string zSearch { get; set; }
        public string zSearchWords { get; set; }
        public int zQueueLength { get; set; }
        public int zUploadSpeed { get; set; }
        public int? zBitRate { get; set; }
        public long zSize { get; set; }
        public int? zLength { get; set; }
        public string zExtention { get; set; }
        public string zFilename { get; set; }
        public string zUsername { get; set; }
        public string zSelected { get; set; }

        public clsData(
            string xSearch,
            int xQueueLength,
            int xUploadSpeed,
            int xBitRate,
            long xSize,
            int xLength,
            string xExtention,
            string xFilename,
            string xUsername,
            string xSelected
        )
        {
            zSearch = xSearch;
        }



    }
}
