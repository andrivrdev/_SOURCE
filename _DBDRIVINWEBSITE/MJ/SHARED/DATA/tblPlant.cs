using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHARED.CLASSES;

namespace SHARED.DATA
{
    public class tblPlant
    {
        public Int64 ID { get; set; }
        public Int64 GroupID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime FirstEntryDateTime { get; set; }
        public DateTime LastEntryDateTime { get; set; }
        public int Age { get; set; }
        public int EventCount { get; set; }
        public string Phase { get; set; }
        public DateTime PhaseDateTime { get; set; }
        public string Medium { get; set; }
        public DateTime MediumDateTime { get; set; }
        public int DailyInspected { get; set; }
        public int DailyWatered { get; set; }
        public string LastNutrient { get; set; }
        public DateTime LastNutrientDateTime { get; set; }
        public string LastChemical { get; set; }
        public DateTime LastChemicalDateTime { get; set; }
        public string LastProblem { get; set; }
        public DateTime LastProblemDateTime { get; set; }
        public byte[] LastPicture { get; set; }
        public DateTime LastPictureDateTime { get; set; }
        public byte[] LastPictureThumbnail { get; set; }
        public string LastEnvironment { get; set; }
        public string LastEnvironmentValue { get; set; }
        public DateTime LastEnvironmentDateTime { get; set; }
        public string OriginatedFrom { get; set; }
        public DateTime OriginatedFromDateTime { get; set; }
        public string Variety { get; set; }
        public DateTime VarietyDateTime { get; set; }
        public string Location { get; set; }
        public DateTime LocationDateTime { get; set; }
        public string LastNote { get; set; }
        public DateTime LastNoteDateTime { get; set; }

        public DataTable dtPlant { get; set; }
        public IEnumerable<tblPlant> iePlant { get; set; }

