namespace Try1
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
            this.components = new System.ComponentModel.Container();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.edtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.edtLongToken = new System.Windows.Forms.TextBox();
            this.btnLongToken = new System.Windows.Forms.Button();
            this.timCheckForCode = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.edtToken = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(386, 12);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(349, 331);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Long Lived Token";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(0, 370);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(781, 56);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox2.Location = new System.Drawing.Point(0, 303);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(781, 67);
            this.textBox2.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 264);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // edtCode
            // 
            this.edtCode.Location = new System.Drawing.Point(12, 238);
            this.edtCode.Name = "edtCode";
            this.edtCode.Size = new System.Drawing.Size(332, 20);
            this.edtCode.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Token Found";
            // 
            // edtLongToken
            // 
            this.edtLongToken.Location = new System.Drawing.Point(12, 173);
            this.edtLongToken.Name = "edtLongToken";
            this.edtLongToken.Size = new System.Drawing.Size(332, 20);
            this.edtLongToken.TabIndex = 10;
            // 
            // btnLongToken
            // 
            this.btnLongToken.Location = new System.Drawing.Point(12, 131);
            this.btnLongToken.Name = "btnLongToken";
            this.btnLongToken.Size = new System.Drawing.Size(123, 23);
            this.btnLongToken.TabIndex = 12;
            this.btnLongToken.Text = "Get Long Token";
            this.btnLongToken.UseVisualStyleBackColor = true;
            this.btnLongToken.Click += new System.EventHandler(this.btnLongToken_Click);
            // 
            // timCheckForCode
            // 
            this.timCheckForCode.Enabled = true;
            this.timCheckForCode.Interval = 1000;
            this.timCheckForCode.Tick += new System.EventHandler(this.timCheckForCode_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // edtToken
            // 
            this.edtToken.Location = new System.Drawing.Point(12, 100);
            this.edtToken.Name = "edtToken";
            this.edtToken.Size = new System.Drawing.Size(332, 20);
            this.edtToken.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(212, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 426);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnLongToken);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edtLongToken);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edtToken);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtCode);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox edtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edtLongToken;
        private System.Windows.Forms.Button btnLongToken;
        private System.Windows.Forms.Timer timCheckForCode;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox edtToken;
        private System.Windows.Forms.Button button4;
    }
}

