using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Try1.CLASSES;

namespace Try1.DATA
{
    public class tblInstagramUser
    {
        public DataTable dtInstagramUser { get; set; }

        public tblInstagramUser()
        {
            string SQL = "";

            try
            {
                SQL =
                "SELECT *" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblUser";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, clsSQLiteDB.zConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtInstagramUser = new DataTable();
                dtInstagramUser.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();
            }
            catch (Exception Ex)
            {
                //XtraMessageBox.Show("tblAccount: " + Ex.Message);
            }
        }

    }
}
