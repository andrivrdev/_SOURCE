using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SocialRankAPI.SHARED
{
    public static class clsSQLiteDBAPI
    {
        public static string zDBPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), clsGlobalAPI.gDBSubFolderName);
        public static string zDBName = clsGlobalAPI.gDBName;
        public static string zDBPathAndFileName = Path.Combine(zDBPath, zDBName);
        public static SqliteConnection zConn = null;

        public static string CreateDB()
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

                MyCommand = new SqliteCommand(SQL, zConn);
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

                MyCommand = new SqliteCommand(SQL, zConn);
                MyCommand.ExecuteNonQuery();

                return "Success";
            }
            catch (Exception Ex)
            {
                return "Failed: " + Ex.Message;
            }
        
        }
    }
}
