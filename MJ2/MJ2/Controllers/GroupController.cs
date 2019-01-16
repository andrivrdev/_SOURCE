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
        public ActionResult Index(string GroupID, string validation_Command, string validation_groupName, string validation_groupDescription, DateTime? validation_groupCreatedDateTime)
        {
            tblGroup xtblGroup;
            if (validation_Command == "CreateGroup")
            {
                xtblGroup = new tblGroup();
                xtblGroup.AddRec(Convert.ToInt32(Session["gtblCompany_ID"].ToString()), validation_groupName, validation_groupDescription, validation_groupCreatedDateTime);
            }

            if (validation_Command == "EditGroup")
            {
                xtblGroup = new tblGroup();
                xtblGroup.UpdateRec(Convert.ToInt32(GroupID), Convert.ToInt32(Session["gtblCompany_ID"].ToString()), validation_groupName, validation_groupDescription, validation_groupCreatedDateTime);
            }

            if (validation_Command == "GotoPlants")
            {
                Session["GroupID"] = GroupID;
                return RedirectToAction("Index", "Plant");

            }


            xtblGroup = new tblGroup();
            xtblGroup.LoadData();

            var xFiltered = xtblGroup.ieGroup.Where(r => r.CompanyID.ToString() == Session["gtblCompany_ID"].ToString());

            ViewData["GroupID"] = GroupID;
            return View(xFiltered);
        }
    }
}