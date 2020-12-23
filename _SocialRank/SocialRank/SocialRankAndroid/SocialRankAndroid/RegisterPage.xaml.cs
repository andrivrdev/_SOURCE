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
        

        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            if (ValidateEntries())
            {
                var xData = new List<string>();

                xData.Add(edtAlias.Text);
                xData.Add(edtEmail.Text);
                xData.Add(edtPassword1.Text);
                
                clsSE xclsSE = new clsSE();

                var xResult = xclsSE.Send("frmRegister_RegisterUser", xData);
                xResult = xclsSE.DecodeMessage(xResult);
                lblResult.Text = xResult;



                /*
                var xresult = xclsSE.Send("frmRegister_RegisterUser", xData);
                xresult = xclsSE.DecodeMessage(xresult);

                if (xresult.Contains("Success" + clsGlobal.gMessageCommandSeperator))
                {
                    var xMessage = xresult.Replace("Success" + clsGlobal.gMessageCommandSeperator, "");
                    var dData = JsonConvert.DeserializeObject<List<string>>(xMessage);

                    string xLines = "";
                    foreach (var xLine in dData)
                    {
                        xLines += xLine + Environment.NewLine;
                    }

                    XtraMessageBox.Show(xLines, "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (xresult.Contains("ErrorNotVerified" + clsGlobal.gMessageCommandSeperator))
                {
                    var xMessage = xresult.Replace("ErrorNotVerified" + clsGlobal.gMessageCommandSeperator, "");
                    var dData = JsonConvert.DeserializeObject<List<string>>(xMessage);

                    string xLines = "";
                    foreach (var xLine in dData)
                    {
                        xLines += xLine + Environment.NewLine;
                    }

                    XtraMessageBox.Show(xLines, "Account Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.DialogResult = DialogResult.None;
                    edtAlias.Focus();
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

                    XtraMessageBox.Show(xLines, "Account Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.DialogResult = DialogResult.None;
                    edtAlias.Focus();
                }

                if (xresult.Contains("Error" + clsGlobal.gMessageCommandSeperator))
                {
                    XtraMessageBox.Show("An unknown error has occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.DialogResult = DialogResult.None;
                    edtAlias.Focus();
                }

                */
            }
           

        }


    }
}