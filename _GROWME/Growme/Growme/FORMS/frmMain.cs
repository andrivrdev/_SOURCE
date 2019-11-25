using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Growme.FORMS
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            ribbonMain.ApplicationIcon = Icon.ExtractAssociatedIcon(Application.ExecutablePath).ToBitmap();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            this.Enabled = false;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            frmLogin xForm = new frmLogin();

            if (xForm.ShowDialog() == DialogResult.OK)
            {
                this.Enabled = true;
            }
            else
            {
                Close();
            }
        }
    }
}