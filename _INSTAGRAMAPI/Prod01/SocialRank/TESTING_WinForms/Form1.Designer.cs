
namespace TESTING_WinForms
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnExecute = new System.Windows.Forms.Button();
            this.edtData = new System.Windows.Forms.TextBox();
            this.edtResult = new System.Windows.Forms.TextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.edtEncDec01 = new System.Windows.Forms.TextBox();
            this.edtEncDec02 = new System.Windows.Forms.TextBox();
            this.btnEnc01 = new System.Windows.Forms.Button();
            this.btnDec01 = new System.Windows.Forms.Button();
            this.btnDec02 = new System.Windows.Forms.Button();
            this.btnEnc02 = new System.Windows.Forms.Button();
            this.edtEncodingCommand = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.edtEncodingCommand);
            this.splitContainer1.Panel1.Controls.Add(this.btnDec02);
            this.splitContainer1.Panel1.Controls.Add(this.btnEnc02);
            this.splitContainer1.Panel1.Controls.Add(this.btnExecute);
            this.splitContainer1.Panel1.Controls.Add(this.btnDec01);
            this.splitContainer1.Panel1.Controls.Add(this.btnEnc01);
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.edtData);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.edtResult);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(800, 146);
            this.splitContainer2.SplitterDistance = 397;
            this.splitContainer2.TabIndex = 1;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(12, 12);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 0;
            this.btnExecute.Text = "Call DoWork";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // edtData
            // 
            this.edtData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtData.Location = new System.Drawing.Point(0, 0);
            this.edtData.Multiline = true;
            this.edtData.Name = "edtData";
            this.edtData.Size = new System.Drawing.Size(397, 146);
            this.edtData.TabIndex = 0;
            // 
            // edtResult
            // 
            this.edtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtResult.Location = new System.Drawing.Point(0, 0);
            this.edtResult.Multiline = true;
            this.edtResult.Name = "edtResult";
            this.edtResult.Size = new System.Drawing.Size(399, 146);
            this.edtResult.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer3.Location = new System.Drawing.Point(0, 154);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.edtEncDec01);
            this.splitContainer3.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.edtEncDec02);
            this.splitContainer3.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer3.Size = new System.Drawing.Size(800, 146);
            this.splitContainer3.SplitterDistance = 397;
            this.splitContainer3.TabIndex = 2;
            // 
            // edtEncDec01
            // 
            this.edtEncDec01.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.edtEncDec01.Location = new System.Drawing.Point(0, 0);
            this.edtEncDec01.Multiline = true;
            this.edtEncDec01.Name = "edtEncDec01";
            this.edtEncDec01.Size = new System.Drawing.Size(397, 146);
            this.edtEncDec01.TabIndex = 0;
            // 
            // edtEncDec02
            // 
            this.edtEncDec02.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.edtEncDec02.Location = new System.Drawing.Point(0, 0);
            this.edtEncDec02.Multiline = true;
            this.edtEncDec02.Name = "edtEncDec02";
            this.edtEncDec02.Size = new System.Drawing.Size(399, 146);
            this.edtEncDec02.TabIndex = 1;
            // 
            // btnEnc01
            // 
            this.btnEnc01.Location = new System.Drawing.Point(12, 125);
            this.btnEnc01.Name = "btnEnc01";
            this.btnEnc01.Size = new System.Drawing.Size(75, 23);
            this.btnEnc01.TabIndex = 3;
            this.btnEnc01.Text = "Encode";
            this.btnEnc01.UseVisualStyleBackColor = true;
            this.btnEnc01.Click += new System.EventHandler(this.btnEnc01_Click);
            // 
            // btnDec01
            // 
            this.btnDec01.Location = new System.Drawing.Point(93, 125);
            this.btnDec01.Name = "btnDec01";
            this.btnDec01.Size = new System.Drawing.Size(75, 23);
            this.btnDec01.TabIndex = 4;
            this.btnDec01.Text = "Decode";
            this.btnDec01.UseVisualStyleBackColor = true;
            this.btnDec01.Click += new System.EventHandler(this.btnDec01_Click);
            // 
            // btnDec02
            // 
            this.btnDec02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDec02.Location = new System.Drawing.Point(713, 128);
            this.btnDec02.Name = "btnDec02";
            this.btnDec02.Size = new System.Drawing.Size(75, 23);
            this.btnDec02.TabIndex = 8;
            this.btnDec02.Text = "Decode";
            this.btnDec02.UseVisualStyleBackColor = true;
            this.btnDec02.Click += new System.EventHandler(this.btnDec02_Click);
            // 
            // btnEnc02
            // 
            this.btnEnc02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnc02.Location = new System.Drawing.Point(632, 128);
            this.btnEnc02.Name = "btnEnc02";
            this.btnEnc02.Size = new System.Drawing.Size(75, 23);
            this.btnEnc02.TabIndex = 7;
            this.btnEnc02.Text = "Encode";
            this.btnEnc02.UseVisualStyleBackColor = true;
            this.btnEnc02.Click += new System.EventHandler(this.btnEnc02_Click);
            // 
            // edtEncodingCommand
            // 
            this.edtEncodingCommand.Location = new System.Drawing.Point(320, 125);
            this.edtEncodingCommand.Name = "edtEncodingCommand";
            this.edtEncodingCommand.Size = new System.Drawing.Size(156, 20);
            this.edtEncodingCommand.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "COMMAND WHEN ENCODING";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox edtData;
        private System.Windows.Forms.TextBox edtResult;
        private System.Windows.Forms.Button btnDec01;
        private System.Windows.Forms.Button btnEnc01;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox edtEncDec01;
        private System.Windows.Forms.TextBox edtEncDec02;
        private System.Windows.Forms.Button btnDec02;
        private System.Windows.Forms.Button btnEnc02;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edtEncodingCommand;
    }
}

