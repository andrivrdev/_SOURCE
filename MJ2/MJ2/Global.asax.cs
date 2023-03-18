﻿using SHARED.CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace MJ2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start(object sender, EventArgs e)
        {
            // your code here, it will be executed upon session start
            DoInit();
        }
        protected void DoInit()
        {
            //Load globals
            Session["gConnectionString"] = clsGlobal.gConnectionString;
            Session["gCompanyID"] = clsGlobal.gCompanyID;

            //Get conn details
            string xConnStr = clsGlobal.gConnectionString;
            string[] xPars = xConnStr.Split(';');

            string xServer = "";
            string xDatabase = "";
            string xUserID = "";
            string xPassword = "";

            foreach (string xRec in xPars)
            {
                if (xRec.Contains("Server"))
                {
                    var xTemp = xRec.Split('=');
                    xServer = xTemp[1];
                }
                if (xRec.Contains("Database"))
                {
                    var xTemp = xRec.Split('=');
                    xDatabase = xTemp[1];
                }
                if (xRec.Contains("User ID"))
                {
                    var xTemp = xRec.Split('=');
                    xUserID = xTemp[1];
                }
                if (xRec.Contains("Password"))
                {
                    var xTemp = xRec.Split('=');
                    xPassword = xTemp[1];
                }
            }

            //Check if DB Exists
            clsSE xSE = new clsSE();
            if (!xSE.sqlCheckIfDBExist(xServer, xDatabase, xUserID, xPassword))
            {
                //Create the database
                xSE.sqlCreateDatabase(xServer, xDatabase, xUserID, xPassword);

            }

        }
    }
}
