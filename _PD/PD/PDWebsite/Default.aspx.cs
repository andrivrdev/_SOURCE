using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PDWebsite {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        protected async Task<string> DoSearch()
        {
            Int32 fileLen = FileUpload1.PostedFile.ContentLength;

            // Create a byte array to hold the contents of the file.
            Byte[] buffer = new Byte[fileLen];

            // Initialize the stream to read the uploaded file.
            Stream s = FileUpload1.FileContent;

            // Read the file into the byte array.
            s.Read(buffer, 0, fileLen);

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
                            BootstrapMemo1.Text = xFound;
                            return "";
                        }

                    }

                }

            }


            return "";




        }
    }
}