namespace devGeneric.devForms
{
    partial class frmMaintainUserAccess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaintainUserAccess));
            this.sbMain = new devGeneric.devControls.devStatusBar();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.apAccess = new devGeneric.devControls.devAvailableApplied();
            this.devGroupBox4 = new devGeneric.devControls.devGroupBox();
            this.navBarControl2 = new DevExpress.XtraNavBar.NavBarControl();
            this.nbgOptions = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnSaveandClose = new DevExpress.XtraNavBar.NavBarItem();
            this.btnClose = new DevExpress.XtraNavBar.NavBarItem();
            this.btnAdd = new DevExpress.XtraNavBar.NavBarItem();
            this.btnEdit = new DevExpress.XtraNavBar.NavBarItem();
            this.btnDelete = new DevExpress.XtraNavBar.NavBarItem();
            this.btnShowPassword = new DevExpress.XtraNavBar.NavBarItem();
            this.btnRegisterMAC = new DevExpress.XtraNavBar.NavBarItem();
            this.btnAccessRights = new DevExpress.XtraNavBar.NavBarItem();
            this.devLoading1 = new devGeneric.devControls.devLoading();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.timLoad = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.devGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // sbMain
            // 
            this.sbMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sbMain.BackgroundImage")));
            this.sbMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sbMain.Location = new System.Drawing.Point(0, 550);
            this.sbMain.MinimumSize = new System.Drawing.Size(4, 20);
            this.sbMain.Name = "sbMain";
            this.sbMain.Size = new System.Drawing.Size(881, 20);
            this.sbMain.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.Black;
            this.panelControl1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(881, 7);
            this.panelControl1.TabIndex = 35;
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.pnlMain.Appearance.BackColor2 = System.Drawing.Color.Black;
            this.pnlMain.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.apAccess);
            this.pnlMain.Controls.Add(this.devGroupBox4);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 7);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(881, 543);
            this.pnlMain.TabIndex = 36;
            this.pnlMain.Tag = "9999";
            this.pnlMain.Visible = false;
            // 
            // apAccess
            // 
            this.apAccess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.apAccess.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.apAccess.Appearance.Options.UseBackColor = true;
            this.apAccess.Location = new System.Drawing.Point(174, 0);
            this.apAccess.Name = "apAccess";
            this.apAccess.Size = new System.Drawing.Size(707, 543);
            this.apAccess.TabIndex = 19;
            // 
            // devGroupBox4
            // 
            this.devGroupBox4.Appearance.BackColor = System.Drawing.Color.Black;
            this.devGroupBox4.Appearance.Options.UseBackColor = true;
            this.devGroupBox4.Controls.Add(this.navBarControl2);
            this.devGroupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.devGroupBox4.Location = new System.Drawing.Point(0, 0);
            this.devGroupBox4.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.devGroupBox4.LookAndFeel.UseDefaultLookAndFeel = false;
            this.devGroupBox4.Name = "devGroupBox4";
            this.devGroupBox4.Padding = new System.Windows.Forms.Padding(1);
            this.devGroupBox4.Size = new System.Drawing.Size(172, 543);
            this.devGroupBox4.TabIndex = 18;
            this.devGroupBox4.Tag = "9999";
            // 
            // navBarControl2
            // 
            this.navBarControl2.ActiveGroup = this.nbgOptions;
            this.navBarControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl2.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbgOptions});
            this.navBarControl2.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnShowPassword,
            this.btnRegisterMAC,
            this.btnAccessRights,
            this.btnSaveandClose,
            this.btnClose});
            this.navBarControl2.Location = new System.Drawing.Point(1, 1);
            this.navBarControl2.Name = "navBarControl2";
            this.navBarControl2.OptionsNavPane.ExpandedWidth = 170;
            this.navBarControl2.Size = new System.Drawing.Size(170, 541);
            this.navBarControl2.TabIndex = 0;
            this.navBarControl2.Text = "navBarControl2";
            this.navBarControl2.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("Darkroom");
            // 
            // nbgOptions
            // 
            this.nbgOptions.Caption = "Options";
            this.nbgOptions.Expanded = true;
            this.nbgOptions.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnSaveandClose),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnClose)});
            this.nbgOptions.Name = "nbgOptions";
            this.nbgOptions.SmallImage = global::devGeneric.Properties.Resources.sOptions;
            // 
            // btnSaveandClose
            // 
            this.btnSaveandClose.Caption = "Save and Close";
            this.btnSaveandClose.Hint = "Save changes and close";
            this.btnSaveandClose.Name = "btnSaveandClose";
            this.btnSaveandClose.SmallImage = global::devGeneric.Properties.Resources.sAccept;
            this.btnSaveandClose.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnSaveandClose_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Cancel and Close";
            this.btnClose.Hint = "Close without saving changes";
            this.btnClose.Name = "btnClose";
            this.btnClose.SmallImage = global::devGeneric.Properties.Resources.sCancel;
            this.btnClose.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnClose_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Add";
            this.btnAdd.Hint = "Add a new item";
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.SmallImage = global::devGeneric.Properties.Resources.sAdd;
            this.btnAdd.Tag = "1002";
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Hint = "Modify the selected item";
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.SmallImage = global::devGeneric.Properties.Resources.sEdit;
            this.btnEdit.Tag = "1003";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Delete";
            this.btnDelete.Hint = "Delete the selected item(s)";
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.SmallImage = global::devGeneric.Properties.Resources.sDelete;
            this.btnDelete.Tag = "1004";
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.Caption = "Show/Hide Passwords";
            this.btnShowPassword.Hint = "Show or hide the encrypted/decrypted passwords";
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.SmallImage = global::devGeneric.Properties.Resources.sShowHide;
            this.btnShowPassword.Tag = "1005";
            // 
            // btnRegisterMAC
            // 
            this.btnRegisterMAC.Caption = "Register PCID";
            this.btnRegisterMAC.Hint = "Register the selected PCID for the user";
            this.btnRegisterMAC.Name = "btnRegisterMAC";
            this.btnRegisterMAC.SmallImage = global::devGeneric.Properties.Resources.sRegister;
            // 
            // btnAccessRights
            // 
            this.btnAccessRights.Caption = "Access Rights";
            this.btnAccessRights.Hint = "Maintain selected user access rights";
            this.btnAccessRights.Name = "btnAccessRights";
            this.btnAccessRights.SmallImage = global::devGeneric.Properties.Resources.sAccessRights;
            this.btnAccessRights.Tag = "1006";
            // 
            // devLoading1
            // 
            this.devLoading1.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.devLoading1.Appearance.BackColor2 = System.Drawing.Color.Silver;
            this.devLoading1.Appearance.Options.UseBackColor = true;
            this.devLoading1.devCaption1 = "Please Wait";
            this.devLoading1.devCaption2 = "Loading ...";
            this.devLoading1.Location = new System.Drawing.Point(356, 223);
            this.devLoading1.Name = "devLoading1";
            this.devLoading1.Size = new System.Drawing.Size(169, 96);
            this.devLoading1.TabIndex = 38;
            this.devLoading1.Visible = false;
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // timLoad
            // 
            this.timLoad.Interval = 10;
            this.timLoad.Tick += new System.EventHandler(this.timLoad_Tick);
            // 
            // frmMaintainUserAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 570);
            this.Controls.Add(this.devLoading1);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.sbMain);
            this.DoubleBuffered = true;
            this.Name = "frmMaintainUserAccess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maintain User Access Rights";
            this.Shown += new System.EventHandler(this.frmMaintainUserAccess_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.devGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private devControls.devStatusBar sbMain;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private devControls.devGroupBox devGroupBox4;
        private DevExpress.XtraNavBar.NavBarControl navBarControl2;
        private DevExpress.XtraNavBar.NavBarItem btnAdd;
        private DevExpress.XtraNavBar.NavBarItem btnEdit;
        private DevExpress.XtraNavBar.NavBarItem btnDelete;
        private DevExpress.XtraNavBar.NavBarItem btnShowPassword;
        private DevExpress.XtraNavBar.NavBarItem btnRegisterMAC;
        private DevExpress.XtraNavBar.NavBarItem btnAccessRights;
        private DevExpress.XtraNavBar.NavBarGroup nbgOptions;
        private DevExpress.XtraNavBar.NavBarItem btnSaveandClose;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private devControls.devAvailableApplied apAccess;
        private DevExpress.XtraNavBar.NavBarItem btnClose;
        private System.Windows.Forms.Timer timLoad;
        private devControls.devLoading devLoading1;
    }
}