using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Try1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void edtBrowserURI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                webBrowser1.Url = new Uri(edtBrowserURI.Text);
            }
        }

        private void btnDefaultBrowserURI_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri(CLASSES.clsGlobal.g_URL);
            edtBrowserURI.Text = uri.ToString();
            webBrowser1.Url = uri;

        }
    }
}
