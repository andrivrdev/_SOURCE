using SHARED;
using SHARED.CLASSES;
using SHARED.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MJ.Controllers
{
    [Authorize]
    public class StartController : Controller
    {

        // GET: Start
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string Name, string Password, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string xUsername = Convert.ToString(Name).ToUpper().Trim();
                string xPassword = Convert.ToString(Password);

                //Verify credentials against database
                tblCompany xtblCompany = new tblCompany();
                xtblCompany.LoadData();
                DataRow dr = xtblCompany.dtCompany.AsEnumerable().SingleOrDefault(r => r.Field<string>("Name").ToUpper().Trim() == xUsername);
                if (dr != null)
                {
                    if (xPassword == dr["Password"].ToString())
                    {
                        FormsAuthentication.SetAuthCookie(Name.ToUpper(), false);
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Home", "Index");
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
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult logOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }
    }
}