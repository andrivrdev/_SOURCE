namespace EasyBooks.FORMS
{
    partial class frmItemAccountTransactionDetails
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
            this.label3 = new System.Windows.Forms.Label();
            this.edtAccountType = new DevExpress.XtraEditors.TextEdit();
            this.edtAccount = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.edtItem = new DevExpress.XtraEditors.TextEdit();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.edtReference = new DevExpress.XtraEditors.TextEdit();
            this.edtDate = new DevExpress.XtraEditors.DateEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.edtDescription = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.edtAmount = new System.Windows.Forms.NumericUpDown();
            this.edtReferenceCombo = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAccountType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReference.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenceCombo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Account Type";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtAccountType
            // 
            this.edtAccountType.Enabled = false;
            this.edtAccountType.Location = new System.Drawing.Point(113, 38);
            this.edtAccountType.Name = "edtAccountType";
            this.edtAccountType.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.edtAccountType.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.edtAccountType.Properties.Appearance.Options.UseBackColor = true;
            this.edtAccountType.Properties.Appearance.Options.UseForeColor = true;
            this.edtAccountType.Properties.MaxLength = 20;
            this.edtAccountType.Properties.ReadOnly = true;
            this.edtAccountType.Size = new System.Drawing.Size(211, 20);
            this.edtAccountType.TabIndex = 2;
            // 
            // edtAccount
            // 
            this.edtAccount.Location = new System.Drawing.Point(113, 90);
            this.edtAccount.Name = "edtAccount";
            this.edtAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtAccount.Properties.DropDownRows = 15;
            this.edtAccount.Properties.Sorted = true;
            this.edtAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.edtAccount.Size = new System.Drawing.Size(211, 20);
            this.edtAccount.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Account";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Item";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtItem
            // 
            this.edtItem.Enabled = false;
            this.edtItem.Location = new System.Drawing.Point(113, 12);
            this.edtItem.Name = "edtItem";
            this.edtItem.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.edtItem.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.edtItem.Properties.Appearance.Options.UseBackColor = true;
            this.edtItem.Properties.Appearance.Options.UseForeColor = true;
            this.edtItem.Properties.MaxLength = 20;
            this.edtItem.Properties.ReadOnly = true;
            this.edtItem.Size = new System.Drawing.Size(211, 20);
            this.edtItem.TabIndex = 1;
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(94, 216);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 9;
            this.btnAccept.Text = "Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(175, 216);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Reference";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtReference
            // 
            this.edtReference.Enabled = false;
            this.edtReference.Location = new System.Drawing.Point(113, 116);
            this.edtReference.Name = "edtReference";
            this.edtReference.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.edtReference.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.edtReference.Properties.Appearance.Options.UseBackColor = true;
            this.edtReference.Properties.Appearance.Options.UseForeColor = true;
            this.edtReference.Properties.MaxLength = 20;
            this.edtReference.Properties.ReadOnly = true;
            this.edtReference.Size = new System.Drawing.Size(112, 20);
            this.edtReference.TabIndex = 6;
            // 
            // edtDate
            // 
            this.edtDate.EditValue = null;
            this.edtDate.Location = new System.Drawing.Point(113, 64);
            this.edtDate.Name = "edtDate";
            this.edtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.edtDate.Size = new System.Drawing.Size(112, 20);
            this.edtDate.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Transaction Date";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtDescription
            // 
            this.edtDescription.Location = new System.Drawing.Point(113, 142);
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Properties.MaxLength = 200;
            this.edtDescription.Size = new System.Drawing.Size(211, 20);
            this.edtDescription.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Description";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Amount";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtAmount
            // 
            this.edtAmount.DecimalPlaces = 2;
            this.edtAmount.Location = new System.Drawing.Point(113, 168);
            this.edtAmount.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.edtAmount.Name = "edtAmount";
            this.edtAmount.Size = new System.Drawing.Size(112, 21);
            this.edtAmount.TabIndex = 8;
            this.edtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtReferenceCombo
            // 
            this.edtReferenceCombo.Location = new System.Drawing.Point(113, 116);
            this.edtReferenceCombo.Name = "edtReferenceCombo";
            this.edtReferenceCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtReferenceCombo.Properties.DropDownRows = 15;
            this.edtReferenceCombo.Properties.Sorted = true;
            this.edtReferenceCombo.Size = new System.Drawing.Size(112, 20);
            this.edtReferenceCombo.TabIndex = 5;
            // 
            // frmItemAccountTransactionDetails
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(344, 249);
            this.Controls.Add(this.edtReferenceCombo);
            this.Controls.Add(this.edtAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edtDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edtDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.edtReference);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edtAccountType);
            this.Controls.Add(this.edtAccount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.edtItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItemAccountTransactionDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction Details";
            ((System.ComponentModel.ISupportInitialize)(this.edtAccountType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReference.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenceCombo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        public DevExpress.XtraEditors.TextEdit edtAccountType;
        public DevExpress.XtraEditors.ComboBoxEdit edtAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        public DevExpress.XtraEditors.TextEdit edtItem;
        private System.Windows.Forms.Label label4;
        public DevExpress.XtraEditors.TextEdit edtReference;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public DevExpress.XtraEditors.DateEdit edtDate;
        public DevExpress.XtraEditors.TextEdit edtDescription;
        public DevExpress.XtraEditors.ComboBoxEdit edtReferenceCombo;
        public System.Windows.Forms.NumericUpDown edtAmount;
    }
}