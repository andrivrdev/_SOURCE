using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QBook.Data
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

                SqlCommand MyCommand = new SqlCommand(SQL, clsHelper.zConn);
                SqlDataReader MyReader = MyCommand.ExecuteReader();

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
