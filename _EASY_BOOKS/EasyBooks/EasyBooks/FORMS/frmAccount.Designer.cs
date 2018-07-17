namespace EasyBooks.FORMS
{
    partial class frmAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccount));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnAdd = new DevExpress.XtraNavBar.NavBarItem();
            this.btnEdit = new DevExpress.XtraNavBar.NavBarItem();
            this.btnRemove = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.grdAccount = new DevExpress.XtraGrid.GridControl();
            this.grdAccountView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.repositoryItemImageEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemImageComboBox5 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.timLoad = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAccountView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.navBarControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdAccount);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(569, 426);
            this.splitContainerControl1.SplitterPosition = 143;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnRemove,
            this.navBarItem1});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 143;
            this.navBarControl1.Size = new System.Drawing.Size(143, 426);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Accounts";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnAdd),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnEdit),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnRemove)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Add";
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.SmallImage")));
            this.btnAdd.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnAdd_LinkClicked);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.SmallImage")));
            this.btnEdit.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnEdit_LinkClicked);
            // 
            // btnRemove
            // 
            this.btnRemove.Caption = "Remove";
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRemove.SmallImage")));
            this.btnRemove.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnRemove_LinkClicked);
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "navBarItem1";
            this.navBarItem1.Name = "navBarItem1";
            // 
            // grdAccount
            // 
            this.grdAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAccount.Location = new System.Drawing.Point(0, 0);
            this.grdAccount.MainView = this.grdAccountView;
            this.grdAccount.Name = "grdAccount";
            this.grdAccount.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit3,
            this.repositoryItemImageComboBox5,
            this.repositoryItemImageComboBox4,
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageEdit1,
            this.repositoryItemImageComboBox2});
            this.grdAccount.Size = new System.Drawing.Size(420, 426);
            this.grdAccount.TabIndex = 5;
            this.grdAccount.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdAccountView});
            // 
            // grdAccountView
            // 
            this.grdAccountView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grdAccountView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colName,
            this.colIO});
            this.grdAccountView.GridControl = this.grdAccount;
            this.grdAccountView.Name = "grdAccountView";
            this.grdAccountView.OptionsBehavior.AllowIncrementalSearch = true;
            this.grdAccountView.OptionsBehavior.Editable = false;
            this.grdAccountView.OptionsFind.AlwaysVisible = true;
            this.grdAccountView.OptionsMenu.EnableColumnMenu = false;
            this.grdAccountView.OptionsView.ShowGroupPanel = false;
            this.grdAccountView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grdAccountView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdAccountView_KeyPress);
            this.grdAccountView.DoubleClick += new System.EventHandler(this.grdAccountView_DoubleClick);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colName
            // 
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "Account Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 293;
            // 
            // colIO
            // 
            this.colIO.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIO.AppearanceHeader.Options.UseFont = true;
            this.colIO.AppearanceHeader.Options.UseTextOptions = true;
            this.colIO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIO.Caption = "Account Type";
            this.colIO.ColumnEdit = this.repositoryItemImageComboBox2;
            this.colIO.FieldName = "IO";
            this.colIO.Name = "colIO";
            this.colIO.Visible = true;
            this.colIO.VisibleIndex = 1;
            this.colIO.Width = 112;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Money In", "I", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Money Out", "O", 1)});
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            this.repositoryItemImageComboBox2.SmallImages = this.imageCollection1;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("iconsetsigns3_16x16.png", "images/conditional%20formatting/iconsetsigns3_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/conditional%20formatting/iconsetsigns3_16x16.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "iconsetsigns3_16x16.png");
            this.imageCollection1.InsertGalleryImage("iconsetredtoblack4_16x16.png", "images/conditional%20formatting/iconsetredtoblack4_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/conditional%20formatting/iconsetredtoblack4_16x16.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "iconsetredtoblack4_16x16.png");
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
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // timLoad
            // 
            this.timLoad.Interval = 10;
            this.timLoad.Tick += new System.EventHandler(this.timLoad_Tick);
            // 
            // frmAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 426);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accounts";
            this.Shown += new System.EventHandler(this.frmAccount_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAccountView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem btnAdd;
        private DevExpress.XtraNavBar.NavBarItem btnEdit;
        private DevExpress.XtraNavBar.NavBarItem btnRemove;
        private System.Windows.Forms.Timer timLoad;
        private DevExpress.XtraGrid.GridControl grdAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView grdAccountView;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox5;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox4;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colIO;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
    }
}