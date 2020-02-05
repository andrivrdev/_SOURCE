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
    public partial class frmRegister : DevExpress.XtraEditors.XtraForm
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidateEntries()
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
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
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
        }

    }
}