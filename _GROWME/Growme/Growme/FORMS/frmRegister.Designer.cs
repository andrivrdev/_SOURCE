namespace Growme.FORMS
{
    partial class frmRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegister));
            this.label1 = new System.Windows.Forms.Label();
            this.edtPassword1 = new DevExpress.XtraEditors.TextEdit();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.edtEmail = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.edtPassword2 = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.lblAlias = new System.Windows.Forms.Label();
            this.edtAlias = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.edtPassword1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPassword2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAlias.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Password";
            // 
            // edtPassword1
            // 
            this.edtPassword1.Location = new System.Drawing.Point(14, 235);
            this.edtPassword1.Name = "edtPassword1";
            this.edtPassword1.Properties.MaxLength = 50;
            this.edtPassword1.Properties.PasswordChar = '*';
            this.edtPassword1.Size = new System.Drawing.Size(230, 20);
            this.edtPassword1.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(11, 180);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(31, 13);
            this.lblUser.TabIndex = 29;
            this.lblUser.Text = "Email";
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(169, 309);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Register me";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(14, 309);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // edtEmail
            // 
            this.edtEmail.Location = new System.Drawing.Point(14, 196);
            this.edtEmail.Name = "edtEmail";
            this.edtEmail.Properties.MaxLength = 50;
            this.edtEmail.Size = new System.Drawing.Size(230, 20);
            this.edtEmail.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Confirm Password";
            // 
            // edtPassword2
            // 
            this.edtPassword2.Location = new System.Drawing.Point(14, 274);
            this.edtPassword2.Name = "edtPassword2";
            this.edtPassword2.Properties.MaxLength = 50;
            this.edtPassword2.Properties.PasswordChar = '*';
            this.edtPassword2.Size = new System.Drawing.Size(230, 20);
            this.edtPassword2.TabIndex = 3;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AllowFocused = false;
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Properties.SvgImageSize = new System.Drawing.Size(100, 100);
            this.pictureEdit1.Size = new System.Drawing.Size(255, 120);
            this.pictureEdit1.TabIndex = 33;
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.Location = new System.Drawing.Point(11, 141);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(29, 13);
            this.lblAlias.TabIndex = 35;
            this.lblAlias.Text = "Alias";
            // 
            // edtAlias
            // 
            this.edtAlias.Location = new System.Drawing.Point(14, 157);
            this.edtAlias.Name = "edtAlias";
            this.edtAlias.Properties.MaxLength = 50;
            this.edtAlias.Size = new System.Drawing.Size(230, 20);
            this.edtAlias.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.labelControl1.Appearance.BackColor2 = System.Drawing.Color.White;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 2F);
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(0, 120);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(255, 2);
            this.labelControl1.TabIndex = 37;
            // 
            // frmRegister
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(255, 342);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblAlias);
            this.Controls.Add(this.edtAlias);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edtPassword2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtPassword1);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.edtEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register a new account";
            ((System.ComponentModel.ISupportInitialize)(this.edtPassword1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPassword2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAlias.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public DevExpress.XtraEditors.TextEdit edtPassword1;
        private System.Windows.Forms.Label lblUser;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        public DevExpress.XtraEditors.TextEdit edtEmail;
        private System.Windows.Forms.Label label2;
        public DevExpress.XtraEditors.TextEdit edtPassword2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.Label lblAlias;
        public DevExpress.XtraEditors.TextEdit edtAlias;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}