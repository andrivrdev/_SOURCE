using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBook.Data
{
    public class tblPropertyAccount
    {
        public DataTable dtPropertyAccount { get; set; }
        public DataTable dtPropertyAccountMoneyIn { get; set; }
        public DataTable dtPropertyAccountMoneyOut { get; set; }

        public tblPropertyAccount()
        {
            string SQL = "";

            try
            {
                SQL =
                "SELECT " + Environment.NewLine +
                "  dbo.tblPropertyAccount.ID," + Environment.NewLine +
                "  dbo.tblPropertyAccount.tblPropertyID," + Environment.NewLine +
                "  dbo.tblPropertyAccount.tblAccountID," + Environment.NewLine +
                "  dbo.tblProperty.Property," + Environment.NewLine +
                "  dbo.tblAccount.Name," + Environment.NewLine +
                "  dbo.tblAccount.IO" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  dbo.tblPropertyAccount" + Environment.NewLine +
                "  LEFT OUTER JOIN dbo.tblProperty ON(dbo.tblPropertyAccount.tblPropertyID = dbo.tblProperty.ID)" + Environment.NewLine +
                "  LEFT OUTER JOIN dbo.tblAccount ON(dbo.tblPropertyAccount.tblAccountID = dbo.tblAccount.ID)";

                SqlCommand MyCommand = new SqlCommand(SQL, clsHelper.zConn);
                SqlDataReader MyReader = MyCommand.ExecuteReader();

                dtPropertyAccount = new DataTable();
                dtPropertyAccount.Load(MyReader);

                SQL =
                "SELECT " + Environment.NewLine +
                "  dbo.tblPropertyAccount.ID," + Environment.NewLine +
                "  dbo.tblPropertyAccount.tblPropertyID," + Environment.NewLine +
                "  dbo.tblPropertyAccount.tblAccountID," + Environment.NewLine +
                "  dbo.tblProperty.Property," + Environment.NewLine +
                "  dbo.tblAccount.Name," + Environment.NewLine +
                "  dbo.tblAccount.IO" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  dbo.tblPropertyAccount" + Environment.NewLine +
                "  LEFT OUTER JOIN dbo.tblProperty ON(dbo.tblPropertyAccount.tblPropertyID = dbo.tblProperty.ID)" + Environment.NewLine +
                "  LEFT OUTER JOIN dbo.tblAccount ON(dbo.tblPropertyAccount.tblAccountID = dbo.tblAccount.ID)" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  dbo.tblAccount.IO = 'I'";

                MyCommand = new SqlCommand(SQL, clsHelper.zConn);
                MyReader = MyCommand.ExecuteReader();

                dtPropertyAccountMoneyIn = new DataTable();
                dtPropertyAccountMoneyIn.Load(MyReader);

                SQL =
                "SELECT " + Environment.NewLine +
                "  dbo.tblPropertyAccount.ID," + Environment.NewLine +
                "  dbo.tblPropertyAccount.tblPropertyID," + Environment.NewLine +
                "  dbo.tblPropertyAccount.tblAccountID," + Environment.NewLine +
                "  dbo.tblProperty.Property," + Environment.NewLine +
                "  dbo.tblAccount.Name," + Environment.NewLine +
                "  dbo.tblAccount.IO" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  dbo.tblPropertyAccount" + Environment.NewLine +
                "  LEFT OUTER JOIN dbo.tblProperty ON(dbo.tblPropertyAccount.tblPropertyID = dbo.tblProperty.ID)" + Environment.NewLine +
                "  LEFT OUTER JOIN dbo.tblAccount ON(dbo.tblPropertyAccount.tblAccountID = dbo.tblAccount.ID)" + Environment.NewLine +
                "WHERE" + Environment.NewLine +
                "  dbo.tblAccount.IO = 'O'";

                MyCommand = new SqlCommand(SQL, clsHelper.zConn);
                MyReader = MyCommand.ExecuteReader();

                dtPropertyAccountMoneyOut = new DataTable();
                dtPropertyAccountMoneyOut.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("tblPropertyAccount: " + Ex.Message);
            }
        }
    }
}
