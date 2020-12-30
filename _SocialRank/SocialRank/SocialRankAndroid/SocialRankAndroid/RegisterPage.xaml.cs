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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
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
            if (!((edtAlias.Text is null) ||
                (edtEmail.Text is null) ||
                (edtPassword1.Text is null) ||
                (edtPassword2.Text is null)))
            {

                clsSE xclsSE = new clsSE();

                if ((edtAlias.Text.Trim().Length > 0) &&
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
                            int xAlert = Convert.ToInt32(gMessages.EmailInvalid);
                            DisplayAlert(gclsMessages[xAlert].Title, gclsMessages[xAlert].Message, gclsMessages[xAlert].Button);
                            return false;
                        }
                    }
                    else
                    {
                        int xAlert = Convert.ToInt32(gMessages.PasswordsDoNotMatch);
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
        

        async void btnRegister_Clicked(object sender, EventArgs e)
        {
            if (ValidateEntries())
            {
                var xData = new List<string>();

                xData.Add(edtAlias.Text);
                xData.Add(edtEmail.Text);
                xData.Add(edtPassword1.Text);
                
                clsSE xclsSE = new clsSE();

                var xresult = xclsSE.Send("frmRegister_RegisterUser", xData);
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

                    int xAlert = Convert.ToInt32(gMessages.AccountCreated);
                    DisplayAlert(gclsMessages[xAlert].Title, gclsMessages[xAlert].Message, gclsMessages[xAlert].Button);
                    await Navigation.PushModalAsync(new LoginPage());


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
                    edtAlias.Focus();
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

                    int xAlert = Convert.ToInt32(gMessages.AccountAlreadyExist);
                    DisplayAlert(gclsMessages[xAlert].Title, gclsMessages[xAlert].Message, gclsMessages[xAlert].Button);
                    edtAlias.Focus();
                }

                if (xresult.Contains("Error" + clsGlobal.gMessageCommandSeperator))
                {
                    int xAlert = Convert.ToInt32(gMessages.Error);
                    DisplayAlert(gclsMessages[xAlert].Title, gclsMessages[xAlert].Message, gclsMessages[xAlert].Button);
                    edtAlias.Focus();
                }

                
            }
           

        }


    }
}