using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using PDAPI.Models;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;
using Shared;
using ATL;

namespace PDAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> UploadFile(List<IFormFile> postedFiles)
        {
            string xres =  "QueueLength" + "**||**" + "UploadSpeed" + "**||**" + "BitRate" + "**||**" + "Size" + "**||**" + "Length" + "**||**" + "Extension" + "**||**" + "Filename" + Environment.NewLine;

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);

                long fileLen = postedFile.Length;

                // Create a byte array to hold the contents of the file.
                var s = new MemoryStream();
                postedFile.CopyTo(s);
                var buffer = s.ToArray();

                // Initialize the stream to read the uploaded file.
                // Convert byte array into characters.
                ASCIIEncoding enc = new ASCIIEncoding();
                string str = enc.GetString(buffer);
                clsSE SE = new clsSE();

                List<string> list = new List<string>(Regex.Split(str, Environment.NewLine));

                if (list[0] == "#EXTM3U")
                {
                    foreach (string aLine in list)
                    {
                        if (aLine.Length >= 8)
                        {
                            if (aLine.Substring(0, 8) == "#EXTINF:")
                            {
                                string xSearch = aLine.Replace("#EXTINF:", "");

                                Regex regex = new Regex("[^a-zA-Z0-9]");
                                xSearch = regex.Replace(xSearch, " ");

                                String[] spearator = { " ", "," };
                                Int32 count = 20;

                                // using the method
                                String[] strlist = xSearch.Split(spearator, count,
                                       StringSplitOptions.RemoveEmptyEntries);

                                string xKeywords = "";
                                foreach (String aWord in strlist)
                                {
                                    xKeywords += aWord + " ";
                                }

                                Task<string> xFound = SE.DoPost("SearchSong", xKeywords);
                                xFound.Wait();

                                if (xFound != null)
                                {

                                    if (xFound.Result != "")
                                    {
                                        xres = xres + xFound.Result + Environment.NewLine;
                                    }
                                }
                            }

                        }

                    }

                    Random random = new Random();

                    System.IO.File.WriteAllText((@"C:\" + random.Next(200).ToString() + " - WriteLines.csv"), xres);


                    // Adapt this to whatever your file path needs to be
                    /*
                    string fileName = "C:/temp/MP3/test.mp3";

                    // Load audio file information into memory
                    Track theTrack = new Track(fileName);


                    // That's it ! Now try and display classic 'supported' fields
                    System.Console.WriteLine("Title : " + theTrack.Title);
                    System.Console.WriteLine("Artist : " + theTrack.Artist);
                    System.Console.WriteLine("Album : " + theTrack.Album);
                    System.Console.WriteLine("Recording year : " + theTrack.Year);
                    System.Console.WriteLine("Track number : " + theTrack.TrackNumber);
                    System.Console.WriteLine("Disc number : " + theTrack.DiscNumber);
                    System.Console.WriteLine("Genre : " + theTrack.Genre);
                    System.Console.WriteLine("Comment : " + theTrack.Comment);

                    System.Console.WriteLine("Duration (s) : " + theTrack.Duration);
                    System.Console.WriteLine("Bitrate (KBps) : " + theTrack.Bitrate);
                    System.Console.WriteLine("Number of channels : " + theTrack.ChannelsArrangement.NbChannels);

                    System.Console.WriteLine("Channels arrangement : " + theTrack.ChannelsArrangement.Description);


                    System.Console.WriteLine("Has variable bitrate audio : " + (theTrack.IsVBR ? "yes" : "no"));
                    System.Console.WriteLine("Has lossless audio : " + (AudioDataIOFactory.CF_LOSSLESS == theTrack.CodecFamily ? "yes" : "no"));

                    */
                    /*
                    StreamWriter file = new(@"C:\" + random.Next(200).ToString() + " - WriteLines.csv")
                    
                        List<string> xxlist = new List<string>(Regex.Split(xres, Environment.NewLine));

                        xxlist = xxlist.Distinct().ToList();

                        foreach (string aaa in xxlist)
                        {
                            if (aaa.Length > 0)
                            {
                                file.Write(aaa);
                            }
                        }
                    }

                    file.
                    */




                    return xres;


                }

            }

            return "AAA";
        }
 


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}