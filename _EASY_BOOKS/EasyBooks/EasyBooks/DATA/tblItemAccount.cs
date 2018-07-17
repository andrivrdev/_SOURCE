using DevExpress.XtraEditors;
using EasyBooks.CLASSES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                "  dbo.tblItemAccount.ID," + Environment.NewLine +
                "  dbo.tblItemAccount.tblItemID," + Environment.NewLine +
                "  dbo.tblItemAccount.tblAccountID," + Environment.NewLine +
                "  dbo.tblItem.Item," + Environment.NewLine +
                "  dbo.tblAccount.Name," + Environment.NewLine +
                "  dbo.tblAccount.IO" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  dbo.tblItemAccount" + Environment.NewLine +
                "  LEFT OUTER JOIN dbo.tblItem ON(dbo.tblItemAccount.tblItemID = dbo.tblItem.ID)" + Environment.NewLine +
                "  LEFT OUTER JOIN dbo.tblAccount ON(dbo.tblItemAccount.tblAccountID = dbo.tblAccount.ID)";

                SqlCommand MyCommand = new SqlCommand(SQL, clsHelper.zConn);
                SqlDataReader MyReader = MyCommand.ExecuteReader();

                dtItemAccount = new DataTable();
                dtItemAccount.Load(MyReader);

                SQL =
                "SELECT " + Environment.NewLine +
                "  dbo.tblItemAccount.ID," + Environment.NewLine +
                "  dbo.tblItemAccount.tblItemID," + Environment.NewLine +
                "  dbo.tblItemAccount.tblAccountID," + Environment.NewLine +
                "  dbo.tblItem.Item," + Environment.NewLine +
                "  dbo.tblAccount.Name," + Environment.NewLine +
                "  dbo.tblAccount.IO" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  dbo.tblItemAccount" + Environment.NewLine +
                "  LEFT OUTER JOIN dbo.tblItem ON(dbo.tblItemAccount.tblItemID = dbo.tblItem.ID)" + Environment.NewLine +
                "  LEFT OUTER JOIN dbo.tblAccount ON(dbo.tblItemAccount.tblAccountID = dbo.tblAccount.ID)" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  dbo.tblAccount.IO = 'I'";

                MyCommand = new SqlCommand(SQL, clsHelper.zConn);
                MyReader = MyCommand.ExecuteReader();

                dtItemAccountMoneyIn = new DataTable();
                dtItemAccountMoneyIn.Load(MyReader);

                SQL =
                "SELECT " + Environment.NewLine +
                "  dbo.tblItemAccount.ID," + Environment.NewLine +
                "  dbo.tblItemAccount.tblItemID," + Environment.NewLine +
                "  dbo.tblItemAccount.tblAccountID," + Environment.NewLine +
                "  dbo.tblItem.Item," + Environment.NewLine +
                "  dbo.tblAccount.Name," + Environment.NewLine +
                "  dbo.tblAccount.IO" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  dbo.tblItemAccount" + Environment.NewLine +
                "  LEFT OUTER JOIN dbo.tblItem ON(dbo.tblItemAccount.tblItemID = dbo.tblItem.ID)" + Environment.NewLine +
                "  LEFT OUTER JOIN dbo.tblAccount ON(dbo.tblItemAccount.tblAccountID = dbo.tblAccount.ID)" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  dbo.tblAccount.IO = 'O'";

                MyCommand = new SqlCommand(SQL, clsHelper.zConn);
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
