namespace WinFormsApp1
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
            listBox1 = new ListBox();
            comboBox1 = new ComboBox();
            checkBox1 = new CheckBox();
            label1 = new Label();
            button1 = new Button();
            edtUN = new TextBox();
            edtPW = new TextBox();
            label2 = new Label();
            lblResult = new Label();
            btn2 = new Button();
            btnGo = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 16;
            listBox1.Location = new Point(555, 37);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(146, 180);
            listBox1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 24);
            comboBox1.TabIndex = 1;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(395, 55);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 20);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(202, 105);
            label1.Name = "label1";
            label1.Size = new Size(31, 16);
            label1.TabIndex = 3;
            label1.Text = "User";
            // 
            // button1
            // 
            button1.Location = new Point(363, 177);
            button1.Name = "button1";
            button1.Size = new Size(82, 40);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // edtUN
            // 
            edtUN.Location = new Point(255, 98);
            edtUN.Name = "edtUN";
            edtUN.Size = new Size(190, 23);
            edtUN.TabIndex = 5;
            // 
            // edtPW
            // 
            edtPW.Location = new Point(255, 127);
            edtPW.Name = "edtPW";
            edtPW.Size = new Size(190, 23);
            edtPW.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(202, 134);
            label2.Name = "label2";
            label2.Size = new Size(25, 16);
            label2.TabIndex = 6;
            label2.Text = "PW";
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(174, 273);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(0, 16);
            lblResult.TabIndex = 8;
            // 
            // btn2
            // 
            btn2.Location = new Point(619, 358);
            btn2.Name = "btn2";
            btn2.Size = new Size(82, 40);
            btn2.TabIndex = 9;
            btn2.Text = "button2";
            btn2.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            btnGo.Location = new Point(619, 312);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(82, 40);
            btnGo.TabIndex = 10;
            btnGo.Text = "button3";
            btnGo.UseVisualStyleBackColor = true;
            btnGo.Click += btnGo_Click;
            btnGo.MouseHover += btnGo_MouseHover;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGo);
            Controls.Add(btn2);
            Controls.Add(lblResult);
            Controls.Add(edtPW);
            Controls.Add(label2);
            Controls.Add(edtUN);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(checkBox1);
            Controls.Add(comboBox1);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Form1";
            MouseEnter += Form1_MouseEnter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private ComboBox comboBox1;
        private CheckBox checkBox1;
        private Label label1;
        private Button button1;
        private TextBox edtUN;
        private TextBox edtPW;
        private Label label2;
        private Label lblResult;
        private Button btn2;
        private Button btnGo;
    }
}