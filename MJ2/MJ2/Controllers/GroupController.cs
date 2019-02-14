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
            if (Session["gtblCompany_ID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            tblGroup xtblGroup = new tblGroup();
            xtblGroup.LoadData();
            
            var xFiltered = xtblGroup.ieGroup.Where(r => r.CompanyID.ToString() == Session["gtblCompany_ID"].ToString());
            var xOrdered = xFiltered.OrderBy(x => x.Code);

            ViewData["orderby"] = "Name";
            ViewData["ascendingdescending"] = "Ascending";

            return View(xOrdered);
        }

        [HttpPost]
        public ActionResult Index(string GroupID, string validation_Command, string validation_groupName, string validation_groupDescription, DateTime? validation_groupCreatedDateTime, string orderby, string ascendingdescending)
        {
            if (Session["gtblCompany_ID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

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
            var xOrdered = xFiltered.OrderBy(x => x.Code);

            if (ascendingdescending == "Ascending")
            {
                xOrdered = xFiltered.OrderBy(x => x.Code);
            }
            else
            {
                xOrdered = xFiltered.OrderByDescending(x => x.Code);
            }

            if (orderby == "Created Date")
            {
                if (ascendingdescending == "Ascending")
                {
                    xOrdered = xFiltered.OrderBy(x => x.CreatedDateTime);
                }
                else
                {
                    xOrdered = xFiltered.OrderByDescending(x => x.CreatedDateTime);
                }
            }

            if (orderby == "First Entry Date")
            {
                if (ascendingdescending == "Ascending")
                {
                    xOrdered = xFiltered.OrderBy(x => x.FirstEntryDateTime);
                }
                else
                {
                    xOrdered = xFiltered.OrderByDescending(x => x.FirstEntryDateTime);
                }
            }

            if (orderby == "Last Entry Date")
            {
                if (ascendingdescending == "Ascending")
                {
                    xOrdered = xFiltered.OrderBy(x => x.LastEntryDateTime);
                }
                else
                {
                    xOrdered = xFiltered.OrderByDescending(x => x.LastEntryDateTime);
                }
            }

            if (orderby == "Age")
            {
                if (ascendingdescending == "Ascending")
                {
                    xOrdered = xFiltered.OrderBy(x => x.Age);
                }
                else
                {
                    xOrdered = xFiltered.OrderByDescending(x => x.Age);
                }
            }

            if (orderby == "Amount of Plants")
            {
                if (ascendingdescending == "Ascending")
                {
                    xOrdered = xFiltered.OrderBy(x => x.PlantCount);
                }
                else
                {
                    xOrdered = xFiltered.OrderByDescending(x => x.PlantCount);
                }
            }










            ViewData["GroupID"] = GroupID;

            if (orderby == null)
            {
                ViewData["orderby"] = "Name'";
            }
            else
            {
                ViewData["orderby"] = orderby;
            }

            if (ascendingdescending == null)
            {
                ViewData["ascendingdescending"] = "Ascending'";
            }
            else
            {
                ViewData["ascendingdescending"] = ascendingdescending;
            }

            return View(xOrdered);
        }
    }
}