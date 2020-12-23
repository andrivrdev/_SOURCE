using Newtonsoft.Json;
using Shared.CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for wsSocialRankAPI
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class wsSocialRankAPI : System.Web.Services.WebService
{

    public wsSocialRankAPI()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string DoWork(string xData)
    {
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
