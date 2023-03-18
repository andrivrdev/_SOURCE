using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialRankAPI.SHARED
{
    public static class sqLiteDBAPI
    {
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
    }
}
