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

namespace SocialRankAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
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
                        DisplayAlert("Info", "Please use a valid email address.", "OK");
                        return false;
                    }
                }
                else
                {
                    DisplayAlert("Info", "Please complete all the fields.", "OK");
                    return false;
                }
            }
            else
            {
                DisplayAlert("Info", "Please complete all the fields.", "OK");
                return false;

            }
        }

        private void btnGetCode_Clicked(object sender, EventArgs e)
        {
            if (ValidateEntries())
            {
                var xData = new List<string>();

                xData.Add(edtEmail.Text);

                clsSE xclsSE = new clsSE();

                var xresult = xclsSE.Send("frmForgotPassword_GetCode", xData);
                xresult = xclsSE.DecodeMessage(xresult);
                //lblResult.Text = xResult;

                if (xresult.Contains("Success" + clsGlobal.gMessageCommandSeperator))
                {
                    var xMessage = xresult.Replace("Success" + clsGlobal.gMessageCommandSeperator, "");
                    var dData = JsonConvert.DeserializeObject<List<string>>(xMessage);

                    string xLines = "";
                    foreach (var xLine in dData)
                    {
                        xLines += xLine + Environment.NewLine;
                    }

                    DisplayAlert("Code Sent", xLines, "OK");
                }
                else
                {

                    if (xresult.Contains("ErrorExist" + clsGlobal.gMessageCommandSeperator))
                    {
                        var xMessage = xresult.Replace("ErrorExist" + clsGlobal.gMessageCommandSeperator, "");
                        var dData = JsonConvert.DeserializeObject<List<string>>(xMessage);

                        string xLines = "";
                        foreach (var xLine in dData)
                        {
                            xLines += xLine + Environment.NewLine;
                        }

                        DisplayAlert("Account Does not Exist", xLines, "OK");
                        edtEmail.Focus();
                    }

                    if (xresult.Contains("Error" + clsGlobal.gMessageCommandSeperator))
                    {
                        DisplayAlert("Error", "An unknown error has occured.", "OK");
                        edtEmail.Focus();
                    }
                }


            }

        }

        async void btnHaveCode_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ForgotPasswordEnterCodePage());

        }
    }
}