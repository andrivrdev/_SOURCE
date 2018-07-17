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
using EasyBooks.CLASSES;

namespace EasyBooks.FORMS
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            ribbonMain.ApplicationIcon = Icon.ExtractAssociatedIcon(Application.ExecutablePath).ToBitmap();
            pictureEdit1.Properties.ContextMenuStrip = new ContextMenuStrip();
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
                XtraMessageBox.Show("A new database must be created! This will be done automatically when you continue.");
            }

            clsHelper.GetLocalDB("QBook", false);
            this.Enabled = true;

        }

        private void btnAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var myForm = new frmAccount();
            myForm.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var myForm = new frmItem();
            myForm.ShowDialog();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnAbout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAbout MyForm = new frmAbout();
            MyForm.ShowDialog();
        }
    }
}