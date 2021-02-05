using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileToREST
{
    public partial class MainPage : ContentPage
    {
        bool zRunTimer = false;
        DateTime zEllapsed = DateTime.Now;
        Location zLocation = new Location();

        public MainPage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromMilliseconds(100), NextUpdateIn);


        }

        private bool NextUpdateIn()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (zRunTimer)
                {
                    TimeSpan ts = DateTime.Now - zEllapsed;
                    lblNextUpdateSec.Text = "Next Update In: " + ts.TotalMilliseconds.ToString();
                }
                else
                {
                    lblNextUpdateSec.Text = "Not Running";
                }

                //put here your code which updates the view
            });

            return true;

        }


        CancellationTokenSource cts;

        async Task GetCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    zLocation = location;
                    //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        protected override void OnDisappearing()
        {
            if (cts != null && !cts.IsCancellationRequested)
                cts.Cancel();
            base.OnDisappearing();
        }

        private async void DoPost()

        {
            try
            {
                List<string> cmdData = new List<string>();
                cmdData.Add(zLocation.Latitude.ToString());
                cmdData.Add(zLocation.Longitude.ToString());
                cmdData.Add(zLocation.Altitude.ToString());

                cmdData.Add(DeviceInfo.Idiom.ToString());
                cmdData.Add(DeviceInfo.Model.ToString());
                cmdData.Add(DeviceInfo.Name.ToString());

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(cmdData);

                clsAPIData xData = new clsAPIData();
                xData.Command = "AddLocation";
                xData.Data = JSONresult;
                JSONresult = JsonConvert.SerializeObject(xData);

                HttpClient client = new HttpClient();
                var values = new Dictionary<string, string>
                    {
                        { "thing1", "hello" },
                        { "thing2", "world" }
                    };

                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("http://192.168.1.15:5000/api/api?=&xData=" + JSONresult, content);

                var responseString = await response.Content.ReadAsStringAsync();



                edtResult.Text = responseString;
            }
            catch (Exception Ex)
            {
                edtResult.Text = Ex.Message;
            }

        }

        private void btnPost_Clicked(object sender, EventArgs e)
        {
            DoPost();
        }

        private bool TimerElapsed()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                GetCurrentLocation();
                zEllapsed = DateTime.Now;
                edtLocation.Text = $"Latitude: {zLocation.Latitude}, Longitude: {zLocation.Longitude}, Altitude: {zLocation.Altitude}";
                DoPost();
                //put here your code which updates the view
            });

            return zRunTimer;

        }

        private void btnStart_Clicked(object sender, EventArgs e)
        {
            zRunTimer = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(Convert.ToInt32(edtSeconds.Text) * 1000), TimerElapsed);

        }

        private void btnStop_Clicked(object sender, EventArgs e)
        {
            zRunTimer = false;

        }
    }
}
