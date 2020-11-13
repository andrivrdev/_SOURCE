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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.edtBrowserURI = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.edtclient_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.edt = new System.Windows.Forms.Label();
            this.edtredirect_uri = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edtBasicDisplayAPI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edtResultURI = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edtURI_access_token = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edtclient_secret = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.edtURI_long_access_token = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(597, 508);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(589, 482);
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
            this.panel2.Size = new System.Drawing.Size(583, 417);
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
            this.tabControl2.Size = new System.Drawing.Size(583, 417);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(575, 391);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Browser";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.webBrowser1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 312);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(569, 76);
            this.panel4.TabIndex = 4;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(569, 76);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.edtBrowserURI);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(569, 309);
            this.panel3.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.edtURI_long_access_token);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.edtclient_secret);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.edtURI_access_token);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.edtResultURI);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.edtBasicDisplayAPI);
            this.panel5.Controls.Add(this.edt);
            this.panel5.Controls.Add(this.edtredirect_uri);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.edtclient_id);
            this.panel5.Controls.Add(this.btnReset);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(569, 289);
            this.panel5.TabIndex = 4;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(16, 255);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 28);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Defaults";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // edtBrowserURI
            // 
            this.edtBrowserURI.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.edtBrowserURI.Location = new System.Drawing.Point(0, 289);
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
            // edtclient_id
            // 
            this.edtclient_id.Location = new System.Drawing.Point(131, 39);
            this.edtclient_id.Name = "edtclient_id";
            this.edtclient_id.Size = new System.Drawing.Size(212, 20);
            this.edtclient_id.TabIndex = 1;
            this.edtclient_id.TextChanged += new System.EventHandler(this.edtclient_id_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "App ID (SocialAPI)";
            // 
            // edt
            // 
            this.edt.AutoSize = true;
            this.edt.Location = new System.Drawing.Point(62, 68);
            this.edt.Name = "edt";
            this.edt.Size = new System.Drawing.Size(63, 13);
            this.edt.TabIndex = 4;
            this.edt.Text = "Redirect To";
            // 
            // edtredirect_uri
            // 
            this.edtredirect_uri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtredirect_uri.Location = new System.Drawing.Point(131, 65);
            this.edtredirect_uri.Name = "edtredirect_uri";
            this.edtredirect_uri.Size = new System.Drawing.Size(423, 20);
            this.edtredirect_uri.TabIndex = 3;
            this.edtredirect_uri.TextChanged += new System.EventHandler(this.edtredirect_uri_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Basic Display API URI";
            // 
            // edtBasicDisplayAPI
            // 
            this.edtBasicDisplayAPI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBasicDisplayAPI.Location = new System.Drawing.Point(131, 13);
            this.edtBasicDisplayAPI.Name = "edtBasicDisplayAPI";
            this.edtBasicDisplayAPI.Size = new System.Drawing.Size(423, 20);
            this.edtBasicDisplayAPI.TabIndex = 5;
            this.edtBasicDisplayAPI.TextChanged += new System.EventHandler(this.edtBasicDisplayAPI_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Built URI";
            // 
            // edtResultURI
            // 
            this.edtResultURI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtResultURI.Location = new System.Drawing.Point(131, 91);
            this.edtResultURI.Name = "edtResultURI";
            this.edtResultURI.ReadOnly = true;
            this.edtResultURI.Size = new System.Drawing.Size(423, 20);
            this.edtResultURI.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "API Short Token URI";
            // 
            // edtURI_access_token
            // 
            this.edtURI_access_token.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtURI_access_token.Location = new System.Drawing.Point(131, 130);
            this.edtURI_access_token.Name = "edtURI_access_token";
            this.edtURI_access_token.Size = new System.Drawing.Size(423, 20);
            this.edtURI_access_token.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "App Secret (SocialAPI)";
            // 
            // edtclient_secret
            // 
            this.edtclient_secret.Location = new System.Drawing.Point(131, 156);
            this.edtclient_secret.Name = "edtclient_secret";
            this.edtclient_secret.Size = new System.Drawing.Size(212, 20);
            this.edtclient_secret.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "API Long Token URI";
            // 
            // edtURI_long_access_token
            // 
            this.edtURI_long_access_token.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtURI_long_access_token.Location = new System.Drawing.Point(131, 197);
            this.edtURI_long_access_token.Name = "edtURI_long_access_token";
            this.edtURI_long_access_token.Size = new System.Drawing.Size(423, 20);
            this.edtURI_long_access_token.TabIndex = 13;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 508);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edtclient_id;
        private System.Windows.Forms.Label edt;
        private System.Windows.Forms.TextBox edtredirect_uri;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edtBasicDisplayAPI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edtResultURI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox edtURI_access_token;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edtclient_secret;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox edtURI_long_access_token;
        private System.Windows.Forms.Timer timer1;
    }
}