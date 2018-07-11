namespace devGeneric.devMainForms
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.rpMaintain = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpAdmin = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpSystem = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.repositoryItemProgressBar2 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.barStaticItem7 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem5 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem4 = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.timLoad = new System.Windows.Forms.Timer();
            this.timEndApp = new System.Windows.Forms.Timer();
            this.timSecurity = new System.Windows.Forms.Timer();
            this.timRestartApp = new System.Windows.Forms.Timer();
            this.timKickUser = new System.Windows.Forms.Timer();
            this.timResetKick = new System.Windows.Forms.Timer();
            this.sbMain = new devGeneric.devControls.devStatusBar();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.devLoading1 = new devGeneric.devControls.devLoading();
            this.gbBulletin = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.pnlBullet = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbBulletin)).BeginInit();
            this.gbBulletin.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBullet)).BeginInit();
            this.pnlBullet.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ApplicationButtonDropDownControl = this.applicationMenu1;
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonMain.ExpandCollapseItem,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem7});
            this.ribbonMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.MaxItemId = 22;
            this.ribbonMain.Name = "ribbonMain";
            this.ribbonMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpMaintain,
            this.rpAdmin,
            this.rpSystem});
            this.ribbonMain.QuickToolbarItemLinks.Add(this.barButtonItem6);
            this.ribbonMain.QuickToolbarItemLinks.Add(this.barButtonItem7);
            this.ribbonMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1,
            this.repositoryItemProgressBar2});
            this.ribbonMain.Size = new System.Drawing.Size(983, 147);
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.ribbonMain;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Connections";
            this.barButtonItem2.Hint = "Configure database connections";
            this.barButtonItem2.Id = 16;
            this.barButtonItem2.ImageOptions.LargeImage = global::devGeneric.Properties.Resources.lDatabase;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.Tag = "1012";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Users";
            this.barButtonItem3.Hint = "Maintain users and access rights";
            this.barButtonItem3.Id = 17;
            this.barButtonItem3.ImageOptions.LargeImage = global::devGeneric.Properties.Resources.lUser;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.Tag = "1001";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Key Generator";
            this.barButtonItem4.Hint = "Generate registration keys";
            this.barButtonItem4.Id = 18;
            this.barButtonItem4.ImageOptions.LargeImage = global::devGeneric.Properties.Resources.lKeyGenerator;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.Tag = "1000";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Defaults";
            this.barButtonItem5.Hint = "Configure default system settings";
            this.barButtonItem5.Id = 19;
            this.barButtonItem5.ImageOptions.LargeImage = global::devGeneric.Properties.Resources.lSystem_Defaults;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.Tag = "1007";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Excel";
            this.barButtonItem6.Hint = "Open Excel exports";
            this.barButtonItem6.Id = 20;
            this.barButtonItem6.ImageOptions.Image = global::devGeneric.Properties.Resources.sExcel;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "PDF";
            this.barButtonItem7.Hint = "Open PDF exports";
            this.barButtonItem7.Id = 21;
            this.barButtonItem7.ImageOptions.Image = global::devGeneric.Properties.Resources.sPDF;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // rpMaintain
            // 
            this.rpMaintain.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.rpMaintain.Name = "rpMaintain";
            this.rpMaintain.Text = "Maintain";
            this.rpMaintain.Visible = false;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Tag = "1012|";
            this.ribbonPageGroup1.Text = "Databases";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Tag = "1001|";
            this.ribbonPageGroup2.Text = "Security";
            // 
            // rpAdmin
            // 
            this.rpAdmin.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.rpAdmin.Name = "rpAdmin";
            this.rpAdmin.Text = "Admin";
            this.rpAdmin.Visible = false;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Tag = "1000|";
            this.ribbonPageGroup3.Text = "Registration";
            // 
            // rpSystem
            // 
            this.rpSystem.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.rpSystem.Name = "rpSystem";
            this.rpSystem.Text = "System";
            this.rpSystem.Visible = false;
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Tag = "1007|";
            this.ribbonPageGroup4.Text = "Settings";
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.repositoryItemProgressBar1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            this.repositoryItemProgressBar1.ShowTitle = true;
            this.repositoryItemProgressBar1.Step = 1;
            // 
            // repositoryItemProgressBar2
            // 
            this.repositoryItemProgressBar2.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.repositoryItemProgressBar2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemProgressBar2.Name = "repositoryItemProgressBar2";
            this.repositoryItemProgressBar2.ShowTitle = true;
            this.repositoryItemProgressBar2.Step = 1;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Dark Side";
            // 
            // barStaticItem7
            // 
            this.barStaticItem7.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem7.Caption = "barStaticItem5";
            this.barStaticItem7.Id = 12;
            this.barStaticItem7.Name = "barStaticItem7";
            // 
            // barStaticItem5
            // 
            this.barStaticItem5.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem5.Caption = "barStaticItem5";
            this.barStaticItem5.Id = 12;
            this.barStaticItem5.Name = "barStaticItem5";
            // 
            // barStaticItem4
            // 
            this.barStaticItem4.Caption = "barStaticItem4";
            this.barStaticItem4.Id = 13;
            this.barStaticItem4.Name = "barStaticItem4";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 15;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // timLoad
            // 
            this.timLoad.Interval = 10;
            this.timLoad.Tick += new System.EventHandler(this.timLoad_Tick);
            // 
            // timEndApp
            // 
            this.timEndApp.Interval = 10;
            this.timEndApp.Tick += new System.EventHandler(this.timEndApp_Tick);
            // 
            // timSecurity
            // 
            this.timSecurity.Interval = 10000;
            this.timSecurity.Tick += new System.EventHandler(this.timSecurity_Tick);
            // 
            // timRestartApp
            // 
            this.timRestartApp.Tick += new System.EventHandler(this.timRestartApp_Tick);
            // 
            // timKickUser
            // 
            this.timKickUser.Interval = 10000;
            this.timKickUser.Tick += new System.EventHandler(this.timKickUser_Tick);
            // 
            // timResetKick
            // 
            this.timResetKick.Interval = 20000;
            this.timResetKick.Tick += new System.EventHandler(this.timResetKick_Tick);
            // 
            // sbMain
            // 
            this.sbMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sbMain.BackgroundImage")));
            this.sbMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sbMain.Location = new System.Drawing.Point(0, 642);
            this.sbMain.MinimumSize = new System.Drawing.Size(4, 20);
            this.sbMain.Name = "sbMain";
            this.sbMain.Size = new System.Drawing.Size(983, 20);
            this.sbMain.TabIndex = 135;
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.panelControl2.Appearance.BackColor2 = System.Drawing.Color.Black;
            this.panelControl2.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.devLoading1);
            this.panelControl2.Controls.Add(this.gbBulletin);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 147);
            this.panelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(983, 495);
            this.panelControl2.TabIndex = 139;
            this.panelControl2.DoubleClick += new System.EventHandler(this.panelControl2_DoubleClick);
            // 
            // devLoading1
            // 
            this.devLoading1.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.devLoading1.Appearance.BackColor2 = System.Drawing.Color.Silver;
            this.devLoading1.Appearance.Options.UseBackColor = true;
            this.devLoading1.devCaption1 = "";
            this.devLoading1.devCaption2 = "";
            this.devLoading1.Location = new System.Drawing.Point(69, 80);
            this.devLoading1.Name = "devLoading1";
            this.devLoading1.Size = new System.Drawing.Size(503, 404);
            this.devLoading1.TabIndex = 138;
            this.devLoading1.Visible = false;
            // 
            // gbBulletin
            // 
            this.gbBulletin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBulletin.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gbBulletin.AppearanceCaption.Options.UseFont = true;
            this.gbBulletin.AppearanceCaption.Options.UseTextOptions = true;
            this.gbBulletin.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gbBulletin.Controls.Add(this.simpleButton4);
            this.gbBulletin.Controls.Add(this.xtraScrollableControl1);
            this.gbBulletin.Location = new System.Drawing.Point(665, 5);
            this.gbBulletin.Name = "gbBulletin";
            this.gbBulletin.Size = new System.Drawing.Size(314, 483);
            this.gbBulletin.TabIndex = 131;
            this.gbBulletin.Text = "Bulletin Board";
            this.gbBulletin.Visible = false;
            this.gbBulletin.ClientSizeChanged += new System.EventHandler(this.gbBulletin_ClientSizeChanged);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.Appearance.Options.UseTextOptions = true;
            this.simpleButton4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.simpleButton4.ImageOptions.Image = global::devGeneric.Properties.Resources.sBulletinBoardClose;
            this.simpleButton4.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton4.Location = new System.Drawing.Point(296, 1);
            this.simpleButton4.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(18, 20);
            this.simpleButton4.TabIndex = 125;
            this.simpleButton4.ToolTip = "Hide Bulletin Board";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraScrollableControl1.Appearance.BackColor = System.Drawing.Color.Black;
            this.xtraScrollableControl1.Appearance.BackColor2 = System.Drawing.Color.White;
            this.xtraScrollableControl1.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControl1.Controls.Add(this.pnlBullet);
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 20);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.ScrollBarSmallChange = 1;
            this.xtraScrollableControl1.Size = new System.Drawing.Size(314, 462);
            this.xtraScrollableControl1.TabIndex = 1;
            // 
            // pnlBullet
            // 
            this.pnlBullet.Appearance.BackColor = System.Drawing.Color.Black;
            this.pnlBullet.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlBullet.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlBullet.Appearance.Options.UseBackColor = true;
            this.pnlBullet.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnlBullet.Controls.Add(this.labelControl1);
            this.pnlBullet.Location = new System.Drawing.Point(2, 2);
            this.pnlBullet.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.pnlBullet.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlBullet.Name = "pnlBullet";
            this.pnlBullet.Size = new System.Drawing.Size(292, 457);
            this.pnlBullet.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(18, 13);
            this.labelControl1.LookAndFeel.SkinName = "Black";
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(267, 13);
            this.labelControl1.TabIndex = 134;
            this.labelControl1.Text = "XXXXXXXXXXXXXXX";
            this.labelControl1.ClientSizeChanged += new System.EventHandler(this.gbBulletin_ClientSizeChanged);
            // 
            // frmMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 662);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.sbMain);
            this.Controls.Add(this.ribbonMain);
            this.Name = "frmMain";
            this.Ribbon = this.ribbonMain;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XXXXXX";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbBulletin)).EndInit();
            this.gbBulletin.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBullet)).EndInit();
            this.pnlBullet.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonMain;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpMaintain;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem7;
        private DevExpress.XtraBars.BarStaticItem barStaticItem5;
        private DevExpress.XtraBars.BarStaticItem barStaticItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpAdmin;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpSystem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private System.Windows.Forms.Timer timEndApp;
        private System.Windows.Forms.Timer timSecurity;
        public System.Windows.Forms.Timer timRestartApp;
        private System.Windows.Forms.Timer timKickUser;
        private System.Windows.Forms.Timer timResetKick;
        public System.Windows.Forms.Timer timLoad;
        private devControls.devStatusBar sbMain;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl gbBulletin;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.PanelControl pnlBullet;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private devControls.devLoading devLoading1;
    }
}