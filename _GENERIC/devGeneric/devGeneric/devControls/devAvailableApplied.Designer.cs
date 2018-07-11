namespace devGeneric.devControls
{
    partial class devAvailableApplied
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbAvail = new devGeneric.devControls.devGroupBox();
            this.devLoading2 = new devGeneric.devControls.devLoading();
            this.devGroupBoxTop1 = new devGeneric.devControls.devGroupBoxTop();
            this.grdA = new DevExpress.XtraGrid.GridControl();
            this.grdAView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gbApplied = new devGeneric.devControls.devGroupBox();
            this.devLoading1 = new devGeneric.devControls.devLoading();
            this.devGroupBoxTop2 = new devGeneric.devControls.devGroupBoxTop();
            this.grdB = new DevExpress.XtraGrid.GridControl();
            this.grdBView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemImageEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gbAvail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            this.gbApplied.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAvail
            // 
            this.gbAvail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbAvail.Appearance.BackColor = System.Drawing.Color.Black;
            this.gbAvail.Appearance.Options.UseBackColor = true;
            this.gbAvail.Controls.Add(this.devLoading2);
            this.gbAvail.Controls.Add(this.devGroupBoxTop1);
            this.gbAvail.Controls.Add(this.grdA);
            this.gbAvail.Location = new System.Drawing.Point(0, 0);
            this.gbAvail.Margin = new System.Windows.Forms.Padding(10);
            this.gbAvail.Name = "gbAvail";
            this.gbAvail.Padding = new System.Windows.Forms.Padding(1);
            this.gbAvail.Size = new System.Drawing.Size(315, 478);
            this.gbAvail.TabIndex = 15;
            // 
            // devLoading2
            // 
            this.devLoading2.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.devLoading2.Appearance.BackColor2 = System.Drawing.Color.Silver;
            this.devLoading2.Appearance.Options.UseBackColor = true;
            this.devLoading2.devCaption1 = "Please Wait";
            this.devLoading2.devCaption2 = "";
            this.devLoading2.Location = new System.Drawing.Point(83, 185);
            this.devLoading2.Name = "devLoading2";
            this.devLoading2.Size = new System.Drawing.Size(173, 106);
            this.devLoading2.TabIndex = 21;
            this.devLoading2.Visible = false;
            // 
            // devGroupBoxTop1
            // 
            this.devGroupBoxTop1.Appearance.BackColor = System.Drawing.Color.Black;
            this.devGroupBoxTop1.Appearance.Options.UseBackColor = true;
            this.devGroupBoxTop1.devCaption = "Available Items";
            this.devGroupBoxTop1.devCaptionGradientColor = System.Drawing.Color.SlateGray;
            this.devGroupBoxTop1.devLineColor1 = System.Drawing.Color.Red;
            this.devGroupBoxTop1.devLineColor2 = System.Drawing.Color.Maroon;
            this.devGroupBoxTop1.Dock = System.Windows.Forms.DockStyle.Top;
            this.devGroupBoxTop1.Location = new System.Drawing.Point(1, 1);
            this.devGroupBoxTop1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.devGroupBoxTop1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.devGroupBoxTop1.MaximumSize = new System.Drawing.Size(10000, 19);
            this.devGroupBoxTop1.MinimumSize = new System.Drawing.Size(0, 20);
            this.devGroupBoxTop1.Name = "devGroupBoxTop1";
            this.devGroupBoxTop1.Size = new System.Drawing.Size(313, 20);
            this.devGroupBoxTop1.TabIndex = 0;
            // 
            // grdA
            // 
            this.grdA.AllowDrop = true;
            this.grdA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdA.Location = new System.Drawing.Point(1, 23);
            this.grdA.MainView = this.grdAView;
            this.grdA.Name = "grdA";
            this.grdA.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit1,
            this.repositoryItemImageComboBox1});
            this.grdA.Size = new System.Drawing.Size(312, 454);
            this.grdA.TabIndex = 24;
            this.grdA.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdAView});
            this.grdA.DragDrop += new System.Windows.Forms.DragEventHandler(this.GenericGrid_DragDrop);
            this.grdA.DragOver += new System.Windows.Forms.DragEventHandler(this.GenericGrid_DragOver);
            // 
            // grdAView
            // 
            this.grdAView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grdAView.GridControl = this.grdA;
            this.grdAView.Name = "grdAView";
            this.grdAView.OptionsBehavior.AllowIncrementalSearch = true;
            this.grdAView.OptionsBehavior.Editable = false;
            this.grdAView.OptionsFind.AlwaysVisible = true;
            this.grdAView.OptionsMenu.EnableColumnMenu = false;
            this.grdAView.OptionsSelection.MultiSelect = true;
            this.grdAView.OptionsView.ShowGroupPanel = false;
            this.grdAView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GenericGridiew_MouseDown);
            this.grdAView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GenericGridView_MouseMove);
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("No", false, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Yes", true, 1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // gbApplied
            // 
            this.gbApplied.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbApplied.Appearance.BackColor = System.Drawing.Color.Black;
            this.gbApplied.Appearance.Options.UseBackColor = true;
            this.gbApplied.Controls.Add(this.devLoading1);
            this.gbApplied.Controls.Add(this.devGroupBoxTop2);
            this.gbApplied.Controls.Add(this.grdB);
            this.gbApplied.Location = new System.Drawing.Point(316, 0);
            this.gbApplied.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.gbApplied.Margin = new System.Windows.Forms.Padding(10);
            this.gbApplied.Name = "gbApplied";
            this.gbApplied.Padding = new System.Windows.Forms.Padding(1);
            this.gbApplied.Size = new System.Drawing.Size(315, 478);
            this.gbApplied.TabIndex = 16;
            // 
            // devLoading1
            // 
            this.devLoading1.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.devLoading1.Appearance.BackColor2 = System.Drawing.Color.Silver;
            this.devLoading1.Appearance.Options.UseBackColor = true;
            this.devLoading1.devCaption1 = "Please Wait";
            this.devLoading1.devCaption2 = "";
            this.devLoading1.Location = new System.Drawing.Point(83, 185);
            this.devLoading1.Name = "devLoading1";
            this.devLoading1.Size = new System.Drawing.Size(167, 106);
            this.devLoading1.TabIndex = 21;
            this.devLoading1.Visible = false;
            // 
            // devGroupBoxTop2
            // 
            this.devGroupBoxTop2.Appearance.BackColor = System.Drawing.Color.Black;
            this.devGroupBoxTop2.Appearance.Options.UseBackColor = true;
            this.devGroupBoxTop2.devCaption = "Applied Items";
            this.devGroupBoxTop2.devCaptionGradientColor = System.Drawing.Color.SlateGray;
            this.devGroupBoxTop2.devLineColor1 = System.Drawing.Color.LimeGreen;
            this.devGroupBoxTop2.devLineColor2 = System.Drawing.Color.DarkGreen;
            this.devGroupBoxTop2.Dock = System.Windows.Forms.DockStyle.Top;
            this.devGroupBoxTop2.Location = new System.Drawing.Point(1, 1);
            this.devGroupBoxTop2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.devGroupBoxTop2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.devGroupBoxTop2.MaximumSize = new System.Drawing.Size(10000, 19);
            this.devGroupBoxTop2.MinimumSize = new System.Drawing.Size(0, 20);
            this.devGroupBoxTop2.Name = "devGroupBoxTop2";
            this.devGroupBoxTop2.Size = new System.Drawing.Size(313, 20);
            this.devGroupBoxTop2.TabIndex = 0;
            // 
            // grdB
            // 
            this.grdB.AllowDrop = true;
            this.grdB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdB.Location = new System.Drawing.Point(1, 23);
            this.grdB.MainView = this.grdBView;
            this.grdB.Name = "grdB";
            this.grdB.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit2,
            this.repositoryItemImageComboBox2});
            this.grdB.Size = new System.Drawing.Size(312, 454);
            this.grdB.TabIndex = 25;
            this.grdB.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdBView});
            this.grdB.DragDrop += new System.Windows.Forms.DragEventHandler(this.GenericGrid_DragDrop);
            this.grdB.DragOver += new System.Windows.Forms.DragEventHandler(this.GenericGrid_DragOver);
            // 
            // grdBView
            // 
            this.grdBView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grdBView.GridControl = this.grdB;
            this.grdBView.Name = "grdBView";
            this.grdBView.OptionsBehavior.AllowIncrementalSearch = true;
            this.grdBView.OptionsBehavior.Editable = false;
            this.grdBView.OptionsFind.AlwaysVisible = true;
            this.grdBView.OptionsMenu.EnableColumnMenu = false;
            this.grdBView.OptionsSelection.MultiSelect = true;
            this.grdBView.OptionsView.ShowGroupPanel = false;
            this.grdBView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GenericGridiew_MouseDown);
            this.grdBView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GenericGridView_MouseMove);
            // 
            // repositoryItemImageEdit2
            // 
            this.repositoryItemImageEdit2.AutoHeight = false;
            this.repositoryItemImageEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit2.Name = "repositoryItemImageEdit2";
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("No", false, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Yes", true, 1)});
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            // 
            // devAvailableApplied
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbApplied);
            this.Controls.Add(this.gbAvail);
            this.DoubleBuffered = true;
            this.Name = "devAvailableApplied";
            this.Size = new System.Drawing.Size(631, 478);
            this.ClientSizeChanged += new System.EventHandler(this.devAvailableApplied_ClientSizeChanged);
            this.gbAvail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            this.gbApplied.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private devGroupBox gbAvail;
        private devLoading devLoading2;
        private devGroupBoxTop devGroupBoxTop1;
        private devGroupBox gbApplied;
        private devLoading devLoading1;
        private devGroupBoxTop devGroupBoxTop2;
        private DevExpress.XtraGrid.GridControl grdA;
        private DevExpress.XtraGrid.Views.Grid.GridView grdAView;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.GridControl grdB;
        private DevExpress.XtraGrid.Views.Grid.GridView grdBView;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
    }
}
