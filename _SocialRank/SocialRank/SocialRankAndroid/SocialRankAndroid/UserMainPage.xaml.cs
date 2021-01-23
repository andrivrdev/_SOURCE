using CPShared;
using SocialRankAndroid.SHARED.CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialRankAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserMainPage : TabbedPage
    {
        public UserMainPage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromMilliseconds(30000), TimerElapsed);
        }

        async void btnLinkInstagram_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LinkInstagramPage());

        }

        private bool TimerElapsed()
        {
            var xReturnResult = true;

            Device.BeginInvokeOnMainThread(() =>
            {
                var xData = new List<string>();

                xData.Add(clsCurrentUser.Id.ToString());

                clsSE xclsSE = new clsSE();

                var xresult = xclsSE.Send("UpdateInstagramMediaCounts", xData);
                xresult = xclsSE.DecodeMessage(xresult);

                if (xresult.Contains("Success" + clsGlobal.gMessageCommandSeperator))
                {
                    var xMessage = xresult.Replace("Success" + clsGlobal.gMessageCommandSeperator, "");
                    xMessage = xMessage.Substring(1, xMessage.Length - 2);

                    lblRank.Text = xMessage;
                }

                
                //Page currentPage = Navigation.NavigationStack.LastOrDefault();

                xData = new List<string>();

                xData.Add(clsGlobal.gLogLevel.DEBUG.ToString());
                xData.Add("Current page is: " + "TODO");


                xclsSE.Send("DoRemoteLog", xData);

                //xReturnResult = (currentPage == this);

                //put here your code which updates the view
            });

            return xReturnResult;
            
        }
    }
}