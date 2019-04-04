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
        public int Deleted { get; set; }
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
        public Int64 LastPictureID { get; set; }
        public byte[] LastPicture { get; set; }
        public DateTime LastPictureDateTime { get; set; }
        public byte[] LastPictureThumbnail { get; set; }
        public string LastEnvironment { get; set; }
        public string LastEnvironmentValue { get; set; }
        public DateTime LastEnvironmentDateTime { get; set; }
        public string OriginatedFrom { get; set; }
        public string OriginatedFromPlantName { get; set; }
        public DateTime OriginatedFromDateTime { get; set; }
        public string Variety { get; set; }
        public DateTime VarietyDateTime { get; set; }
        public string Location { get; set; }
        public DateTime LocationDateTime { get; set; }
        public Int64 LastNoteID { get; set; }
        public string LastNote { get; set; }
        public DateTime LastNoteDateTime { get; set; }
        public int CuttingCount { get; set; }
        public IEnumerable<tblPlantHistory> iePlantHistory { get; set; }

        public DataTable dtPlant { get; set; }
        public IEnumerable<tblPlant> iePlant { get; set; }



        private string zSQL =
                @"
                SELECT 
                    p.ID,
                    p.GroupID,
                    p.Name,
                    p.CreatedDateTime,
                    p.Deleted,
  
                    (SELECT MIN(ph.CreatedDateTime) FROM tblPlantHistory ph WHERE (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    ) AS FirstEntryDateTime,
 
                    (SELECT MIN(ph.CreatedDateTime) FROM tblPlantHistory ph WHERE (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    ) AS LastEntryDateTime,
  
                    (SELECT DATEDIFF(DAY, p.CreatedDateTime , GETDATE())) AS Age,
  
                    (SELECT COUNT(*) FROM tblPlantHistory ph WHERE (ph.PlantID = p.ID) AND (ph.Deleted = 0)) AS EventCount,
  
                    -- Current Phase
  
                    (SELECT e.[Name] FROM tblEvent e WHERE e.ID = 
                    (SELECT TOP 1
                    ph.EventID
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
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
                    ph.CreatedDateTime DESC)) AS Phase,
    
  
                    (SELECT TOP 1
                    ph.CreatedDateTime
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
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
                    ph.CreatedDateTime DESC) AS PhaseDateTime,    
    
                    --Medium Change  
  
                    (SELECT TOP 1
                    CAST(ph.[Data] AS VARCHAR(200))
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
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
                    ph.CreatedDateTime DESC) AS Medium,
    
                (SELECT TOP 1
                    ph.[CreatedDateTime]
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
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
                    ph.CreatedDateTime DESC) AS MediumDateTime,    
  
  
    
                    --Daily
        
                    (SELECT COUNT(*)
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    CAST(ph.CreatedDateTime AS DATE) = CAST(GETDATE() AS DATE)
                    AND
    
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID = 9
                    ) AS DailyInspected,
   
                    (SELECT COUNT(*)
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    CAST(ph.CreatedDateTime AS DATE) = CAST(GETDATE() AS DATE)
                    AND
    
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID = 10
                    ) AS DailyWatered,

                    --Last Nutrient
                    (SELECT TOP 1
                    CAST(ph.[Data] AS VARCHAR(200))
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID = 11   
                    ORDER BY
                    ph.CreatedDateTime DESC) AS LastNutrient,
    
                    (SELECT TOP 1
                    ph.[CreatedDateTime]
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID = 11   
                    ORDER BY
                    ph.CreatedDateTime DESC) AS LastNutrientDateTime,

                        --Last Chemical
  
  
                    (SELECT TOP 1
                    CAST(ph.[Data] AS VARCHAR(200))
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID = 12   
                    ORDER BY
                    ph.CreatedDateTime DESC) AS LastChemical,
    
                    (SELECT TOP 1
                    ph.[CreatedDateTime]
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID = 12   
                    ORDER BY
                    ph.CreatedDateTime DESC) AS LastChemicalDateTime,
    
                    -- Last Problem
  
                    (SELECT e.[Name] FROM tblEvent e WHERE e.ID = 
                    (SELECT TOP 1
                    ph.EventID
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID IN  
                    (
                    SELECT 
                        e.ID
                    FROM
                        dbo.tblEvent e
                    WHERE
                        e.EventCategoryID = 6
                    )  
                    ORDER BY
                    ph.CreatedDateTime DESC)) AS LastProblem,
    
  
                    (SELECT TOP 1
                    ph.CreatedDateTime
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID IN  
                    (
                    SELECT 
                        e.ID
                    FROM
                        dbo.tblEvent e
                    WHERE
                        e.EventCategoryID = 6
                    )  
                    ORDER BY
                    ph.CreatedDateTime DESC) AS LastProblemDateTime,
    
	                --Last Picture
  
  
                    (SELECT TOP 1
                    ph.[ID]
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID = 15   
                    ORDER BY
                    ph.CreatedDateTime DESC) AS LastPictureID,

                    (SELECT TOP 1
                    ph.[Data]
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID = 15   
                    ORDER BY
                    ph.CreatedDateTime DESC) AS LastPicture,
    
                    (SELECT TOP 1
                    ph.[CreatedDateTime]
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID = 15   
                    ORDER BY
                    ph.CreatedDateTime DESC) AS LastPictureDateTime,    

                -- Last Environment
  
                    (SELECT e.[Name] FROM tblEvent e WHERE e.ID = 
                    (SELECT TOP 1
                    ph.EventID
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
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
                    ph.CreatedDateTime DESC)) AS LastEnvironment,
      
    
  
                    (SELECT TOP 1
                    CAST(ph.[Data] AS VARCHAR(200))
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
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
                    ph.CreatedDateTime DESC) AS LastEnvironmentValue,
    
                    (SELECT TOP 1
                    ph.[CreatedDateTime]
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
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
                    ph.CreatedDateTime DESC) AS LastEnvironmentDateTime,    
    
                    -- Originated From 
                  (SELECT TOP 1
                    CAST(ph.[Data] AS VARCHAR(200))
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID IN  
                  (
                  '22','24'
                  )  
                  ORDER BY
                    ph.CreatedDateTime DESC) AS OriginatedFrom,
    
                  (SELECT pp.Name FROM tblPlant pp WHERE CAST(pp.ID AS VARCHAR) = 
                  (SELECT TOP 1
                    CAST(ph.[Data] AS VARCHAR)
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID IN  
                  (
                  '22','24'
                  )  
                  ORDER BY
                    ph.CreatedDateTime DESC)) AS OriginatedFromPlantName,
    
  
                    (SELECT TOP 1
                    ph.CreatedDateTime
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID IN  
                    (
                    '22','24'
                    )  
                    ORDER BY
                    ph.CreatedDateTime DESC) AS OriginatedFromDateTime,
    
                    --Variety
  
  
                    (SELECT TOP 1
                    CAST(ph.[Data] AS VARCHAR(200))
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID = 25   
                    ORDER BY
                    ph.CreatedDateTime DESC) AS Variety,
    
                    (SELECT TOP 1
                    ph.[CreatedDateTime]
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID = 25   
                    ORDER BY
                    ph.CreatedDateTime DESC) AS VarietyDateTime,
    
                    --Location
  
  
                    (SELECT TOP 1
                    CAST(ph.[Data] AS VARCHAR(200))
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID = 26   
                    ORDER BY
                    ph.CreatedDateTime DESC) AS Location,
    
                    (SELECT TOP 1
                    ph.[CreatedDateTime]
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID = 26   
                    ORDER BY
                    ph.CreatedDateTime DESC) AS LocationDateTime,
    
                    --Last Note
  
                    (SELECT TOP 1
                    ph.[ID]
                  FROM
                    dbo.tblPlantHistory ph
                  WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID = 27
                  ORDER BY
                    ph.CreatedDateTime DESC) AS LastNoteID,

                    (SELECT TOP 1
                    CAST(ph.[Data] AS VARCHAR(200))
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID = 27  
                    ORDER BY
                    ph.CreatedDateTime DESC) AS LastNote,
    
                    (SELECT TOP 1
                    ph.[CreatedDateTime]
                    FROM
                    dbo.tblPlantHistory ph
                    WHERE
                    (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                    AND
                    ph.EventID = 27
                    ORDER BY
                    ph.CreatedDateTime DESC) AS LastNoteDateTime,

                    --Cutting Count
                    (SELECT 
                      COUNT(*)
    
                    FROM
                      dbo.tblPlantHistory ph
                    WHERE
                      (ph.PlantID = p.ID) AND (ph.Deleted = 0)
                      AND
                      ph.EventID = 30
                    ) AS CuttingCount

                FROM
                    dbo.tblPlant p";


        public void LoadData(bool xIncludeDeleted)
        {
            string SQL = zSQL;

            if (xIncludeDeleted)
            {
               // SQL = SQL + " WHERE p.[Deleted] = '0'";
            }
            else
            {
                SQL = SQL + " WHERE p.[Deleted] = '0'";
            }

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
                    xtblPlant.Deleted = Convert.ToInt32(dr["Deleted"]);

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
                    if (dr["LastPictureID"] != DBNull.Value)
                    {
                        xtblPlant.LastPictureID = Convert.ToInt64(dr["LastPictureID"]);
                    }

                    if (dr["LastPicture"] != DBNull.Value)
                    {
                        xtblPlant.LastPicture = (byte[])(dr["LastPicture"]);
                    }

                    if (dr["LastPictureDateTime"] != DBNull.Value)
                    {
                        xtblPlant.LastPictureDateTime = Convert.ToDateTime(dr["LastPictureDateTime"]);
                    }

                    //THUMBNAIL
                    if (clsGlobal.gOnTheFlyImageResize)
                    {
                        clsSE xSE = new clsSE();
                        xSE.WriteLog("Resizing...");

                        if (dr["LastPicture"] != DBNull.Value)
                        {
                            byte[] xLastPicture = (byte[])(dr["LastPicture"]);

                            //Resize
                            using (Image image = xSE.byteArrayToImage(xLastPicture))
                            {
                                using (Bitmap resizedImage = xSE.ResizeImage(image, clsGlobal.gThumbnailSize))
                                {
                                    xtblPlant.LastPictureThumbnail = xSE.ImageToByteArray(resizedImage);
                                }
                            }
                        }
                        xSE.WriteLog("Resizing done");
                    }
                    else
                    {
                        if (dr["LastPicture"] != DBNull.Value)
                        {
                            xtblPlant.LastPictureThumbnail = xtblPlant.LastPicture;
                        }
                    }
                    /*

                    */



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

                    if (dr["OriginatedFromPlantName"] != DBNull.Value)
                    {
                        xtblPlant.OriginatedFromPlantName = dr["OriginatedFromPlantName"].ToString();
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

                    if (dr["LastNoteID"] != DBNull.Value)
                    {
                        xtblPlant.LastNoteID = Convert.ToInt64(dr["LastNoteID"]);
                    }

                    if (dr["LastNote"] != DBNull.Value)
                    {
                        xtblPlant.LastNote = dr["LastNote"].ToString();
                    }

                    if (dr["LastNoteDateTime"] != DBNull.Value)
                    {
                        xtblPlant.LastNoteDateTime = Convert.ToDateTime(dr["LastNoteDateTime"]);
                    }

                    if (dr["CuttingCount"] != DBNull.Value)
                    {
                        xtblPlant.CuttingCount = Convert.ToInt32(dr["CuttingCount"]);
                    }

                    


                    tblPlantHistory xtblPlantHistory = new tblPlantHistory();
                    xtblPlantHistory.LoadData(Convert.ToInt32(xtblPlant.ID));

                    var xOrdered = xtblPlantHistory.iePlantHistory.OrderByDescending(x => x.CreatedDateTime);
                    xtblPlant.iePlantHistory = xOrdered;

                    xPlant.Add(xtblPlant);
                }

                iePlant = xPlant;
            }
        }

        public void LoadData(int xID, int xPlantOrGroup, bool xIncludeDeleted)
        {
            string SQL = zSQL;

            if (xPlantOrGroup == 0)
            {
                SQL = SQL + " WHERE (p.ID = '" + xID.ToString() + "')";
            }
            else
            {
                SQL = SQL + " WHERE (p.GroupID = '" + xID.ToString() + "')";
            }

            if (xIncludeDeleted)
            {
                //SQL = SQL + " AND (p.[Deleted] = '1')";
            } 
            else
            {
                SQL = SQL + " AND (p.[Deleted] = '0')";
            }

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
                    xtblPlant.Deleted = Convert.ToInt32(dr["Deleted"]);

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
                        if (Convert.ToInt32(dr["DailyInspected"]) > 0)
                        {
                            xtblPlant.DailyInspected = 1;
                        }
                        else
                        {
                            xtblPlant.DailyInspected = 0;
                        }
                    }

                    if (dr["DailyWatered"] != DBNull.Value)
                    {
                        if (Convert.ToInt32(dr["DailyWatered"]) > 0)
                        {
                            xtblPlant.DailyWatered = 1;
                        }
                        else
                        {
                            xtblPlant.DailyWatered = 0;
                        }
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
                    if (dr["LastPictureID"] != DBNull.Value)
                    {
                        xtblPlant.LastPictureID = Convert.ToInt64(dr["LastPictureID"]);
                    }

                    if (dr["LastPicture"] != DBNull.Value)
                    {
                        xtblPlant.LastPicture = (byte[])(dr["LastPicture"]);
                    }

                    if (dr["LastPictureDateTime"] != DBNull.Value)
                    {
                        xtblPlant.LastPictureDateTime = Convert.ToDateTime(dr["LastPictureDateTime"]);
                    }

                    //THUMBNAIL
                    if (clsGlobal.gOnTheFlyImageResize)
                    {
                        clsSE xSE = new clsSE();
                        xSE.WriteLog("Resizing...");

                        if (dr["LastPicture"] != DBNull.Value)
                        {
                            byte[] xLastPicture = (byte[])(dr["LastPicture"]);

                            //Resize
                            using (Image image = xSE.byteArrayToImage(xLastPicture))
                            {
                                using (Bitmap resizedImage = xSE.ResizeImage(image, clsGlobal.gThumbnailSize))
                                {
                                    xtblPlant.LastPictureThumbnail = xSE.ImageToByteArray(resizedImage);
                                }
                            }
                        }
                        xSE.WriteLog("Resizing done.");
                    }
                    else
                    {
                        if (dr["LastPicture"] != DBNull.Value)
                        {
                            xtblPlant.LastPictureThumbnail = xtblPlant.LastPicture;
                        }
                    }

                    /*
                    */



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

                    if (dr["OriginatedFromPlantName"] != DBNull.Value)
                    {
                        xtblPlant.OriginatedFromPlantName = dr["OriginatedFromPlantName"].ToString();
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

                    if (dr["LastNoteID"] != DBNull.Value)
                    {
                        xtblPlant.LastNoteID = Convert.ToInt64(dr["LastNoteID"]);
                    }

                    if (dr["LastNote"] != DBNull.Value)
                    {
                        xtblPlant.LastNote = dr["LastNote"].ToString();
                    }

                    if (dr["LastNoteDateTime"] != DBNull.Value)
                    {
                        xtblPlant.LastNoteDateTime = Convert.ToDateTime(dr["LastNoteDateTime"]);
                    }

                    if (dr["CuttingCount"] != DBNull.Value)
                    {
                        xtblPlant.CuttingCount = Convert.ToInt32(dr["CuttingCount"]);
                    }


                    tblPlantHistory xtblPlantHistory = new tblPlantHistory();
                    xtblPlantHistory.LoadData(Convert.ToInt32(xtblPlant.ID));

                    var xOrdered = xtblPlantHistory.iePlantHistory.OrderByDescending(x => x.CreatedDateTime);
                    xtblPlant.iePlantHistory = xOrdered;

                    xPlant.Add(xtblPlant);
                }

                iePlant = xPlant;
            }
        }

        public void AddRec(int xGroupID, string xName, DateTime? xCreatedDateTime)
        {
            List<string> fFields = new List<string>();
            List<string> vValues = new List<string>();

            fFields.Add("GroupID");
            fFields.Add("Name");

            if (xCreatedDateTime == null)
            {
                vValues.Add(xGroupID.ToString());
                vValues.Add(xName.ToString());
            }
            else
            {
                fFields.Add("CreatedDateTime");

                vValues.Add(xGroupID.ToString());
                vValues.Add(xName.ToString());
                vValues.Add(xCreatedDateTime.ToString());
            }

            clsSE xclsSE = new clsSE();
            xclsSE.sqlInsertRec("tblPlant", fFields, vValues);
        }

        public void UpdateRec(int xID, int xGroupID, string xName, DateTime? xCreatedDateTime)
        {
            List<string> fFields = new List<string>();
            List<string> vValues = new List<string>();

            fFields.Add("GroupID");
            fFields.Add("Name");

            if (xCreatedDateTime == null)
            {
                vValues.Add(xGroupID.ToString());
                vValues.Add(xName.ToString());
            }
            else
            {
                fFields.Add("CreatedDateTime");

                vValues.Add(xGroupID.ToString());
                vValues.Add(xName.ToString());
                vValues.Add(xCreatedDateTime.ToString());
            }

            clsSE xclsSE = new clsSE();
            xclsSE.sqlUpdateRec("tblPlant", fFields, vValues, "[ID] = '" + xID + "'");
            
        }

        public void DeleteRec(int xID)
        {
            List<string> fFields = new List<string>();
            List<string> vValues = new List<string>();

            fFields.Add("Deleted");

            vValues.Add("1");

            clsSE xclsSE = new clsSE();
            xclsSE.sqlUpdateRec("tblPlant", fFields, vValues, "[ID] = '" + xID + "'");
        }

        public void TakeCutting(int xID)
        {
            //Create garden if not exist
            tblGroup xtblGroup = new tblGroup();
            xtblGroup.LoadData();

            tblPlant xtblPlant = new tblPlant();
            xtblPlant.LoadData(xID, 0, false);



            //Get Company ID
            var xFiltered = xtblGroup.ieGroup.Where(r => r.ID == xtblPlant.iePlant.FirstOrDefault().GroupID);
            var xCompanyID = xFiltered.FirstOrDefault().CompanyID;

            //Look for garden
            xFiltered = xtblGroup.ieGroup.Where(r => (r.Code.ToString() == "Cuttings") && (r.CompanyID == xCompanyID));

            //Create garden
            if (xFiltered.Count() == 0)
            {
                xtblGroup.AddRec(Convert.ToInt32(xCompanyID), "Cuttings", "New cuttings", null);
                xtblGroup.LoadData();
            }

            //Get cuttings garden id
            xFiltered = xtblGroup.ieGroup.Where(r => (r.Code.ToString() == "Cuttings") && (r.CompanyID == xCompanyID));
            var xCuttingGardenID = xFiltered.FirstOrDefault().ID;

            //Generate plant name
            tblPlant xtblCuttingGardenPlant = new tblPlant();
            xtblCuttingGardenPlant.LoadData(Convert.ToInt32(xCuttingGardenID), 1, false);

            var xName = xtblPlant.iePlant.FirstOrDefault().Name;
            var xC1 = 1;
            var xMatchingName = xtblCuttingGardenPlant.iePlant.Where(r => r.Name == xName + " - " + xC1.ToString().PadLeft(2,'0'));

            while (xMatchingName.Count() > 0)
            {
                xC1 = xC1 + 1;
                xMatchingName = xtblCuttingGardenPlant.iePlant.Where(r => r.Name == xName + " - " + xC1.ToString().PadLeft(2, '0'));
            }

            //Create the plant
            xtblPlant.AddRec(Convert.ToInt32(xCuttingGardenID), xName + " - " + xC1.ToString().PadLeft(2, '0'), null);

            //Find created plant id
            xtblCuttingGardenPlant.LoadData(Convert.ToInt32(xCuttingGardenID), 1, false);
            xMatchingName = xtblCuttingGardenPlant.iePlant.Where(r => r.Name == xName + " - " + xC1.ToString().PadLeft(2, '0'));
            var xCreatedPlantID = xMatchingName.FirstOrDefault().ID;

            //Add event to source plant
            tblPlantHistory xtblPlantHistory = new tblPlantHistory();
            xtblPlantHistory.AddRec(xID, "30", xCreatedPlantID.ToString(), null, false);

            //Clone properties to new cutting
            //Phase
            xtblPlantHistory.AddRec(Convert.ToInt32(xCreatedPlantID), "4", null, null, false);
            //Variety
            if (xtblPlant.iePlant.FirstOrDefault().Variety != null)
            {
                xtblPlantHistory.AddRec(Convert.ToInt32(xCreatedPlantID), "25", xtblPlant.iePlant.FirstOrDefault().Variety, null, false);
            }
            //Cutting of
            xtblPlantHistory.AddRec(Convert.ToInt32(xCreatedPlantID), "24", xtblPlant.iePlant.FirstOrDefault().ID.ToString(), null, false);


            var x = 1;

        }
    }
}
