using QBook.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QBook
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new frmAccount();
            myForm.ShowDialog();
        }

        private void propertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new frmProperty();
            myForm.ShowDialog();
        }
    }
}
