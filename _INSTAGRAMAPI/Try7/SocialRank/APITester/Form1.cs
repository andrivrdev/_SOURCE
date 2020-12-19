using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APITester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var remoteAddress = new System.ServiceModel.EndpointAddress("http://andrivr.hopto.org:8080/SocialRankAPI/SocialRankAPI.asmx");

                using (var xwsServerSoapClient = new wsSocialRankAPI.SocialRankAPISoapClient(new System.ServiceModel.BasicHttpBinding(), remoteAddress))
                {
                    //set timeout
                    xwsServerSoapClient.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 0, 5000);

                    //call web service method
                    var xResponse = xwsServerSoapClient.Dowork(edtData.Text);

                    edtResponse.Text = xResponse;
                }
        }
    }
}
