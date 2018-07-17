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
    public class tblItem
    {
        public DataTable dtItem { get; set; }

        public tblItem()
        {
            string SQL = "";

            try
            {
                SQL =
                "SELECT " + Environment.NewLine +
                "  tblItem.ID," + Environment.NewLine +
                "  tblItem.Item" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblItem";

                SqlCommand MyCommand = new SqlCommand(SQL, clsHelper.zConn);
                SqlDataReader MyReader = MyCommand.ExecuteReader();

                dtItem = new DataTable();
                dtItem.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("tblItem: " + Ex.Message);
            }
        }
    }
}
