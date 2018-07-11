namespace devGeneric.devForms
{
    partial class frmConnectionDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConnectionDetails));
            this.sbMain = new devGeneric.devControls.devStatusBar();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.edtConnString = new DevExpress.XtraEditors.ButtonEdit();
            this.edtDatabase = new DevExpress.XtraEditors.TextEdit();
            this.edtPort = new DevExpress.XtraEditors.SpinEdit();
            this.edtHost = new DevExpress.XtraEditors.TextEdit();
            this.edtPassword = new DevExpress.XtraEditors.TextEdit();
            this.edtUsername = new DevExpress.XtraEditors.TextEdit();
            this.edtType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.edtDesc = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtConnString.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDesc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sbMain
            // 
            this.sbMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sbMain.BackgroundImage")));
            this.sbMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sbMain.Location = new System.Drawing.Point(0, 249);
            this.sbMain.MinimumSize = new System.Drawing.Size(4, 20);
            this.sbMain.Name = "sbMain";
            this.sbMain.Size = new System.Drawing.Size(645, 20);
            this.sbMain.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.panelControl2.Appearance.BackColor2 = System.Drawing.Color.Black;
            this.panelControl2.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Controls.Add(this.edtConnString);
            this.panelControl2.Controls.Add(this.edtDatabase);
            this.panelControl2.Controls.Add(this.edtPort);
            this.panelControl2.Controls.Add(this.edtHost);
            this.panelControl2.Controls.Add(this.edtPassword);
            this.panelControl2.Controls.Add(this.edtUsername);
            this.panelControl2.Controls.Add(this.edtType);
            this.panelControl2.Controls.Add(this.labelControl8);
            this.panelControl2.Controls.Add(this.labelControl7);
            this.panelControl2.Controls.Add(this.labelControl6);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.btnAccept);
            this.panelControl2.Controls.Add(this.btnCancel);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.edtDesc);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(645, 249);
            this.panelControl2.TabIndex = 30;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = global::devGeneric.Properties.Resources.sDatabase;
            this.simpleButton1.Location = new System.Drawing.Point(285, 213);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 22;
            this.simpleButton1.Text = "Test";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // edtConnString
            // 
            this.edtConnString.Location = new System.Drawing.Point(111, 168);
            this.edtConnString.Name = "edtConnString";
            this.edtConnString.Properties.ReadOnly = true;
            this.edtConnString.Size = new System.Drawing.Size(520, 22);
            this.edtConnString.TabIndex = 20;
            // 
            // edtDatabase
            // 
            this.edtDatabase.Location = new System.Drawing.Point(111, 142);
            this.edtDatabase.Name = "edtDatabase";
            this.edtDatabase.Properties.MaxLength = 20;
            this.edtDatabase.Size = new System.Drawing.Size(166, 22);
            this.edtDatabase.TabIndex = 6;
            this.edtDatabase.EditValueChanged += new System.EventHandler(this.edtDatabase_EditValueChanged);
            // 
            // edtPort
            // 
            this.edtPort.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.edtPort.Location = new System.Drawing.Point(309, 64);
            this.edtPort.Name = "edtPort";
            this.edtPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtPort.Size = new System.Drawing.Size(60, 22);
            this.edtPort.TabIndex = 3;
            this.edtPort.EditValueChanged += new System.EventHandler(this.edtPort_EditValueChanged);
            // 
            // edtHost
            // 
            this.edtHost.Location = new System.Drawing.Point(111, 64);
            this.edtHost.Name = "edtHost";
            this.edtHost.Properties.MaxLength = 20;
            this.edtHost.Size = new System.Drawing.Size(166, 22);
            this.edtHost.TabIndex = 2;
            this.edtHost.EditValueChanged += new System.EventHandler(this.edtHost_EditValueChanged);
            // 
            // edtPassword
            // 
            this.edtPassword.Location = new System.Drawing.Point(111, 116);
            this.edtPassword.Name = "edtPassword";
            this.edtPassword.Properties.MaxLength = 20;
            this.edtPassword.Properties.PasswordChar = '*';
            this.edtPassword.Size = new System.Drawing.Size(166, 22);
            this.edtPassword.TabIndex = 5;
            this.edtPassword.EditValueChanged += new System.EventHandler(this.edtPassword_EditValueChanged);
            // 
            // edtUsername
            // 
            this.edtUsername.Location = new System.Drawing.Point(111, 90);
            this.edtUsername.Name = "edtUsername";
            this.edtUsername.Properties.MaxLength = 20;
            this.edtUsername.Size = new System.Drawing.Size(166, 22);
            this.edtUsername.TabIndex = 4;
            this.edtUsername.EditValueChanged += new System.EventHandler(this.edtUsername_EditValueChanged);
            // 
            // edtType
            // 
            this.edtType.Location = new System.Drawing.Point(111, 38);
            this.edtType.Name = "edtType";
            this.edtType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtType.Properties.Items.AddRange(new object[] {
            "Microsoft SQL Server"});
            this.edtType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.edtType.Size = new System.Drawing.Size(167, 22);
            this.edtType.TabIndex = 1;
            this.edtType.EditValueChanged += new System.EventHandler(this.edtType_EditValueChanged);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(21, 171);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(85, 13);
            this.labelControl8.TabIndex = 19;
            this.labelControl8.Text = "Connection String";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(283, 67);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(20, 13);
            this.labelControl7.TabIndex = 18;
            this.labelControl7.Text = "Port";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(60, 145);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(46, 13);
            this.labelControl6.TabIndex = 17;
            this.labelControl6.Text = "Database";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(82, 67);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(22, 13);
            this.labelControl5.TabIndex = 16;
            this.labelControl5.Text = "Host";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(58, 119);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(46, 13);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "Password";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(56, 93);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Username";
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.ImageOptions.Image = global::devGeneric.Properties.Resources.sAccept;
            this.btnAccept.Location = new System.Drawing.Point(204, 213);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 9;
            this.btnAccept.Text = "Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageOptions.Image = global::devGeneric.Properties.Resources.sCancel;
            this.btnCancel.Location = new System.Drawing.Point(366, 213);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(82, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 13);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Type";
            // 
            // edtDesc
            // 
            this.edtDesc.Location = new System.Drawing.Point(111, 11);
            this.edtDesc.Name = "edtDesc";
            this.edtDesc.Properties.MaxLength = 20;
            this.edtDesc.Size = new System.Drawing.Size(258, 22);
            this.edtDesc.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(52, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 13);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Description";
            // 
            // frmConnectionDetails
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(645, 269);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.sbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConnectionDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection Details";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtConnString.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDesc.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private devControls.devStatusBar sbMain;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        public DevExpress.XtraEditors.ButtonEdit edtConnString;
        public DevExpress.XtraEditors.TextEdit edtDatabase;
        public DevExpress.XtraEditors.SpinEdit edtPort;
        public DevExpress.XtraEditors.TextEdit edtHost;
        public DevExpress.XtraEditors.TextEdit edtPassword;
        public DevExpress.XtraEditors.TextEdit edtUsername;
        public DevExpress.XtraEditors.ComboBoxEdit edtType;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit edtDesc;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}