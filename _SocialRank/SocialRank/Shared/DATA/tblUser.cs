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
    public class tblUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Alias { get; set; }
        public string Password { get; set; }
        public int EmailVerified { get; set; }
        public DataTable dtUser { get; set; }
        public IEnumerable<tblUser> ieUser { get; set; }

        public void LoadData()
        {
            try
            {
                string SQL = "";

                SQL =
                    @"
                SELECT 
                  dbo.tblUser.Id,
                  dbo.tblUser.Email,
                  dbo.tblUser.Alias,
                  dbo.tblUser.Password,
                  dbo.tblUser.EmailVerified
                FROM
                  dbo.tblUser
                ";

                List<tblUser> xUsers = new List<tblUser>();

                using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    con.Open();
                    SqlDataReader MyReader = MyCommand.ExecuteReader();

                    dtUser = new DataTable();
                    dtUser.Load(MyReader);

                    foreach (DataRow dr in dtUser.Rows)
                    {
                        tblUser xtblUser = new tblUser();
                        xtblUser.Id = Convert.ToInt32(dr["ID"]);
                        xtblUser.Email = dr["Email"].ToString();
                        xtblUser.Alias = dr["Alias"].ToString();
                        xtblUser.Password = dr["Password"].ToString();
                        xtblUser.EmailVerified = Convert.ToInt32(dr["EmailVerified"]);

                        xUsers.Add(xtblUser);
                    }

                    ieUser = xUsers;
                }
            }
            catch (Exception Ex)
            {
                clsSE xclsSE = new clsSE();
                xclsSE.DoError(Ex);
                throw new Exception(Ex.Message);
            }
        }

        public bool CheckIfEmailExist(string xEmail)
        {
            try
            {
                string SQL = "";

                SQL =
                    @"
                SELECT TOP 1
                  dbo.tblUser.Id
                FROM
                  dbo.tblUser
                WHERE
                  dbo.tblUser.Email = '" + xEmail + "'";

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
                throw new Exception(Ex.Message);
            }

        }

        public int GetId(string xEmail)
        {
            try
            {
                string SQL = "";

                SQL =
                    @"
                SELECT TOP 1
                  dbo.tblUser.Id
                FROM
                  dbo.tblUser
                WHERE
                  dbo.tblUser.Email = '" + xEmail + "'";

                using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    con.Open();
                    SqlDataReader MyReader = MyCommand.ExecuteReader();

                    dtUser = new DataTable();
                    dtUser.Load(MyReader);

                    foreach (DataRow dr in dtUser.Rows)
                    {
                        return Convert.ToInt32(dr["Id"]);
                    }

                    return -1;
                }
            }
            catch (Exception Ex)
            {
                clsSE xclsSE = new clsSE();
                xclsSE.DoError(Ex);
                throw new Exception(Ex.Message);
            }

        }

        public bool CheckIfEmailAndCodeExist(string xEmail, string xCode)
        {
            try
            {
                if (xCode is null)
                {
                    return false;
                }
                else
                {
                    if (Convert.ToInt32(xCode) < 10000)
                    {
                        return false;
                    }
                    else
                    {
                        string SQL = "";

                        SQL =
                            @"
                            SELECT TOP 1
                              dbo.tblUser.Id
                            FROM
                              dbo.tblUser
                            WHERE
                              (dbo.tblUser.ResetPasswordCode = '" + xCode + @"')
                              AND
                              (dbo.tblUser.Email = '" + xEmail + "')";

                        using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
                        {
                            SqlCommand MyCommand = new SqlCommand(SQL, con);

                            con.Open();
                            SqlDataReader MyReader = MyCommand.ExecuteReader();

                            return MyReader.HasRows;
                        }

                    }
                }
            }
            catch (Exception Ex)
            {
                clsSE xclsSE = new clsSE();
                xclsSE.DoError(Ex);
                throw new Exception(Ex.Message);
            }

        }

        public bool CheckIfEmailVerified(string xEmail)
        {
            try
            {
                string SQL = "";

                SQL =
                    @"
                SELECT TOP 1
                  dbo.tblUser.EmailVerified
                FROM
                  dbo.tblUser
                WHERE
                  dbo.tblUser.Email = '" + xEmail + "'";

                using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    con.Open();
                    SqlDataReader MyReader = MyCommand.ExecuteReader();

                    if (!MyReader.HasRows)
                    {
                        return false;
                    }
                    else
                    {
                        dtUser = new DataTable();
                        dtUser.Load(MyReader);

                        if (Convert.ToInt32(dtUser.Rows[0]["EmailVerified"]) == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                }
            }
            catch (Exception Ex)
            {
                clsSE xclsSE = new clsSE();
                xclsSE.DoError(Ex);
                throw new Exception(Ex.Message);
            }
        }

        public bool CheckPassword(string xEmail, string xPassword)
        {
            try
            {
                string SQL = "";

                SQL =
                    @"
                    SELECT TOP 1
                        dbo.tblUser.Id
                    FROM
                        dbo.tblUser
                    WHERE
                        (dbo.tblUser.Password = '" + xPassword + @"')
                        AND
                        (dbo.tblUser.Email = '" + xEmail + "')";

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

        public bool AddRec(string xEmail, string xAlias, string xPassword)
        {
            try
            {
                List<string> fFields = new List<string>();
                List<string> vValues = new List<string>();

                fFields.Add("Email");
                fFields.Add("Alias");
                fFields.Add("Password");

                vValues.Add(xEmail);
                vValues.Add(xAlias);
                vValues.Add(xPassword);

                clsSE xclsSE = new clsSE();

                if (xclsSE.sqlInsertRec("tblUser", fFields, vValues))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                clsSE xclsSE = new clsSE();
                xclsSE.DoError(Ex);
                return false;
            }
        }

        public bool VerifyEmail(string xEmail)
        {
            try
            {
                List<string> fFields = new List<string>();
                List<string> vValues = new List<string>();

                fFields.Add("EmailVerified");

                vValues.Add("1");

                clsSE xclsSE = new clsSE();

                if (xclsSE.sqlUpdateRec("tblUser", fFields, vValues, "[Email] = '" + xEmail + "'"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                clsSE xclsSE = new clsSE();
                xclsSE.DoError(Ex);
                return false;
            }
        }

        public bool UpdatePasswordResetCode(string xEmail, string xCode)
        {
            try
            {
                List<string> fFields = new List<string>();
                List<string> vValues = new List<string>();

                fFields.Add("ResetPasswordCode");

                vValues.Add(xCode);

                clsSE xclsSE = new clsSE();

                if (xclsSE.sqlUpdateRec("tblUser", fFields, vValues, "[Email] = '" + xEmail + "'"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                clsSE xclsSE = new clsSE();
                xclsSE.DoError(Ex);
                return false;
            }
        }

        public bool ResetPassword(string xEmail, string xPassword)
        {
            try
            {
                List<string> fFields = new List<string>();
                List<string> vValues = new List<string>();

                fFields.Add("Password");
                fFields.Add("ResetPasswordCode");

                vValues.Add(xPassword);
                vValues.Add("00000");

                clsSE xclsSE = new clsSE();

                if (xclsSE.sqlUpdateRec("tblUser", fFields, vValues, "[Email] = '" + xEmail + "'"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                clsSE xclsSE = new clsSE();
                xclsSE.DoError(Ex);
                return false;
            }
        }
    }
}
