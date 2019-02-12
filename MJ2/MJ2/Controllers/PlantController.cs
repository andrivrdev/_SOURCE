using SHARED.CLASSES;
using SHARED.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MJ2.Controllers
{
    public class PlantController : Controller
    {
        // GET: Plant
        public ActionResult Index()
        {
            tblPlant xtblPlant = new tblPlant();
            xtblPlant.LoadData();

            var xFiltered = xtblPlant.iePlant.Where(r => r.GroupID.ToString() == Session["GroupID"].ToString());
            var xOrdered = xFiltered.OrderBy(x => x.Name);

            ViewData["orderby"] = "Name";
            ViewData["ascendingdescending"] = "Ascending";

            return View(xOrdered);
        }

        [HttpPost]
        public ActionResult Index(string xplantid, string xcompressedpic, HttpPostedFileBase xpic)
        {
            if (xcompressedpic != null)
            {
                string xx = xcompressedpic.Replace(@"data:image/png;base64,", "");

                byte[] xImage = Convert.FromBase64String(xx);
                //byte[] xImage = Encoding.UTF8.GetBytes(xpic);
                //byte[] xImage = new byte[xpic.ContentLength];

                /*
                byte[] ximg = null;
                xpic.InputStream.Read(xImage, 0, xpic.ContentLength);
                
                //Resize
                using (Image image = Image.FromStream(xpic.InputStream, true, true))
                {
                    using (Bitmap resizedImage = ResizeImage(image, 800, 600))
                    {
                        ximg = ImageToByteArray(resizedImage);
                    }
                }
                */

                string SQL = "";

                try
                {
                    //Build SQL
                    SQL =
                        @"INSERT INTO tblPlantHistory values('" + xplantid + "', '15', @Data," +
                        "GETDATE(), GETDATE())";


                    using (SqlConnection con = new SqlConnection(clsGlobal.gConnectionString))
                    {
                        SqlCommand MyCommand = new SqlCommand(SQL, con);

                        SqlParameter sqlParam = MyCommand.Parameters.AddWithValue("@Data", xImage);
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











            tblPlant xtblPlant = new tblPlant();
            xtblPlant.LoadData();

            var xFiltered = xtblPlant.iePlant.Where(r => r.GroupID.ToString() == Session["GroupID"].ToString());
            var xOrdered = xFiltered.OrderBy(x => x.Name);

            ViewData["orderby"] = "Name";
            ViewData["ascendingdescending"] = "Ascending";

            return View(xOrdered);
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
                imageIn.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
    }
}