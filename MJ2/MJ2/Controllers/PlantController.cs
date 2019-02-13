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
        public ActionResult Index(string xplantid, string xcompressedpic)
        {
            if (xcompressedpic != null)
            {
                string xx = xcompressedpic.Replace(@"data:image/png;base64,", "");

                byte[] xImage = Convert.FromBase64String(xx);

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
    }
}