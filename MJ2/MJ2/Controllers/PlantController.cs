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
        tblPlantHistory ztblPlantHistory = new tblPlantHistory();



        // GET: Plant
        public ActionResult Index()
        {
            if (Session["GroupID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            tblPlant xtblPlant = new tblPlant();
            xtblPlant.LoadData();

            var xFiltered = xtblPlant.iePlant.Where(r => r.GroupID.ToString() == Session["GroupID"].ToString());
            var xOrdered = xFiltered.OrderBy(x => x.Name);

            ViewData["orderby"] = "Name";
            ViewData["ascendingdescending"] = "Ascending";

            return View(xOrdered);
        }

        [HttpPost]
        public ActionResult Index(string xcommand, string xplantid, string xname, DateTime? xcreateddatetime, string orderby, string ascendingdescending, string xcompressedpic)
        {
            if (Session["GroupID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            tblPlant xtblPlant;

            if (xcommand == "Add")
            {
                xtblPlant = new tblPlant();
                xtblPlant.AddRec(Convert.ToInt32(Session["GroupID"].ToString()), xname, null);
            }

            if (xcommand == "Edit")
            {
                xtblPlant = new tblPlant();
                xtblPlant.UpdateRec(Convert.ToInt32(xplantid), Convert.ToInt32(Session["GroupID"].ToString()), xname, xcreateddatetime);
            }

            if (xcommand == "AddImage")
            {
                if (xcompressedpic != null)
                {
                    string scompressedpic = xcompressedpic.Replace(@"data:image/png;base64,", "");

                    ztblPlantHistory.AddRec(Convert.ToInt32(xplantid), "15", scompressedpic, xcreateddatetime);
                }
            }

            if (xcommand == "AddInspected")
            {
                ztblPlantHistory.AddRec(Convert.ToInt32(xplantid), "9", null, xcreateddatetime);
            }

            if (xcommand == "AddWatered")
            {
                ztblPlantHistory.AddRec(Convert.ToInt32(xplantid), "10", null, xcreateddatetime);
            }










            xtblPlant = new tblPlant();
            xtblPlant.LoadData();

            var xFiltered = xtblPlant.iePlant.Where(r => r.GroupID.ToString() == Session["GroupID"].ToString());
            var xOrdered = xFiltered.OrderBy(x => x.Name);

            ViewData["orderby"] = "Name";
            ViewData["ascendingdescending"] = "Ascending";

            return View(xOrdered);
        }

        public PartialViewResult PreviousImage(string xpreviousornext, string xplantid, string xplanthistoryid)
        {
            //Get recs for images for this plant
            ztblPlantHistory.LoadData(Convert.ToInt32(xplantid));

            var xImageList = ztblPlantHistory.iePlantHistory.Where(r => (r.EventID.ToString() == "15") && (r.PlantID.ToString() == xplantid));
            var xOrdered = xImageList.OrderByDescending(x => x.ID);

            //Find previous record
            var xPreviousRec = new tblPlantHistory();
            foreach (var ARec in xOrdered)
            {
                if (ARec.ID < Convert.ToInt32(xplanthistoryid))
                {
                    xPreviousRec = ARec;
                    break;
                }
            }

            if (xPreviousRec.Data == null)
            {
                xOrdered = xImageList.OrderBy(x => x.ID);
                xPreviousRec = xOrdered.FirstOrDefault();
            }

            return PartialView("_PlantImage", xPreviousRec);
        }

        public PartialViewResult NextImage(string xplantid, string xplanthistoryid)
        {
            //Get recs for images for this plant
            ztblPlantHistory.LoadData(Convert.ToInt32(xplantid));

            var xImageList = ztblPlantHistory.iePlantHistory.Where(r => (r.EventID.ToString() == "15") && (r.PlantID.ToString() == xplantid));
            var xOrdered = xImageList.OrderBy(x => x.ID);

            //Find previous record
            var xNextRec = new tblPlantHistory();
            foreach (var ARec in xOrdered)
            {
                if (ARec.ID > Convert.ToInt32(xplanthistoryid))
                {
                    xNextRec = ARec;
                    break;
                }
            }

            if (xNextRec.Data == null)
            {
                xOrdered = xImageList.OrderByDescending(x => x.ID);
                xNextRec = xOrdered.FirstOrDefault();
            }

            return PartialView("_PlantImage", xNextRec);
        }

    }
}