using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoWorkController : ControllerBase
    {
        // GET: api/<DoWorkController>
        [HttpGet("{Data}")]
        public string Get(string Data)
        {
            var xMessage = Data;

            clsSE xclsSE = new clsSE();
            xMessage = xclsSE.DecodeMessage(xMessage);

            //Test
            if (xMessage.Contains("Test" + clsGlobal.gMessageCommandSeperator))
            {
                return xclsSE.EncodeMessage("Success", "Test received");
            }

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
            return xclsSE.EncodeMessage("Error", "Invalid command");
        }

        /*
        // GET: api/<DoWorkController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DoWorkController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        */
        // POST api/<DoWorkController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DoWorkController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DoWorkController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
