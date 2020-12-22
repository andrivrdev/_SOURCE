﻿using System;
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

        private void btnRunAPIRequest_Clicked(object sender, EventArgs e)
        {
            try
            {
                

                wsSocialRankAPI.wsSocialRankAPISoapClient xSoapClient = new wsSocialRankAPI.wsSocialRankAPISoapClient
                    (wsSocialRankAPI.wsSocialRankAPISoapClient.EndpointConfiguration.wsSocialRankAPISoap12);

                var xresult = xSoapClient.DoWork("Test");

                edtOutput.Text = xresult;
            }
            catch (Exception Ex)
            {
                edtOutput.Text = Ex.Message;

            }
        }
    }
}
