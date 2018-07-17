namespace EasyBooks.FORMS
{
    partial class frmItemAccountDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.edtItem = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.edtAccount = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.edtAccountType = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAccountType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Item";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(79, 99);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(160, 99);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            // 
            // edtItem
            // 
            this.edtItem.Enabled = false;
            this.edtItem.Location = new System.Drawing.Point(92, 6);
            this.edtItem.Name = "edtItem";
            this.edtItem.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.edtItem.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.edtItem.Properties.Appearance.Options.UseBackColor = true;
            this.edtItem.Properties.Appearance.Options.UseForeColor = true;
            this.edtItem.Properties.MaxLength = 20;
            this.edtItem.Properties.ReadOnly = true;
            this.edtItem.Size = new System.Drawing.Size(211, 20);
            this.edtItem.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
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
            this.edtAccount.Size = new System.Drawing.Size(211, 20);
            this.edtAccount.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
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
            // frmItemAccountDetails
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
            this.Controls.Add(this.edtItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItemAccountDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Account Details";
            ((System.ComponentModel.ISupportInitialize)(this.edtItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAccountType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        public DevExpress.XtraEditors.TextEdit edtItem;
        private System.Windows.Forms.Label label2;
        public DevExpress.XtraEditors.ComboBoxEdit edtAccount;
        private System.Windows.Forms.Label label3;
        public DevExpress.XtraEditors.TextEdit edtAccountType;
    }
}