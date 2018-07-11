namespace QBook.Forms
{
    partial class frmProperty
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProperty));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnAddProperty = new DevExpress.XtraNavBar.NavBarItem();
            this.btnEditProperty = new DevExpress.XtraNavBar.NavBarItem();
            this.btnRemoveProperty = new DevExpress.XtraNavBar.NavBarItem();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdProperty = new DevExpress.XtraGrid.GridControl();
            this.grdPropertyView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProperty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemImageComboBox5 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl4 = new DevExpress.XtraEditors.SplitContainerControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl5 = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnAddLinkedAccount = new DevExpress.XtraNavBar.NavBarItem();
            this.btnEditLinkedAccount = new DevExpress.XtraNavBar.NavBarItem();
            this.btnRemoveLinkedAccount = new DevExpress.XtraNavBar.NavBarItem();
            this.timLoad = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            this.splitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPropertyView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl4)).BeginInit();
            this.splitContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl5)).BeginInit();
            this.splitContainerControl5.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.navBarControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(871, 477);
            this.splitContainerControl1.SplitterPosition = 143;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btnAddProperty,
            this.btnEditProperty,
            this.btnRemoveProperty,
            this.btnAddLinkedAccount,
            this.btnEditLinkedAccount,
            this.btnRemoveLinkedAccount});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 143;
            this.navBarControl1.Size = new System.Drawing.Size(143, 477);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Properties";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnAddProperty),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnEditProperty),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnRemoveProperty)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // btnAddProperty
            // 
            this.btnAddProperty.Caption = "Add";
            this.btnAddProperty.Name = "btnAddProperty";
            this.btnAddProperty.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAddProperty.SmallImage")));
            this.btnAddProperty.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnAddProperty_LinkClicked);
            // 
            // btnEditProperty
            // 
            this.btnEditProperty.Caption = "Edit";
            this.btnEditProperty.Name = "btnEditProperty";
            this.btnEditProperty.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnEditProperty.SmallImage")));
            this.btnEditProperty.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnEditProperty_LinkClicked);
            // 
            // btnRemoveProperty
            // 
            this.btnRemoveProperty.Caption = "Remove";
            this.btnRemoveProperty.Name = "btnRemoveProperty";
            this.btnRemoveProperty.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveProperty.SmallImage")));
            this.btnRemoveProperty.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnRemoveProperty_LinkClicked);
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.splitContainerControl3);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.splitContainerControl5);
            this.splitContainerControl2.Panel2.Controls.Add(this.labelControl3);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(723, 477);
            this.splitContainerControl2.SplitterPosition = 234;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl3.Horizontal = false;
            this.splitContainerControl3.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl3.Name = "splitContainerControl3";
            this.splitContainerControl3.Panel1.Controls.Add(this.grdProperty);
            this.splitContainerControl3.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl3.Panel1.Text = "Panel1";
            this.splitContainerControl3.Panel2.Controls.Add(this.splitContainerControl4);
            this.splitContainerControl3.Panel2.Controls.Add(this.labelControl2);
            this.splitContainerControl3.Panel2.Text = "Panel2";
            this.splitContainerControl3.Size = new System.Drawing.Size(234, 477);
            this.splitContainerControl3.SplitterPosition = 351;
            this.splitContainerControl3.TabIndex = 3;
            this.splitContainerControl3.Text = "splitContainerControl3";
            // 
            // grdProperty
            // 
            this.grdProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProperty.Location = new System.Drawing.Point(0, 17);
            this.grdProperty.MainView = this.grdPropertyView;
            this.grdProperty.Name = "grdProperty";
            this.grdProperty.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit3,
            this.repositoryItemImageComboBox5,
            this.repositoryItemImageComboBox4,
            this.repositoryItemImageComboBox1});
            this.grdProperty.Size = new System.Drawing.Size(234, 334);
            this.grdProperty.TabIndex = 6;
            this.grdProperty.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdPropertyView});
            // 
            // grdPropertyView
            // 
            this.grdPropertyView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grdPropertyView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colProperty});
            this.grdPropertyView.GridControl = this.grdProperty;
            this.grdPropertyView.Name = "grdPropertyView";
            this.grdPropertyView.OptionsBehavior.AllowIncrementalSearch = true;
            this.grdPropertyView.OptionsBehavior.Editable = false;
            this.grdPropertyView.OptionsFind.AlwaysVisible = true;
            this.grdPropertyView.OptionsMenu.EnableColumnMenu = false;
            this.grdPropertyView.OptionsView.ShowGroupPanel = false;
            this.grdPropertyView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colProperty, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grdPropertyView.DoubleClick += new System.EventHandler(this.grdPropertyView_DoubleClick);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.Name = "colID";
            // 
            // colProperty
            // 
            this.colProperty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProperty.AppearanceHeader.Options.UseFont = true;
            this.colProperty.AppearanceHeader.Options.UseTextOptions = true;
            this.colProperty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProperty.Caption = "Property";
            this.colProperty.FieldName = "Property";
            this.colProperty.Name = "colProperty";
            this.colProperty.Visible = true;
            this.colProperty.VisibleIndex = 0;
            this.colProperty.Width = 327;
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
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(234, 17);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "PROPERTIES";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseBackColor = true;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl2.Location = new System.Drawing.Point(0, 0);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(234, 17);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "ACCOUNTS";
            // 
            // splitContainerControl4
            // 
            this.splitContainerControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl4.Location = new System.Drawing.Point(0, 17);
            this.splitContainerControl4.Name = "splitContainerControl4";
            this.splitContainerControl4.Panel1.Text = "Panel1";
            this.splitContainerControl4.Panel2.Text = "Panel2";
            this.splitContainerControl4.Size = new System.Drawing.Size(234, 104);
            this.splitContainerControl4.SplitterPosition = 116;
            this.splitContainerControl4.TabIndex = 9;
            this.splitContainerControl4.Text = "splitContainerControl4";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseBackColor = true;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl3.Location = new System.Drawing.Point(0, 0);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(484, 17);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "TRANSACTIONS";
            // 
            // splitContainerControl5
            // 
            this.splitContainerControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl5.Location = new System.Drawing.Point(0, 17);
            this.splitContainerControl5.Name = "splitContainerControl5";
            this.splitContainerControl5.Panel1.Text = "Panel1";
            this.splitContainerControl5.Panel2.Text = "Panel2";
            this.splitContainerControl5.Size = new System.Drawing.Size(484, 460);
            this.splitContainerControl5.SplitterPosition = 242;
            this.splitContainerControl5.TabIndex = 10;
            this.splitContainerControl5.Text = "splitContainerControl5";
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Linked Accounts";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnAddLinkedAccount),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnEditLinkedAccount),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnRemoveLinkedAccount)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // btnAddLinkedAccount
            // 
            this.btnAddLinkedAccount.Caption = "Add";
            this.btnAddLinkedAccount.Name = "btnAddLinkedAccount";
            this.btnAddLinkedAccount.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAddLinkedAccount.SmallImage")));
            // 
            // btnEditLinkedAccount
            // 
            this.btnEditLinkedAccount.Caption = "Edit";
            this.btnEditLinkedAccount.Name = "btnEditLinkedAccount";
            this.btnEditLinkedAccount.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnEditLinkedAccount.SmallImage")));
            // 
            // btnRemoveLinkedAccount
            // 
            this.btnRemoveLinkedAccount.Caption = "Remove";
            this.btnRemoveLinkedAccount.Name = "btnRemoveLinkedAccount";
            this.btnRemoveLinkedAccount.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveLinkedAccount.SmallImage")));
            // 
            // timLoad
            // 
            this.timLoad.Interval = 10;
            this.timLoad.Tick += new System.EventHandler(this.timLoad_Tick);
            // 
            // frmProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 477);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmProperty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Properties";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.frmProperty_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPropertyView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl4)).EndInit();
            this.splitContainerControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl5)).EndInit();
            this.splitContainerControl5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem btnAddProperty;
        private DevExpress.XtraNavBar.NavBarItem btnEditProperty;
        private DevExpress.XtraNavBar.NavBarItem btnRemoveProperty;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
        private DevExpress.XtraGrid.GridControl grdProperty;
        private DevExpress.XtraGrid.Views.Grid.GridView grdPropertyView;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colProperty;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox5;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox4;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem btnAddLinkedAccount;
        private DevExpress.XtraNavBar.NavBarItem btnEditLinkedAccount;
        private DevExpress.XtraNavBar.NavBarItem btnRemoveLinkedAccount;
        private System.Windows.Forms.Timer timLoad;
    }
}