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
using EasyBooks.DATA;
using EasyBooks.CLASSES;

namespace EasyBooks.FORMS
{
    public partial class frmAccountDetails : DevExpress.XtraEditors.XtraForm
    {
        int zMyMode;
        Int64 zID;

        public frmAccountDetails(int xMode, Int64 xID)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            zMyMode = xMode;
            zID = xID;

            //Add
            if (zMyMode == 0)
            {
                edtName.Text = "";
                edtIn.Checked = true;

                this.Text = "New Account Details";

                edtName.Focus();
            }

            //Edit
            if (zMyMode == 1)
            {
                this.Text = "Edit Account Details";

                edtName.Focus();
            }
        }

        private bool ValidationSuccess()
        {
            //CHeck if all required fields are populated
            if (edtName.Text == "")
            {
                XtraMessageBox.Show("Account Name field is required.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            tblAccount xtblAccount = new tblAccount();

            if (zMyMode == 0)
            {
                //Check if record exist
                var IO = "I";
                if (edtIn.Checked)
                {
                    IO = "I";
                }
                else
                {
                    IO = "O";
                }

                var rows = xtblAccount.dtAccount.AsEnumerable().Where(r => (r.Field<string>("Name") == edtName.Text) && (r.Field<string>("IO") == IO));

                if (rows.Count() == 1)
                {
                    XtraMessageBox.Show("This record already exist.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
            }
            else
            {
                //Check if record exist
                var IO = "I";
                if (edtIn.Checked)
                {
                    IO = "I";
                }
                else
                {
                    IO = "O";
                }

                var rows = xtblAccount.dtAccount.AsEnumerable().Where(r => (r.Field<string>("Name") == edtName.Text) && (r.Field<string>("IO") == IO) && (r.Field<Int64>("ID") != zID));

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
            edtName.Text = edtName.Text.Trim();


            if (ValidationSuccess() == false)
            {
                this.DialogResult = DialogResult.None;

                edtName.Focus();
                edtName.SelectAll();
            }
            else
            {
                var IO = "I";
                if (edtIn.Checked)
                {
                    IO = "I";
                }
                else
                {
                    IO = "O";
                }

                List<string> fFields = new List<string>();
                List<string> vValues = new List<string>();

                fFields.Add("Name");
                fFields.Add("IO");

                vValues.Add(edtName.Text);
                vValues.Add(IO);

                if (zMyMode == 0)
                {
                    //Add the record
                    clsHelper.InsertRec("tblAccount", fFields, vValues);
                }

                if (zMyMode == 1)
                {
                    //Update the record
                    clsHelper.UpdateRec("tblAccount", fFields, vValues, "[ID] = '" + zID + "'");
                }
            }
        }
    }
}