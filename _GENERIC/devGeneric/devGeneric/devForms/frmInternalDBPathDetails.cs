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
using devGeneric.devClasses.devDynamic;
using System.IO;

namespace devGeneric.devForms
{
    public partial class frmInternalDBPathDetails : DevExpress.XtraEditors.XtraForm
    {
        devSE SE;
        int MyMode;
        string zOldPath;

        public frmInternalDBPathDetails(int xMode, string xOldPath)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            MyMode = xMode;

            SE = new devSE();

            if (MyMode == 0)
            {
                edtPath.Text = "";

                this.Text = "Initial Setup";
                sbMain.SetText("Please choose the path to your internal database file");

                edtPath.Focus();
            }

            //Edit Path
            if (MyMode == 1)
            {
                this.Text = "Edit Path";
                sbMain.SetText("Please update the path to your internal database file");

                zOldPath = xOldPath;

                edtPath.Focus();
            }
        }

        private bool DoValidate()
        {
            if (!Directory.Exists(edtPath.Text))
            {
                XtraMessageBox.Show("The selected folder is invalid.", "No No No !!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            return true;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            edtPath.Text = edtPath.Text.Trim();

            if (DoValidate() == false)
            {
                this.DialogResult = DialogResult.None;

                edtPath.Text = "";
                edtPath.Focus();
            }
            else
            {
                //Update the path
                SE.SetDBPath(edtPath.Text);
            }
        }

        private void edtPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            dlgFolder.SelectedPath = Application.StartupPath;

            DialogResult MyResult = dlgFolder.ShowDialog();
            if (MyResult == DialogResult.OK)
            {
                edtPath.Text = dlgFolder.SelectedPath;
            }
        }
    }
}