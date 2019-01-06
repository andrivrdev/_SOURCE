using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MJ2.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult Index()
        {
            
            return View();
        }

          [HttpPost]
        public ActionResult Index(string GroupID)
        {

            ViewData["GroupID"] = GroupID;
            return View();
        }
    }
}