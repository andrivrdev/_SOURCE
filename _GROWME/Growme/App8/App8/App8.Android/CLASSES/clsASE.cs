﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Shared.CLASSES;

namespace App8.Droid.CLASSES
{
    public class clsASE
    {
        public string Send(string xCommand, Object xObject)
        {
            try
            {
                clsSE xclsSE = new clsSE();
                var xData = xclsSE.EncodeMessage(xCommand, xObject);

                //Send
                var remoteAddress = clsGlobal.gEndpointAddress;

                using (var xwsServerSoapClient = new Droid.wsGrowmeAPI.GrowmeWS())
                {
                    //set timeout
                    xwsServerSoapClient.Url = remoteAddress;
                    xwsServerSoapClient.Timeout = clsGlobal.gSoapCallTimeout;

                    //call web service method
                    var xResponse = xwsServerSoapClient.DoWork(xData);

                    return xResponse;
                }
            }
            catch (Exception Ex)
            {
                return "";
            }
        }

    }
}