using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using ClientDataTest.DATA;
using System.Reflection;

namespace ClientDataTest.CLASSES
{
    public class devCSV
    {
        public void SaveData(DataTable xDTData)
        {
            //Build the file from data using DataMap
            List<string> xLines = new List<string>();
            string xALine = "";
            int C1 = 0;

            Dictionary<string, string> xDataMap = new Dictionary<string, string>();
            xDataMap = tblDataMap.GetCSVMap();

            //Add columns line
            foreach (DataColumn AField in xDTData.Columns)
            {
                if (C1 < xDTData.Columns.Count - 1)
                {
                    if (xDataMap.ContainsKey(xDTData.Columns[C1].ColumnName.ToString())) //Skip unmapped fields
                    {
                        xALine = xALine + xDataMap[xDTData.Columns[C1].ColumnName.ToString()] + ",";
                    }
                }
                else
                {
                    if (xDataMap.ContainsKey(xDTData.Columns[C1].ColumnName.ToString())) //Skip unmapped fields
                    {
                        xALine = xALine + xDataMap[xDTData.Columns[C1].ColumnName.ToString()];
                    }
                }
                C1++;
            }
            xLines.Add(xALine);

            //Add record lines
            foreach (DataRow xARec in xDTData.Rows)
            {
                xALine = "";
                C1 = 0;
                foreach (DataColumn AField in xDTData.Columns)
                {
                    if (xDataMap.ContainsKey(xDTData.Columns[C1].ColumnName.ToString())) //Skip unmapped fields
                    {
                        if (C1 < xDTData.Columns.Count - 1)
                        {
                            xALine = xALine + xARec[C1].ToString() + ",";
                        }
                        else
                        {
                            xALine = xALine + xARec[C1].ToString();
                        }
                    }
                    C1++;
                }
                xLines.Add(xALine);
            }

            //Write the file
            StreamWriter xCSV = new StreamWriter(Application.StartupPath + "\\CSVData.csv", false, Encoding.Unicode);
            for (int i = 0; i < xLines.Count; i++)
            {
                xCSV.WriteLine(xLines[i]);
            }
            xCSV.Close();
        }

        public DataTable LoadData()
        {
            Dictionary<string, string> xDataMap = new Dictionary<string, string>();
            xDataMap = tblDataMap.GetCSVMap();

            //Read the file
            StreamReader xCSVFile = new StreamReader(Application.StartupPath + "\\CSVData.csv", Encoding.Unicode);

            List<string> xLines = new List<string>();

            while (xCSVFile.Peek() >= 0)
            {
                xLines.Add(xCSVFile.ReadLine());
            }

            xCSVFile.Close();

            //Get fields
            List<string> xFields = new List<string>();
            string xField = "";
            for (int i = 0; i < xLines[0].Length; i++)
            {
                if (xLines[0][i] != ',')
                {
                    xField = xField + xLines[0][i];
                }
                else
                {
                    xFields.Add(xField);
                    xField = "";
                }
            }

            xFields.Add(xField);

            //Build Recs
            List<List<string>> xFriendlyCSVRecs = new List<List<string>>();
            List<string> xFriendlyRec = new List<string>();
            for (int i = 1; i < xLines.Count; i++)
            {
                string xAFriedlyValue = xLines[i];

                while (xFriendlyRec.Count != xFields.Count)
                {
                    string xFixedValue = "";
                    while ((xAFriedlyValue != "") && (xAFriedlyValue[0] != ','))
                    {
                        xFixedValue = xFixedValue + xAFriedlyValue[0];
                        xAFriedlyValue = xAFriedlyValue.Remove(0, 1);
                    }

                    if (xAFriedlyValue.Contains(","))
                    {
                        xAFriedlyValue = xAFriedlyValue.Remove(0, 1);
                    }

                    xFriendlyRec.Add(xFixedValue);
                }

                xFriendlyCSVRecs.Add(xFriendlyRec);
                xFriendlyRec = new List<string>();
            }

            //Build Result
            DataTable xDataTable = new DataTable();
            foreach (PropertyInfo xInfo in typeof(tblClient).GetProperties())
            {
                xDataTable.Columns.Add(new DataColumn(xInfo.Name, xInfo.PropertyType));
            }

            int xIDX = 1;
            foreach (List<string> xARec in xFriendlyCSVRecs)
            {
                DataRow xDTRec = xDataTable.NewRow();
                xDTRec["IDX"] = xIDX;

                foreach (string xAField in xDataMap.Keys)
                {
                    //Find field
                    int C1 = -1;
                    for (int i = 0; i < xFields.Count; i++)
                    {
                        if (xFields[i] == xDataMap[xAField])
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