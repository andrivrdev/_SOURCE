using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QBook.Forms
{
    public partial class frmPropertyAccountDetails : Form
    {
        int zMyMode;
        int zID;

        public frmPropertyAccountDetails(int xMode, int xID)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            zMyMode = xMode;
            zID = xID;

            //Add
            if (zMyMode == 0)
            {
                edtAccount.SelectedIndex = -1;

                this.Text = "New Property Account Details";

                edtAccount.Focus();
            }

            //Edit
            if (zMyMode == 1)
            {
                this.Text = "Edit Property Account Details";

                edtAccount.Focus();
            }

        }
    }
}