        public void LoadData()
        {
            string SQL = "";

            SQL =
                @"
                SELECT 
                  p.ID,
                  p.GroupID,
                  p.Name,
                  p.CreatedDateTime,
  
                  (SELECT MIN(ph.EventDateTime) FROM tblPlantHistory ph WHERE ph.PlantID = p.ID
                  ) AS FirstEntryDateTime,
 
                  (SELECT MIN(ph.EventDateTime) FROM tblPlantHistory ph WHERE ph.PlantID = p.ID
                  ) AS LastEntryDateTime,
  
                  (SELECT DATEDIFF(DAY, MIN(ph.EventDateTime), MAX(ph.EventDateTime)) FROM tblPlantHistory ph WHERE ph.PlantID = p.ID
                  ) AS Age,
  
                  (SELECT COUNT(*) FROM tblPlantHistory ph WHERE ph.PlantID = p.ID) AS EventCount,
  
                  -- Current Phase
  
                  (SELECT e.[Name] FROM tblEvent e WHERE e.ID = 
                  (SELECT TOP 1
                    ph.EventID
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID IN  
                  (
                    SELECT 
                      e.ID
                    FROM
                      dbo.tblEvent e
                    WHERE
                      e.EventCategoryID = 1
                  )  
                  ORDER BY
                    ph.EventDateTime DESC)) AS Phase,
    
  
                  (SELECT TOP 1
                    ph.EventDateTime
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID IN  
                  (
                    SELECT 
                      e.ID
                    FROM
                      dbo.tblEvent e
                    WHERE
                      e.EventCategoryID = 1
                  )  
                  ORDER BY
                    ph.EventDateTime DESC) AS PhaseDateTime,    
    
                  --Medium Change  
  
                  (SELECT TOP 1
                    CAST(ph.[Data] AS VARCHAR(200))
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID IN  
                  (
                    SELECT 
                      e.ID
                    FROM
                      dbo.tblEvent e
                    WHERE
                      e.EventCategoryID = 2
                  )  
                  ORDER BY
                    ph.EventDateTime DESC) AS Medium,
    
                (SELECT TOP 1
                    ph.[EventDateTime]
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID IN  
                  (
                    SELECT 
                      e.ID
                    FROM
                      dbo.tblEvent e
                    WHERE
                      e.EventCategoryID = 2
                  )  
                  ORDER BY
                    ph.EventDateTime DESC) AS MediumDateTime,    
  
  
    
                    --Daily
                    
    
                  (SELECT COUNT(*)
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    CAST(ph.EventDateTime AS DATE) = CAST(GETDATE() AS DATE)
                    AND
    
                    ph.PlantID = p.ID
                    AND
                    ph.EventID = 9
                   ) AS DailyInspected,
   
                  (SELECT COUNT(*)
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    CAST(ph.EventDateTime AS DATE) = CAST(GETDATE() AS DATE)
                    AND
    
                    ph.PlantID = p.ID
                    AND
                    ph.EventID = 10
                   ) AS DailyWatered,

                  --Last Nutrient
                  (SELECT TOP 1
                    CAST(ph.[Data] AS VARCHAR(200))
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID = 11   
                  ORDER BY
                    ph.EventDateTime DESC) AS LastNutrient,
    
                  (SELECT TOP 1
                    ph.[EventDateTime]
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID = 11   
                  ORDER BY
                    ph.EventDateTime DESC) AS LastNutrientDateTime,

                     --Last Chemical
  
  
                  (SELECT TOP 1
                    CAST(ph.[Data] AS VARCHAR(200))
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID = 12   
                  ORDER BY
                    ph.EventDateTime DESC) AS LastChemical,
    
                  (SELECT TOP 1
                    ph.[EventDateTime]
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID = 12   
                  ORDER BY
                    ph.EventDateTime DESC) AS LastChemicalDateTime,
    
                  -- Last Problem
  
                  (SELECT e.[Name] FROM tblEvent e WHERE e.ID = 
                  (SELECT TOP 1
                    ph.EventID
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID IN  
                  (
                    SELECT 
                      e.ID
                    FROM
                      dbo.tblEvent e
                    WHERE
                      e.EventCategoryID = 10002
                  )  
                  ORDER BY
                    ph.EventDateTime DESC)) AS LastProblem,
    
  
                  (SELECT TOP 1
                    ph.EventDateTime
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID IN  
                  (
                    SELECT 
                      e.ID
                    FROM
                      dbo.tblEvent e
                    WHERE
                      e.EventCategoryID = 10002
                  )  
                  ORDER BY
                    ph.EventDateTime DESC) AS LastProblemDateTime,
    
	                --Last Picture
  
  
                  (SELECT TOP 1
                    ph.[Data]
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID = 15   
                  ORDER BY
                    ph.EventDateTime DESC) AS LastPicture,
    
                  (SELECT TOP 1
                    ph.[EventDateTime]
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID = 15   
                  ORDER BY
                    ph.EventDateTime DESC) AS LastPictureDateTime,    

                -- Last Environment
  
                  (SELECT e.[Name] FROM tblEvent e WHERE e.ID = 
                  (SELECT TOP 1
                    ph.EventID
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID IN  
                  (
                    SELECT 
                      e.ID
                    FROM
                      dbo.tblEvent e
                    WHERE
                      e.EventCategoryID = 4
                  )  
                  ORDER BY
                    ph.EventDateTime DESC)) AS LastEnvironment,
      
    
  
                  (SELECT TOP 1
                    CAST(ph.[Data] AS VARCHAR(200))
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID IN  
                  (
                    SELECT 
                      e.ID
                    FROM
                      dbo.tblEvent e
                    WHERE
                      e.EventCategoryID = 4
                  )  
                  ORDER BY
                    ph.EventDateTime DESC) AS LastEnvironmentValue,
    
                  (SELECT TOP 1
                    ph.[EventDateTime]
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID IN
                 (
                    SELECT 
                      e.ID
                    FROM
                      dbo.tblEvent e
                    WHERE
                      e.EventCategoryID = 4
                  )        
                  ORDER BY
                    ph.EventDateTime DESC) AS LastEnvironmentDateTime,    
    
                  -- Originated From 
  
                  (SELECT e.[Name] FROM tblEvent e WHERE e.ID = 
                  (SELECT TOP 1
                    ph.EventID
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID IN  
                  (
                  '22','24'
                  )  
                  ORDER BY
                    ph.EventDateTime DESC)) AS OriginatedFrom,
    
  
                  (SELECT TOP 1
                    ph.EventDateTime
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID IN  
                  (
                    '22','24'
                  )  
                  ORDER BY
                    ph.EventDateTime DESC) AS OriginatedFromDateTime,
    
                    --Variety
  
  
                  (SELECT TOP 1
                    CAST(ph.[Data] AS VARCHAR(200))
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID = 25   
                  ORDER BY
                    ph.EventDateTime DESC) AS Variety,
    
                  (SELECT TOP 1
                    ph.[EventDateTime]
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID = 25   
                  ORDER BY
                    ph.EventDateTime DESC) AS VarietyDateTime,
    
                    --Location
  
  
                  (SELECT TOP 1
                    CAST(ph.[Data] AS VARCHAR(200))
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID = 26   
                  ORDER BY
                    ph.EventDateTime DESC) AS Location,
    
                  (SELECT TOP 1
                    ph.[EventDateTime]
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID = 26   
                  ORDER BY
                    ph.EventDateTime DESC) AS LocationDateTime,
    
                    --Last Note
  
  
                  (SELECT TOP 1
                    CAST(ph.[Data] AS VARCHAR(200))
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID = 27  
                  ORDER BY
                    ph.EventDateTime DESC) AS LastNote,
    
                  (SELECT TOP 1
                    ph.[EventDateTime]
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    ph.PlantID = p.ID
                    AND
                    ph.EventID = 27
                  ORDER BY
                    ph.EventDateTime DESC) AS LastNoteDateTime
                FROM
                  dbo.tblPlant p                ";

            List<tblPlant> xPlant = new List<tblPlant>();

            using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
            {
                SqlCommand MyCommand = new SqlCommand(SQL, con);

                con.Open();
                SqlDataReader MyReader = MyCommand.ExecuteReader();

                dtPlant = new DataTable();
                dtPlant.Load(MyReader);

                foreach (DataRow dr in dtPlant.Rows)
                {
                    tblPlant xtblPlant = new tblPlant();

                    xtblPlant.ID = Convert.ToInt64(dr["ID"]);
                    xtblPlant.GroupID = Convert.ToInt64(dr["GroupID"]);
                    xtblPlant.Name = dr["Name"].ToString();
                    xtblPlant.CreatedDateTime = Convert.ToDateTime(dr["CreatedDateTime"]);
                    if (dr["FirstEntryDateTime"] != DBNull.Value)
                    {
                        xtblPlant.FirstEntryDateTime = Convert.ToDateTime(dr["FirstEntryDateTime"]);
                    }

                    if (dr["LastEntryDateTime"] != DBNull.Value)
                    {
                        xtblPlant.LastEntryDateTime = Convert.ToDateTime(dr["LastEntryDateTime"]);
                    }

                    if (dr["Age"] != DBNull.Value)
                    {
                        xtblPlant.Age = Convert.ToInt32(dr["Age"]);
                    }

                    xtblPlant.EventCount = Convert.ToInt32(dr["EventCount"]);

                    if (dr["Phase"] != DBNull.Value)
                    {
                        xtblPlant.Phase = dr["Phase"].ToString();
                    }

                    if (dr["PhaseDateTime"] != DBNull.Value)
                    {
                        xtblPlant.PhaseDateTime = Convert.ToDateTime(dr["PhaseDateTime"]);
                    }

                    if (dr["Medium"] != DBNull.Value)
                    {
                        xtblPlant.Medium = dr["Medium"].ToString();
                    }

                    if (dr["MediumDateTime"] != DBNull.Value)
                    {
                        xtblPlant.MediumDateTime = Convert.ToDateTime(dr["MediumDateTime"]);
                    }

                    if (dr["DailyInspected"] != DBNull.Value)
                    {
                        xtblPlant.DailyInspected = Convert.ToInt32(dr["DailyInspected"]);
                    }

                    if (dr["DailyWatered"] != DBNull.Value)
                    {
                        xtblPlant.DailyWatered = Convert.ToInt32(dr["DailyWatered"]);
                    }

                    if (dr["LastNutrient"] != DBNull.Value)
                    {
                        xtblPlant.LastNutrient = dr["LastNutrient"].ToString();
                    }

                    if (dr["LastNutrientDateTime"] != DBNull.Value)
                    {
                        xtblPlant.LastNutrientDateTime = Convert.ToDateTime(dr["LastNutrientDateTime"]);
                    }

                    if (dr["LastChemical"] != DBNull.Value)
                    {
                        xtblPlant.LastChemical = dr["LastChemical"].ToString();
                    }

                    if (dr["LastChemicalDateTime"] != DBNull.Value)
                    {
                        xtblPlant.LastChemicalDateTime = Convert.ToDateTime(dr["LastChemicalDateTime"]);
                    }

                    if (dr["LastProblem"] != DBNull.Value)
                    {
                        xtblPlant.LastProblem = dr["LastProblem"].ToString();
                    }

                    if (dr["LastProblemDateTime"] != DBNull.Value)
                    {
                        xtblPlant.LastProblemDateTime = Convert.ToDateTime(dr["LastProblemDateTime"]);
                    }

                    if (dr["LastProblemDateTime"] != DBNull.Value)
                    {
                        xtblPlant.LastProblemDateTime = Convert.ToDateTime(dr["LastProblemDateTime"]);
                    }

                    //IMAGE
                    if (dr["LastPicture"] != DBNull.Value)
                    {
                        xtblPlant.LastPicture = (byte[])(dr["LastPicture"]);
                    }

                    if (dr["LastPictureDateTime"] != DBNull.Value)
                    {
                        xtblPlant.LastPictureDateTime = Convert.ToDateTime(dr["LastPictureDateTime"]);
                    }

                    //THUMBNAIL
                    if (dr["LastPicture"] != DBNull.Value)
                    {
                        byte[] xLastPicture = (byte[])(dr["LastPicture"]);

                        //Resize
                        clsSE xSE = new clsSE();
                        using (Image image = xSE.byteArrayToImage(xLastPicture))
                        {
                            using (Bitmap resizedImage = xSE.ResizeImage(image, 0.3m))
                            {
                                xtblPlant.LastPictureThumbnail = xSE.ImageToByteArray(resizedImage);
                            }
                        }
                    }



                    if (dr["LastEnvironment"] != DBNull.Value)
                    {
                        xtblPlant.LastEnvironment = dr["LastEnvironment"].ToString();
                    }

                    if (dr["LastEnvironmentValue"] != DBNull.Value)
                    {
                        xtblPlant.LastEnvironmentValue = dr["LastEnvironmentValue"].ToString();
                    }

                    if (dr["LastEnvironmentDateTime"] != DBNull.Value)
                    {
                        xtblPlant.LastEnvironmentDateTime = Convert.ToDateTime(dr["LastEnvironmentDateTime"]);
                    }

                    if (dr["OriginatedFrom"] != DBNull.Value)
                    {
                        xtblPlant.OriginatedFrom = dr["OriginatedFrom"].ToString();
                    }

                    if (dr["OriginatedFromDateTime"] != DBNull.Value)
                    {
                        xtblPlant.OriginatedFromDateTime = Convert.ToDateTime(dr["OriginatedFromDateTime"]);
                    }

                    if (dr["Variety"] != DBNull.Value)
                    {
                        xtblPlant.Variety = dr["Variety"].ToString();
                    }

                    if (dr["VarietyDateTime"] != DBNull.Value)
                    {
                        xtblPlant.VarietyDateTime = Convert.ToDateTime(dr["VarietyDateTime"]);
                    }

                    if (dr["Location"] != DBNull.Value)
                    {
                        xtblPlant.Location = dr["Location"].ToString();
                    }

                    if (dr["LocationDateTime"] != DBNull.Value)
                    {
                        xtblPlant.LocationDateTime = Convert.ToDateTime(dr["LocationDateTime"]);
                    }

                    if (dr["LastNote"] != DBNull.Value)
                    {
                        xtblPlant.LastNote = dr["LastNote"].ToString();
                    }

                    if (dr["LastNoteDateTime"] != DBNull.Value)
                    {
                        xtblPlant.LastNoteDateTime = Convert.ToDateTime(dr["LastNoteDateTime"]);
                    }


                    xPlant.Add(xtblPlant);
                }

                iePlant = xPlant;
            }
        }

        public void AddRec(int xCompanyID, string xCode, string xDescription, DateTime? xCreatedDateTime)
        {
            /*
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
            */
        }

        public void UpdateRec(int xID, int xCompanyID, string xCode, string xDescription, DateTime? xCreatedDateTime)
        {
            /*
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
            */
        }
    }
}
