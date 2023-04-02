using Soulseek;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class clsGlobal
    {
        public SoulseekClient zSSClient = new SoulseekClient();

        public DataTable zSearchDT = new DataTable();
        public DataTable zSearchDTAllCombo = new DataTable();
        public DataTable zSearchDTValid = new DataTable();
        public DataTable zResultDT = new DataTable();
        public Dictionary<string, int> zTracker = new Dictionary<string, int>();

        public clsGlobal()
        {
            zSearchDT.Columns.Add("zSearch");
            zSearchDT.Columns.Add("zSearchWords");
            zSearchDT.Columns.Add("zQueueLength");
            zSearchDT.Columns.Add("zUploadSpeed");
            zSearchDT.Columns.Add("zBitRate");
            zSearchDT.Columns.Add("zSize");
            zSearchDT.Columns.Add("zLength");
            zSearchDT.Columns.Add("zExtention");
            zSearchDT.Columns.Add("zFilename");

            zSearchDTAllCombo.Columns.Add("zSearch");
            zSearchDTAllCombo.Columns.Add("zSearchWords");
            zSearchDTAllCombo.Columns.Add("zQueueLength");
            zSearchDTAllCombo.Columns.Add("zUploadSpeed");
            zSearchDTAllCombo.Columns.Add("zBitRate");
            zSearchDTAllCombo.Columns.Add("zSize");
            zSearchDTAllCombo.Columns.Add("zLength");
            zSearchDTAllCombo.Columns.Add("zExtention");
            zSearchDTAllCombo.Columns.Add("zFilename");

            zSearchDTValid.Columns.Add("zSearch");
            zSearchDTValid.Columns.Add("zSearchWords");
            zSearchDTValid.Columns.Add("zQueueLength");
            zSearchDTValid.Columns.Add("zUploadSpeed");
            zSearchDTValid.Columns.Add("zBitRate");
            zSearchDTValid.Columns.Add("zSize");
            zSearchDTValid.Columns.Add("zLength");
            zSearchDTValid.Columns.Add("zExtention");
            zSearchDTValid.Columns.Add("zFilename");
            zSearchDTValid.Columns.Add("zUsername");
            zSearchDTValid.Columns.Add("zSelected");

            zResultDT.Columns.Add("zSearch");
            zResultDT.Columns.Add("zSearchWords");
            zResultDT.Columns.Add("zQueueLength");
            zResultDT.Columns.Add("zUploadSpeed");
            zResultDT.Columns.Add("zBitRate");
            zResultDT.Columns.Add("zSize");
            zResultDT.Columns.Add("zLength");
            zResultDT.Columns.Add("zExtention");
            zResultDT.Columns.Add("zFilename");
            zResultDT.Columns.Add("zUsername");
            zResultDT.Columns.Add("zSelected");

        }

    }
    
}

