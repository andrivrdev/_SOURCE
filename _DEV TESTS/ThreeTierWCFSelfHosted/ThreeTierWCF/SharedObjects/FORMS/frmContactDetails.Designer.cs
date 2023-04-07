namespace SharedObjects.FORMS
{
    partial class frmContactDetails
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
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.edt1 = new System.Windows.Forms.TextBox();
            this.edtType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.edt2 = new System.Windows.Forms.TextBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.edt3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(12, 42);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(80, 13);
            this.lbl1.TabIndex = 29;
            this.lbl1.Text = "Number";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(167, 133);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(86, 133);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 26;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.LimeGreen;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(328, 5);
            this.lblHeader.TabIndex = 25;
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edt1
            // 
            this.edt1.Location = new System.Drawing.Point(98, 39);
            this.edt1.Name = "edt1";
            this.edt1.Size = new System.Drawing.Size(189, 20);
            this.edt1.TabIndex = 1;
            // 
            // edtType
            // 
            this.edtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edtType.FormattingEnabled = true;
            this.edtType.Items.AddRange(new object[] {
            "Number",
            "Address"});
            this.edtType.Location = new System.Drawing.Point(98, 12);
            this.edtType.Name = "edtType";
            this.edtType.Size = new System.Drawing.Size(189, 21);
            this.edtType.TabIndex = 0;
            this.edtType.SelectedIndexChanged += new System.EventHandler(this.edtType_TextChanged);
            this.edtType.SelectedValueChanged += new System.EventHandler(this.edtType_TextChanged);
            this.edtType.TextChanged += new System.EventHandler(this.edtType_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Contact Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(12, 68);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(80, 13);
            this.lbl2.TabIndex = 31;
            this.lbl2.Text = "Number";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edt2
            // 
            this.edt2.Location = new System.Drawing.Point(98, 65);
            this.edt2.Name = "edt2";
            this.edt2.Size = new System.Drawing.Size(189, 20);
            this.edt2.TabIndex = 2;
            // 
            // lbl3
            // 
            this.lbl3.Location = new System.Drawing.Point(12, 94);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(80, 13);
            this.lbl3.TabIndex = 33;
            this.lbl3.Text = "Number";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edt3
            // 
            this.edt3.Location = new System.Drawing.Point(98, 91);
            this.edt3.Name = "edt3";
            this.edt3.Size = new System.Drawing.Size(189, 20);
            this.edt3.TabIndex = 3;
            // 
            // frmContactDetails
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(328, 166);
            this.ControlBox = false;
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.edt3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.edt2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.edt1);
            this.Controls.Add(this.edtType);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmContactDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contact Details";
            this.Shown += new System.EventHandler(this.frmContactDetails_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblHeader;
        public System.Windows.Forms.TextBox edt1;
        public System.Windows.Forms.ComboBox edtType;
        public System.Windows.Forms.TextBox edt2;
        public System.Windows.Forms.TextBox edt3;
        public System.Windows.Forms.Label lbl1;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lbl2;
        public System.Windows.Forms.Label lbl3;
    }
}