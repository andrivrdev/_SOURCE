using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for tblRegisterAPI
/// </summary>
public class tblRegisterAPI
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Alias { get; set; }
    public string Password { get; set; }
    public int EmailVerified { get; set; }
    public DataTable dtRegisterAPI { get; set; }
    public IEnumerable<tblRegisterAPI> ieRegisterAPI { get; set; }

    public void LoadData()
    {
        try
        {
            string SQL = "";

            SQL =
                @"
                SELECT 
                  dbo.tblRegisterAPI.Id,
                  dbo.tblRegisterAPI.Email,
                  dbo.tblRegisterAPI.Alias,
                  dbo.tblRegisterAPI.Password,
                  dbo.tblRegisterAPI.EmailVerified
                FROM
                  dbo.tblRegisterAPI
                ";

            List<tblRegisterAPI> xRegisterAPIs = new List<tblRegisterAPI>();
            SQLiteCommand MyCommand = new SQLiteCommand(SQL, clsSQLiteDBAPI.zConn);

            SQLiteDataReader MyReader = MyCommand.ExecuteReader();

            dtRegisterAPI = new DataTable();
            dtRegisterAPI.Load(MyReader);

            foreach (DataRow dr in dtRegisterAPI.Rows)
            {
                tblRegisterAPI xtblRegisterAPI = new tblRegisterAPI();
                xtblRegisterAPI.Id = Convert.ToInt32(dr["ID"]);
                xtblRegisterAPI.Email = dr["Email"].ToString();
                xtblRegisterAPI.Alias = dr["Alias"].ToString();
                xtblRegisterAPI.Password = dr["Password"].ToString();
                xtblRegisterAPI.EmailVerified = Convert.ToInt32(dr["EmailVerified"]);

                xRegisterAPIs.Add(xtblRegisterAPI);
            }

            ieRegisterAPI = xRegisterAPIs;

        }
        catch (Exception Ex)
        {
            clsSEAPI xclsSE = new clsSEAPI();
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
                  dbo.tblRegisterAPI.Id
                FROM
                  dbo.tblRegisterAPI
                WHERE
                  dbo.tblRegisterAPI.Email = '" + xEmail + "'";


            SQLiteCommand MyCommand = new SQLiteCommand(SQL, clsSQLiteDBAPI.zConn);

            SQLiteDataReader MyReader = MyCommand.ExecuteReader();

            return MyReader.HasRows;

        }
        catch (Exception Ex)
        {
            clsSEAPI xclsSE = new clsSEAPI();
            xclsSE.DoError(Ex);
            throw new Exception(Ex.Message);
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

            if (clsSQLiteDBAPI.InsertRec("tblRegisterAPI", fFields, vValues))
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
            clsSEAPI xclsSE = new clsSEAPI();
            xclsSE.DoError(Ex);
            return false;
        }
    }

}