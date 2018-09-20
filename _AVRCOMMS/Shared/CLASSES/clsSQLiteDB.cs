using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shared.CLASSES
{
    public static class clsSQLiteDB
    {
        public static string zDBPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), clsGlobal.gDBSubFolderName);
        public static string zDBName = clsGlobal.gDBName;
        public static string zDBPathAndFileName = Path.Combine(zDBPath, zDBName);
        public static SQLiteConnection zConn = null;

        public static bool CheckIfDBExist(int xClientOrServer, bool xReplaceExistingDB)
        {
            try
            {
                if (xClientOrServer == 1)
                {
                    zDBPath = Path.Combine(Path.GetDirectoryName(@"C:\wsServer\"), clsGlobal.gDBSubFolderName);
                    zDBPathAndFileName = Path.Combine(zDBPath, zDBName);
                }

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
            catch (Exception Ex)
            {
                clsSE.WriteLog(1, Ex.Message, "clsSQLiteDB", "CheckIfDBExist");
                return false;
            }
        }

        public static bool CreateDB(int xClientOrServer)
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

                if (xClientOrServer == 0)
                {
                    SQL =
                    @"
                    CREATE TABLE tblLog (
                        ID      INTEGER       PRIMARY KEY AUTOINCREMENT
                                              NOT NULL,
                        DT      VARCHAR (30)  NOT NULL,
                        Type    INT           NOT NULL,
                        Form    VARCHAR (200) NOT NULL,
                        Method  VARCHAR (200) NOT NULL,
                        Message VARCHAR (250) NOT NULL
                    );
                    ";
                    MyCommand = new SQLiteCommand(SQL, zConn);
                    MyCommand.ExecuteNonQuery();

                    SQL =
                    @"
                    CREATE TABLE tblServerConnection (
                        ID        INTEGER       PRIMARY KEY AUTOINCREMENT
                                                NOT NULL,
                        ConnectTo VARCHAR (250) NOT NULL
                    );
                    ";
                    MyCommand = new SQLiteCommand(SQL, zConn);
                    MyCommand.ExecuteNonQuery();

                    SQL =
                    @"
                    CREATE TABLE tblClientDetail (
                        ID   INTEGER      PRIMARY KEY AUTOINCREMENT
                                          NOT NULL,
                        Name VARCHAR (250) NOT NULL
                    );
                    ";
                    MyCommand = new SQLiteCommand(SQL, zConn);
                    MyCommand.ExecuteNonQuery();


                    List<string> fFields = new List<string>();
                    List<string> vValues = new List<string>();

                    //tblServerConnection
                    fFields.Add("ConnectTo");
                    vValues.Add("41.180.72.26");
                    clsSE.sqliteInsertRec("tblServerConnection", fFields, vValues);

                    //tblClientDetail
                    Guid id = Guid.NewGuid();
                    fFields = new List<string>();
                    vValues = new List<string>();

                    fFields.Add("Name");
                    vValues.Add(id.ToString());
                    clsSE.sqliteInsertRec("tblClientDetail", fFields, vValues);
                }
                else
                {
                    SQL =
                    @"
                    CREATE TABLE tblLog (
                        ID      INTEGER       PRIMARY KEY AUTOINCREMENT
                                              NOT NULL,
                        DT      VARCHAR (30)  NOT NULL,
                        Type    INT           NOT NULL,
                        Form    VARCHAR (200) NOT NULL,
                        Method  VARCHAR (200) NOT NULL,
                        Message VARCHAR (250) NOT NULL
                    );
                    ";
                    MyCommand = new SQLiteCommand(SQL, zConn);
                    MyCommand.ExecuteNonQuery();

                    SQL =
                    @"
                    CREATE TABLE tblServerDetail (
                        ID   INTEGER      PRIMARY KEY AUTOINCREMENT
                                          NOT NULL,
                        Name VARCHAR (250) NOT NULL
                    );
                    ";
                    MyCommand = new SQLiteCommand(SQL, zConn);
                    MyCommand.ExecuteNonQuery();

                    List<string> fFields = new List<string>();
                    List<string> vValues = new List<string>();

                    //tblServerDetail
                    Guid id = Guid.NewGuid();
                    fFields = new List<string>();
                    vValues = new List<string>();

                    fFields.Add("Name");
                    vValues.Add(id.ToString());
                    clsSE.sqliteInsertRec("tblServerDetail", fFields, vValues);
                }

                return true;
            }
            catch (Exception Ex)
            {
                clsSE.WriteLog(1, Ex.Message, "clsSQLiteDB", "CreateDB");
                return false;
            }
        }
    }
}
