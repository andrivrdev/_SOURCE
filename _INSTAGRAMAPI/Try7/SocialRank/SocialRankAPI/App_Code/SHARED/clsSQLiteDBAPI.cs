using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

/// <summary>
/// Summary description for clsSQLiteDBAPI
/// </summary>
public static class clsSQLiteDBAPI
{
    public static string zDBPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), clsGlobalAPI.gDBSubFolderName);
    public static string zDBName = clsGlobalAPI.gDBName;
    public static string zDBPathAndFileName = Path.Combine(zDBPath, zDBName);
    public static SQLiteConnection zConn = null;

    public static string CreateDB()
    {
        try
        {
            FileInfo MyFile = new FileInfo(zDBPathAndFileName);

            if (!(Directory.Exists(MyFile.DirectoryName)))
            {
                Directory.CreateDirectory(MyFile.DirectoryName);
            }

            bool xCreateTables = !(MyFile.Exists);

            zConn = new SQLiteConnection(@"Data Source=" + zDBPathAndFileName);
            //SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_winsqlite3());
            zConn.Open();
            string SQL = "PRAGMA foreign_keys = ON;";
            SQLiteCommand MyCommand = new SQLiteCommand(SQL, zConn);
            MyCommand.ExecuteNonQuery();

            if (xCreateTables)
            {
                SQL =
                @"
                    CREATE TABLE tblRegisterAPI (
                    Id INTEGER        PRIMARY KEY AUTOINCREMENT
                                      NOT NULL,
                    [Email]          VARCHAR(500),
                    [Alias]                VARCHAR(50),
                    [Password]             VARCHAR(50),
                    [EmailVerified]              INTEGER  DEFAULT (0), 
                    CreatedDT TIMESTAMP      DEFAULT CURRENT_TIMESTAMP
                                                                 NOT NULL
                    );";

                MyCommand = new SQLiteCommand(SQL, zConn);
                MyCommand.ExecuteNonQuery();

                SQL =
                @"
                    CREATE TABLE tblUser (
                    ID INTEGER        PRIMARY KEY AUTOINCREMENT
                                      NOT NULL,
                    [01_BasicDisplayAPI]          VARCHAR(2000),
                    [01_Client_id]                VARCHAR(2000),
                    [01_Redirect_uri]             VARCHAR(2000),
                    [01_URI_GetCode]              VARCHAR(2000),
                    [01_URI_ResponseAfterGetCode] VARCHAR(2000),
                    [02_URI_access_token]         VARCHAR(2000),
                    [02_Client_secret]            VARCHAR(2000),
                    [02_Code]                     VARCHAR(2000),
                    [02_S_access_token]           VARCHAR(2000),
                    [02_S_user_id]                VARCHAR(2000),
                    [03_URI_long_access_token]    VARCHAR(2000),
                    [03_L_access_token]           VARCHAR(2000),
                    [03_L_token_type]             VARCHAR(2000),
                    [03_L_expires_in]             VARCHAR(2000),
                    [04_username]                 VARCHAR(2000),
                    [04_media_count]              INTEGER,
                    CreatedDT TIMESTAMP      DEFAULT CURRENT_TIMESTAMP
                                                                 NOT NULL
                    );";

                MyCommand = new SQLiteCommand(SQL, zConn);
                MyCommand.ExecuteNonQuery();

                SQL =
                @"
                    CREATE TABLE tblUserMediaID (
                    ID        INTEGER   PRIMARY KEY AUTOINCREMENT
                                        NOT NULL,
                    tblUserID INTEGER   REFERENCES tblUser (ID) ON DELETE CASCADE
                                                                ON UPDATE RESTRICT,
                    MediaID   INTEGER,
                    CreatedDT TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                                        NOT NULL
                    );";

                MyCommand = new SQLiteCommand(SQL, zConn);
                MyCommand.ExecuteNonQuery();
            }

            return "Success";
        }
        catch (Exception Ex)
        {
            return "Failed: " + Ex.Message;
        }

    }

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

            SQLiteCommand MyCommand = new SQLiteCommand(SQL, zConn);
            MyCommand.ExecuteNonQuery();

            return true;
        }
        catch (Exception Ex)
        {
            //XtraMessageBox.Show("clsHelper: " + Ex.Message);
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

            SQLiteCommand MyCommand = new SQLiteCommand(SQL, zConn);
            MyCommand.ExecuteNonQuery();

            return true;
        }
        catch (Exception Ex)
        {
            //XtraMessageBox.Show("clsHelper: " + Ex.Message);
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

            SQLiteCommand MyCommand = new SQLiteCommand(SQL, zConn);
            MyCommand.ExecuteNonQuery();

            return true;
        }
        catch
        {
            //XtraMessageBox.Show("This record has other records linked to it," + Environment.NewLine +
            //                    "and can not be removed until the linked records are" + Environment.NewLine +
            //                    "removed first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            //XtraMessageBox.Show("clsHelper: " + Ex.Message);
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

            SQLiteCommand MyCommand = new SQLiteCommand(SQL, zConn);
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

}