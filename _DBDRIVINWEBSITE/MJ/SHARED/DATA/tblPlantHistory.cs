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
    public class tblPlantHistory
    {
        public Int64 ID { get; set; }
        public Int64 PlantID { get; set; }
        public Int64 EventID { get; set; }
        public byte[] Data { get; set; }
        public DateTime EventDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public DataTable dtPlantHistory { get; set; }
        public IEnumerable<tblPlantHistory> iePlantHistory { get; set; }

        public void LoadData()
        {
            string SQL = "";

            SQL =
                @"
                SELECT 
                  dbo.tblPlantHistory.ID,
                  dbo.tblPlantHistory.PlantID,
                  dbo.tblPlantHistory.EventID,
                  dbo.tblPlantHistory.Data,
                  dbo.tblPlantHistory.EventDateTime,
                  dbo.tblPlantHistory.CreatedDateTime
                FROM
                  dbo.tblPlantHistory                ";

            List<tblGroup> xGroup = new List<tblGroup>();

            using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
            {
                SqlCommand MyCommand = new SqlCommand(SQL, con);

                con.Open();
                SqlDataReader MyReader = MyCommand.ExecuteReader();

                dtGroup = new DataTable();
                dtGroup.Load(MyReader);

                foreach (DataRow dr in dtGroup.Rows)
                {
                    tblGroup xtblGroup = new tblGroup();
                    xtblGroup.ID = Convert.ToInt64(dr["ID"]);
                    xtblGroup.CompanyID = Convert.ToInt64(dr["CompanyID"]);
                    xtblGroup.Code = dr["Code"].ToString();
                    xtblGroup.Description = dr["Description"].ToString();
                    xtblGroup.CreatedDateTime = Convert.ToDateTime(dr["CreatedDateTime"]);

                    if (dr["FirstEntryDateTime"] != DBNull.Value)
                    {
                        xtblGroup.FirstEntryDateTime = Convert.ToDateTime(dr["FirstEntryDateTime"]);

                    }

                    if (dr["LastEntryDateTime"] != DBNull.Value)
                    {
                        xtblGroup.LastEntryDateTime = Convert.ToDateTime(dr["LastEntryDateTime"]);

                    }

                    if (dr["Age"] != DBNull.Value)
                    {
                        xtblGroup.Age = Convert.ToInt32(dr["Age"]);

                    }

                    xtblGroup.PlantCount = Convert.ToInt32(dr["PlantCount"]);

                    xGroup.Add(xtblGroup);
                }

                ieGroup = xGroup;
            }
        }

        public void AddRec(int xCompanyID, string xCode, string xDescription, DateTime? xCreatedDateTime)
        {
            List<string> fFields = new List<string>();
            List<string> vValues = new List<string>();

            fFields.Add("CompanyID");
            fFields.Add("Code");
            fFields.Add("Description");

            if (xCreatedDateTime == null)
            {
                vValues.Add(xCompanyID.ToString());
                vValues.Add(xCode.ToString());
                vValues.Add(xDescription.ToString());
            }
            else
            {
                fFields.Add("CreatedDateTime");

                vValues.Add(xCompanyID.ToString());
                vValues.Add(xCode.ToString());
                vValues.Add(xDescription.ToString());
                vValues.Add(xCreatedDateTime.ToString());
            }

            clsSE xclsSE = new clsSE();
            xclsSE.sqlInsertRec("tblGroup", fFields, vValues);
        }

        public void UpdateRec(int xID, int xCompanyID, string xCode, string xDescription, DateTime? xCreatedDateTime)
        {
            List<string> fFields = new List<string>();
            List<string> vValues = new List<string>();

            fFields.Add("CompanyID");
            fFields.Add("Code");
            fFields.Add("Description");

            if (xCreatedDateTime == null)
            {
                vValues.Add(xCompanyID.ToString());
                vValues.Add(xCode.ToString());
                vValues.Add(xDescription.ToString());
            }
            else
            {
                fFields.Add("CreatedDateTime");

                vValues.Add(xCompanyID.ToString());
                vValues.Add(xCode.ToString());
                vValues.Add(xDescription.ToString());
                vValues.Add(xCreatedDateTime.ToString());
            }

            clsSE xclsSE = new clsSE();
            xclsSE.sqlUpdateRec("tblGroup", fFields, vValues, "[ID] = '" + xID + "'");
        }
    }
}
