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
    public class tblGroup
    {
        public Int64 ID { get; set; }
        public Int64 CompanyID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime FirstEntryDateTime { get; set; }
        public DateTime LastEntryDateTime { get; set; }
        public int Age { get; set; }
        public int PlantCount { get; set; }
        public DataTable dtGroup { get; set; }
        public IEnumerable<tblGroup> ieGroup { get; set; }

        public void LoadData()
        {
            string SQL = "";

            SQL =
                @"
                SELECT 
                  g.ID,
                  g.CompanyID,
                  g.Code,
                  g.Description,
                  g.CreatedDateTime,
  
                  --Get Age
                  (SELECT MIN(ph.EventDateTime) FROM tblPlantHistory ph WHERE ph.PlantID IN 
                    (SELECT p.ID FROM tblPlant p WHERE p.GroupID = g.ID)
                  ) AS FirstEntryDateTime,
  
                  (SELECT MAX(ph.EventDateTime) FROM tblPlantHistory ph WHERE ph.PlantID IN 
                    (SELECT p.ID FROM tblPlant p WHERE p.GroupID = g.ID)
                  ) AS LastEntryDateTime,
 
                (SELECT DATEDIFF(DAY, MIN(ph.EventDateTime), MAX(ph.EventDateTime)) FROM tblPlantHistory ph WHERE ph.PlantID IN 
                    (SELECT p.ID FROM tblPlant p WHERE p.GroupID = g.ID)
                  ) AS Age,
  
                  (SELECT COUNT(*) FROM tblPlant p WHERE p.GroupID = g.ID) AS PlantCount
                FROM
                  dbo.tblGroup g
                ";

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
