using Shared.CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SocialRankAPI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            try
            {
                clsSE xclsSE = new clsSE();
                if (!(xclsSE.sqlCheckIfDBExist(clsGlobal.gDBServer, clsGlobal.gDBDatabase, clsGlobal.gDBUser, clsGlobal.gDBPassword)))
                {
                    xclsSE.sqlCreateDatabase(clsGlobal.gDBServer, clsGlobal.gDBDatabase, clsGlobal.gDBUser, clsGlobal.gDBPassword, clsGlobal.gAppSQL);
                }
            }
            catch
            {

            }
        }
    }
}
