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
                "CREATE TABLE [tblAccount] (" + Environment.NewLine +
                "  [ID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," + Environment.NewLine +
                "  [Name] varchar(50) NOT NULL," + Environment.NewLine +
                "  [IO] varchar(1) NOT NULL," + Environment.NewLine +
                "  CONSTRAINT [tblAccount_uq] UNIQUE ([Name], [IO])" + Environment.NewLine +
                ");";
                MyCommand = new SQLiteCommand(SQL, zConn);
                MyCommand.ExecuteNonQuery();


                SQL =
                "CREATE TABLE [tblItem] (" + Environment.NewLine +
                "  [ID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," + Environment.NewLine +
                "  [Item] varchar(200) NOT NULL," + Environment.NewLine +
                "  CONSTRAINT [tblItem_uq] UNIQUE ([Item])" + Environment.NewLine +
                ");";
                MyCommand = new SQLiteCommand(SQL, zConn);
                MyCommand.ExecuteNonQuery();

                SQL =
                "CREATE TABLE [tblItemAccount] (" + Environment.NewLine +
                "  [ID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," + Environment.NewLine +
                "  [tblItemID] INTEGER NOT NULL REFERENCES tblItem(ID) ON DELETE RESTRICT ON UPDATE RESTRICT," + Environment.NewLine +
                "  [tblAccountID] INTEGER NOT NULL REFERENCES tblAccount(ID) ON DELETE RESTRICT ON UPDATE RESTRICT" + Environment.NewLine +
                ");";
                MyCommand = new SQLiteCommand(SQL, zConn);
                MyCommand.ExecuteNonQuery();

                SQL =
                "CREATE UNIQUE INDEX [tblItemAccount_uq] ON [tblItemAccount]" + Environment.NewLine +
                "  ([tblItemID], [tblAccountID]);";
                MyCommand = new SQLiteCommand(SQL, zConn);
                MyCommand.ExecuteNonQuery();

                SQL =
                "CREATE TABLE [tblItemAccountTransaction] (" + Environment.NewLine +
                "  [ID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," + Environment.NewLine +
                "  [tblItemAccountID] INTEGER NOT NULL REFERENCES tblItemAccount(ID) ON DELETE RESTRICT ON UPDATE RESTRICT," + Environment.NewLine +
                "  [DT] DATE NOT NULL," + Environment.NewLine +
                "  [Reference] varchar(10) NULL," + Environment.NewLine +
                "  [Description] varchar(200) NOT NULL," + Environment.NewLine +
                "  [Amount] money NOT NULL" + Environment.NewLine +
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
