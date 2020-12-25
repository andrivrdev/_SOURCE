﻿using Newtonsoft.Json;
using Shared.CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialRankAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult VerifyEmail(string xData)
        {
            try
            {
                if (!(xData is null))
                {
                    if (xData != "")
                    {
                        var xMessage = xData;

                        clsSE xclsSE = new clsSE();
                        xMessage = xclsSE.DecodeMessage(xMessage);

                        //Validate an email address
                        if (xMessage.Contains("ValidateUserEmail" + clsGlobal.gMessageCommandSeperator))
                        {
                            xMessage = xMessage.Replace("ValidateUserEmail" + clsGlobal.gMessageCommandSeperator, "");
                            var dData = JsonConvert.DeserializeObject<string>(xMessage);
                            var xResult = xclsSE.ValidateUserEmail(dData);

                            ViewBag.Message = xResult;
                            return View();
                        }


                        //Invalid
                        ViewBag.Message = "Failed";
                        return View();
                    }
                    else
                    {
                        ViewBag.Message = "Failed";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = "Failed";
                    return View();
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Message = "Failed";
                return View();
            }

        }
    }
}