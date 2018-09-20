using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Client
{
    /// <summary>
    /// Summary description for ClientWS
    /// </summary>
    [WebService(Namespace = "http://avrcomms/client/api")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ClientWS : System.Web.Services.WebService
    {
        public ClientWS()
        {
            for (int i = 0; i < 10; i++)
            {
                string x = i.ToString();
            }
        }



        [WebMethod]
        public string DoWork(string xData)
        {
            string xHost = ".";
            string xDatabase = "PaySlips";
            string xUsername = "sa";
            string xPassword = "passNEW.m3";

            string xConn = String.Format("Data Source={0}; Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};", xHost, xDatabase, xUsername, xPassword);

            DataTable dtData;

            SqlConnection MyConn = new SqlConnection(xConn);
            MyConn.Open();

            string xSQL =
                    @"
                    SELECT TOP 10
                      dbo.[User].UserID,
                      dbo.[User].Name,
                      dbo.[User].ID,
                      dbo.[User].EntityID,
                      dbo.[User].EmployeeNumber,
                      dbo.[User].TaxNumber,
                      dbo.[User].Cell,
                      dbo.[User].Password,
                      dbo.[User].Inactive
                    FROM
                      dbo.[User]                  
                    ";
            
            string SQL = xSQL;
            
            SqlCommand MyCommand = new SqlCommand(SQL, MyConn);
            SqlDataReader MyReader = MyCommand.ExecuteReader();

            dtData = new DataTable();
            dtData.Load(MyReader);

            MyCommand.Dispose();
            MyReader.Dispose();

            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dtData);

            DataTable dtData2 = new DataTable();
            dtData2 = JsonConvert.DeserializeObject<DataTable>(JSONresult);
           // DataSet dsData2 = JsonConvert.DeserializeObject<DataSet>(JSONresult);

          //  dtData2 = dsData2.Tables["Table1"];


          //  dtData2 = (DataTable)JsonConvert.DeserializeObject(JSONresult);




            return "Hello World";
        }
    }
}
