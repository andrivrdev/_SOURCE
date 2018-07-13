using QBook.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QBook
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            ribbonMain.ApplicationIcon = Icon.ExtractAssociatedIcon(Application.ExecutablePath).ToBitmap();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new frmAccount();
            myForm.ShowDialog();
        }

        private void propertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new frmProperty();
            myForm.ShowDialog();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (clsHelper.CheckDB("QBook", false))
            {
                MessageBox.Show("A new database must be created! This will be done automatically when you continue.");
            }

            clsHelper.GetLocalDB("QBook", false);
            this.Enabled = true;

        }
    }
}
