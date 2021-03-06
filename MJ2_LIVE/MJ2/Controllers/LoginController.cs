﻿using SHARED.CLASSES;
using SHARED.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MJ2.Controllers
{
    public class LoginController : Controller
    {
        
        [AllowAnonymous]
        public ActionResult Test()
        {
            return View();
        }

        
        [AllowAnonymous]
        public ActionResult Test2()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Test2(string validation_Command, string takepic_0001)
        {
            return View();
        }



        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(tblCompany u, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string xUsername = Convert.ToString(u.Name).ToUpper().Trim();
                string xPassword = Convert.ToString(u.Password);

                clsSE xSE = new clsSE();
                xSE.WriteLog("Login.. [" + xUsername + "] [" + xPassword + "]");

                //Verify credentials against database
                tblCompany xtblCompany = new tblCompany();
                xtblCompany.LoadData();
                DataRow dr = xtblCompany.dtCompany.AsEnumerable().SingleOrDefault(r => r.Field<string>("Name").ToUpper().Trim() == xUsername);
                if (dr != null)
                {
                    if (xPassword == dr["Password"].ToString())
                    {
                        Session["gtblCompany_ID"] = dr["ID"];
                        Session["gtblCompany_Name"] = dr["Name"];

                        FormsAuthentication.SetAuthCookie(u.Name.ToUpper(), false);
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            if (!(returnUrl == "/" + SHARED.CLASSES.clsGlobal.gAppName + "/") && !(returnUrl == "/" + SHARED.CLASSES.clsGlobal.gAppName + "/Plant/Index"))
                            {
                                //return Redirect(returnUrl); FOR LATER USE
                                return RedirectToAction("Index", "Group");
                            }
                            else
                            {
                                return RedirectToAction("Index", "Group");
                            }
                        }
                        else
                        {
                            return RedirectToAction("Index", "Group");
                        }
                    }
                    else
                    {
                        ViewData["Error"] = "Invalid username or password.";
                    }
                }
                else
                {
                    ViewData["Error"] = "Invalid username or password.";
                }
            }
            return View(u);
        }
    }
}