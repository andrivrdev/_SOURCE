using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Try1.DATA;
using Try1.CLASSES;
using System.IO;
using Newtonsoft.Json;

namespace Try1
{
    public partial class Form1 : Form
    {



        List<tblTemp> zHTML = new List<tblTemp>();

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            Uri uri = new Uri(CLASSES.clsGlobal.g_URL);
            webBrowser1.Url = uri;

            //webBrowser1.re

          //  var responseString = await CLASSES.clsGlobal.client.GetStringAsync("https://api.instagram.com/oauth/authorize?client_id=1101018996984145&redirect_uri=https://avrdev001.azurewebsites.net/&scope=user_profile,user_media&response_type=code");
         //   textBox1.Text = responseString;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            /*
            string param1 = HttpUtility.ParseQueryString(webBrowser1.Url.Query).Get("code");
            textBox1.Text = webBrowser1.Url.ToString();
            textBox1.Text = param1;

            tblToken xtblToken = new tblToken();

            xtblToken = xtblToken.GetTokenAndUserIdFromCode(clsGlobal.g_URI_access_token, clsGlobal.g_client_id, clsGlobal.g_client_secret, clsGlobal.g_redirect_uri, param1);
            textBox2.Text = xtblToken.access_token;

            tblTemp xtblTemp = new tblTemp();
            xtblTemp.Field01 = webBrowser1.Url.ToString();
            xtblTemp.Field02 = webBrowser1.DocumentText;


            zHTML.Add(xtblTemp);

            using (StreamWriter file = File.CreateText(@"c:\HTML.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, zHTML);
            }
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://api.instagram.com/oauth/access_token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("client_id", "1101018996984145");
            request.AddParameter("client_secret", "a3eac22d8a35bb4400e1de27b46a415b");
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("redirect_uri", "https://avrdev001.azurewebsites.net/");
            request.AddParameter("code", "AQDisdGCIAvNAyeQ06vkJF4DpkYZMcV8kfKs97prU2yunsC9b4nBJ28TBRuED5drzQvus9vhuvFqm6_0yhF0h6pLqCIq6pp0t8ZzTi0vQn-8SpSbcCMVW78VMiKyow9klcuQaChpeJqdPaCT2wiQCY7feuulDJaEF6y94_h5bFOmHb0jCdasavkE2D62_KNZvNRgG5R5zSDTx_GhcRsbi5rBElv_2VSU89fSu61SKPtw8A");
            IRestResponse response = client.Execute(request);

            textBox2.Text = response.Content;
            //Console.WriteLine(response.Content);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tblToken xtblToken = new tblToken();

            xtblToken = xtblToken.GetTokenAndUserIdFromCode(clsGlobal.g_URI_access_token, clsGlobal.g_client_id, clsGlobal.g_client_secret, clsGlobal.g_redirect_uri, edtCode.Text);
            textBox2.Text = xtblToken.access_token;
        }

        private void timCheckForCode_Tick(object sender, EventArgs e)
        {
            if (edtToken.Text == "")
            {
                if (!(webBrowser1.Url is null))
                {
                    string xCode = HttpUtility.ParseQueryString(webBrowser1.Url.Query).Get("code");

                    if (!(xCode is null))
                    {
                        tblToken xtblToken = new tblToken();

                        xtblToken = xtblToken.GetTokenAndUserIdFromCode(clsGlobal.g_URI_access_token, clsGlobal.g_client_id, clsGlobal.g_client_secret, clsGlobal.g_redirect_uri, xCode);
                        edtToken.Text = xtblToken.access_token;

                        using (StreamWriter file = File.CreateText(@"c:\GetTokenAndUserIdFromCode.json"))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Serialize(file, xtblToken);
                        }
                    }
                }
            }



        }
    }
}
