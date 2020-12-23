using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
            /// <summary>
            /// Execute a Soap WebService call
            /// </summary>
            public void Execute()
            {
                HttpWebRequest request = CreateWebRequest();
                XmlDocument soapEnvelopeXml = new XmlDocument();
                soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                  <soap:Body>
                    <HelloWorld xmlns=""http://tempuri.org/"" />
                  </soap:Body>
                </soap:Envelope>");

                using (Stream stream = request.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }

                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        string soapResult = rd.ReadToEnd();
                        lblResult.Text = soapResult;
                        lblRes2.Text = ParseSoapResponse(soapResult);
                }
                }
            }
            /// <summary>
            /// Create a soap webrequest to [Url]
            /// </summary>
            /// <returns></returns>
            public HttpWebRequest CreateWebRequest()
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://52.186.136.188/API/wsAPI.asmx?op=HelloWorld");
                webRequest.Headers.Add(@"SOAP:Action");
                webRequest.ContentType = "text/xml;charset=\"utf-8\"";
                webRequest.Accept = "text/xml";
                webRequest.Method = "POST";
                return webRequest;
            }

         
        



        private async void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.wsAPISoapClient wsAPISoapClient = new ServiceReference1.wsAPISoapClient();
            lblResult.Text = wsAPISoapClient.HelloWorld();




            

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await Hello(new Uri(@"http://52.186.136.188/API/wsAPI.asmx"));
        }

        public async Task<string> Hello(Uri uri)
        {
            var soapString = this.ConstructSoapRequest();

            var xStatic = @"<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:tem='http://tempuri.org/'>
   < soapenv:Header />
 
    < soapenv:Body >
  
        < tem:HelloWorld />
   
      </ soapenv:Body >
    </ soapenv:Envelope > ";

            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Add("SOAPAction", "http://52.186.136.188/API/wsAPI.asmx");
                var content = new StringContent(xStatic, Encoding.UTF8, "text/xml");
                using (var response = await client.PostAsync(uri, content))
                {
                    var soapResponse = await response.Content.ReadAsStringAsync();
                    return this.ParseSoapResponse(soapResponse);
                }
            }
        }

        private string ConstructSoapRequest()
        {
            string xRequest = @"<soapenv:Envelope xmlns:soapenv=" + @"http://schemas.xmlsoap.org/soap/envelope/" + @"xmlns:tem=" + @"http://tempuri.org/" + @">
   < soapenv:Header />
 
    < soapenv:Body >
  
        < tem:HelloWorld />
   
      </ soapenv:Body >
    </ soapenv:Envelope >";

            /*
            return String.Format(@"<?xml version=""1.0"" encoding=""utf-8""?>
    <s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"">
        <s:Body>
            <Add xmlns=""http://CalculatorService/"">
                <a>{0}</a>
                <b>{1}</b>
            </Add>
        </s:Body>
    </s:Envelope>", a, b);*/
            return xRequest;
        }

        private string ParseSoapResponse(string response)
        {
            var soap = XDocument.Parse(response);
            XNamespace ns = "http://tempuri.org/";
            var result = soap.Descendants(ns + "HelloWorldResponse").First().Element(ns + "HelloWorldResult").Value;
            return result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Execute();
        }
    }
}
