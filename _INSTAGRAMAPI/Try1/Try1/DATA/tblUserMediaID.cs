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
    public class tblUserMediaID
    {
        public DataTable dtUserMediaID { get; set; }

        public tblUserMediaID()
        {
            string SQL = "";

            try
            {
                SQL =
                "SELECT *" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblUserMediaID";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, clsSQLiteDB.zConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtUserMediaID = new DataTable();
                dtUserMediaID.Load(MyReader);

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
