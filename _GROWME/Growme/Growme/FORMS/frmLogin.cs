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

namespace Growme.FORMS
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            var xData = new List<string>();

            xData.Add(edtEmail.Text);
            xData.Add(edtPassword.Text);

            clsSE xclsSE = new clsSE();
            var xresult = xclsSE.Send("Test", xData);

            MessageBox.Show(xresult);


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}