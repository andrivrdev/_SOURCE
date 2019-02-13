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
        // ----- SQL LITE DB -----
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

    }
}