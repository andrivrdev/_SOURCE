namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.pnlBlock = new DevExpress.XtraEditors.PanelControl();
            this.pnlWall = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWall)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBlock
            // 
            this.pnlBlock.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlBlock.Appearance.Options.UseBackColor = true;
            this.pnlBlock.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBlock.Location = new System.Drawing.Point(226, 247);
            this.pnlBlock.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.pnlBlock.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlBlock.Name = "pnlBlock";
            this.pnlBlock.Size = new System.Drawing.Size(30, 30);
            this.pnlBlock.TabIndex = 0;
            // 
            // pnlWall
            // 
            this.pnlWall.Appearance.BackColor = System.Drawing.Color.Red;
            this.pnlWall.Appearance.Options.UseBackColor = true;
            this.pnlWall.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlWall.Location = new System.Drawing.Point(340, 149);
            this.pnlWall.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.pnlWall.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlWall.Name = "pnlWall";
            this.pnlWall.Size = new System.Drawing.Size(30, 215);
            this.pnlWall.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 462);
            this.Controls.Add(this.pnlWall);
            this.Controls.Add(this.pnlBlock);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBlock;
        private DevExpress.XtraEditors.PanelControl pnlWall;

    }
}

