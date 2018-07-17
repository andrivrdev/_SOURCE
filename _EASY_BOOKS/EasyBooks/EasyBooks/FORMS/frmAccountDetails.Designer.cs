namespace EasyBooks.FORMS
{
    partial class frmAccountDetails
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
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.edtName = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.edtOut = new System.Windows.Forms.RadioButton();
            this.edtIn = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(90, 161);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(171, 161);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            // 
            // edtName
            // 
            this.edtName.Location = new System.Drawing.Point(90, 9);
            this.edtName.Name = "edtName";
            this.edtName.Properties.MaxLength = 50;
            this.edtName.Size = new System.Drawing.Size(239, 20);
            this.edtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Account Name";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.edtOut);
            this.groupControl1.Controls.Add(this.edtIn);
            this.groupControl1.Location = new System.Drawing.Point(90, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(238, 88);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Account Type";
            // 
            // edtOut
            // 
            this.edtOut.AutoSize = true;
            this.edtOut.Location = new System.Drawing.Point(21, 56);
            this.edtOut.Name = "edtOut";
            this.edtOut.Size = new System.Drawing.Size(78, 17);
            this.edtOut.TabIndex = 1;
            this.edtOut.TabStop = true;
            this.edtOut.Text = "Money Out";
            this.edtOut.UseVisualStyleBackColor = true;
            // 
            // edtIn
            // 
            this.edtIn.AutoSize = true;
            this.edtIn.Checked = true;
            this.edtIn.Location = new System.Drawing.Point(21, 33);
            this.edtIn.Name = "edtIn";
            this.edtIn.Size = new System.Drawing.Size(70, 17);
            this.edtIn.TabIndex = 0;
            this.edtIn.TabStop = true;
            this.edtIn.Text = "Money In";
            this.edtIn.UseVisualStyleBackColor = true;
            // 
            // frmAccountDetails
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(337, 196);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.edtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAccountDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Details";
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        public DevExpress.XtraEditors.TextEdit edtName;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        public System.Windows.Forms.RadioButton edtOut;
        public System.Windows.Forms.RadioButton edtIn;
    }
}