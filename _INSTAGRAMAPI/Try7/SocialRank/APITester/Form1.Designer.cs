﻿
namespace APITester
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
            this.button1 = new System.Windows.Forms.Button();
            this.edtData = new System.Windows.Forms.TextBox();
            this.edtResponse = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // edtData
            // 
            this.edtData.Location = new System.Drawing.Point(21, 12);
            this.edtData.Multiline = true;
            this.edtData.Name = "edtData";
            this.edtData.Size = new System.Drawing.Size(259, 154);
            this.edtData.TabIndex = 2;
            // 
            // edtResponse
            // 
            this.edtResponse.Location = new System.Drawing.Point(404, 12);
            this.edtResponse.Multiline = true;
            this.edtResponse.Name = "edtResponse";
            this.edtResponse.Size = new System.Drawing.Size(259, 154);
            this.edtResponse.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.edtResponse);
            this.Controls.Add(this.edtData);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox edtData;
        private System.Windows.Forms.TextBox edtResponse;
    }
}

