using DevExpress.XtraEditors;
using EasyBooks.CLASSES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyBooks.DATA
{
    public class tblAccount
    {
        public DataTable dtAccount { get; set; } 

        public tblAccount()
        {
            string SQL = "";

            try
            {
                SQL =
                "SELECT " + Environment.NewLine +
                "  tblAccount.ID," + Environment.NewLine +
                "  tblAccount.Name," + Environment.NewLine +
                "  tblAccount.IO" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblAccount";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, clsSQLiteDB.zConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtAccount = new DataTable();
                dtAccount.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("tblAccount: " + Ex.Message);
            }
        }
    }
}
