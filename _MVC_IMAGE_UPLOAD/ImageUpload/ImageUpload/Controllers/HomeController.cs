using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1()
        {
            var db = new ImageUploadEntities();
            var recs = (from r in db.tblImage
                        select r).ToList();

            return View(recs);
        }

        public ActionResult AddImage()
        {
            tblImage xtblImage = new tblImage();
            return View(xtblImage);
        }

        [HttpPost]
        public ActionResult AddImage(tblImage xtblImage, HttpPostedFileBase xImage1)
        {
            var db = new ImageUploadEntities();

            if (xImage1 != null)
            {
                xtblImage.Image = new byte[xImage1.ContentLength];
                xImage1.InputStream.Read(xtblImage.Image, 0, xImage1.ContentLength);
            }

            db.tblImage.Add(xtblImage);
            db.SaveChanges();
            return View(xtblImage);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}