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
    public partial class ForgotPasswordEnterCodePage : ContentPage
    {
        public ForgotPasswordEnterCodePage()
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
            if (!((edtCode.Text is null) ||
                (edtEmail.Text is null) ||
                (edtPassword1.Text is null) ||
                (edtPassword2.Text is null)))
            {

                clsSE xclsSE = new clsSE();

                if ((edtCode.Text.Trim().Length > 0) &&
                    (edtEmail.Text.Trim().Length > 0) &&
                    (edtPassword1.Text.Trim().Length > 0) &&
                    (edtPassword2.Text.Trim().Length > 0))
                {
                    if (edtPassword1.Text.Trim() == edtPassword2.Text.Trim())
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
                        DisplayAlert("Info", "Your passwords do not match.", "OK");
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

        async void btnResetPassword_Clicked(object sender, EventArgs e)
        {
            if (ValidateEntries())
            {
                var xData = new List<string>();

                xData.Add(edtCode.Text);
                xData.Add(edtEmail.Text);
                xData.Add(edtPassword1.Text);

                clsSE xclsSE = new clsSE();

                var xresult = xclsSE.Send("frmForgotPassword_ResetPassword", xData);
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

                    DisplayAlert("Password was Reset", xLines, "OK");
                    await Navigation.PushModalAsync(new LoginPage());


                }

                if (xresult.Contains("ErrorExist" + clsGlobal.gMessageCommandSeperator))
                {
                    var xMessage = xresult.Replace("ErrorExist" + clsGlobal.gMessageCommandSeperator, "");
                    var dData = JsonConvert.DeserializeObject<List<string>>(xMessage);

                    string xLines = "";
                    foreach (var xLine in dData)
                    {
                        xLines += xLine + Environment.NewLine;
                    }

                    DisplayAlert("Account Does Not Exist", xLines, "OK");
                    edtCode.Focus();
                }

                if (xresult.Contains("Error" + clsGlobal.gMessageCommandSeperator))
                {
                    DisplayAlert("Error", "An unknown error has occured.", "OK");
                    edtCode.Focus();
                }


            }



        }
    }
}