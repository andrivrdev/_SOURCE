﻿using DevExpress.XtraEditors;
using QBook.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QBook.Forms
{
    public partial class frmPropertyAccountDetails : DevExpress.XtraEditors.XtraForm
    {
        int zMyMode;
        int zAccountID;
        int zPropertyID;

        public frmPropertyAccountDetails(int xMode, int xAccountID, int xPropertyID)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            zMyMode = xMode;
            zAccountID = xAccountID;
            zPropertyID = xPropertyID;

            //Add
            if (zMyMode == 0)
            {
                edtAccount.SelectedIndex = 0;

                this.Text = "New Property Account Details";

                edtAccount.Focus();
            }

            //Edit
            if (zMyMode == 1)
            {
                this.Text = "Edit Property Account Details";

                edtAccount.Focus();
            }
        }

        private bool ValidationSuccess()
        {
            if (edtAccount.Text == "")
            {
                XtraMessageBox.Show("Account Name field is required.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            tblPropertyAccount xtblAccount = new tblPropertyAccount();

            if (zMyMode == 0)
            {
                //Check if record exist
                var rows = xtblAccount.dtPropertyAccountMoneyIn.AsEnumerable().Where(r => (r.Field<string>("Property") == edtProperty.Text) && (r.Field<string>("Name").ToString() == edtAccount.Text));
                if (edtAccountType.Text == "Money Out")
                {
                    rows = xtblAccount.dtPropertyAccountMoneyOut.AsEnumerable().Where(r => (r.Field<string>("Property") == edtProperty.Text) && (r.Field<string>("Name").ToString() == edtAccount.Text));
                }

                if (rows.Count() == 1)
                {
                    XtraMessageBox.Show("This record already exist.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
            }
            else
            {
                //Check if record exist
                var rows = xtblAccount.dtPropertyAccountMoneyIn.AsEnumerable().Where(r => (r.Field<string>("Property") == edtProperty.Text) && (r.Field<string>("Name").ToString() == edtAccount.Text) && (r.Field<int>("ID").ToString() != zAccountID.ToString()));
                if (edtAccountType.Text == "Money Out")
                {
                    rows = xtblAccount.dtPropertyAccountMoneyOut.AsEnumerable().Where(r => (r.Field<string>("Property") == edtProperty.Text) && (r.Field<string>("Name").ToString() == edtAccount.Text) && (r.Field<int>("ID").ToString() != zAccountID.ToString()));
                }

                if (rows.Count() == 1)
                {
                    XtraMessageBox.Show("This record already exist.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
            }

            return true;
        }


        private void btnAccept_Click(object sender, EventArgs e)
        {
            edtAccount.Text = edtAccount.Text.Trim();


            if (ValidationSuccess() == false)
            {
                this.DialogResult = DialogResult.None;

                edtAccount.Focus();
                edtAccount.SelectAll();
            }
            else
            {
                List<string> fFields = new List<string>();
                List<string> vValues = new List<string>();

                fFields.Add("tblPropertyID");
                fFields.Add("tblAccountID");

                vValues.Add(zPropertyID.ToString());
                if (edtAccountType.Text == "Money In")
                {
                    vValues.Add(clsHelper.FindAccountID("I", edtAccount.Text).ToString());
                }
                else
                {
                    vValues.Add(clsHelper.FindAccountID("O", edtAccount.Text).ToString());
                }

                if (zMyMode == 0)
                {
                    //Add the record
                    clsHelper.InsertRec("tblPropertyAccount", fFields, vValues);
                }

                if (zMyMode == 1)
                {
                    //Update the record
                    clsHelper.UpdateRec("tblPropertyAccount", fFields, vValues, "[ID] = '" + zAccountID + "'");
                }
            }
        }
    }
}
