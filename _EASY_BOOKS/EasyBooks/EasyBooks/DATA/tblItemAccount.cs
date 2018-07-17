using DevExpress.XtraEditors;
using EasyBooks.CLASSES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBooks.DATA
{
    public class tblItemAccount
    {
        public DataTable dtItemAccount { get; set; }
        public DataTable dtItemAccountMoneyIn { get; set; }
        public DataTable dtItemAccountMoneyOut { get; set; }

        public tblItemAccount()
        {
            string SQL = "";

            try
            {
                SQL =
                "SELECT " + Environment.NewLine +
                "  tblItemAccount.ID," + Environment.NewLine +
                "  tblItemAccount.tblItemID," + Environment.NewLine +
                "  tblItemAccount.tblAccountID," + Environment.NewLine +
                "  tblItem.Item," + Environment.NewLine +
                "  tblAccount.Name," + Environment.NewLine +
                "  tblAccount.IO" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblItemAccount" + Environment.NewLine +
                "  LEFT OUTER JOIN tblItem ON(tblItemAccount.tblItemID = tblItem.ID)" + Environment.NewLine +
                "  LEFT OUTER JOIN tblAccount ON(tblItemAccount.tblAccountID = tblAccount.ID)";

                SQLiteCommand MyCommand = new SQLiteCommand(SQL, clsSQLiteDB.zConn);
                SQLiteDataReader MyReader = MyCommand.ExecuteReader();

                dtItemAccount = new DataTable();
                dtItemAccount.Load(MyReader);

                SQL =
                "SELECT " + Environment.NewLine +
                "  tblItemAccount.ID," + Environment.NewLine +
                "  tblItemAccount.tblItemID," + Environment.NewLine +
                "  tblItemAccount.tblAccountID," + Environment.NewLine +
                "  tblItem.Item," + Environment.NewLine +
                "  tblAccount.Name," + Environment.NewLine +
                "  tblAccount.IO" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblItemAccount" + Environment.NewLine +
                "  LEFT OUTER JOIN tblItem ON(tblItemAccount.tblItemID = tblItem.ID)" + Environment.NewLine +
                "  LEFT OUTER JOIN tblAccount ON(tblItemAccount.tblAccountID = tblAccount.ID)" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  tblAccount.IO = 'I'";

                MyCommand = new SQLiteCommand(SQL, clsSQLiteDB.zConn);
                MyReader = MyCommand.ExecuteReader();

                dtItemAccountMoneyIn = new DataTable();
                dtItemAccountMoneyIn.Load(MyReader);

                SQL =
                "SELECT " + Environment.NewLine +
                "  tblItemAccount.ID," + Environment.NewLine +
                "  tblItemAccount.tblItemID," + Environment.NewLine +
                "  tblItemAccount.tblAccountID," + Environment.NewLine +
                "  tblItem.Item," + Environment.NewLine +
                "  tblAccount.Name," + Environment.NewLine +
                "  tblAccount.IO" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblItemAccount" + Environment.NewLine +
                "  LEFT OUTER JOIN tblItem ON(tblItemAccount.tblItemID = tblItem.ID)" + Environment.NewLine +
                "  LEFT OUTER JOIN tblAccount ON(tblItemAccount.tblAccountID = tblAccount.ID)" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  tblAccount.IO = 'O'";

                MyCommand = new SQLiteCommand(SQL, clsSQLiteDB.zConn);
                MyReader = MyCommand.ExecuteReader();

                dtItemAccountMoneyOut = new DataTable();
                dtItemAccountMoneyOut.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("tblItemAccount: " + Ex.Message);
            }
        }
    }
}
