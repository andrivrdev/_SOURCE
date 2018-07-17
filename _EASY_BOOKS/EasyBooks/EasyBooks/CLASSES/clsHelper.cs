using DevExpress.XtraEditors;
using EasyBooks.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyBooks.CLASSES
{
    public static class clsHelper
    {
        public static bool InsertRec(string xTableName, List<string> xFields, List<string> xValues)
        {
            string SQL = "";

            try
            {
                //Build SQL
                SQL =
                "INSERT INTO [" + xTableName + "]" + Environment.NewLine +
                "(" + Environment.NewLine;

                //Fields
                for (int i = 0; i < xFields.Count; i++)
                {
                    SQL += "[" + xFields[i] + "]";

                    if (i + 1 != xFields.Count)
                    {
                        SQL += ",";
                    }

                    SQL += Environment.NewLine;
                }

                SQL +=
                    ")" + Environment.NewLine +
                    "values" + Environment.NewLine +
                    "(" + Environment.NewLine;

                //Values
                for (int i = 0; i < xValues.Count; i++)
                {
                    //If the value start with || then dont put the value in quotes

                    string tmpSQL = "";
                    if (xValues[i].Contains("'"))
                    {
                        tmpSQL = "'" + xValues[i].Replace("'", "''") + "'";
                    }
                    else
                    {
                        tmpSQL = "'" + xValues[i] + "'";
                    }

                    if (xValues[i].Length > 2)
                    {
                        if (xValues[i].Substring(0, 2) == "||")
                        {
                            xValues[i] = xValues[i].Substring(2);
                            tmpSQL = xValues[i];
                        }
                    }

                    SQL += tmpSQL;

                    if (i + 1 != xFields.Count)
                    {
                        SQL += ",";
                    }

                    SQL += Environment.NewLine;
                }

                SQL += ")";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, clsSQLiteDB.zConn);
                MyCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("clsHelper: " + Ex.Message);
                return false;
            }
        }

        public static bool UpdateRec(string xTableName, List<string> xFields, List<string> xValues, string xWhere)
        {
            try
            {
                string SQL = "";

                //Build SQL
                SQL =
                "UPDATE [" + xTableName + "]" + Environment.NewLine +
                "SET" + Environment.NewLine;

                for (int i = 0; i < xFields.Count; i++)
                {
                    //Fix '
                    if (xValues[i].Contains("'"))
                    {
                        xValues[i] = xValues[i].Replace("'", "''");
                    }

                    //If the value start with || then dont put the value in quotes
                    string tmpSQL = "[" + xFields[i] + "] = '" + xValues[i] + "'";
                    if (xValues[i].Length > 2)
                    {
                        if (xValues[i].Substring(0, 2) == "||")
                        {
                            xValues[i] = xValues[i].Substring(2);

                            tmpSQL = "[" + xFields[i] + "] = " + xValues[i];
                        }
                    }

                    SQL += tmpSQL;
                    if (i + 1 != xFields.Count)
                    {
                        SQL += ",";
                    }

                    SQL += Environment.NewLine;
                }

                if (xWhere.Length > 0)
                {
                    SQL +=
                        "WHERE" + Environment.NewLine + xWhere;
                }

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, clsSQLiteDB.zConn);
                MyCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("clsHelper: " + Ex.Message);
                return false;
            }
        }

        public static bool DeleteRec(string xTableName, string xWhere)
        {
            try
            {
                string SQL = "";

                //Build SQL
                SQL =
                "DELETE FROM [" + xTableName + "]" + Environment.NewLine;

                if (xWhere.Length > 0)
                {
                    SQL += "WHERE" + Environment.NewLine + xWhere;
                }

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, clsSQLiteDB.zConn);
                MyCommand.ExecuteNonQuery();

                return true;
            }
            catch 
            {
                XtraMessageBox.Show("This record has other records linked to it," + Environment.NewLine +
                                    "and can not be removed until the linked records are" + Environment.NewLine +
                                    "removed first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
        }

        public static void DeleteRecByID(string xTableName, Int64 xID)
        {
            try
            {
                DeleteRec(xTableName, "[ID] = '" + xID + "'");
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("clsHelper: " + Ex.Message);
            }
        }

        public static Int64 GetLastRecID(string xTableName)
        {
            string SQL = "";

            try
            {
                SQL =
                "SELECT " + Environment.NewLine +
                "  MAX(" + xTableName + ".ID) AS LastRecID" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  " + xTableName + "";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, clsSQLiteDB.zConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                DataTable dtLastRec = new DataTable();
                dtLastRec.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                return Convert.ToInt64(dtLastRec.Rows[0]["LastRecID"].ToString());
            }
            catch 
            {
                return -1;
            }
        }

        public static Int64 FindAccountID(string xIO, string xAccountName)
        {
            //Find Account ID
            tblAccount xtblAccount = new tblAccount();
            Int64 xAccountID = -1;
            var rows = xtblAccount.dtAccount.AsEnumerable().Where(r => (r.Field<string>("Name") == xAccountName) && (r.Field<string>("IO") == xIO));
            foreach (DataRow ARec in rows)
            {
                xAccountID = Convert.ToInt64(ARec["ID"]);
            }

            return xAccountID;
        }

        public static Int64 FindItemID(string xItem)
        {
            //Find Account ID
            tblItem xtblItem = new tblItem();
            Int64 xID = -1;
            var rows = xtblItem.dtItem.AsEnumerable().Where(r => (r.Field<string>("Item") == xItem));
            foreach (DataRow ARec in rows)
            {
                xID = Convert.ToInt64(ARec["ID"]);
            }

            return xID;
        }

        public static Int64 FindItemAccountID(string xIO, Int64 xItemID, string xAccountName)
        {
            //Find Account ID
            Int64 xAccountID = FindAccountID(xIO, xAccountName);

            //Find Item Account ID
            tblItemAccount xtblItemAccount = new tblItemAccount();
            Int64 xItemAccountID = -1;
            var rows = xtblItemAccount.dtItemAccount.AsEnumerable().Where(r => (r.Field<Int64>("tblItemID") == xItemID) && (r.Field<Int64>("tblAccountID") == xAccountID));
            foreach (DataRow ARec in rows)
            {
                xItemAccountID = Convert.ToInt64(ARec["ID"]);
            }

            return xItemAccountID;
        }

        public static DataTable GetReferencesForMoneyOutTransaction(string xItemID)
        {
            string SQL = "";

            try
            {
                SQL =
                @"
                SELECT DISTINCT
                  tblItemAccountTransaction.Reference
                FROM
                  tblItemAccountTransaction
                  LEFT OUTER JOIN tblItemAccount ON (tblItemAccountTransaction.tblItemAccountID = tblItemAccount.ID)
                  LEFT OUTER JOIN tblAccount ON (tblItemAccount.tblAccountID = tblAccount.ID)
                WHERE
                  tblItemAccount.tblItemID = '" + xItemID + @"' AND
                  tblAccount.IO = 'I'
                ";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, clsSQLiteDB.zConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();

                return dt;
            }
            catch 
            {
                return new DataTable();
            }
        }

    }
}
