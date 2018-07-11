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
    public class tblProperty
    {
        public DataTable dtProperty { get; set; }

        public tblProperty()
        {
            string SQL = "";

            try
            {
                SqlConnection MyConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

                MyConn.Open();

                SQL =
                "SELECT " + Environment.NewLine +
                "  tblProperty.ID," + Environment.NewLine +
                "  tblProperty.Property" + Environment.NewLine +
                "FROM" + Environment.NewLine +
                "  tblProperty";

                SqlCommand MyCommand = new SqlCommand(SQL, MyConn);
                SqlDataReader MyReader = MyCommand.ExecuteReader();

                dtProperty = new DataTable();
                dtProperty.Load(MyReader);

                MyCommand.Dispose();
                MyReader.Dispose();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("tblProperty: " + Ex.Message);
            }
        }
    }
}
