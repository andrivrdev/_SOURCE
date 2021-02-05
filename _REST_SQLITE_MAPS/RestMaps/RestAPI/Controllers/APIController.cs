using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        [HttpGet]
        public string CreateDB()
        {
            try
            {
                return clsSQLiteDB.Connect().ToString();

            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
        }

        [HttpPost]
        public string DoWork(string xData)
        {
            try
            {
                clsSQLiteDB.Connect();
                var dData = JsonConvert.DeserializeObject<clsAPIData>(xData);

                if (dData.Command == "AddLocation")
                {
                    var xLocation = JsonConvert.DeserializeObject<List<string>>(dData.Data);


                    List<string> fFields = new List<string>();
                    List<string> vValues = new List<string>();

                    fFields.Add("DeviceIdiom");
                    fFields.Add("DeviceModel");
                    fFields.Add("DeviceName");
                    fFields.Add("Latitude");
                    fFields.Add("Longitude");
                    fFields.Add("Altitude");

                    vValues.Add(xLocation[0]);
                    vValues.Add(xLocation[1]);
                    vValues.Add(xLocation[2]);
                    vValues.Add(xLocation[3]);
                    vValues.Add(xLocation[4]);
                    vValues.Add(xLocation[5]);

                    clsSQLiteDB.sqlInsertRec("tblLocation", fFields, vValues);

                    return xData;
                }

                return "Not Valid";

            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
        }
    }
}
