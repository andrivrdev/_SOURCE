using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;

namespace ClientDataTest.DATA
{
    public static class tblDataMap
    {
        public static BindingList<tblDataMapFields> zDataMap = new BindingList<tblDataMapFields>();

        public static void PopulateDataMap()
        {
            //Populate defaults (Custom data mapping can be done here)
            zDataMap = new BindingList<tblDataMapFields>();
            tblDataMapFields xAMap = new tblDataMapFields();
            xAMap.IDX = 1;
            xAMap.OurField = "Name";
            xAMap.CSVField = "Name";
            xAMap.JSONField = "Name";
            zDataMap.Add(xAMap);

            xAMap = new tblDataMapFields();
            xAMap.IDX = 1;
            xAMap.OurField = "Cell";
            xAMap.CSVField = "Cell";
            xAMap.JSONField = "Cell";
            zDataMap.Add(xAMap);

            xAMap = new tblDataMapFields();
            xAMap.IDX = 1;
            xAMap.OurField = "Email";
            xAMap.CSVField = "Email";
            xAMap.JSONField = "Email";
            zDataMap.Add(xAMap);

            xAMap = new tblDataMapFields();
            xAMap.IDX = 1;
            xAMap.OurField = "IsValid";
            xAMap.CSVField = "IsValid";
            xAMap.JSONField = "IsValid";
            zDataMap.Add(xAMap);
        }

        public static Dictionary<string,string> GetCSVMap()
        {
            Dictionary<string, string> xTheData = new Dictionary<string, string>();
            foreach (tblDataMapFields xARec in zDataMap)
            {
                xTheData.Add(xARec.OurField, xARec.CSVField);
            }
            return xTheData;
        }

        public static Dictionary<string, string> GetJSONMap()
        {
            Dictionary<string, string> xTheData = new Dictionary<string, string>();
            foreach (tblDataMapFields xARec in zDataMap)
            {
                xTheData.Add(xARec.OurField, xARec.JSONField);
            }
            return xTheData;
        }

    }
}
