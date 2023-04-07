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
    public partial class frmClientDetail : Form
    {
        public frmClientDetail()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (edtDescription.Text.Contains("|"))
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show("Invalid characters used");
            }
        }

        private void frmClientDetail_Shown(object sender, EventArgs e)
        {
            edtType.Focus();
        }
    }
}
