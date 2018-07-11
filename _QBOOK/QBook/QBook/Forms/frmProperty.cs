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

        private void LoadData()
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
            LoadData();
        }

        private void grdPropertyView_DoubleClick(object sender, EventArgs e)
        {
            DoEdit();
        }

        private void DoEdit()
        {
            if (grdPropertyView.RowCount > 0)
            {
                frmPropertyDetails MyForm;

                MyForm = new frmPropertyDetails(1, Convert.ToInt32(grdPropertyView.GetFocusedRowCellValue("ID").ToString()));

                MyForm.edtProperty.Text = grdPropertyView.GetFocusedRowCellValue("Property").ToString();

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnAddProperty_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmPropertyDetails MyForm;

            MyForm = new frmPropertyDetails(0, 0);

            if (MyForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEditProperty_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DoEdit();
        }

        private void btnRemoveProperty_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdPropertyView.RowCount > 0)
            {
                if (XtraMessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsHelper.DeleteRecByID("tblProperty", Convert.ToInt32(grdPropertyView.GetFocusedRowCellValue("ID").ToString()));

                    LoadData();
                }
            }
        }
    }
}
