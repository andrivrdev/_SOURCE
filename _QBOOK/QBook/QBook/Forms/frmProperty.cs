﻿using DevExpress.XtraEditors;
using QBook.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QBook.Forms
{
    public partial class frmProperty : DevExpress.XtraEditors.XtraForm
    {
        public frmProperty()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void LoadProperty()
        {
            tblProperty xtblProperty = new tblProperty();
            grdProperty.DataSource = xtblProperty.dtProperty;

            grdPropertyView.BestFitColumns();
        }

        private void frmProperty_Shown(object sender, EventArgs e)
        {
            timLoad.Start();
        }

        private void timLoad_Tick(object sender, EventArgs e)
        {
            timLoad.Stop();

            //Load data
            LoadProperty();
        }

        private void grdPropertyView_DoubleClick(object sender, EventArgs e)
        {
            DoEditProperty();
        }

        private void DoEditProperty()
        {
            if (grdPropertyView.RowCount > 0)
            {
                frmPropertyDetails MyForm;

                MyForm = new frmPropertyDetails(1, Convert.ToInt32(grdPropertyView.GetFocusedRowCellValue("ID").ToString()));

                MyForm.edtProperty.Text = grdPropertyView.GetFocusedRowCellValue("Property").ToString();

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProperty();
                }
            }
        }

        private void btnAddProperty_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmPropertyDetails MyForm;

            MyForm = new frmPropertyDetails(0, 0);

            if (MyForm.ShowDialog() == DialogResult.OK)
            {
                LoadProperty();
            }
        }

        private void btnEditProperty_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DoEditProperty();
        }

        private void btnRemoveProperty_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdPropertyView.RowCount > 0)
            {
                if (XtraMessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsHelper.DeleteRecByID("tblProperty", Convert.ToInt32(grdPropertyView.GetFocusedRowCellValue("ID").ToString()));

                    LoadProperty();
                }
            }
        }

        private void LoadPropertyAccount()
        {
            tblPropertyAccount xtblPropertyAccount = new tblPropertyAccount();

            DataTable xdtPropertyAccountMoneyIn = xtblPropertyAccount.dtPropertyAccountMoneyIn.Clone();
            DataTable xdtPropertyAccountMoneyOut = xtblPropertyAccount.dtPropertyAccountMoneyOut.Clone();

            foreach(DataRow ARec in xtblPropertyAccount.dtPropertyAccountMoneyIn.Rows)
            {
                if (ARec["tblPropertyID"].ToString() == grdPropertyView.GetFocusedRowCellValue("ID").ToString())
                {
                    xdtPropertyAccountMoneyIn.ImportRow(ARec);
                }
            }

            foreach (DataRow ARec in xtblPropertyAccount.dtPropertyAccountMoneyOut.Rows)
            {
                if (ARec["tblPropertyID"].ToString() == grdPropertyView.GetFocusedRowCellValue("ID").ToString())
                {
                    xdtPropertyAccountMoneyOut.ImportRow(ARec);
                }
            }

            grdPropertyAccountMoneyIn.DataSource = xdtPropertyAccountMoneyIn;
            grdPropertyAccountMoneyOut.DataSource = xdtPropertyAccountMoneyOut;

            grdPropertyAccountMoneyInView.BestFitColumns();
            grdPropertyAccountMoneyOutView.BestFitColumns();
        }

        private void btnAddMoneyInAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdPropertyView.RowCount > 0)
            {
                frmPropertyAccountDetails MyForm;

                MyForm = new frmPropertyAccountDetails(0, 0, Convert.ToInt32(grdPropertyView.GetFocusedRowCellValue("ID").ToString()));
                MyForm.edtProperty.Text = grdPropertyView.GetFocusedRowCellValue("Property").ToString();
                MyForm.edtAccountType.Text = "Money In";

                tblAccount xtblAccount = new tblAccount();
                foreach (DataRow ARec in xtblAccount.dtAccount.Rows)
                {
                    if (ARec["IO"].ToString() == "I")
                    {
                        MyForm.edtAccount.Properties.Items.Add(ARec["Name"]);
                    }
                }

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    LoadPropertyAccount();
                }
            }
        }

        private void grdPropertyView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                DoEditProperty();
            }
        }

        private void btnAddMoneyOutAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdPropertyView.RowCount > 0)
            {
                frmPropertyAccountDetails MyForm;

                MyForm = new frmPropertyAccountDetails(0, 0, Convert.ToInt32(grdPropertyView.GetFocusedRowCellValue("ID").ToString()));
                MyForm.edtProperty.Text = grdPropertyView.GetFocusedRowCellValue("Property").ToString();
                MyForm.edtAccountType.Text = "Money Out";

                tblAccount xtblAccount = new tblAccount();
                foreach (DataRow ARec in xtblAccount.dtAccount.Rows)
                {
                    if (ARec["IO"].ToString() == "O")
                    {
                        MyForm.edtAccount.Properties.Items.Add(ARec["Name"]);
                    }
                }

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    LoadPropertyAccount();
                }
            }
        }

        private void btnEditMoneyInAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DoEditPropertyMoneyInAccount();
        }

        private void DoEditPropertyMoneyInAccount()
        {
            if (grdPropertyAccountMoneyInView.RowCount > 0)
            {
                frmPropertyAccountDetails MyForm;

                MyForm = new frmPropertyAccountDetails(1, Convert.ToInt32(grdPropertyAccountMoneyInView.GetFocusedRowCellValue("ID").ToString()), Convert.ToInt32(grdPropertyView.GetFocusedRowCellValue("ID").ToString()));
                MyForm.edtProperty.Text = grdPropertyView.GetFocusedRowCellValue("Property").ToString();
                MyForm.edtAccountType.Text = "Money In";

                tblAccount xtblAccount = new tblAccount();
                foreach (DataRow ARec in xtblAccount.dtAccount.Rows)
                {
                    if (ARec["IO"].ToString() == "I")
                    {
                        MyForm.edtAccount.Properties.Items.Add(ARec["Name"]);
                    }
                }

                MyForm.edtAccount.Text = grdPropertyAccountMoneyInView.GetFocusedRowCellValue("Name").ToString();

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    LoadPropertyAccount();
                }
            }
        }

        private void grdPropertyAccountMoneyInView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                DoEditPropertyMoneyInAccount();
            }
        }

        private void btnEditMoneyOutAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DoEditPropertyMoneyOutAccount();
        }

        private void grdPropertyAccountMoneyInView_DoubleClick(object sender, EventArgs e)
        {
            DoEditPropertyMoneyInAccount();
        }

        private void DoEditPropertyMoneyOutAccount()
        {
            if (grdPropertyAccountMoneyOutView.RowCount > 0)
            {
                frmPropertyAccountDetails MyForm;

                MyForm = new frmPropertyAccountDetails(1, Convert.ToInt32(grdPropertyAccountMoneyOutView.GetFocusedRowCellValue("ID").ToString()), Convert.ToInt32(grdPropertyView.GetFocusedRowCellValue("ID").ToString()));
                MyForm.edtProperty.Text = grdPropertyView.GetFocusedRowCellValue("Property").ToString();
                MyForm.edtAccountType.Text = "Money Out";

                tblAccount xtblAccount = new tblAccount();
                foreach (DataRow ARec in xtblAccount.dtAccount.Rows)
                {
                    if (ARec["IO"].ToString() == "O")
                    {
                        MyForm.edtAccount.Properties.Items.Add(ARec["Name"]);
                    }
                }

                MyForm.edtAccount.Text = grdPropertyAccountMoneyOutView.GetFocusedRowCellValue("Name").ToString();

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    LoadPropertyAccount();
                }
            }
        }

        private void grdPropertyAccountMoneyOutView_DoubleClick(object sender, EventArgs e)
        {
            DoEditPropertyMoneyOutAccount();
        }

        private void grdPropertyView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadPropertyAccount();
        }

        private void grdPropertyAccountMoneyOutView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                DoEditPropertyMoneyOutAccount();
            }
        }

        private void btnRemoveMoneyInAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdPropertyAccountMoneyInView.RowCount > 0)
            {
                if (XtraMessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsHelper.DeleteRecByID("tblPropertyAccount", Convert.ToInt32(grdPropertyAccountMoneyInView.GetFocusedRowCellValue("ID").ToString()));

                    LoadPropertyAccount();
                }
            }
        }

        private void btnRemoveMoneyOutAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdPropertyAccountMoneyOutView.RowCount > 0)
            {
                if (XtraMessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsHelper.DeleteRecByID("tblPropertyAccount", Convert.ToInt32(grdPropertyAccountMoneyOutView.GetFocusedRowCellValue("ID").ToString()));

                    LoadPropertyAccount();
                }
            }
        }
    }
}
