using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Try1.CLASSES
{
    public static class clsSQLiteDB
    {
        public static string zDBPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), clsGlobal.gDBSubFolderName);
        public static string zDBName = clsGlobal.gDBName;
        public static string zDBPathAndFileName = Path.Combine(zDBPath, zDBName);
        public static SQLiteConnection zConn = null;

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
                        zConn = new SQLiteConnection(@"Data Source=" + zDBPathAndFileName);
                        zConn.Open();
                        string SQL = "PRAGMA foreign_keys = ON;";
                        SQLiteCommand MyCommand = new SQLiteCommand(SQL, zConn);
                        MyCommand.ExecuteNonQuery();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                throw;
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

                if (!File.Exists(zDBPathAndFileName))
                {
                    SQLiteConnection.CreateFile(zDBPathAndFileName);
                }

                zConn = new SQLiteConnection(@"Data Source=" + zDBPathAndFileName);
                zConn.Open();
                string SQL = "PRAGMA foreign_keys = ON;";
                SQLiteCommand MyCommand = new SQLiteCommand(SQL, zConn);
                MyCommand.ExecuteNonQuery();

                SQL =
                "CREATE TABLE [tblUser] (" + Environment.NewLine +
                "  [ID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," + Environment.NewLine +
                "  [01_BasicDisplayAPI] varchar(2000) NULL," + Environment.NewLine +
                "  [01_Client_id] varchar(2000) NULL," + Environment.NewLine +
                "  [01_Redirect_uri] varchar(2000) NULL," + Environment.NewLine +
                "  [01_URI_GetCode] varchar(2000) NULL," + Environment.NewLine +
                "  [01_URI_ResponseAfterGetCode] varchar(2000) NULL," + Environment.NewLine +

                "  [02_URI_access_token] varchar(2000) NULL," + Environment.NewLine +
                "  [02_Client_secret] varchar(2000) NULL," + Environment.NewLine +
                "  [02_Code] varchar(2000) NULL," + Environment.NewLine +
                "  [02_S_access_token] varchar(2000) NULL," + Environment.NewLine +
                "  [02_S_user_id] varchar(2000) NULL," + Environment.NewLine +

                "  [03_URI_long_access_token] varchar(2000) NULL," + Environment.NewLine +
                "  [03_L_access_token] varchar(2000) NULL," + Environment.NewLine +
                "  [03_L_token_type] varchar(2000) NULL," + Environment.NewLine +
                "  [03_L_expires_in] varchar(2000) NULL" + Environment.NewLine +
                ");";

                MyCommand = new SQLiteCommand(SQL, zConn);
                MyCommand.ExecuteNonQuery();


                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
