using SHARED.CLASSES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
        public DateTime CreatedDateTime { get; set; }
        public byte[] PictureThumbnail { get; set; }
        

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
                  dbo.tblPlantHistory.CreatedDateTime
                FROM
                  dbo.tblPlantHistory WHERE Deleted = '0'               ";

            List<tblPlantHistory> xPlantHistory = new List<tblPlantHistory>();

            using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
            {
                SqlCommand MyCommand = new SqlCommand(SQL, con);

                con.Open();
                SqlDataReader MyReader = MyCommand.ExecuteReader();

                dtPlantHistory = new DataTable();
                dtPlantHistory.Load(MyReader);

                foreach (DataRow dr in dtPlantHistory.Rows)
                {
                    tblPlantHistory xtblPlantHistory = new tblPlantHistory();
                    xtblPlantHistory.ID = Convert.ToInt64(dr["ID"]);
                    xtblPlantHistory.PlantID = Convert.ToInt64(dr["PlantID"]);
                    xtblPlantHistory.EventID = Convert.ToInt64(dr["EventID"]);

                    if (dr["Data"] != DBNull.Value)
                    {
                        xtblPlantHistory.Data = (byte[])(dr["Data"]);

                    }

                    xtblPlantHistory.CreatedDateTime = Convert.ToDateTime(dr["CreatedDateTime"]);


                    //THUMBNAIL
                    if (clsGlobal.gOnTheFlyImageResize)
                    {
                        clsSE xSE = new clsSE();
                        xSE.WriteLog("Resizing...");

                        if (dr["Data"] != DBNull.Value && Convert.ToInt64(dr["EventID"]) == 15)
                        {
                            byte[] xData = (byte[])(dr["Data"]);

                            //Resize
                            using (Image image = xSE.byteArrayToImage(xData))
                            {
                                using (Bitmap resizedImage = xSE.ResizeImage(image, clsGlobal.gThumbnailSize))
                                {
                                    xtblPlantHistory.PictureThumbnail = xSE.ImageToByteArray(resizedImage);
                                }
                            }
                        }
                        xSE.WriteLog("Resizing done");
                    }
                    else
                    {


                        if (dr["Data"] != DBNull.Value && Convert.ToInt64(dr["EventID"]) == 15)
                        {
                            xtblPlantHistory.PictureThumbnail = xtblPlantHistory.Data;
                        }
                    }




                    xPlantHistory.Add(xtblPlantHistory);
                }

                iePlantHistory = xPlantHistory;
            }
        }

        public void LoadData(int xPlantID)
        {
            string SQL = "";

            SQL =
                @"
                SELECT 
                  dbo.tblPlantHistory.ID,
                  dbo.tblPlantHistory.PlantID,
                  dbo.tblPlantHistory.EventID,
                  dbo.tblPlantHistory.Data,
                  dbo.tblPlantHistory.CreatedDateTime
                FROM
                  dbo.tblPlantHistory WHERE (PlantID = '" + xPlantID.ToString() + "') AND (Deleted = '0')";

            List<tblPlantHistory> xPlantHistory = new List<tblPlantHistory>();

            using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
            {
                SqlCommand MyCommand = new SqlCommand(SQL, con);

                con.Open();
                SqlDataReader MyReader = MyCommand.ExecuteReader();

                dtPlantHistory = new DataTable();
                dtPlantHistory.Load(MyReader);

                foreach (DataRow dr in dtPlantHistory.Rows)
                {
                    tblPlantHistory xtblPlantHistory = new tblPlantHistory();
                    xtblPlantHistory.ID = Convert.ToInt64(dr["ID"]);
                    xtblPlantHistory.PlantID = Convert.ToInt64(dr["PlantID"]);
                    xtblPlantHistory.EventID = Convert.ToInt64(dr["EventID"]);

                    if (dr["Data"] != DBNull.Value)
                    {
                        xtblPlantHistory.Data = (byte[])(dr["Data"]);

                    }

                    xtblPlantHistory.CreatedDateTime = Convert.ToDateTime(dr["CreatedDateTime"]);


                    //THUMBNAIL
                    if (clsGlobal.gOnTheFlyImageResize)
                    {
                        clsSE xSE = new clsSE();
                        xSE.WriteLog("Resizing...");

                        if (dr["Data"] != DBNull.Value && Convert.ToInt64(dr["EventID"]) == 15)
                        {
                            byte[] xData = (byte[])(dr["Data"]);

                            //Resize
                            using (Image image = xSE.byteArrayToImage(xData))
                            {
                                using (Bitmap resizedImage = xSE.ResizeImage(image, clsGlobal.gThumbnailSize))
                                {
                                    xtblPlantHistory.PictureThumbnail = xSE.ImageToByteArray(resizedImage);
                                }
                            }
                        }

                        xSE.WriteLog("Resizing done");
                    }
                    else
                    {
                        if (dr["Data"] != DBNull.Value && Convert.ToInt64(dr["EventID"]) == 15)
                        {
                            xtblPlantHistory.PictureThumbnail = xtblPlantHistory.Data;
                        }
                    }





                    xPlantHistory.Add(xtblPlantHistory);
                }

                iePlantHistory = xPlantHistory;
            }
        }


        public void AddRec(int xPlantID, string xEventID, string xData, DateTime? xCreatedDateTime)
        {
            string SQL = "";

            try
            {
                //Build SQL
                if (xCreatedDateTime == null)
                {
                    if (xData != null)
                    {

                        SQL =
                        @"INSERT INTO tblPlantHistory ([PlantID], [EventID], [Data]) values('" +
                        xPlantID + "', '" + xEventID + "', @Data)";
                    }
                    else
                    {
                        SQL =
                        @"INSERT INTO tblPlantHistory ([PlantID], [EventID]) values('" +
                        xPlantID + "', '" + xEventID + "')";
                    }
                }
                else
                {
                    if (xData != null)
                    {
                        SQL =
                        @"INSERT INTO tblPlantHistory ([PlantID], [EventID], [Data], [CreatedDateTime]) values('" +
                        xPlantID + "', '" + xEventID + "', @Data,'" + xCreatedDateTime.ToString() + "')";
                    }
                    else
                    {
                        SQL =
                        @"INSERT INTO tblPlantHistory ([PlantID], [EventID], [CreatedDateTime]) values('" +
                        xPlantID + "', '" + xEventID + "', '" + xCreatedDateTime.ToString() + "')";
                    }
                }

                using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    if (xData != null)
                    {
                        byte[] sqlData = Convert.FromBase64String(xData);

                        SqlParameter sqlParam = MyCommand.Parameters.AddWithValue("@Data", sqlData);
                        sqlParam.DbType = DbType.Binary;
                    }

                    con.Open();

                    MyCommand.ExecuteNonQuery();
                }
            }
            catch (Exception Ex)
            {
                var x = 1;
            }
        }

        public void UpdateRec(int xID, int xPlantID, string xEventID, string xData, DateTime xEventDateTime, DateTime? xCreatedDateTime)
        {
            string SQL = "";

            try
            {
                //Build SQL
                if (xCreatedDateTime == null)
                {
                    SQL =
                    @"UPDATE" +
                     "  tblPlantHistory" +
                     "SET" +
                     "  [PlantID] = '" + xPlantID + "'," +
                     "  [EventID] = '" + xEventID + "'," +
                     "  [Data] = @Data" +
                     "WHERE" +
                     "  [ID] = '" + xID + "'";
                }
                else
                {
                    SQL =
                    @"UPDATE" +
                     "  tblPlantHistory" +
                     "SET" +
                     "  [PlantID] = '" + xPlantID + "'," +
                     "  [EventID] = '" + xEventID + "'," +
                     "  [Data] = @Data," +
                     "  [CreatedDateTime] = '" + xCreatedDateTime.ToString() + "'," +
                     "WHERE" +
                     "  [ID] = '" + xID + "'";
                }

                using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
                {
                    SqlCommand MyCommand = new SqlCommand(SQL, con);

                    byte[] sqlData = Convert.FromBase64String(xData);

                    SqlParameter sqlParam = MyCommand.Parameters.AddWithValue("@Data", sqlData);
                    sqlParam.DbType = DbType.Binary;

                    con.Open();

                    MyCommand.ExecuteNonQuery();
                }
            }
            catch (Exception Ex)
            {
                var x = 1;
            }
        }

        public void DeleteRec(int xID)
        {
            List<string> fFields = new List<string>();
            List<string> vValues = new List<string>();

            fFields.Add("Deleted");

            vValues.Add("1");

            clsSE xclsSE = new clsSE();
            xclsSE.sqlUpdateRec("tblPlantHistory", fFields, vValues, "[ID] = '" + xID + "'");
        }

    }
}
