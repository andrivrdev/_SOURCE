using SHARED.DATA;
using System;
using System.Collections.Generic;
using System.Data;
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
            tblGroup xtblGroup = new tblGroup();
            xtblGroup.LoadData();
            
            var xFiltered = xtblGroup.ieGroup.Where(r => r.CompanyID.ToString() == Session["gtblCompany_ID"].ToString());

            return View(xFiltered);
        }

          [HttpPost]
        public ActionResult Index(string GroupID)
        {
            tblGroup xtblGroup = new tblGroup();
            xtblGroup.LoadData();

            var xFiltered = xtblGroup.ieGroup.Where(r => r.CompanyID.ToString() == Session["gtblCompany_ID"].ToString());

            ViewData["GroupID"] = GroupID;
            return View(xFiltered);
        }
    }
}