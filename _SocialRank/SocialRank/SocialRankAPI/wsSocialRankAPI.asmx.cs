using CPShared;
using Newtonsoft.Json;
using Shared.CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using static CPShared.clsGlobal;

namespace SocialRankAPI
{
    /// <summary>
    /// Summary description for wsSocialRankAPI
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class wsSocialRankAPI : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string DoWork(string xData)
        {
            clsCPShared xclsCPShared = new clsCPShared();
            xclsCPShared.DoLog(gLogLevel.INFO, "API Dowork: xData RAW=" + xData);

            try
            {
                if (!(xData is null))
                {
                    if (xData != "")
                    {
                        var xMessage = xData;

                        //Test
                        if (xMessage == "Test")
                        {
                            return "Success! Test received.";
                        }


                        clsSE xclsSE = new clsSE();
                        xMessage = xclsSE.DecodeMessage(xMessage);

                        xclsCPShared.DoLog(gLogLevel.INFO, "API Dowork: xData Decoded=" + xMessage);

                        //Register a new user
                        if (xMessage.Contains("frmRegister_RegisterUser" + clsGlobal.gMessageCommandSeperator))
                        {
                            xMessage = xMessage.Replace("frmRegister_RegisterUser" + clsGlobal.gMessageCommandSeperator, "");
                            var dData = JsonConvert.DeserializeObject<List<string>>(xMessage);
                            var xResult = xclsSE.frmRegister_RegisterUser(dData);
                            return xResult;
                        }

                        //Validate an email address
                        if (xMessage.Contains("ValidateUserEmail" + clsGlobal.gMessageCommandSeperator))
                        {
                            xMessage = xMessage.Replace("ValidateUserEmail" + clsGlobal.gMessageCommandSeperator, "");
                            var dData = JsonConvert.DeserializeObject<string>(xMessage);
                            var xResult = xclsSE.ValidateUserEmail(dData);
                            return xResult;
                        }

                        //Send reset password link
                        if (xMessage.Contains("frmForgotPassword_ResetPassword" + clsGlobal.gMessageCommandSeperator))
                        {
                            xMessage = xMessage.Replace("frmForgotPassword_ResetPassword" + clsGlobal.gMessageCommandSeperator, "");
                            var dData = JsonConvert.DeserializeObject<List<string>>(xMessage);
                            var xResult = xclsSE.frmForgotPassword_ResetPassword(dData);
                            return xResult;
                        }

                        //Resend activation link
                        if (xMessage.Contains("frmResendActivationEmail_Resend" + clsGlobal.gMessageCommandSeperator))
                        {
                            xMessage = xMessage.Replace("frmResendActivationEmail_Resend" + clsGlobal.gMessageCommandSeperator, "");
                            var dData = JsonConvert.DeserializeObject<List<string>>(xMessage);
                            var xResult = xclsSE.frmResendActivationEmail_Resend(dData);
                            return xResult;
                        }

                        //Get Password Reset Code
                        if (xMessage.Contains("frmForgotPassword_GetCode" + clsGlobal.gMessageCommandSeperator))
                        {
                            xMessage = xMessage.Replace("frmForgotPassword_GetCode" + clsGlobal.gMessageCommandSeperator, "");
                            var dData = JsonConvert.DeserializeObject<List<string>>(xMessage);
                            var xResult = xclsSE.frmForgotPassword_GetCode(dData);
                            return xResult;
                        }

                        //frmResendActivationEmail_Resend
                        //Invalid
                        return "Invalid command";
                    }
                    else
                    {
                        return "Empty string received";
                    }
                }
                else
                {
                    return "Null Received";
                }
            }
            catch (Exception Ex)
            {
                return "Error:" + Ex.Message;
            }
        }
    }
}
