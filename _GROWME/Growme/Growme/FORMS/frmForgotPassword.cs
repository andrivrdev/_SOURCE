using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Shared.CLASSES;
using Newtonsoft.Json;

namespace Growme.FORMS
{
    public partial class frmForgotPassword : DevExpress.XtraEditors.XtraForm
    {
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        private bool ValidateEntries()
        {
            clsSE xclsSE = new clsSE();

            if (edtEmail.Text.Trim().Length > 0)
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
                XtraMessageBox.Show("Please complete all the fields.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateEntries())
            {
                var xData = new List<string>();

                xData.Add(edtEmail.Text);

                clsSE xclsSE = new clsSE();
                var xresult = xclsSE.Send("frmForgotPassword_ResetPassword", xData);
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

                    XtraMessageBox.Show(xLines, "Link Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    XtraMessageBox.Show(xLines, "Reset Password Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.DialogResult = DialogResult.None;
                    edtEmail.Focus();
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

                    XtraMessageBox.Show(xLines, "Reset Password Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.DialogResult = DialogResult.None;
                    edtEmail.Focus();
                }

                if (xresult.Contains("Error" + clsGlobal.gMessageCommandSeperator))
                {
                    XtraMessageBox.Show("An unknown error has occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                this.DialogResult = DialogResult.None;
                edtEmail.Focus();
            }
        }
    }
}