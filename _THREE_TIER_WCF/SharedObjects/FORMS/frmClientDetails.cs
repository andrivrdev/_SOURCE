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
    public partial class frmClientDetails : Form
    {
        public frmClientDetails()
        {
            InitializeComponent();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (edtName.Text.Contains("|") ||
                edtSurname.Text.Contains("|") ||
                edtAge.Text.Contains("|"))
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show("Invalid characters used");
            }
        }

        private void frmClientDetails_Shown(object sender, EventArgs e)
        {
            edtName.Focus();
        }
    }
}
