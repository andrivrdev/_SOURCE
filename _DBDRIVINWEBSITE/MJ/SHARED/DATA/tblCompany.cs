using SHARED.CLASSES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARED.DATA
{
    public class tblCompany
    {
        public Int64 ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DataTable dtCompany { get; set; }
        public IEnumerable<tblCompany> ieCompany { get; set; }

        public void LoadData()
        {
            string SQL = "";

            SQL =
                @"
                SELECT
                  dbo.tblCompany.ID,
                  dbo.tblCompany.Name,
                  dbo.tblCompany.Password,
                  dbo.tblCompany.CreatedDateTime
                FROM
                  dbo.tblCompany
                ";

            List<tblCompany> xCompanies = new List<tblCompany>();

            using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
            {
                SqlCommand MyCommand = new SqlCommand(SQL, con);

                con.Open();
                SqlDataReader MyReader = MyCommand.ExecuteReader();

                dtCompany = new DataTable();
                dtCompany.Load(MyReader);

                foreach (DataRow dr in dtCompany.Rows)
                {
                    tblCompany xtblCompany = new tblCompany();
                    xtblCompany.ID = Convert.ToInt64(dr["ID"]);
                    xtblCompany.Name = dr["Name"].ToString();
                    xtblCompany.Password = dr["Password"].ToString();
                    xtblCompany.CreatedDateTime = Convert.ToDateTime(dr["CreatedDateTime"]);

                    xCompanies.Add(xtblCompany);
                }

                ieCompany = xCompanies;
            }
        }
    }
}
