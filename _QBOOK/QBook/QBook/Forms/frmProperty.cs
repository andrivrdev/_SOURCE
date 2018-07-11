using DevExpress.XtraEditors;
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
    public partial class frmProperty : Form
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

        private void grdPropertyAccountMoneyInView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadPropertyAccount();
        }

        private void LoadPropertyAccount()
        {
            tblPropertyAccount xtblPropertyAccount = new tblPropertyAccount();
            grdPropertyAccountMoneyIn.DataSource = xtblPropertyAccount.dtPropertyAccountMoneyIn;

            grdPropertyAccountMoneyInView.BestFitColumns();
        }

        private void btnAddMoneyInAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdPropertyView.RowCount > 0)
            {
                frmPropertyAccountDetails MyForm;

                MyForm = new frmPropertyAccountDetails(0, 0);
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

                MyForm = new frmPropertyAccountDetails(0, 0);
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
    }
}
