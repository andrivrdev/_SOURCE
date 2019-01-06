using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using SHARED.CLASSES;

namespace MJ
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
        }
    }
}
