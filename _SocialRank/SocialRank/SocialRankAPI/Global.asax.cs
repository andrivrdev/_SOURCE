using CPShared;
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
                clsLogger xclsLogger = new clsLogger();
                //xclsCPShared.DoError(Ex);

                clsSE xclsSE = new clsSE();
                if (!(xclsSE.sqlCheckIfDBExist(clsGlobal.gDBServer, clsGlobal.gDBDatabase, clsGlobal.gDBUser, clsGlobal.gDBPassword)))
                {
                    xclsSE.sqlCreateDatabase(clsGlobal.gDBServer, clsGlobal.gDBDatabase, clsGlobal.gDBUser, clsGlobal.gDBPassword, clsGlobal.gAppSQL);
                }
                if (!(xclsSE.sqlCheckIfDBExist(clsGlobal.gDBServer, clsGlobal.gDBDatabase + "Errors", clsGlobal.gDBUser, clsGlobal.gDBPassword)))
                {
                    xclsSE.sqlCreateDatabase(clsGlobal.gDBServer, clsGlobal.gDBDatabase + "Errors", clsGlobal.gDBUser, clsGlobal.gDBPassword, clsGlobal.gErrorSQL);
                }
            }
            catch (Exception Ex)
            {
                clsCPShared xclsCPShared = new clsCPShared();
                xclsCPShared.DoError(Ex);


            }

        }
    }
}
