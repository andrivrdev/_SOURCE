using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared;
using Soulseek;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace PDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        [HttpPost]
        public async Task<string> DoWork(string xData)
        {
            try
            {
                var toDecode = xData;
                toDecode = toDecode.Remove(0, 1);

                clsSE xSE = new clsSE();

                //Check if compressed
                if (xData[0] == '1')
                {
                    //Decompress
                    toDecode = xSE.DecompressString(toDecode);
                }

                //Decrypt
                toDecode = xSE.Decrypt(toDecode);

                //clsSQLiteDB.Connect();
                var dData = JsonConvert.DeserializeObject<clsAPIData>(toDecode);

                if (dData.Command == "SearchSong")
                {
                    var xSearch = JsonConvert.DeserializeObject<List<string>>(dData.Data);
                    string aSearch = xSearch[0];

                    string xResult = "";


                    var responses = await clsSSClient.zSSClient.SearchAsync(SearchQuery.FromText(aSearch));

                    if (responses.Responses.Count == 0)
                    {
                        string output = Regex.Replace(aSearch, @"\d{2,}", "");
                        output = Regex.Replace(output, @"\d", "");

                        List<string> or = output.Split(' ').ToList();
                        List<string> nor = new List<string>();

                        foreach (string s in or)
                        {

                            if (s.Length != 1)
                            {
                                nor.Add(s);
                            }

                        }

                        var rs = String.Join(" ", nor.ToArray());

                        aSearch = rs;

                        responses = await clsSSClient.zSSClient.SearchAsync(SearchQuery.FromText(aSearch));
                    }

                    int xCount = 0;


                    foreach (var r in responses.Responses)
                    {
                        int xCount2 = 0;
                        foreach (var f in r.Files)
                        {

                            xResult += r.QueueLength.ToString() + "**||**" + r.UploadSpeed.ToString() + "**||**" + f.BitRate.ToString() + "**||**" + f.Size.ToString() + "**||**" + f.Length.ToString() + "**||**" + f.Extension + "**||**" + f.Filename.ToString() + Environment.NewLine;

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
