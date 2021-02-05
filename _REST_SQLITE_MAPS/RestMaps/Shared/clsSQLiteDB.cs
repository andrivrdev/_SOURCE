using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Shared
{
    public static class clsSQLiteDB
    {
        public static string zDBPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), clsGlobal.gDBSubFolderName);
        public static string zDBName = clsGlobal.gDBName;
        public static string zDBPathAndFileName = Path.Combine(zDBPath, zDBName);
        public static SqliteConnection zConn = null;

        private static bool ReConnect()
        {
            try
            {
                if (CheckIfDBExist(false))
                {
                    return true;
                }
                else
                {
                    if (CreateDB())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public static bool Connect()
        {
            try
            {
                if (zConn is null)
                {
                    return ReConnect();
                }
                else
                {
                    if (zConn.State == System.Data.ConnectionState.Open)
                    {
                        return true;
                    }
                    else
                    {
                        return ReConnect();
                    }
                }
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public static bool CheckIfDBExist(bool xReplaceExistingDB)
        {
            try
            {
                if (File.Exists(zDBPathAndFileName) && xReplaceExistingDB)
                {
                    File.Delete(zDBPathAndFileName);
                    return false;
                }
                else
                {
                    if (File.Exists(zDBPathAndFileName))
                    {
                        zConn = new SqliteConnection(@"Data Source=" + zDBPathAndFileName);
                        SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_winsqlite3());
                        zConn.Open();
                        string SQL = "PRAGMA foreign_keys = ON;";
                        SqliteCommand MyCommand = new SqliteCommand(SQL, zConn);
                        MyCommand.ExecuteNonQuery();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public static bool CreateDB()
        {
            try
            {
                FileInfo MyFile = new FileInfo(zDBPathAndFileName);

                if (!(Directory.Exists(MyFile.DirectoryName)))
                {
                    Directory.CreateDirectory(MyFile.DirectoryName);
                }



                zConn = new SqliteConnection(@"Data Source=" + zDBPathAndFileName);
                SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_winsqlite3());
                zConn.Open();
                string SQL = "PRAGMA foreign_keys = ON;";
                SqliteCommand MyCommand = new SqliteCommand(SQL, zConn);
                MyCommand.ExecuteNonQuery();


                SQL =
                "CREATE TABLE [tblLocation] (" + Environment.NewLine +
                "  [ID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," + Environment.NewLine +
                "  [DeviceIdiom] VARCHAR(100)," + Environment.NewLine +
                "  [DeviceModel] VARCHAR(100)," + Environment.NewLine +
                "  [DeviceName] VARCHAR(100)," + Environment.NewLine +
                "  [Latitude] DOUBLE," + Environment.NewLine +
                "  [Longitude] DOUBLE," + Environment.NewLine +
                "  [Altitude] DOUBLE," + Environment.NewLine +
                "  [DT] TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL" + Environment.NewLine +
                ");";

                MyCommand = new SqliteCommand(SQL, zConn);
                MyCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public static bool sqlInsertRec(string xTableName, List<string> xFields, List<string> xValues)
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

                SqliteCommand MyCommand = new SqliteCommand(SQL, zConn);

                MyCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

    }
}
