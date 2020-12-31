using CPShared;
using Shared.CLASSES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DATA
{
    public class tblInstagramUser
    {
        public List<string> GetInstagramUserRescs(int xtblUserId)
        {
            try
            {
                string SQL = "";

                SQL =
                    @"
                SELECT *
                  
                FROM
                  dbo.tblInstagramUser
                WHERE
                  dbo.tblInstagramUser.tblUserId = '" + xtblUserId.ToString() + @"'";

                List<tblUser> xUsers = new List<tblUser>();

                using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    con.Open();
                    SqlDataReader MyReader = MyCommand.ExecuteReader();

                    var dtUser = new DataTable();
                    dtUser.Load(MyReader);

                    List<string> xResult = new List<string>();
                    foreach (DataRow dr in dtUser.Rows)
                    {
                        xResult.Add(dr["Id"].ToString());
                    }

                    return xResult;
                }
            }
            catch (Exception Ex)
            {
                clsSE xclsSE = new clsSE();
                xclsSE.DoError(Ex);
                return new List<string>();
            }

        }

        public bool CheckBeforeNewRec(int xtblUserId, string x02_S_user_id)
        {
            try
            {
                string SQL = "";

                SQL =
                    @"
                SELECT *
                  
                FROM
                  dbo.tblInstagramUser
                WHERE
                  (dbo.tblInstagramUser.tblUserId = '" + xtblUserId.ToString() + @"') AND (dbo.tblInstagramUser.02_S_user_id = '" + x02_S_user_id + "')";

                

                using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    con.Open();
                    SqlDataReader MyReader = MyCommand.ExecuteReader();

                    return MyReader.HasRows;
                }
            }
            catch (Exception Ex)
            {
                clsSE xclsSE = new clsSE();
                xclsSE.DoError(Ex);
                return false;
            }

        }

        public string GetLongAccessTokenFromRecId(string xId)
        {
            try
            {
                string SQL = "";

                SQL =
                    @"
                SELECT *
                  
                FROM
                  dbo.tblInstagramUser
                WHERE
                  (dbo.tblInstagramUser.Id = '" + xId + @"')";



                using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    con.Open();
                    SqlDataReader MyReader = MyCommand.ExecuteReader();

                    var dtUser = new DataTable();
                    dtUser.Load(MyReader);

                    foreach (DataRow dr in dtUser.Rows)
                    {
                       return dr["03_L_access_token"].ToString();
                    }
                }
                return "";
            }
            catch (Exception Ex)
            {
                clsSE xclsSE = new clsSE();
                xclsSE.DoError(Ex);
                return "";
            }

        }


    }
}
