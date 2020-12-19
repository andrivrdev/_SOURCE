using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SocialRankAPI.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialRankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoWorkController : ControllerBase
    {
        [HttpGet]
        public string Get(string xData)
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
}
