﻿namespace devGeneric.devForms
{
    partial class frmMaintainDatabaseConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaintainDatabaseConnection));
            this.sbMain = new devGeneric.devControls.devStatusBar();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.devLoadingMain = new devGeneric.devControls.devLoading();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.devGroupBox4 = new devGeneric.devControls.devGroupBox();
            this.navBarControl2 = new DevExpress.XtraNavBar.NavBarControl();
            this.nbgItems = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnAdd = new DevExpress.XtraNavBar.NavBarItem();
            this.btnEdit = new DevExpress.XtraNavBar.NavBarItem();
            this.btnDelete = new DevExpress.XtraNavBar.NavBarItem();
            this.nbgOptions = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnClose = new DevExpress.XtraNavBar.NavBarItem();
            this.btnShowPassword = new DevExpress.XtraNavBar.NavBarItem();
            this.btnRegisterMAC = new DevExpress.XtraNavBar.NavBarItem();
            this.btnAccessRights = new DevExpress.XtraNavBar.NavBarItem();
            this.devGroupBox3 = new devGeneric.devControls.devGroupBox();
            this.devLoadingData = new devGeneric.devControls.devLoading();
            this.grdDatabaseConnection = new DevExpress.XtraGrid.GridControl();
            this.grdDatabaseConnectionView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemImageComboBox5 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.devGroupBoxTop3 = new devGeneric.devControls.devGroupBoxTop();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.timLoad = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.devGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl2)).BeginInit();
            this.devGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatabaseConnection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatabaseConnectionView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // sbMain
            // 
            this.sbMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sbMain.BackgroundImage")));
            this.sbMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sbMain.Location = new System.Drawing.Point(0, 495);
            this.sbMain.MinimumSize = new System.Drawing.Size(4, 20);
            this.sbMain.Name = "sbMain";
            this.sbMain.Size = new System.Drawing.Size(682, 20);
            this.sbMain.TabIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.panelControl3.Appearance.BackColor2 = System.Drawing.Color.Black;
            this.panelControl3.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.devLoadingMain);
            this.panelControl3.Controls.Add(this.pnlMain);
            this.panelControl3.Controls.Add(this.panelControl1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(682, 495);
            this.panelControl3.TabIndex = 37;
            // 
            // devLoadingMain
            // 
            this.devLoadingMain.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.devLoadingMain.Appearance.BackColor2 = System.Drawing.Color.Silver;
            this.devLoadingMain.Appearance.Options.UseBackColor = true;
            this.devLoadingMain.devCaption1 = "Please Wait";
            this.devLoadingMain.devCaption2 = "Loading ...";
            this.devLoadingMain.Location = new System.Drawing.Point(273, 221);
            this.devLoadingMain.Name = "devLoadingMain";
            this.devLoadingMain.Size = new System.Drawing.Size(152, 106);
            this.devLoadingMain.TabIndex = 37;
            this.devLoadingMain.Visible = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.pnlMain.Appearance.BackColor2 = System.Drawing.Color.Black;
            this.pnlMain.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.devGroupBox4);
            this.pnlMain.Controls.Add(this.devGroupBox3);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 7);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(682, 488);
            this.pnlMain.TabIndex = 34;
            this.pnlMain.Tag = "9999";
            this.pnlMain.Visible = false;
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
            this.devGroupBox4.Size = new System.Drawing.Size(172, 488);
            this.devGroupBox4.TabIndex = 18;
            this.devGroupBox4.Tag = "9999";
            // 
            // navBarControl2
            // 
            this.navBarControl2.ActiveGroup = this.nbgItems;
            this.navBarControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl2.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbgItems,
            this.nbgOptions});
            this.navBarControl2.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnShowPassword,
            this.btnRegisterMAC,
            this.btnAccessRights,
            this.btnClose});
            this.navBarControl2.Location = new System.Drawing.Point(1, 1);
            this.navBarControl2.Name = "navBarControl2";
            this.navBarControl2.OptionsNavPane.ExpandedWidth = 170;
            this.navBarControl2.Size = new System.Drawing.Size(170, 486);
            this.navBarControl2.TabIndex = 0;
            this.navBarControl2.Text = "navBarControl2";
            this.navBarControl2.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("Darkroom");
            // 
            // nbgItems
            // 
            this.nbgItems.Caption = "Items";
            this.nbgItems.Expanded = true;
            this.nbgItems.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnAdd),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnEdit),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnDelete)});
            this.nbgItems.Name = "nbgItems";
            this.nbgItems.SmallImage = global::devGeneric.Properties.Resources.sItems;
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Add";
            this.btnAdd.Hint = "Add a new item";
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.SmallImage = global::devGeneric.Properties.Resources.sAdd;
            this.btnAdd.Tag = "1002";
            this.btnAdd.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnAdd_LinkClicked);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Hint = "Modify the selected item";
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.SmallImage = global::devGeneric.Properties.Resources.sEdit;
            this.btnEdit.Tag = "1003";
            this.btnEdit.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnEdit_LinkClicked);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Delete";
            this.btnDelete.Hint = "Delete the selected item(s)";
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.SmallImage = global::devGeneric.Properties.Resources.sDelete;
            this.btnDelete.Tag = "1004";
            this.btnDelete.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnDelete_LinkClicked);
            // 
            // nbgOptions
            // 
            this.nbgOptions.Caption = "Options";
            this.nbgOptions.Expanded = true;
            this.nbgOptions.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnClose)});
            this.nbgOptions.Name = "nbgOptions";
            this.nbgOptions.SmallImage = global::devGeneric.Properties.Resources.sOptions;
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Name = "btnClose";
            this.btnClose.SmallImage = global::devGeneric.Properties.Resources.sClose;
            this.btnClose.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnClose_LinkClicked);
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
            // devGroupBox3
            // 
            this.devGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.devGroupBox3.Appearance.BackColor = System.Drawing.Color.Black;
            this.devGroupBox3.Appearance.Options.UseBackColor = true;
            this.devGroupBox3.Controls.Add(this.devLoadingData);
            this.devGroupBox3.Controls.Add(this.grdDatabaseConnection);
            this.devGroupBox3.Controls.Add(this.devGroupBoxTop3);
            this.devGroupBox3.Location = new System.Drawing.Point(174, 0);
            this.devGroupBox3.Margin = new System.Windows.Forms.Padding(10);
            this.devGroupBox3.Name = "devGroupBox3";
            this.devGroupBox3.Padding = new System.Windows.Forms.Padding(1);
            this.devGroupBox3.Size = new System.Drawing.Size(508, 488);
            this.devGroupBox3.TabIndex = 16;
            // 
            // devLoadingData
            // 
            this.devLoadingData.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.devLoadingData.Appearance.BackColor2 = System.Drawing.Color.Silver;
            this.devLoadingData.Appearance.Options.UseBackColor = true;
            this.devLoadingData.devCaption1 = "Please Wait";
            this.devLoadingData.devCaption2 = "Loading ...";
            this.devLoadingData.Location = new System.Drawing.Point(267, 156);
            this.devLoadingData.Name = "devLoadingData";
            this.devLoadingData.Size = new System.Drawing.Size(170, 109);
            this.devLoadingData.TabIndex = 21;
            this.devLoadingData.Visible = false;
            // 
            // grdDatabaseConnection
            // 
            this.grdDatabaseConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDatabaseConnection.Location = new System.Drawing.Point(1, 21);
            this.grdDatabaseConnection.MainView = this.grdDatabaseConnectionView;
            this.grdDatabaseConnection.Name = "grdDatabaseConnection";
            this.grdDatabaseConnection.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit3,
            this.repositoryItemImageComboBox5,
            this.repositoryItemImageComboBox4,
            this.repositoryItemImageComboBox1});
            this.grdDatabaseConnection.Size = new System.Drawing.Size(506, 466);
            this.grdDatabaseConnection.TabIndex = 4;
            this.grdDatabaseConnection.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdDatabaseConnectionView});
            // 
            // grdDatabaseConnectionView
            // 
            this.grdDatabaseConnectionView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grdDatabaseConnectionView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.grdDatabaseConnectionView.GridControl = this.grdDatabaseConnection;
            this.grdDatabaseConnectionView.Name = "grdDatabaseConnectionView";
            this.grdDatabaseConnectionView.OptionsBehavior.AllowIncrementalSearch = true;
            this.grdDatabaseConnectionView.OptionsBehavior.Editable = false;
            this.grdDatabaseConnectionView.OptionsFind.AlwaysVisible = true;
            this.grdDatabaseConnectionView.OptionsMenu.EnableColumnMenu = false;
            this.grdDatabaseConnectionView.OptionsView.ShowGroupPanel = false;
            this.grdDatabaseConnectionView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grdDatabaseConnectionView.DoubleClick += new System.EventHandler(this.grdDatabaseConnectionView_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Description";
            this.gridColumn1.FieldName = "Description";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 327;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Type";
            this.gridColumn2.ColumnEdit = this.repositoryItemImageComboBox1;
            this.gridColumn2.FieldName = "Type";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 162;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", -1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Microsoft SQL Server", 0, -1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // repositoryItemImageEdit3
            // 
            this.repositoryItemImageEdit3.AutoHeight = false;
            this.repositoryItemImageEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit3.Name = "repositoryItemImageEdit3";
            // 
            // repositoryItemImageComboBox5
            // 
            this.repositoryItemImageComboBox5.AutoHeight = false;
            this.repositoryItemImageComboBox5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox5.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox5.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("No", false, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Yes", true, 1)});
            this.repositoryItemImageComboBox5.Name = "repositoryItemImageComboBox5";
            // 
            // repositoryItemImageComboBox4
            // 
            this.repositoryItemImageComboBox4.AutoHeight = false;
            this.repositoryItemImageComboBox4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox4.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.repositoryItemImageComboBox4.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("No", 0, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Yes", 1, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Admin", 2, 1)});
            this.repositoryItemImageComboBox4.Name = "repositoryItemImageComboBox4";
            // 
            // devGroupBoxTop3
            // 
            this.devGroupBoxTop3.Appearance.BackColor = System.Drawing.Color.Black;
            this.devGroupBoxTop3.Appearance.Options.UseBackColor = true;
            this.devGroupBoxTop3.devCaption = "Connections";
            this.devGroupBoxTop3.devCaptionGradientColor = System.Drawing.Color.SlateGray;
            this.devGroupBoxTop3.devLineColor1 = System.Drawing.Color.DodgerBlue;
            this.devGroupBoxTop3.devLineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(87)))), ((int)(((byte)(151)))));
            this.devGroupBoxTop3.Dock = System.Windows.Forms.DockStyle.Top;
            this.devGroupBoxTop3.Location = new System.Drawing.Point(1, 1);
            this.devGroupBoxTop3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.devGroupBoxTop3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.devGroupBoxTop3.MaximumSize = new System.Drawing.Size(10000, 19);
            this.devGroupBoxTop3.MinimumSize = new System.Drawing.Size(0, 20);
            this.devGroupBoxTop3.Name = "devGroupBoxTop3";
            this.devGroupBoxTop3.Size = new System.Drawing.Size(506, 20);
            this.devGroupBoxTop3.TabIndex = 2;
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
            this.panelControl1.Size = new System.Drawing.Size(682, 7);
            this.panelControl1.TabIndex = 34;
            // 
            // timLoad
            // 
            this.timLoad.Interval = 10;
            this.timLoad.Tick += new System.EventHandler(this.timLoad_Tick);
            // 
            // frmMaintainDatabaseConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 515);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.sbMain);
            this.Name = "frmMaintainDatabaseConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maintain Database Connections";
            this.Shown += new System.EventHandler(this.frmMaintainDatabaseConnection_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.devGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl2)).EndInit();
            this.devGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatabaseConnection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatabaseConnectionView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private devControls.devStatusBar sbMain;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private devControls.devLoading devLoadingMain;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private devControls.devGroupBox devGroupBox4;
        private DevExpress.XtraNavBar.NavBarControl navBarControl2;
        private DevExpress.XtraNavBar.NavBarGroup nbgItems;
        private DevExpress.XtraNavBar.NavBarItem btnAdd;
        private DevExpress.XtraNavBar.NavBarItem btnEdit;
        private DevExpress.XtraNavBar.NavBarItem btnDelete;
        private DevExpress.XtraNavBar.NavBarItem btnShowPassword;
        private DevExpress.XtraNavBar.NavBarItem btnRegisterMAC;
        private DevExpress.XtraNavBar.NavBarItem btnAccessRights;
        private DevExpress.XtraNavBar.NavBarGroup nbgOptions;
        private DevExpress.XtraNavBar.NavBarItem btnClose;
        private devControls.devGroupBox devGroupBox3;
        private devControls.devLoading devLoadingData;
        private DevExpress.XtraGrid.GridControl grdDatabaseConnection;
        private DevExpress.XtraGrid.Views.Grid.GridView grdDatabaseConnectionView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox5;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox4;
        private devControls.devGroupBoxTop devGroupBoxTop3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Timer timLoad;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
    }
}