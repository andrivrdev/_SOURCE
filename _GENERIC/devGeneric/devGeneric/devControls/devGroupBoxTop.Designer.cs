namespace devGeneric.devControls
{
    partial class devGroupBoxTop
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
            this.pnlColor = new DevExpress.XtraEditors.PanelControl();
            this.lblCaption = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlColor)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlColor
            // 
            this.pnlColor.Appearance.BackColor = System.Drawing.Color.Red;
            this.pnlColor.Appearance.BackColor2 = System.Drawing.Color.Maroon;
            this.pnlColor.Appearance.Options.UseBackColor = true;
            this.pnlColor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlColor.Location = new System.Drawing.Point(0, 18);
            this.pnlColor.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.pnlColor.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(150, 2);
            this.pnlColor.TabIndex = 5;
            // 
            // lblCaption
            // 
            this.lblCaption.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCaption.Appearance.BackColor2 = System.Drawing.Color.SlateGray;
            this.lblCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCaption.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblCaption.Appearance.Options.UseBackColor = true;
            this.lblCaption.Appearance.Options.UseFont = true;
            this.lblCaption.Appearance.Options.UseForeColor = true;
            this.lblCaption.Appearance.Options.UseTextOptions = true;
            this.lblCaption.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaption.Location = new System.Drawing.Point(0, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblCaption.Size = new System.Drawing.Size(150, 18);
            this.lblCaption.TabIndex = 4;
            this.lblCaption.Text = "XXX";
            // 
            // devGroupBoxTop
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlColor);
            this.Controls.Add(this.lblCaption);
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximumSize = new System.Drawing.Size(10000, 20);
            this.MinimumSize = new System.Drawing.Size(0, 20);
            this.Name = "devGroupBoxTop";
            this.Size = new System.Drawing.Size(150, 20);
            ((System.ComponentModel.ISupportInitialize)(this.pnlColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlColor;
        private DevExpress.XtraEditors.LabelControl lblCaption;
    }
}
