﻿using App8.Droid.CLASSES;
using Shared.CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App8
{
	public partial class MainPage : ContentPage
	{
        Editor edtSend;
        Button btnSend;
        Button btnExit;
        Editor edtRecieved;

		public MainPage()
		{
			InitializeComponent();

            BackgroundColor = Color.White;

            edtSend = new Editor
            {
                BackgroundColor = Color.White
            };

            btnSend = new Button
            {
                Text = "Send",
                TextColor = Color.White,
                BackgroundColor = Color.Green
            };
            btnSend.Clicked += BtnSend_Clicked;


            btnExit = new Button
            {
                Text = "Exit",
                TextColor = Color.White,
                BackgroundColor = Color.Red
            };
            btnExit.Clicked += BtnExit_Clicked;

            edtRecieved = new Editor
            {
                BackgroundColor = Color.LightGoldenrodYellow,
                IsEnabled = false
            };

            var xGrid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },

                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(0.5, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) }
                }
            };

            xGrid.Children.Add(edtSend, 0, 0);
            Grid.SetColumnSpan(edtSend, 2);

            xGrid.Children.Add(btnSend, 0, 1);
            xGrid.Children.Add(btnExit, 1, 1);

            xGrid.Children.Add(edtRecieved, 0, 2);
            Grid.SetColumnSpan(edtRecieved, 2);

            Content = xGrid;
        }

        private void BtnExit_Clicked(object sender, EventArgs e)
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }

        private void BtnSend_Clicked(object sender, EventArgs e)
        {
            clsSE xclsSE = new clsSE();
            clsASE xclsASE = new clsASE();
            var xresult = xclsASE.Send(edtSend.Text, edtSend.Text);
            xresult = xclsSE.DecodeMessage(xresult);
            edtRecieved.Text = xresult;


            /*
            var XX = new Droid.wsGrowmeAPI.GrowmeWS();

            XX.Url = "http://andrivrddns.dlinkddns.com:8081//GrowmeAPI/GrowmeWS.asmx";

            var xresult = XX.DoWork("XXX");

            edtRecieved.Text = xresult;
            */

            /*
            var remoteAddress = new System.ServiceModel.EndpointAddress(clsGlobal.gEndpointAddress);

            using (var xwsServerSoapClient = new Droid.wsGrowmeAPI.GrowmeWSSoapClient(new System.ServiceModel.BasicHttpBinding(), remoteAddress))
            {
                //set timeout
                xwsServerSoapClient.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, clsGlobal.gSoapCallTimeout);

                //call web service method
                var xResponse = xwsServerSoapClient.DoWork(xData);

                return xResponse;
            }

            clsSE xclsSE = new clsSE();
            var xresult = xclsSE.Send("Test", edtSend.Text);
            edtRecieved.Text = xclsSE.DecodeMessage(xresult);*/
        }
    }
}
