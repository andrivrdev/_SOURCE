using SocialRankAndroid.SHARED.CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPShared;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CPShared.clsGlobal;
using Newtonsoft.Json;

namespace SocialRankAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            lblResend.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnlblResendClick()));
            lblForgotPassword.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnlblForgotPasswordClick()));

        }

        async void OnlblResendClick()
        {
            await Navigation.PushModalAsync(new ResendActivationEmailPage());
        }

        async void OnlblForgotPasswordClick()
        {
            await Navigation.PushModalAsync(new ForgotPasswordPage());
        }

        async void btnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage());
        }

        private bool ValidateEntries()
        {
            if (!(
                (edtEmail.Text is null) ||
                (edtPassword1.Text is null) 
                ))
            {

                clsSE xclsSE = new clsSE();

                if (
                    (edtEmail.Text.Trim().Length > 0) &&
                    (edtPassword1.Text.Trim().Length > 0) 
                    )
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

        async void btnLogin_Clicked(object sender, EventArgs e)
        {
            if (ValidateEntries())
            {
                var xData = new List<string>();

                xData.Add(edtEmail.Text);
                xData.Add(edtPassword1.Text);

                clsSE xclsSE = new clsSE();

                var xresult = xclsSE.Send("frmLogin_Login", xData);
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

                    //int xAlert = Convert.ToInt32(gMessages.AccountCreated);
                    //DisplayAlert(gclsMessages[xAlert].Title, gclsMessages[xAlert].Message, gclsMessages[xAlert].Button);
                    await Navigation.PushModalAsync(new UserMainPage());


                }

                if (xresult.Contains("ErrorNotVerified" + clsGlobal.gMessageCommandSeperator))
                {
                    var xMessage = xresult.Replace("ErrorNotVerified" + clsGlobal.gMessageCommandSeperator, "");
                    /*
                    var dData = JsonConvert.DeserializeObject<List<string>>(xMessage);

                    string xLines = "";
                    foreach (var xLine in dData)
                    {
                        xLines += xLine + Environment.NewLine;
                    }
                    */

                    int xAlert = Convert.ToInt32(gMessages.AccountNotVerified);
                    DisplayAlert(gclsMessages[xAlert].Title, gclsMessages[xAlert].Message, gclsMessages[xAlert].Button);
                    edtEmail.Focus();
                }

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

                if (xresult.Contains("InvalidPassword" + clsGlobal.gMessageCommandSeperator))
                {
                    var xMessage = xresult.Replace("InvalidPassword" + clsGlobal.gMessageCommandSeperator, "");
                    /*
                    var dData = JsonConvert.DeserializeObject<List<string>>(xMessage);

                    string xLines = "";
                    foreach (var xLine in dData)
                    {
                        xLines += xLine + Environment.NewLine;
                    }
                    */

                    int xAlert = Convert.ToInt32(gMessages.InvalidPassword);
                    DisplayAlert(gclsMessages[xAlert].Title, gclsMessages[xAlert].Message, gclsMessages[xAlert].Button);
                    edtEmail.Focus();
                }

                if (xresult.Contains("Error" + clsGlobal.gMessageCommandSeperator))
                {
                    int xAlert = Convert.ToInt32(gMessages.Error);
                    DisplayAlert(gclsMessages[xAlert].Title, gclsMessages[xAlert].Message, gclsMessages[xAlert].Button);
                    edtEmail.Focus();
                }


            }

        }
    }
}