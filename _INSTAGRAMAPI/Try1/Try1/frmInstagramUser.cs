using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Try1.DATA;

namespace Try1
{
    public partial class frmInstagramUser : Form
    {
        tblInstagramUser ztblInstagramUser;

        public frmInstagramUser()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            LoadData();

        }

        private void LoadData()
        {
            ztblInstagramUser = new tblInstagramUser();
            grdInstagramUser.DataSource = ztblInstagramUser.dtInstagramUser;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }



        private void grdInstagramUser_SelectionChanged(object sender, EventArgs e)
        {
            if (grdInstagramUser.SelectedRows.Count > 0)
            {
                string xToken = grdInstagramUser.SelectedRows[0].Cells["03_L_access_token"].Value.ToString();
            }
        }
    }
}
