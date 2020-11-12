namespace Try1
{
    partial class frmMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel3 = new System.Windows.Forms.Panel();
            this.edtBrowserURI = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnDefaultBrowserURI = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(597, 481);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(589, 455);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Get Auth";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(583, 390);
            this.panel2.TabIndex = 3;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(583, 390);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(575, 364);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Browser";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.webBrowser1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 51);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(569, 310);
            this.panel4.TabIndex = 4;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(569, 310);
            this.webBrowser1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.edtBrowserURI);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(569, 48);
            this.panel3.TabIndex = 3;
            // 
            // edtBrowserURI
            // 
            this.edtBrowserURI.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.edtBrowserURI.Location = new System.Drawing.Point(0, 28);
            this.edtBrowserURI.Name = "edtBrowserURI";
            this.edtBrowserURI.Size = new System.Drawing.Size(569, 20);
            this.edtBrowserURI.TabIndex = 0;
            this.edtBrowserURI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtBrowserURI_KeyPress);
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(575, 364);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Source";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 59);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(583, 59);
            this.label2.TabIndex = 2;
            this.label2.Text = "Get Access to User Profile (Returns the Code from the Website URI)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(589, 455);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnDefaultBrowserURI);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(569, 28);
            this.panel5.TabIndex = 4;
            // 
            // btnDefaultBrowserURI
            // 
            this.btnDefaultBrowserURI.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDefaultBrowserURI.Location = new System.Drawing.Point(0, 0);
            this.btnDefaultBrowserURI.Name = "btnDefaultBrowserURI";
            this.btnDefaultBrowserURI.Size = new System.Drawing.Size(75, 28);
            this.btnDefaultBrowserURI.TabIndex = 0;
            this.btnDefaultBrowserURI.Text = "Default URI";
            this.btnDefaultBrowserURI.UseVisualStyleBackColor = true;
            this.btnDefaultBrowserURI.Click += new System.EventHandler(this.btnDefaultBrowserURI_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 481);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox edtBrowserURI;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnDefaultBrowserURI;
    }
}