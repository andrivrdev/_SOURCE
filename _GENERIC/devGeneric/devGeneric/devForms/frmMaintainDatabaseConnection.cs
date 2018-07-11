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
using devGeneric.devClasses.devStatic;
using devGeneric.devData;

namespace devGeneric.devForms
{
    public partial class frmMaintainDatabaseConnection : DevExpress.XtraEditors.XtraForm
    {
        devSE SE;
        tblDatabaseConnections dsDatabaseConnections;

        List<Control> tmpControls = new List<Control>();

        public frmMaintainDatabaseConnection()
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void LoadData()
        {
            sbMain.SetPBText(0, "Loading...");
            sbMain.pbDoInit(0, 1);

            tmpControls = new List<Control>();
            tmpControls.Add(devLoadingData);
            SE.ShowHideLoading(this, 1, tmpControls);

            grdDatabaseConnection.DataSource = dsDatabaseConnections.GetData();

            grdDatabaseConnectionView.BestFitColumns();

            tmpControls = new List<Control>();
            tmpControls.Add(devLoadingMain);
            tmpControls.Add(devLoadingData);
            pnlMain.Visible = true;
            SE.ShowHideLoading(this, 0, tmpControls);

            sbMain.pbDoFinal(0);
        }

        private void frmMaintainDatabaseConnection_Shown(object sender, EventArgs e)
        {
            timLoad.Start();
        }

        private void timLoad_Tick(object sender, EventArgs e)
        {
            timLoad.Stop();

            SE = new devSE();

            tmpControls = new List<Control>();
            tmpControls.Add(devLoadingMain);
            SE.ShowHideLoading(this, 1, tmpControls);

            dsDatabaseConnections = new tblDatabaseConnections();

            SE.PrepareRightsData(devGlobals.gUsername);
            SE.ApplyRights(devGlobals.gUsername, this);

            //Status bar
            sbMain.SetText("Maintain database connections");

            //Load data
            LoadData();
        }

        private void grdDatabaseConnectionView_DoubleClick(object sender, EventArgs e)
        {
            DoEdit();
        }

        private void DoEdit()
        {
            if (grdDatabaseConnectionView.RowCount > 0)
            {
                frmConnectionDetails MyForm;

                MyForm = new frmConnectionDetails(1, grdDatabaseConnectionView.GetFocusedRowCellValue("Description").ToString());

                MyForm.edtDesc.Text = grdDatabaseConnectionView.GetFocusedRowCellValue("Description").ToString();
                MyForm.edtType.SelectedIndex = Convert.ToInt32(grdDatabaseConnectionView.GetFocusedRowCellValue("Type").ToString());
                MyForm.edtUsername.Text = grdDatabaseConnectionView.GetFocusedRowCellValue("Username").ToString();
                MyForm.edtPassword.Text = grdDatabaseConnectionView.GetFocusedRowCellValue("Password").ToString();
                MyForm.edtHost.Text = grdDatabaseConnectionView.GetFocusedRowCellValue("Host").ToString();
                MyForm.edtPort.Value = Convert.ToInt32(grdDatabaseConnectionView.GetFocusedRowCellValue("Port").ToString());
                MyForm.edtDatabase.Text = grdDatabaseConnectionView.GetFocusedRowCellValue("DBName").ToString();
                MyForm.edtConnString.Text = grdDatabaseConnectionView.GetFocusedRowCellValue("ConnString").ToString();

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnClose_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Close();
        }

        private void btnAdd_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmConnectionDetails MyForm;

            MyForm = new frmConnectionDetails(0, "");

            if (MyForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DoEdit();
        }

        private void btnDelete_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdDatabaseConnectionView.RowCount > 0)
            {
                if (XtraMessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SE.DeleteConnection(grdDatabaseConnectionView.GetFocusedRowCellValue("Description").ToString());

                    LoadData();
                }
            }
        }
    }
}