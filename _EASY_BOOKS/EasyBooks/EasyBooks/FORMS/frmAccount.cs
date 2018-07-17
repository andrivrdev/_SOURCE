using DevExpress.XtraEditors;
using EasyBooks.CLASSES;
using EasyBooks.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyBooks.FORMS
{
    public partial class frmAccount : DevExpress.XtraEditors.XtraForm
    {
        public frmAccount()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void LoadAccount()
        {
            tblAccount xtblAccount = new tblAccount();
            grdAccount.DataSource = xtblAccount.dtAccount;

            grdAccountView.BestFitColumns();
        }

        private void frmAccount_Shown(object sender, EventArgs e)
        {
            timLoad.Start();
        }

        private void timLoad_Tick(object sender, EventArgs e)
        {
            timLoad.Stop();

            //Load data
            LoadAccount();
        }

        private void grdAccountView_DoubleClick(object sender, EventArgs e)
        {
            DoEdit();
        }

        private void DoEdit()
        {
            if (grdAccountView.RowCount > 0)
            {
                frmAccountDetails MyForm;

                MyForm = new frmAccountDetails(1, Convert.ToInt32(grdAccountView.GetFocusedRowCellValue("ID").ToString()));

                MyForm.edtName.Text = grdAccountView.GetFocusedRowCellValue("Name").ToString();

                if (grdAccountView.GetFocusedRowCellValue("IO").ToString() == "I")
                {
                    MyForm.edtIn.Checked = true;
                }
                else
                {
                    MyForm.edtOut.Checked = true;
                }

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    int xID = Convert.ToInt32(grdAccountView.GetFocusedRowCellValue("ID").ToString());

                    LoadAccount();

                    int rowHandle = grdAccountView.LocateByValue("ID", xID);
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        grdAccountView.FocusedRowHandle = rowHandle;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void btnAdd_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmAccountDetails MyForm;

            MyForm = new frmAccountDetails(0, 0);

            if (MyForm.ShowDialog() == DialogResult.OK)
            {
                LoadAccount();

                int rowHandle = grdAccountView.LocateByValue("ID", clsHelper.GetLastRecID("tblAccount"));
                if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    grdAccountView.FocusedRowHandle = rowHandle;
                }
            }
        }

        private void btnEdit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DoEdit();
        }

        private void btnRemove_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdAccountView.RowCount > 0)
            {
                if (XtraMessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsHelper.DeleteRecByID("tblAccount", Convert.ToInt32(grdAccountView.GetFocusedRowCellValue("ID").ToString()));

                    LoadAccount();
                }
            }
            else
            {
                XtraMessageBox.Show("Please select a valid record first.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void grdAccountView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                DoEdit();
            }
        }
    }
}