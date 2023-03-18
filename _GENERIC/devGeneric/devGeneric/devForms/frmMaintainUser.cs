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
    public partial class frmMaintainUser : DevExpress.XtraEditors.XtraForm
    {
        devSE SE;
        tblUsers dsUsers;
        tblUserPCID dsUserPCID;
        tblUserAccessRights dsUserAccessRights;

        List<Control> tmpControls = new List<Control>();

        public frmMaintainUser()
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void LoadData()
        {
            sbMain.SetPBText(0, "Loading...");
            sbMain.pbDoInit(0, 1);

            tmpControls = new List<Control>();
            tmpControls.Add(devLoading2);
            tmpControls.Add(devLoading3);
            tmpControls.Add(devLoading4);
            SE.ShowHideLoading(this, 1, tmpControls);
            
            grdUser.DataSource = dsUsers.GetData();

            grdUserView.BestFitColumns();

            RefreshData();
        }

        private void RefreshData()
        {
            sbMain.SetPBText(0, "Loading...");
            sbMain.pbDoInit(0, 1);

            tmpControls = new List<Control>();
            tmpControls.Add(devLoading3);
            tmpControls.Add(devLoading4);
            SE.ShowHideLoading(this, 1, tmpControls);

            try
            {
                if (grdUserView.RowCount > 0)
                {
                    grdPCID.DataSource = dsUserPCID.GetData(grdUserView.GetFocusedRowCellValue("Username").ToString());
                    grdPCIDView.BestFitColumns();

                    grdUserAccess.DataSource = dsUserAccessRights.GetData(grdUserView.GetFocusedRowCellValue("Username").ToString());
                    grdUserAccessView.BestFitColumns();
                }
                else
                {
                    grdPCID.DataSource = null;
                    grdUserAccess.DataSource = null;
                }

            }
            catch (Exception Ex)
            {
                SE.WriteLog(Ex.Message, "frmMaintainUser", "RefreshData");

                grdPCID.DataSource = null;
                grdUserAccess.DataSource = null;
            }

            tmpControls = new List<Control>();
            SE.ShowHideLoading(this, 0, tmpControls);

            sbMain.pbDoFinal(0);
            pnlMain.Visible = true;
        }

        private void frmMaintainUser_Shown(object sender, EventArgs e)
        {
            timLoad.Start();
        }

        private void timLoad_Tick(object sender, EventArgs e)
        {
            timLoad.Stop();

            SE = new devSE();

            tmpControls = new List<Control>();
            tmpControls.Add(devLoading1);
            SE.ShowHideLoading(this, 1, tmpControls);

            dsUsers = new tblUsers();
            dsUserPCID = new tblUserPCID();
            dsUserAccessRights = new tblUserAccessRights();

            SE.PrepareRightsData(devGlobals.gUsername);
            SE.ApplyRights(devGlobals.gUsername, this);


            //Status bar
            sbMain.SetText("Maintain users and security");

            //Load data
            LoadData();
        }

        private void grdUserView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RefreshData();
        }

        private void grdUserView_DoubleClick(object sender, EventArgs e)
        {
            DoEdit();
        }

        private void DoEdit()
        {
            if (grdUserView.RowCount > 0)
            {
                frmUserDetail MyForm;

                MyForm = new frmUserDetail(3, grdUserView.GetFocusedRowCellValue("Username").ToString());

                MyForm.edtUsername.Text = grdUserView.GetFocusedRowCellValue("Username").ToString();
                MyForm.edtPassword.Text = SE.Decrypt(SE.GetEncUserPassword(SE.GetEncUsername(grdUserView.GetFocusedRowCellValue("Username").ToString())));

                MyForm.ShowDialog();

                LoadData();
            }
        }

        private void btnEdit_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DoEdit();
        }

        private void btnDelete_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if ((grdUserView.RowCount > 1) && (devGlobals.gUsername != grdUserView.GetFocusedRowCellValue("Username").ToString()))
            {
                if (XtraMessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SE.DeleteUser(grdUserView.GetFocusedRowCellValue("Username").ToString());

                    LoadData();
                }
            }
            else
            {
                XtraMessageBox.Show("You are not allowed to delete the last user or yourself.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnShowPassword_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            colPassword.Visible = (!colPassword.Visible);
        }

        private void btnRegisterMAC_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if ((grdUserView.RowCount > 0) && (grdPCIDView.RowCount > 0))
            {
                frmRegister MyForm;

                MyForm = new frmRegister(grdUserView.GetFocusedRowCellValue("Username").ToString(), grdPCIDView.GetFocusedRowCellValue("PCID").ToString());

                if (MyForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        RefreshData();
                        SE.PrepareRightsData(devGlobals.gUsername);
                        SE.ApplyRights(devGlobals.gUsername, this);
                    }
                    catch (Exception Ex)
                    {
                        SE.WriteLog(Ex.Message, "frmMaintainUser", "btnRegisterMAC_LinkClicked");
                    }
                }
            }
        }

        private void btnAccessRights_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (grdUserView.RowCount > 0)
            {
                frmMaintainUserAccess MyForm;

                MyForm = new frmMaintainUserAccess(grdUserView.GetFocusedRowCellValue("Username").ToString());

                MyForm.ShowDialog();

                RefreshData();
            }
        }

        private void btnClose_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Close();
        }

        private void btnAdd_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmUserDetail MyForm;

            MyForm = new frmUserDetail(2, "");

            MyForm.ShowDialog();

            LoadData();
        }
    }
}