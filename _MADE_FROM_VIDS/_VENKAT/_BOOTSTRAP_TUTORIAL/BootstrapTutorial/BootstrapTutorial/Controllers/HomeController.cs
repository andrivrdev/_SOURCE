using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;

namespace BootstrapTutorial.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmbeddedBootstrap()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ViewBag.Bootstrap3DocsLink = "http://" + ip.ToString() + "/Bootstrap3Docs/";
                }
            }

            return View();
        }
        
        public ActionResult NoCode()
        {
            return View();
        }

        public ActionResult Vid_003_BootstrapGridSystem()
        {
            return View();
        }
        
    }
}