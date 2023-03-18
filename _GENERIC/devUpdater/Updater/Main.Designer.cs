﻿namespace devUpdater
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnCheckForUpdates = new System.Windows.Forms.Button();
            this.lbUpdateFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalSizeCnt = new System.Windows.Forms.Label();
            this.lbMessages = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreateUpdatesFile = new System.Windows.Forms.Button();
            this.lblDlFileName = new System.Windows.Forms.Label();
            this.DlPer = new System.Windows.Forms.Label();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.pb2 = new System.Windows.Forms.PictureBox();
            this.pb3 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCheckForUpdates
            // 
            this.btnCheckForUpdates.Location = new System.Drawing.Point(383, 8);
            this.btnCheckForUpdates.Name = "btnCheckForUpdates";
            this.btnCheckForUpdates.Size = new System.Drawing.Size(127, 23);
            this.btnCheckForUpdates.TabIndex = 0;
            this.btnCheckForUpdates.Text = "Download Updates";
            this.btnCheckForUpdates.UseVisualStyleBackColor = true;
            this.btnCheckForUpdates.Click += new System.EventHandler(this.btnCheckForUpdates_Click);
            // 
            // lbUpdateFiles
            // 
            this.lbUpdateFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUpdateFiles.FormattingEnabled = true;
            this.lbUpdateFiles.Location = new System.Drawing.Point(6, 19);
            this.lbUpdateFiles.Name = "lbUpdateFiles";
            this.lbUpdateFiles.Size = new System.Drawing.Size(486, 251);
            this.lbUpdateFiles.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Reading Local Files";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Reading Update Files";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Downloading Files";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotalSizeCnt);
            this.groupBox1.Controls.Add(this.lbUpdateFiles);
            this.groupBox1.Location = new System.Drawing.Point(12, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 294);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Files To Be Updated";
            // 
            // lblTotalSizeCnt
            // 
            this.lblTotalSizeCnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSizeCnt.AutoSize = true;
            this.lblTotalSizeCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSizeCnt.Location = new System.Drawing.Point(8, 275);
            this.lblTotalSizeCnt.Name = "lblTotalSizeCnt";
            this.lblTotalSizeCnt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalSizeCnt.Size = new System.Drawing.Size(24, 13);
            this.lblTotalSizeCnt.TabIndex = 20;
            this.lblTotalSizeCnt.Text = "0/0";
            // 
            // lbMessages
            // 
            this.lbMessages.FormattingEnabled = true;
            this.lbMessages.HorizontalScrollbar = true;
            this.lbMessages.Location = new System.Drawing.Point(18, 477);
            this.lbMessages.Name = "lbMessages";
            this.lbMessages.Size = new System.Drawing.Size(486, 69);
            this.lbMessages.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 461);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Messages";
            // 
            // btnCreateUpdatesFile
            // 
            this.btnCreateUpdatesFile.Location = new System.Drawing.Point(383, 40);
            this.btnCreateUpdatesFile.Name = "btnCreateUpdatesFile";
            this.btnCreateUpdatesFile.Size = new System.Drawing.Size(127, 23);
            this.btnCreateUpdatesFile.TabIndex = 11;
            this.btnCreateUpdatesFile.Text = "Create Updates File";
            this.btnCreateUpdatesFile.UseVisualStyleBackColor = true;
            this.btnCreateUpdatesFile.Click += new System.EventHandler(this.btnCreateUpdatesFile_Click);
            // 
            // lblDlFileName
            // 
            this.lblDlFileName.AutoSize = true;
            this.lblDlFileName.Location = new System.Drawing.Point(186, 122);
            this.lblDlFileName.Name = "lblDlFileName";
            this.lblDlFileName.Size = new System.Drawing.Size(13, 13);
            this.lblDlFileName.TabIndex = 15;
            this.lblDlFileName.Text = "..";
            // 
            // DlPer
            // 
            this.DlPer.AutoSize = true;
            this.DlPer.Location = new System.Drawing.Point(141, 122);
            this.DlPer.Name = "DlPer";
            this.DlPer.Size = new System.Drawing.Size(21, 13);
            this.DlPer.TabIndex = 16;
            this.DlPer.Text = "0%";
            // 
            // pb1
            // 
            this.pb1.Image = global::Updater.Properties.Resources.AMBER;
            this.pb1.InitialImage = global::Updater.Properties.Resources.AMBER;
            this.pb1.Location = new System.Drawing.Point(12, 12);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(26, 26);
            this.pb1.TabIndex = 17;
            this.pb1.TabStop = false;
            // 
            // pb2
            // 
            this.pb2.Image = global::Updater.Properties.Resources.AMBER;
            this.pb2.InitialImage = global::Updater.Properties.Resources.AMBER;
            this.pb2.Location = new System.Drawing.Point(12, 40);
            this.pb2.Name = "pb2";
            this.pb2.Size = new System.Drawing.Size(26, 26);
            this.pb2.TabIndex = 18;
            this.pb2.TabStop = false;
            // 
            // pb3
            // 
            this.pb3.Image = global::Updater.Properties.Resources.AMBER;
            this.pb3.InitialImage = global::Updater.Properties.Resources.AMBER;
            this.pb3.Location = new System.Drawing.Point(12, 68);
            this.pb3.Name = "pb3";
            this.pb3.Size = new System.Drawing.Size(26, 26);
            this.pb3.TabIndex = 19;
            this.pb3.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 558);
            this.Controls.Add(this.pb3);
            this.Controls.Add(this.pb2);
            this.Controls.Add(this.pb1);
            this.Controls.Add(this.DlPer);
            this.Controls.Add(this.lblDlFileName);
            this.Controls.Add(this.btnCreateUpdatesFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbMessages);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCheckForUpdates);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Opacity = 0.01D;
            this.Text = "Updater";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheckForUpdates;
        private System.Windows.Forms.ListBox lbUpdateFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbMessages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreateUpdatesFile;
        private System.Windows.Forms.Label lblDlFileName;
        private System.Windows.Forms.Label DlPer;
        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.PictureBox pb2;
        private System.Windows.Forms.PictureBox pb3;
        private System.Windows.Forms.Label lblTotalSizeCnt;
    }
}