namespace EasyBooks.FORMS
{
    partial class frmAbout
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
            this.imgLogo = new DevExpress.XtraEditors.PictureEdit();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.BackColor = System.Drawing.Color.Transparent;
            this.lbl1.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold);
            this.lbl1.ForeColor = System.Drawing.Color.Black;
            this.lbl1.Location = new System.Drawing.Point(1, 18);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(336, 84);
            this.lbl1.TabIndex = 7;
            this.lbl1.Text = "Easy Books";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgLogo
            // 
            this.imgLogo.Cursor = System.Windows.Forms.Cursors.Default;
            this.imgLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgLogo.EditValue = global::EasyBooks.Properties.Resources.TransparentLogo;
            this.imgLogo.Location = new System.Drawing.Point(0, 0);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Properties.AllowFocused = false;
            this.imgLogo.Properties.ReadOnly = true;
            this.imgLogo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.imgLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.imgLogo.Size = new System.Drawing.Size(337, 286);
            this.imgLogo.TabIndex = 5;
            // 
            // lbl2
            // 
            this.lbl2.BackColor = System.Drawing.Color.Transparent;
            this.lbl2.Font = new System.Drawing.Font("Tahoma", 15F);
            this.lbl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.lbl2.Location = new System.Drawing.Point(0, 102);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(337, 35);
            this.lbl2.TabIndex = 9;
            this.lbl2.Text = "Proudly made by:";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl4
            // 
            this.lbl4.BackColor = System.Drawing.Color.Transparent;
            this.lbl4.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lbl4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.lbl4.Location = new System.Drawing.Point(0, 167);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(337, 44);
            this.lbl4.TabIndex = 12;
            this.lbl4.Text = "andrivr@gmail.com";
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl3
            // 
            this.lbl3.BackColor = System.Drawing.Color.Transparent;
            this.lbl3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lbl3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.lbl3.Location = new System.Drawing.Point(0, 137);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(337, 20);
            this.lbl3.TabIndex = 10;
            this.lbl3.Text = "Andri van Rooyen";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 286);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.imgLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl1;
        private DevExpress.XtraEditors.PictureEdit imgLogo;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl3;
    }
}