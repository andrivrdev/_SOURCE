using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using PDAPI.Models;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;
using Shared;

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
                /*
                            System.IO.Stream myStream;
                            Int32 fileLen;
                            StringBuilder displayString = new StringBuilder();

                            // Get the length of the file.
                            fileLen = FileUpload1.PostedFile.ContentLength;

                            // Display the length of the file in a label.
                            //LengthLabel.Text = "The length of the file is " +
                            //                   fileLen.ToString() + " bytes.";

                            // Create a byte array to hold the contents of the file.
                            Byte[] Input = new Byte[fileLen];

                            // Initialize the stream to read the uploaded file.
                            myStream = FileUpload1.FileContent;

                            // Read the file into the byte array.
                            myStream.Read(Input, 0, fileLen);

                            // Copy the byte array to a string.
                            for (int loop1 = 0; loop1 < fileLen; loop1++)
                            {
                                displayString.Append(Input[loop1].ToString());
                            }

                            */
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

                                var xFound = await SE.DoPost("SearchSong", xKeywords);

                                int xxx = 1;
                            }

                        }

                    }

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