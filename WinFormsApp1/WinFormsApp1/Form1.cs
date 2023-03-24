namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((edtUN.Text == "avr") &&
                    (edtPW.Text == "a"))
            {
                lblResult.Text = "It was correct";


            }
            else
            {
                lblResult.Text = "Invalid username or password";

            }
        }

        private void btnGo_MouseHover(object sender, EventArgs e)
        {
            btn2.BackColor = Color.Pink;
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            btn2.BackColor = Color.Blue;

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            while (btn2.Left > 10)
            {
                btn2.Left = btn2.Left - 1;

                var xAns = 0;
                xAns = btn2.Left * 3;

                System.Threading.Thread.Sleep(5);
            }
            while (btn2.Left < 816 - btn2.Width - 10) 
            {
                btn2.Left = btn2.Left + 1;

                var xAns = 0;
                xAns = btn2.Left * 3;

                System.Threading.Thread.Sleep(5);
            }


        }
    }
}