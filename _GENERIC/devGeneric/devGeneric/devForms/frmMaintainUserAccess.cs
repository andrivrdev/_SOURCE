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
using devGeneric.devData;
using devGeneric.devClasses.devStatic;

namespace devGeneric.devForms
{
    public partial class frmMaintainUserAccess : DevExpress.XtraEditors.XtraForm
    {
        devSE SE;
        tblAccessRights dsAccessRights;
        tblUserAccessRights dsUserAccessRights;
        string MyUsername;

        List<Control> tmpControls = new List<Control>();

        public frmMaintainUserAccess(string xUsername)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            MyUsername = xUsername;
        }

        private void btnClose_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Close();
        }

        private void LoadData()
        {
            sbMain.SetPBText(0, "Loading...");
            sbMain.pbDoInit(0, 1);

            apAccess.ShowLoading();

            List<string> AFields = new List<string>();
            List<string> ACols = new List<string>();
            List<string> BFields = new List<string>();
            List<string> BCols = new List<string>();

            AFields.Add("Tag|0");
            AFields.Add("AccessRight|1");
            ACols.Add("Tag");
            ACols.Add("Access Right Description");

            BFields.Add("Tag|0");
            BFields.Add("AccessRight|1");
            BCols.Add("Tag");
            BCols.Add("Access Right Description");

            apAccess.SetData(SE.BindingListToDataTable(dsAccessRights.GetData()), SE.BindingListToDataTable(dsUserAccessRights.GetData(MyUsername)), AFields, ACols, BFields, BCols, "Tag", "Tag", "AccessRight", "AccessRight", 0);
            apAccess.HideLoading();

            tmpControls = new List<Control>();
            SE.ShowHideLoading(this, 0, tmpControls);

            sbMain.pbDoFinal(0);
            pnlMain.Visible = true;
        }

        private void frmMaintainUserAccess_Shown(object sender, EventArgs e)
        {
            timLoad.Start();
        }

        private void btnSaveandClose_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            apAccess.ShowLoading();

            //Save Data
            SE.onDoProgress1 += new devSE_Progress1(frmMain_onDoProgress1);
            SE.onDoProgressText1 += new devSE_ProgressText1(frmMain_onDoProgressText1);

            DataTable SaveData = new DataTable();
            List<string> NewRights = new List<string>();

            SaveData = apAccess.GetData(1);

            for (int C1 = 0; C1 < SaveData.Rows.Count; C1++)
            {
                NewRights.Add(SaveData.Rows[C1]["Tag"].ToString());
            }

            SE.WriteUserAccess(SE.GetEncUsername(MyUsername), NewRights);

            apAccess.HideLoading();

            Close();
        }

        void frmMain_onDoProgress1(int Max, int Progress)
        {
            sbMain.pbDoProgress(0, Max, Progress);
            Application.DoEvents();
        }

        void frmMain_onDoProgressText1(string xMessage)
        {
            sbMain.SetPBText(0, xMessage);
            Application.DoEvents();
        }

        private void timLoad_Tick(object sender, EventArgs e)
        {
            timLoad.Stop();

            SE = new devSE();

            tmpControls = new List<Control>();
            tmpControls.Add(devLoading1);
            SE.ShowHideLoading(this, 1, tmpControls);
            Application.DoEvents();

            dsAccessRights = new tblAccessRights();
            dsUserAccessRights = new tblUserAccessRights();

            SE.ApplyRights(devGlobals.gUsername, this);

            //Status bar
            sbMain.SetText("Maintain user access rights");

            //Load data
            LoadData();
        }
    }
}