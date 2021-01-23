using CPShared;
using Newtonsoft.Json;
using SocialRankAndroid.SHARED.CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CPShared.clsGlobal;

namespace SocialRankAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResendActivationEmailPage : ContentPage
    {
        public ResendActivationEmailPage()
        {
            InitializeComponent();

            lblBackToLogin.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnlblBackToLogin()));

        }

        async void OnlblBackToLogin()
        {
            await Navigation.PushModalAsync(new LoginPage());
        }

        private bool ValidateEntries()
        {
            if (!(
                (edtEmail.Text is null)

                ))
            {

                clsSE xclsSE = new clsSE();

                if (
                    (edtEmail.Text.Trim().Length > 0))
                {
                    if (xclsSE.IsValidEmailAddress(edtEmail.Text.Trim()))
                    {
                        return true;
                    }
                    else
                    {
                        int xAlert = Convert.ToInt32(gMessages.EmailInvalid);
                        DisplayAlert(gclsMessages[xAlert].Title, gclsMessages[xAlert].Message, gclsMessages[xAlert].Button);
                        return false;
                    }
                }
                else
                {
                    int xAlert = Convert.ToInt32(gMessages.CompleteAllFields);
                    DisplayAlert(gclsMessages[xAlert].Title, gclsMessages[xAlert].Message, gclsMessages[xAlert].Button);
                    return false;
                }
            }
            else
            {
                int xAlert = Convert.ToInt32(gMessages.CompleteAllFields);
                DisplayAlert(gclsMessages[xAlert].Title, gclsMessages[xAlert].Message, gclsMessages[xAlert].Button);
                return false;

            }
        }

        async void btnResendActivationLink_Clicked(object sender, EventArgs e)
        {
            if (ValidateEntries())
            {
                var xData = new List<string>();

                xData.Add(edtEmail.Text);

                clsSE xclsSE = new clsSE();

                var xresult = xclsSE.Send("frmResendActivationEmail_Resend", xData);
                xresult = xclsSE.DecodeMessage(xresult);
                //lblResult.Text = xResult;

                if (xresult.Contains("Success" + clsGlobal.gMessageCommandSeperator))
                {
                    var xMessage = xresult.Replace("Success" + clsGlobal.gMessageCommandSeperator, "");
                    /*
                    var dData = JsonConvert.DeserializeObject<List<string>>(xMessage);

                    string xLines = "";
                    foreach (var xLine in dData)
                    {
                        xLines += xLine + Environment.NewLine;
                    }
                    */

                    int xAlert = Convert.ToInt32(gMessages.ActivationLinkSent);
                    DisplayAlert(gclsMessages[xAlert].Title, gclsMessages[xAlert].Message, gclsMessages[xAlert].Button);
                    await Navigation.PushModalAsync(new LoginPage());


                }
                else
                {

                    if (xresult.Contains("ErrorExist" + clsGlobal.gMessageCommandSeperator))
                    {
                        var xMessage = xresult.Replace("ErrorExist" + clsGlobal.gMessageCommandSeperator, "");
                        /*
                        var dData = JsonConvert.DeserializeObject<List<string>>(xMessage);

                        string xLines = "";
                        foreach (var xLine in dData)
                        {
                            xLines += xLine + Environment.NewLine;
                        }
                        */

                        int xAlert = Convert.ToInt32(gMessages.AccountDoesNotExist);
                        DisplayAlert(gclsMessages[xAlert].Title, gclsMessages[xAlert].Message, gclsMessages[xAlert].Button);
                        edtEmail.Focus();
                    }

                    if (xresult.Contains("Error" + clsGlobal.gMessageCommandSeperator))
                    {
                        int xAlert = Convert.ToInt32(gMessages.Error);

                        if (g_DebugMode)
                        {
                            var xMessage = xresult.Replace("Error" + clsGlobal.gMessageCommandSeperator, "");

                            var dData = JsonConvert.DeserializeObject<List<string>>(xMessage);

                            string xLines = "";
                            foreach (var xLine in dData)
                            {
                                xLines += xLine + Environment.NewLine;
                            }

                            DisplayAlert("DEBUGMODE", xLines, "OK");
                        }

                        DisplayAlert(gclsMessages[xAlert].Title, gclsMessages[xAlert].Message, gclsMessages[xAlert].Button);
                        edtEmail.Focus();
                    }
                }


            }
        }
    }
}