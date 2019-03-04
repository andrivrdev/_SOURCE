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
        tblPlant ztblPlant = new tblPlant();
        tblPlantHistory ztblPlantHistory = new tblPlantHistory();




        // GET: Plant
        public ActionResult Index()
        {
            if (Session["GroupID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            tblPlant xtblPlant = new tblPlant();
            xtblPlant.LoadData(Convert.ToInt32(Session["GroupID"]), 1, false);

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

            if (xcommand == "Delete")
            {
                xtblPlant = new tblPlant();
                xtblPlant.DeleteRec(Convert.ToInt32(xplantid));
            }


            xtblPlant = new tblPlant();
            xtblPlant.LoadData(Convert.ToInt32(Session["GroupID"]), 1, false);

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

        [HttpPost]

        public PartialViewResult AddImage(string xplantid, string xcompressedimage, string xx)
        {
            if (xcompressedimage != null)
            {
                string scompressedpic = xcompressedimage.Replace(@"data:image/png;base64,", "");

                ztblPlantHistory.AddRec(Convert.ToInt32(xplantid), "15", scompressedpic, null, true);
            }


            //Get recs for images for this plant
            ztblPlantHistory.LoadData(Convert.ToInt32(xplantid));

            var xImageList = ztblPlantHistory.iePlantHistory.Where(r => (r.EventID.ToString() == "15") && (r.PlantID.ToString() == xplantid));
            var xOrdered = xImageList.OrderByDescending(x => x.ID);

            //Find previous record
            var xPreviousRec = new tblPlantHistory();
            foreach (var ARec in xOrdered)
            {
                if (ARec.ID < int.MaxValue)
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

        [HttpPost]
        public PartialViewResult DeleteImage(string xplantid, string xplanthistoryid)
        {

            ztblPlantHistory.DeleteRec(Convert.ToInt32(xplanthistoryid));

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

            if (xPreviousRec == null)
            {
                ViewData["item.ID"] = xplantid;
                ViewData["divpic"] = "divpic_" + xplantid;
                ViewData["divloadinganimation"] = "divloadinganimation_" + xplantid;
                ViewData["previousactionid"] = "previousactionid_" + xplantid;

                return PartialView("_PlantNoImage");
            }
            else
            {
                return PartialView("_PlantImage", xPreviousRec);
            }
        }


        public PartialViewResult RefreshData(string xplantid, string xcount)
        {

            ztblPlant.LoadData(Convert.ToInt32(xplantid), 0, false);
            ViewData["xCount"] = xcount;
            return PartialView("_PlantData", ztblPlant);
        }

        [HttpPost]
        public PartialViewResult AddInspected(string xplantid, string xcount)
        {
            
            ztblPlantHistory.AddRec(Convert.ToInt32(xplantid), "9", null, null, false);
            ztblPlant.LoadData(Convert.ToInt32(xplantid), 0, false);
            ViewData["xCount"] = xcount;
            return PartialView("_PlantData", ztblPlant);
        }

        [HttpPost]
        public PartialViewResult AddWatered(string xplantid, string xcount)
        {

            ztblPlantHistory.AddRec(Convert.ToInt32(xplantid), "10", null, null, false);
            ztblPlant.LoadData(Convert.ToInt32(xplantid), 0, false);
            ViewData["xCount"] = xcount;
            return PartialView("_PlantData", ztblPlant);
        }

        [HttpPost]
        public PartialViewResult AddNote(string xplantid, string xnote, string xcount)
        {

            ztblPlantHistory.AddRec(Convert.ToInt32(xplantid), "27", xnote, null, false);
            ztblPlant.LoadData(Convert.ToInt32(xplantid), 0, false);
            ViewData["xCount"] = xcount;
            return PartialView("_PlantData", ztblPlant);
        }

        [HttpPost]
        public PartialViewResult Edit(string xplantid, string xcount, string xname, DateTime? xcreateddatetime)
        {
            ztblPlant.UpdateRec(Convert.ToInt32(xplantid), Convert.ToInt32(Session["GroupID"].ToString()), xname, xcreateddatetime);
            ztblPlant.LoadData(Convert.ToInt32(xplantid), 0, false);
            ViewData["xCount"] = xcount;
            return PartialView("_PlantData", ztblPlant);
        }
    }
}