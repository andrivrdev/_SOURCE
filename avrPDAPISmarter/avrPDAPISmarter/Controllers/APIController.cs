using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;

namespace avrPDAPISmarter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        [HttpPost]
        public string DoWork(string xData)
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
                    SearchOptions searchOptions = new SearchOptions(5000, 250, true, 1, 5, 0, 25000, true);


                    var responses = clsSSClient.zSSClient.SearchAsync(SearchQuery.FromText(aSearch), null, null, searchOptions);
                    responses.Wait();
                    if (responses.Result.Responses.Count == 0)
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
                        responses = clsSSClient.zSSClient.SearchAsync(SearchQuery.FromText(aSearch), null, null, searchOptions);
                        responses.Wait();

                    }

                    int xCount = 0;

                    bool xdodl = true;
                    foreach (var r in responses.Result.Responses)
                    {
                        int xCount2 = 0;
                        foreach (var f in r.Files)
                        {
                            if (xdodl)
                            {
                                var cts = new CancellationTokenSource();

                                var completedTransfer = clsSSClient.zSSClient.DownloadAsync(
                            username: r.Username,
                            remoteFilename: f.Filename,
                            outputStreamFactory: () => Task.FromResult(clsGlobal.GetLocalFileStream(f.Filename, @"C:\ssf\")),
                            size: f.Size,
                            startOffset: 0,
                            token: null,
                            cancellationToken: cts.Token
                            );
                                while ((completedTransfer.Result.State == TransferStates.Queued) || (completedTransfer.Result.State == TransferStates.InProgress))
                                {
                                    Thread.Sleep(1000);
                                }
                            }
                            /*
                                                        while ((completedTransfer.State == TransferStates.Queued) || (completedTransfer.State == TransferStates.InProgress))
                                                        {
                                                            Thread.Sleep(1000);
                                                        }
                            */


                            // byte[] dlfile = clsSSClient.zSSClient.DownloadAsync(r.Username, f.Filename, @"c:\" + Path.GetFileNameWithoutExtension(f.Filename) + ".mp3", f.Size).Result.;
                            //   var fs = new FileStream(@"c:\" + Path.GetFileNameWithoutExtension(f.Filename) + ".mp3", FileMode.Create);
                            //  (username: "some username", filename: "some fully qualified filename", outputStream: fs, size: 42);


                            //  await clsSSClient.zSSClient.DownloadAsync(r.Username, f.Filename, @"c:\" + Path.GetFileNameWithoutExtension(f.Filename) + ".mp3", 42);

                            //   (r.Username, f.Filename, fs.Name , 42);

                            xResult += r.QueueLength.ToString() + "**||**" + r.UploadSpeed.ToString() + "**||**" + f.BitRate.ToString() + "**||**" + f.Size.ToString() + "**||**" + f.Length.ToString() + "**||**" + f.Extension + "**||**" + f.Filename.ToString() + Environment.NewLine;
                            xdodl = false;


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
