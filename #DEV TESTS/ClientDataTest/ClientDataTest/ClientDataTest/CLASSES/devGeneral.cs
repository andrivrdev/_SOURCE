using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.Reflection;

namespace ClientDataTest.CLASSES
{
    public static class devGeneral
    {
        static Random zRand = new Random();
        static string zLetters = "abcdefghijklmnopqrstuvwxyz";
        static string zNumbers = "1234567890";

        public static string GenerateAWord()
        {
            Dictionary<string, string> aa = new Dictionary<string, string>();


            int xLength = zRand.Next(1, 15);

            string xWord = "";
            for (int i = 1; i <= xLength; i++)
            {
                int xChar = zRand.Next(0, 26);
                int xUpperOrLower = zRand.Next(0, 2);
                string xAChar = zLetters[xChar].ToString();

                if (xUpperOrLower == 0)
                {
                    xWord = xWord + zLetters[xChar];
                }
                else
                {
                    xWord = xWord + xAChar.ToUpper();
                }
            }
            return xWord;
        }

        public static string GenerateANumber(int xLength)
        {
            string xNum = "";
            for (int i = 1; i <= xLength; i++)
            {
                int xChar = zRand.Next(0, 10);
                string xAChar = zNumbers[xChar].ToString();
                xNum = xNum + zNumbers[xChar];
            }
            return xNum;
        }

        public static string GenerateAnEMail()
        {
            string xWord = GenerateAWord() + "@" + GenerateAWord();
            int xComCoZa = zRand.Next(0, 2);

            if (xComCoZa == 0)
            {
                xWord = xWord + ".com";
            }
            else
            {
                xWord = xWord + ".co.za";
            }
            return xWord;
        }

        public static DataTable BindingListToDataTable<T>(BindingList<T> xList)
        {
            DataTable xDataTable = new DataTable();

            foreach (PropertyInfo xInfo in typeof(T).GetProperties())
            {
                xDataTable.Columns.Add(new DataColumn(xInfo.Name, xInfo.PropertyType));
            }

            foreach (T t in xList)
            {
                DataRow xRec = xDataTable.NewRow();

                foreach (PropertyInfo xInfo in typeof(T).GetProperties())
                {
                    xRec[xInfo.Name] = xInfo.GetValue(t, null);
                }

                xDataTable.Rows.Add(xRec);
            }
            return xDataTable;
        }

        public static string DataTableToJson(DataTable xDT)
        {
            DataSet xDataSet = new DataSet();
            xDataSet.Merge(xDT);

            StringBuilder JsonString = new StringBuilder();

            if (xDataSet != null && xDataSet.Tables[0].Rows.Count > 0)
            {
                JsonString.Append("[");
                for (int i = 0; i < xDataSet.Tables[0].Rows.Count; i++)
                {
                    JsonString.Append("{");
                    for (int i2 = 0; i2 < xDataSet.Tables[0].Columns.Count; i2++)
                    {
                        if (i2 < xDataSet.Tables[0].Columns.Count - 1)
                        {
                            JsonString.Append("\"" + xDataSet.Tables[0].Columns[i2].ColumnName.ToString() + "\":" + "\"" + xDataSet.Tables[0].Rows[i][i2].ToString() + "\",");
                        }
                        else if (i2 == xDataSet.Tables[0].Columns.Count - 1)
                        {
                            JsonString.Append("\"" + xDataSet.Tables[0].Columns[i2].ColumnName.ToString() + "\":" + "\"" + xDataSet.Tables[0].Rows[i][i2].ToString() + "\"");
                        }
                    }

                    if (i == xDataSet.Tables[0].Rows.Count - 1)
                    {
                        JsonString.Append("}");
                    }
                    else
                    {
                        JsonString.Append("},");
                    }
                }

                JsonString.Append("]");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
