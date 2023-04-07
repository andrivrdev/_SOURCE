namespace PDWindows
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            edtUN = new TextBox();
            edtPW = new TextBox();
            label2 = new Label();
            button1 = new Button();
            memLog = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            openFileDialog1 = new OpenFileDialog();
            btnSelectFile = new Button();
            edtFilename = new TextBox();
            label3 = new Label();
            btnSearch = new Button();
            dgView1 = new DataGridView();
            button2 = new Button();
            dgView2 = new DataGridView();
            lblStatus = new Label();
            dgView3 = new DataGridView();
            button3 = new Button();
            dgView4 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgView4).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 13);
            label1.Name = "label1";
            label1.Size = new Size(62, 16);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // edtUN
            // 
            edtUN.Location = new Point(82, 10);
            edtUN.Name = "edtUN";
            edtUN.Size = new Size(240, 23);
            edtUN.TabIndex = 1;
            edtUN.Text = "andrivr@gmail.com";
            // 
            // edtPW
            // 
            edtPW.Location = new Point(82, 39);
            edtPW.Name = "edtPW";
            edtPW.Size = new Size(240, 23);
            edtPW.TabIndex = 3;
            edtPW.Text = "passNEWm.3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 42);
            label2.Name = "label2";
            label2.Size = new Size(57, 16);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // button1
            // 
            button1.Location = new Point(82, 68);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // memLog
            // 
            memLog.Dock = DockStyle.Bottom;
            memLog.Location = new Point(0, 621);
            memLog.Multiline = true;
            memLog.Name = "memLog";
            memLog.ScrollBars = ScrollBars.Both;
            memLog.Size = new Size(800, 118);
            memLog.TabIndex = 5;
            // 
            // timer1
            // 
            timer1.Interval = 5000;
            timer1.Tick += timer1_Tick;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSelectFile
            // 
            btnSelectFile.Location = new Point(723, 97);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(32, 23);
            btnSelectFile.TabIndex = 8;
            btnSelectFile.Text = "...";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += btnSelectFile_Click;
            // 
            // edtFilename
            // 
            edtFilename.Location = new Point(82, 97);
            edtFilename.Name = "edtFilename";
            edtFilename.ReadOnly = true;
            edtFilename.Size = new Size(635, 23);
            edtFilename.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 100);
            label3.Name = "label3";
            label3.Size = new Size(26, 16);
            label3.TabIndex = 6;
            label3.Text = "File";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(82, 152);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(161, 23);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "Build Combos to Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgView1
            // 
            dgView1.AllowUserToOrderColumns = true;
            dgView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgView1.Dock = DockStyle.Bottom;
            dgView1.Location = new Point(0, 501);
            dgView1.Name = "dgView1";
            dgView1.RowTemplate.DefaultCellStyle.Font = new Font("Courier New", 6.75F, FontStyle.Regular, GraphicsUnit.Point);
            dgView1.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgView1.RowTemplate.Height = 25;
            dgView1.Size = new Size(800, 120);
            dgView1.TabIndex = 10;
            // 
            // button2
            // 
            button2.Location = new Point(249, 152);
            button2.Name = "button2";
            button2.Size = new Size(195, 23);
            button2.TabIndex = 11;
            button2.Text = "Search All Users for Files";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dgView2
            // 
            dgView2.AllowUserToOrderColumns = true;
            dgView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgView2.Dock = DockStyle.Bottom;
            dgView2.Location = new Point(0, 393);
            dgView2.Name = "dgView2";
            dgView2.RowTemplate.Height = 25;
            dgView2.Size = new Size(800, 108);
            dgView2.TabIndex = 12;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(387, 13);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 16);
            lblStatus.TabIndex = 13;
            // 
            // dgView3
            // 
            dgView3.AllowUserToOrderColumns = true;
            dgView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgView3.Dock = DockStyle.Bottom;
            dgView3.Location = new Point(0, 312);
            dgView3.Name = "dgView3";
            dgView3.RowTemplate.Height = 25;
            dgView3.Size = new Size(800, 81);
            dgView3.TabIndex = 14;
            // 
            // button3
            // 
            button3.Location = new Point(450, 152);
            button3.Name = "button3";
            button3.Size = new Size(195, 23);
            button3.TabIndex = 15;
            button3.Text = "Download";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dgView4
            // 
            dgView4.AllowUserToOrderColumns = true;
            dgView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgView4.Dock = DockStyle.Bottom;
            dgView4.Location = new Point(0, 181);
            dgView4.Name = "dgView4";
            dgView4.RowTemplate.DefaultCellStyle.Font = new Font("Lucida Sans Unicode", 6F, FontStyle.Regular, GraphicsUnit.Point);
            dgView4.RowTemplate.Height = 20;
            dgView4.RowTemplate.Resizable = DataGridViewTriState.True;
            dgView4.Size = new Size(800, 131);
            dgView4.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 739);
            Controls.Add(dgView4);
            Controls.Add(button3);
            Controls.Add(dgView3);
            Controls.Add(lblStatus);
            Controls.Add(dgView2);
            Controls.Add(button2);
            Controls.Add(dgView1);
            Controls.Add(btnSearch);
            Controls.Add(btnSelectFile);
            Controls.Add(edtFilename);
            Controls.Add(label3);
            Controls.Add(memLog);
            Controls.Add(button1);
            Controls.Add(edtPW);
            Controls.Add(label2);
            Controls.Add(edtUN);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgView4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox edtUN;
        private TextBox edtPW;
        private Label label2;
        private Button button1;
        private TextBox memLog;
        private System.Windows.Forms.Timer timer1;
        private OpenFileDialog openFileDialog1;
        private Button btnSelectFile;
        private TextBox edtFilename;
        private Label label3;
        private Button btnSearch;
        private DataGridView dgView1;
        private Button button2;
        private DataGridView dgView2;
        private Label lblStatus;
        private DataGridView dgView3;
        private Button button3;
        private DataGridView dgView4;
    }
}