using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientDataTest.DATA;
using System.Data;
using System.ComponentModel;
using System.Web;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace ClientDataTest.CLASSES
{
    public class devJSON
    {
        public void SaveData(DataTable xDTData)
        {
            //Build the file from data using DataMap
            DataTable xMappedDTData = new DataTable();
            xMappedDTData = xDTData.Copy();

            Dictionary<string, string> xDataMap = new Dictionary<string, string>();
            xDataMap = tblDataMap.GetJSONMap();

            //Build new DataTable with mapped Fields
            int C1 = 0;
            foreach (DataColumn AField in xDTData.Columns)
            {
                if (!xDataMap.ContainsKey(xDTData.Columns[C1].ColumnName.ToString())) //Skip unmapped fields
                {
                    xMappedDTData.Columns.Remove(xDTData.Columns[C1].ColumnName.ToString());
                }
                else
                {
                    xMappedDTData.Columns[xDTData.Columns[C1].ColumnName.ToString()].ColumnName = xDataMap[xDTData.Columns[C1].ColumnName.ToString()];
                }

                C1++;
            }

            //Convert to JSON
            string xJsonString = devGeneral.DataTableToJson(xMappedDTData);

            //Write the file
            StreamWriter xJSON = new StreamWriter(Application.StartupPath + "\\JSONData.json", false, Encoding.Unicode);
            xJSON.WriteLine(xJsonString);
            xJSON.Close();
        }

        public DataTable LoadData()
        {
            Dictionary<string, string> xDataMap = new Dictionary<string, string>();
            xDataMap = tblDataMap.GetJSONMap();

            //Read the file
            StreamReader xJSONFile = new StreamReader(Application.StartupPath + "\\JSONData.json", Encoding.Unicode);
            StringBuilder xJSONFileLine = new StringBuilder();

            while (xJSONFile.Peek() >= 0)
            {
                xJSONFileLine.Append(xJSONFile.ReadLine());
            }

            xJSONFile.Close();

            string xJSONString = xJSONFileLine.ToString();
            List<string> xJSONRecs = new List<string>();

            while (xJSONString != "}]")
            {
                while (xJSONString[0] != '{')
                {
                    xJSONString = xJSONString.Remove(0,1);
                }

                xJSONString = xJSONString.Remove(0,1);
                string xAJSONRec = "";

                while (xJSONString[0] != '}')
                {
                    xAJSONRec = xAJSONRec + xJSONString[0];
                    xJSONString = xJSONString.Remove(0,1);
                }

                xJSONRecs.Add(xAJSONRec);
            }

            //Build field list
            List<string> xJSONFields = new List<string>();
            string xAJSONField = "";
            for (int i = 0; i < xJSONRecs[0].Length; i++)
            {
                if (xJSONRecs[0][i] != ':')
                {
                    xAJSONField = xAJSONField + xJSONRecs[0][i];
                }
                else
                {
                    if (xAJSONField.Contains(","))
                    {
                        string xFixedField = "";
                        bool xFieldStart = false;
                        for (int i2 = 0; i2 < xAJSONField.Length; i2++)
                        {
                            if (xFieldStart)
                            {
                                xFixedField = xFixedField + xAJSONField[i2];
                            }

                            if (xAJSONField[i2] == ',')
                            {
                                xFieldStart = true;
                            }
                        }

                        xAJSONField = xFixedField;
                    }

                    xAJSONField = xAJSONField.Remove(0, 1);
                    xAJSONField = xAJSONField.Remove(xAJSONField.Length - 1, 1);

                    xJSONFields.Add(xAJSONField);
                    xAJSONField = "";
                }
            }

            //Build Recs
            List<List<string>> xFriendlyJSONRecs = new List<List<string>>();
            List<string> xFriendlyRec = new List<string>();
            for (int i = 0; i < xJSONRecs.Count; i++)
            {
                string xAFriedlyValue = xJSONRecs[i];

                while (xFriendlyRec.Count != xJSONFields.Count)
                {
                    while (xAFriedlyValue[0] != ':')
                    {
                        xAFriedlyValue = xAFriedlyValue.Remove(0, 1);
                    }

                    string xFixedValue = "";
                    while ((xAFriedlyValue != "") && (xAFriedlyValue[0] != ','))
                    {
                        xFixedValue = xFixedValue + xAFriedlyValue[0];
                        xAFriedlyValue = xAFriedlyValue.Remove(0, 1);
                    }

                    xFixedValue = xFixedValue.Remove(0, 2);
                    xFixedValue = xFixedValue.Remove(xFixedValue.Length - 1, 1);

                    xFriendlyRec.Add(xFixedValue);
                }

                xFriendlyJSONRecs.Add(xFriendlyRec);
                xFriendlyRec = new List<string>();
            }

            //Build Result
            DataTable xDataTable = new DataTable();
            foreach (PropertyInfo xInfo in typeof(tblClient).GetProperties())
            {
                xDataTable.Columns.Add(new DataColumn(xInfo.Name, xInfo.PropertyType));
            }

            int xIDX = 1;
            foreach (List<string> xARec in xFriendlyJSONRecs)
            {
                DataRow xDTRec = xDataTable.NewRow();
                xDTRec["IDX"] = xIDX;

                foreach (string xAField in xDataMap.Keys)
                {
                    //Find field
                    int C1 = -1;
                    for (int i = 0; i < xJSONFields.Count; i++)
                    {
                        if (xJSONFields[i] == xDataMap[xAField])
                        {
                            C1 = i;
                        }
                    }

                    if (C1 > -1)
                    {
                        xDTRec[xAField] = xARec[C1];
                    }
                }

                //Validate cell
                xDTRec["IsValid"] = "False";
                double xVal = 0;
                if ((xDTRec["Cell"].ToString().Length == 10) && (double.TryParse(xDTRec["Cell"].ToString(), out xVal)))
                {
                    xDTRec["IsValid"] = "True";
                }

                xDataTable.Rows.Add(xDTRec);
                xIDX = xIDX + 1;
            }

            SaveData(xDataTable);
            return xDataTable;
        }
    }
}
