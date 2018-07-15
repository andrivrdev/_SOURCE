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

namespace QBook.Forms
{
    public partial class frmPropertyAccountTransactionDetails : DevExpress.XtraEditors.XtraForm
    {
        int zMyMode;
        int zPropertyAccountTransactionID;

        public frmPropertyAccountTransactionDetails(int xMode, int xPropertyAccountTransactionID)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            zMyMode = xMode;
            zPropertyAccountTransactionID = xPropertyAccountTransactionID;

            //Add
            if (zMyMode == 0)
            {
                edtAccount.SelectedIndex = 0;

                this.Text = "New Transaction Details";

                edtDate.Focus();
            }

            //Edit
            if (zMyMode == 1)
            {
                this.Text = "Edit Transaction Details";

                edtDate.Focus();
            }
        }

        private bool ValidationSuccess()
        {
            if (edtDate.Text == "")
            {
                XtraMessageBox.Show("Date field is required.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }


            if (edtAccount.Text == "")
            {
                XtraMessageBox.Show("Account Name field is required.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (edtAccountType.Text == "Money Out")
            {
                bool xFound = false;
                foreach (DataRow ARec in clsHelper.GetReferencesForMoneyOutTransaction(clsHelper.FindPropertyID(edtProperty.Text).ToString()).Rows)
                {
                    if (edtReferenceCombo.Text == ARec["Reference"].ToString())
                    {
                        xFound = true;
                    }
                }

                if (!xFound)
                {
                    XtraMessageBox.Show("Invalid reference selected.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
            }

            if (edtDescription.Text == "")
            {
                XtraMessageBox.Show("Description field is required.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (edtAmount.Text == "")
            {
                XtraMessageBox.Show("Amount field is required.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            return true;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            edtAccount.Text = edtAccount.Text.Trim();
            edtDescription.Text = edtDescription.Text.Trim();
            edtAmount.Value = Math.Round(edtAmount.Value, 2);

            if (ValidationSuccess() == false)
            {
                this.DialogResult = DialogResult.None;

                edtDate.Focus();
            }
            else
            {
                string xIO = "I";
                if (edtAccountType.Text == "Money Out")
                {
                    xIO = "O";
                }

                List<string> fFields = new List<string>();
                List<string> vValues = new List<string>();

                fFields.Add("tblPropertyAccountID");
                fFields.Add("DT");
                fFields.Add("Description");
                fFields.Add("Amount");

                vValues.Add(clsHelper.FindPropertyAccountID(xIO, clsHelper.FindPropertyID(edtProperty.Text), edtAccount.Text).ToString());
                vValues.Add(edtDate.Text);
                vValues.Add(edtDescription.Text);
                vValues.Add(edtAmount.Text.Replace(",","."));

                if (zMyMode == 0)
                {
                    //Add the record
                    clsHelper.InsertRec("tblPropertyAccountTransaction", fFields, vValues);

                    //Update the reference
                    string xRef = clsHelper.GetLastRecID("tblPropertyAccountTransaction").ToString().PadLeft(10, '0');

                    fFields = new List<string>();
                    vValues = new List<string>();

                    fFields.Add("Reference");

                    if (edtAccountType.Text == "Money In")
                    {
                        vValues.Add(xRef);
                    }
                    else
                    {
                        vValues.Add(edtReferenceCombo.Text);
                    }

                    clsHelper.UpdateRec("tblPropertyAccountTransaction", fFields, vValues, "[ID] = '" + clsHelper.GetLastRecID("tblPropertyAccountTransaction").ToString() + "'");
                }

                if (zMyMode == 1)
                {
                    //Update the record
                    fFields.Add("Reference");

                    if (edtAccountType.Text == "Money In")
                    {
                        vValues.Add(edtReference.Text);
                    }
                    else
                    {
                        vValues.Add(edtReferenceCombo.Text);
                    }

                    clsHelper.UpdateRec("tblPropertyAccountTransaction", fFields, vValues, "[ID] = '" + zPropertyAccountTransactionID + "'");
                }
            }
        }
    }
}