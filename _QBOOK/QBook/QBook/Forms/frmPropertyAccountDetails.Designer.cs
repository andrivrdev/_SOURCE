namespace QBook.Forms
{
    partial class frmPropertyAccountDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPropertyAccountDetails));
            this.label1 = new System.Windows.Forms.Label();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.edtProperty = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.edtAccount = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.edtAccountType = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProperty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAccountType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Property";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAccept.ImageOptions.Image")));
            this.btnAccept.Location = new System.Drawing.Point(79, 99);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Accept";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(160, 99);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            // 
            // edtProperty
            // 
            this.edtProperty.Enabled = false;
            this.edtProperty.Location = new System.Drawing.Point(92, 6);
            this.edtProperty.Name = "edtProperty";
            this.edtProperty.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.edtProperty.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.edtProperty.Properties.Appearance.Options.UseBackColor = true;
            this.edtProperty.Properties.Appearance.Options.UseForeColor = true;
            this.edtProperty.Properties.MaxLength = 20;
            this.edtProperty.Properties.ReadOnly = true;
            this.edtProperty.Size = new System.Drawing.Size(211, 20);
            this.edtProperty.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Account";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtAccount
            // 
            this.edtAccount.Location = new System.Drawing.Point(92, 58);
            this.edtAccount.Name = "edtAccount";
            this.edtAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtAccount.Properties.DropDownRows = 15;
            this.edtAccount.Properties.Sorted = true;
            this.edtAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.edtAccount.Size = new System.Drawing.Size(210, 20);
            this.edtAccount.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Account Type";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtAccountType
            // 
            this.edtAccountType.Enabled = false;
            this.edtAccountType.Location = new System.Drawing.Point(92, 32);
            this.edtAccountType.Name = "edtAccountType";
            this.edtAccountType.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.edtAccountType.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.edtAccountType.Properties.Appearance.Options.UseBackColor = true;
            this.edtAccountType.Properties.Appearance.Options.UseForeColor = true;
            this.edtAccountType.Properties.MaxLength = 20;
            this.edtAccountType.Properties.ReadOnly = true;
            this.edtAccountType.Size = new System.Drawing.Size(211, 20);
            this.edtAccountType.TabIndex = 27;
            // 
            // frmPropertyAccountDetails
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(315, 134);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edtAccountType);
            this.Controls.Add(this.edtAccount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.edtProperty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPropertyAccountDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Property Account Details";
            ((System.ComponentModel.ISupportInitialize)(this.edtProperty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAccountType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        public DevExpress.XtraEditors.TextEdit edtProperty;
        private System.Windows.Forms.Label label2;
        public DevExpress.XtraEditors.ComboBoxEdit edtAccount;
        private System.Windows.Forms.Label label3;
        public DevExpress.XtraEditors.TextEdit edtAccountType;
    }
}