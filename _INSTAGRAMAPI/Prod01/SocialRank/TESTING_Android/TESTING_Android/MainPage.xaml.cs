using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TESTING_Android
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnRunAPIRequest_Clicked(object sender, EventArgs e)
        {
            try
            {
                wsSocialRankAPI.wsSocialRankAPISoapClient xSoapClient = new wsSocialRankAPI.wsSocialRankAPISoapClient
                    (wsSocialRankAPI.wsSocialRankAPISoapClient.EndpointConfiguration.wsSocialRankAPISoap12);

                var xresult = await xSoapClient.DoWorkAsync("Test");

                edtOutput.Text = xresult.Body.DoWorkResult;
            }
            catch (Exception Ex)
            {
               

            }
        }
    }
}
