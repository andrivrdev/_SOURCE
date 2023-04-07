using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SharedObjects.FORMS
{
    public partial class frmContactDetails : Form
    {
        public List<string> dummyTypes = new List<string>();

        public frmContactDetails()
        {
            InitializeComponent();
        }

        private void edtType_TextChanged(object sender, EventArgs e)
        {
            if (dummyTypes[edtType.SelectedIndex] == "Number")
            {
                lbl1.Text = "Number";

                lbl1.Visible = true;
                lbl2.Visible = false;
                lbl3.Visible = false;

                edt1.Visible = true;
                edt2.Visible = false;
                edt3.Visible = false;

                this.Height = 140;
            }
            else
            {
                lbl1.Text = "Addr Line 1";
                lbl2.Text = "Addr Line 2";
                lbl3.Text = "Addr Line 3";

                lbl1.Visible = true;
                lbl2.Visible = true;
                lbl3.Visible = true;

                edt1.Visible = true;
                edt2.Visible = true;
                edt3.Visible = true;

                this.Height = 200;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((edt1.Text.Contains("|") || edt1.Text.Contains(",")) ||
                    (edt1.Text.Contains("|") || edt1.Text.Contains(",")) ||
                    (edt1.Text.Contains("|") || edt1.Text.Contains(",")))
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show("Invalid characters used");
            }

            if (dummyTypes[edtType.SelectedIndex] == "Number")
            {
                try
                {
                    Convert.ToDouble(edt1.Text);
                }
                catch
                {
                    this.DialogResult = DialogResult.None;
                    MessageBox.Show("Invalid characters used");
                }
            }
        }

        private void frmContactDetails_Shown(object sender, EventArgs e)
        {
            edtType.Focus();
        }
    }
}
