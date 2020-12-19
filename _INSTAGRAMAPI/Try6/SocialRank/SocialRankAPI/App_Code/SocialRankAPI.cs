using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for SocialRankAPI
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class SocialRankAPI : System.Web.Services.WebService
{

    public SocialRankAPI()
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


                var xMessage = xData;

                //Test
                if (xMessage.Contains("Test"))
                {
                    return "Test received";
                }


                //Create DB
                var xResultDB = clsSQLiteDBAPI.CreateDB();
                if (xResultDB == "Success")
                {
                    clsSEAPI xclsSEAPI = new clsSEAPI();
                    xMessage = xclsSEAPI.DecodeMessage(xMessage);


                    //Register a new user
                    if (xMessage.Contains("frmRegister_RegisterUser" + clsGlobalAPI.gMessageCommandSeperator))
                    {
                        xMessage = xMessage.Replace("frmRegister_RegisterUser" + clsGlobalAPI.gMessageCommandSeperator, "");
                        var dData = JsonConvert.DeserializeObject<List<string>>(xMessage);
                        var xResult = xclsSEAPI.frmRegister_RegisterUser(dData);
                        return xResult;
                    }

                    /*
                    //Validate an email address
                    if (xMessage.Contains("ValidateUserEmail" + clsGlobalAPI.gMessageCommandSeperator))
                    {
                        xMessage = xMessage.Replace("ValidateUserEmail" + clsGlobalAPI.gMessageCommandSeperator, "");
                        var dData = JsonConvert.DeserializeObject<string>(xMessage);
                        var xResult = xclsSEAPI.ValidateUserEmail(dData);
                        return xResult;
                    }

                    //Send reset password link
                    if (xMessage.Contains("frmForgotPassword_ResetPassword" + clsGlobalAPI.gMessageCommandSeperator))
                    {
                        xMessage = xMessage.Replace("frmForgotPassword_ResetPassword" + clsGlobalAPI.gMessageCommandSeperator, "");
                        var dData = JsonConvert.DeserializeObject<List<string>>(xMessage);
                        var xResult = xclsSEAPI.frmForgotPassword_ResetPassword(dData);
                        return xResult;
                    }
                    */







                    //Invalid
                    return "Invalid command";
                }
                else
                {
                    return "Error with database:" + xResultDB;
                }
            }
            else
            {
                //No Data passed
                return "Data was null";
            }

        }
        catch (Exception Ex)
        {
            return "Failed: " + Ex.Message;
        }
    }



}
