﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialRank.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class frmRegster : ContentPage
    {
        public frmRegster()
        {
            InitializeComponent();
        }

        private bool ValidateEntries()
        {
            /*
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
                        XtraMessageBox.Show("Please use a valid email address.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Your passwords do not match.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                XtraMessageBox.Show("Please complete all the fields.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }*/
            return true;
        }

        async void btnRegister_Clicked(object sender, EventArgs e)
        {

            if (ValidateEntries())
            {
                var xData = new List<string>();

                xData.Add(edtUsername.Text);
                xData.Add(edtPassword.Text);

                clsSE xclsSE = new clsSE();
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
            }
            else
            {
                this.DialogResult = DialogResult.None;
                edtAlias.Focus();
            }


            await Navigation.PushAsync(new frmRegster());
        }


    }
}