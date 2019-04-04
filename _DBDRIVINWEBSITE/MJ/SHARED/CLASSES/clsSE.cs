using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARED.CLASSES
{
    public class clsSE
    {
        // ----- MSSQL DB -----
        public bool sqlCheckIfDBExist(string xServer, string xDatabase, string xUserID, string xPassword)
        {
            try
            {
                string SQL = "SELECT * FROM master.dbo.sysdatabases where name = '" + xDatabase + "'";
                string xConnStr = "Server=" + xServer + ";User ID=" + xUserID + ";Password=" + xPassword + ";Trusted_Connection=False;Connection Timeout=30";


                using (SqlConnection con = new SqlConnection(xConnStr))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    con.Open();
                    SqlDataReader MyReader = MyCommand.ExecuteReader();

                    if (MyReader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception Ex)
            {
                //WriteLog(1, Ex.Message, "clsSE", "sqliteInsertRec");
                return false;
            }
        }

        public void sqlCreateDatabase(string xServer, string xDatabase, string xUserID, string xPassword)
        {
            try
            {
                string SQL = "CREATE DATABASE " + xDatabase;
                string xConnStr = "Server=" + xServer + ";User ID=" + xUserID + ";Password=" + xPassword + ";Trusted_Connection=False;Connection Timeout=30";

                using (SqlConnection con = new SqlConnection(xConnStr))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    con.Open();

                    MyCommand.ExecuteNonQuery();
                }

                //Create Tables
                SQL =
                    @"
                    CREATE TABLE [dbo].[tblCompany] (
                      [ID] bigint IDENTITY(1, 1) NOT NULL,
                      [Name] varchar(50) COLLATE Latin1_General_CI_AS NOT NULL,
                      [Password] varchar(50) COLLATE Latin1_General_CI_AS NOT NULL,
                      [CreatedDateTime] datetime CONSTRAINT [DF__tblCompan__Creat__38996AB5] DEFAULT getdate() NOT NULL,
                      CONSTRAINT [PK__tblCompa__3214EC27B92D6FB9] PRIMARY KEY CLUSTERED ([ID]),
                      CONSTRAINT [UQ__tblCompa__737584F686184EDA] UNIQUE ([Name])
                    )
                    ON [PRIMARY];

                    CREATE TABLE [dbo].[tblGroup] (
                      [ID] bigint IDENTITY(1, 1) NOT NULL,
                      [CompanyID] bigint NOT NULL,
                      [Code] varchar(20) COLLATE Latin1_General_CI_AS NOT NULL,
                      [Description] varchar(1000) COLLATE Latin1_General_CI_AS NULL,
                      [CreatedDateTime] datetime CONSTRAINT [DF__tblGroup__Create__3B75D760] DEFAULT getdate() NOT NULL,
                      [Deleted] int CONSTRAINT [DF__tblGroup__Delete__3C69FB99] DEFAULT 0 NOT NULL,
                      CONSTRAINT [PK__tblGroup__3214EC2756898800] PRIMARY KEY CLUSTERED ([ID]),
                      CONSTRAINT [tblGroup_fk] FOREIGN KEY ([CompanyID]) 
                      REFERENCES [dbo].[tblCompany] ([ID]) 
                      ON UPDATE NO ACTION
                      ON DELETE NO ACTION
                    )
                    ON [PRIMARY];


                    CREATE NONCLUSTERED INDEX [tblGroup_idx] ON [dbo].[tblGroup]
                      ([CompanyID], [Code])
                    WITH (
                      PAD_INDEX = OFF,
                      DROP_EXISTING = OFF,
                      STATISTICS_NORECOMPUTE = OFF,
                      SORT_IN_TEMPDB = OFF,
                      ONLINE = OFF,
                      ALLOW_ROW_LOCKS = ON,
                      ALLOW_PAGE_LOCKS = ON)
                    ON [PRIMARY];

                    CREATE TABLE [dbo].[tblPlant] (
                      [ID] bigint IDENTITY(1, 1) NOT NULL,
                      [GroupID] bigint NOT NULL,
                      [Name] varchar(20) COLLATE Latin1_General_CI_AS NOT NULL,
                      [CreatedDateTime] datetime CONSTRAINT [DF__tblPlant__Create__3F466844] DEFAULT getdate() NOT NULL,
                      [Deleted] int CONSTRAINT [DF__tblPlant__Delete__403A8C7D] DEFAULT 0 NOT NULL,
                      CONSTRAINT [PK__tblPlant__3214EC277B4686F3] PRIMARY KEY CLUSTERED ([ID]),
                      CONSTRAINT [tblPlant_fk] FOREIGN KEY ([GroupID]) 
                      REFERENCES [dbo].[tblGroup] ([ID]) 
                      ON UPDATE NO ACTION
                      ON DELETE NO ACTION
                    )
                    ON [PRIMARY];

                    CREATE TABLE [dbo].[tblEventCategory] (
                      [ID] bigint IDENTITY(1, 1) NOT NULL,
                      [Name] varchar(20) COLLATE Latin1_General_CI_AS NOT NULL,
                      [CreatedDateTime] datetime CONSTRAINT [DF__tblEventC__Creat__4AB81AF0] DEFAULT getdate() NOT NULL,
                      CONSTRAINT [PK__tblEvent__3214EC2742022F94] PRIMARY KEY CLUSTERED ([ID]),
                      CONSTRAINT [UQ__tblEvent__737584F64A0B5310] UNIQUE ([Name])
                    )
                    ON [PRIMARY];

                    CREATE TABLE [dbo].[tblEvent] (
                      [ID] bigint IDENTITY(1, 1) NOT NULL,
                      [EventCategoryID] bigint NOT NULL,
                      [Name] varchar(20) COLLATE Latin1_General_CI_AS NOT NULL,
                      [CreatedDateTime] datetime CONSTRAINT [DF__tblEvent__Create__4E88ABD4] DEFAULT getdate() NOT NULL,
                      CONSTRAINT [PK__tblEvent__3214EC27D8DB0C78] PRIMARY KEY CLUSTERED ([ID]),
                      CONSTRAINT [UQ__tblEvent__737584F6700DD539] UNIQUE ([Name]),
                      CONSTRAINT [tblEvent_fk] FOREIGN KEY ([EventCategoryID]) 
                      REFERENCES [dbo].[tblEventCategory] ([ID]) 
                      ON UPDATE NO ACTION
                      ON DELETE NO ACTION
                    )
                    ON [PRIMARY];

                    CREATE TABLE [dbo].[tblPlantHistory] (
                      [ID] bigint IDENTITY(1, 1) NOT NULL,
                      [PlantID] bigint NOT NULL,
                      [EventID] bigint NOT NULL,
                      [Data] varbinary(max) NULL,
                      [CreatedDateTime] datetime CONSTRAINT [DF__tblPlantH__Creat__44FF419A] DEFAULT getdate() NOT NULL,
                      [Deleted] int CONSTRAINT [DF__tblPlantH__Delet__45F365D3] DEFAULT 0 NOT NULL,
                      CONSTRAINT [PK__tblPlant__3214EC2739B8AABD] PRIMARY KEY CLUSTERED ([ID]),
                      CONSTRAINT [tblPlantHistory_fk] FOREIGN KEY ([PlantID]) 
                      REFERENCES [dbo].[tblPlant] ([ID]) 
                      ON UPDATE NO ACTION
                      ON DELETE NO ACTION,
                      CONSTRAINT [tblPlantHistory_fk2] FOREIGN KEY ([EventID]) 
                      REFERENCES [dbo].[tblEvent] ([ID]) 
                      ON UPDATE NO ACTION
                      ON DELETE NO ACTION
                    )
                    ON [PRIMARY];





                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Phases');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Mediums');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Daily');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Environmental');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Chemicals');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Problems');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Images');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Nutrients');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Origin');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Varieties');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Notes');
                    

                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'Cuttings');
                    
                    INSERT INTO [dbo].[tblEventCategory] ([Name])
                    VALUES (N'X1 Placeholder');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (1, N'Germination');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (1, N'Vegitative');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (1, N'Flower');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (1, N'Cutting');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (1, N'Trimming');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (1, N'Curing');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (1, N'End of Life');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (2, N'Medium Change');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (3, N'Inspected');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (3, N'Watered');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (8, N'Nutrient');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (5, N'Chemical');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (6, N'Rotten');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (6, N'Bugs');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (7, N'Image');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (4, N'Temperature');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (4, N'Humidity');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (13, N'X1 Placeholder');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (13, N'X2 Placeholder');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (13, N'X3 Placeholder');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (13, N'X4 Placeholder');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (9, N'Other Origin');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (13, N'X5 Placeholder');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (9, N'Mother');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (10, N'Variety');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (13, N'X6 Placeholder');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (11, N'Note');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (13, N'X7 Placeholder');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (13, N'X8 Placeholder');


                    INSERT INTO [dbo].[tblEvent] ([EventCategoryID], [Name])
                    VALUES (12, N'Took a Cutting');























                    ";
                
                using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    con.Open();

                    MyCommand.ExecuteNonQuery();
                }
            }
            catch (Exception Ex)
            {
                var x = 1;
                //WriteLog(1, Ex.Message, "clsSE", "sqliteInsertRec");
            }
        }


        public bool sqlInsertRec(string xTableName, List<string> xFields, List<string> xValues)
        {
            string SQL = "";

            try
            {
                //Build SQL
                SQL =
                "INSERT INTO [" + xTableName + "]" + Environment.NewLine +
                "(" + Environment.NewLine;

                //Fields
                for (int i = 0; i < xFields.Count; i++)
                {
                    SQL += "[" + xFields[i] + "]";

                    if (i + 1 != xFields.Count)
                    {
                        SQL += ",";
                    }

                    SQL += Environment.NewLine;
                }

                SQL +=
                    ")" + Environment.NewLine +
                    "values" + Environment.NewLine +
                    "(" + Environment.NewLine;

                //Values
                for (int i = 0; i < xValues.Count; i++)
                {
                    //If the value start with || then dont put the value in quotes

                    string tmpSQL = "";
                    if (xValues[i].Contains("'"))
                    {
                        tmpSQL = "'" + xValues[i].Replace("'", "''") + "'";
                    }
                    else
                    {
                        tmpSQL = "'" + xValues[i] + "'";
                    }

                    if (xValues[i].Length > 2)
                    {
                        if (xValues[i].Substring(0, 2) == "||")
                        {
                            xValues[i] = xValues[i].Substring(2);
                            tmpSQL = xValues[i];
                        }
                    }

                    SQL += tmpSQL;

                    if (i + 1 != xFields.Count)
                    {
                        SQL += ",";
                    }

                    SQL += Environment.NewLine;
                }

                SQL += ")";

                using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    con.Open();

                    MyCommand.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception Ex)
            {
                //WriteLog(1, Ex.Message, "clsSE", "sqliteInsertRec");
                return false;
            }
        }

        public bool sqlUpdateRec(string xTableName, List<string> xFields, List<string> xValues, string xWhere)
        {
            try
            {
                string SQL = "";

                //Build SQL
                SQL =
                "UPDATE [" + xTableName + "]" + Environment.NewLine +
                "SET" + Environment.NewLine;

                for (int i = 0; i < xFields.Count; i++)
                {
                    //Fix '
                    if (xValues[i].Contains("'"))
                    {
                        xValues[i] = xValues[i].Replace("'", "''");
                    }

                    //If the value start with || then dont put the value in quotes
                    string tmpSQL = "[" + xFields[i] + "] = '" + xValues[i] + "'";
                    if (xValues[i].Length > 2)
                    {
                        if (xValues[i].Substring(0, 2) == "||")
                        {
                            xValues[i] = xValues[i].Substring(2);

                            tmpSQL = "[" + xFields[i] + "] = " + xValues[i];
                        }
                    }

                    SQL += tmpSQL;
                    if (i + 1 != xFields.Count)
                    {
                        SQL += ",";
                    }

                    SQL += Environment.NewLine;
                }

                if (xWhere.Length > 0)
                {
                    SQL +=
                        "WHERE" + Environment.NewLine + xWhere;
                }

                using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    con.Open();

                    MyCommand.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception Ex)
            {
                //WriteLog(1, Ex.Message, "clsSE", "sqliteUpdateRec");
                return false;
            }
        }

        public bool sqlDeleteRec(string xTableName, string xWhere)
        {
            try
            {
                string SQL = "";

                //Build SQL
                SQL =
                "DELETE FROM [" + xTableName + "]" + Environment.NewLine;

                if (xWhere.Length > 0)
                {
                    SQL += "WHERE" + Environment.NewLine + xWhere;
                }

                using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    con.Open();

                    MyCommand.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception Ex)
            {
                //WriteLog(1, Ex.Message, "clsSE", "sqliteDeleteRec");

                return false;
            }
        }

        public Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public Bitmap ResizeImage(Image image, decimal percentage)
        {
            int width = (int)Math.Round(image.Width * percentage, MidpointRounding.AwayFromZero);
            int height = (int)Math.Round(image.Height * percentage, MidpointRounding.AwayFromZero);
            return ResizeImage(image, width, height);
        }

        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }

        public void  WriteLog(string xMessage)
        {
            if (clsGlobal.gWriteLog)
            {
                xMessage = "[" + DateTime.Now.ToString() + "] [" + xMessage + "]";

                File.AppendAllText(@"C:\Logs\" + SHARED.CLASSES.clsGlobal.gAppName + "Log.txt", xMessage + Environment.NewLine);
            }


        }

    }
}