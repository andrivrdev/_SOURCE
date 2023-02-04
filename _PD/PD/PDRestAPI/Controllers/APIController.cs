using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared;
using Soulseek;

namespace PDRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        SoulseekClient client = new SoulseekClient();

        public APIController()
        {
            var x = client.ConnectAsync("andrivr@gmail.com", "passNEWm.3");
        }

        [HttpGet]
        public string CreateDB()
        {
            try
            {
                //return clsSQLiteDB.Connect().ToString();
                return "";

            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
        }

        [HttpPost]
        public async Task<string> DoWork(string xData)
        {
            try
            {
                //clsSQLiteDB.Connect();
                var dData = JsonConvert.DeserializeObject<clsAPIData>(xData);

                if (dData.Command == "SearchSong")
                {
                    //await client.ConnectAsync("andrivr@gmail.com", "passNEWm.3");

                    var xSearch = JsonConvert.DeserializeObject<List<string>>(dData.Data);
                    string aSearch = xSearch[0];

                    string xResult = "";



                    var responses = await client.SearchAsync(SearchQuery.FromText(aSearch));

                    int xCount = 0;
                    foreach (var r in responses.Responses)
                    {
                        int xCount2 = 0;
                        foreach (var f in r.Files)
                        {
                            xResult += f.Filename.ToString() + Environment.NewLine;

                            xCount = xCount + 1;
                            if (xCount2 > 10)
                            {
                                break;
                            }

                        }

                        xCount = xCount + 1;
                        if (xCount > 10)
                        {
                            break;
                        }
                    }


                    /*

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
                                        */
                    return xResult;
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
