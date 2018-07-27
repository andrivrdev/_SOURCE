using IntelligenAPICaller;
using IntelligenAPICaller.DATA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APICallerTester
{
    public partial class Form1 : Form
    {
        string zBaseURI = "https://www.intelligen.co.za/";

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGetToken_Click(object sender, EventArgs e)
        {
            try
            {
                tblUser xtblUser = new tblUser();
                xtblUser.userName = edtGetTokenUsername.Text;
                xtblUser.password = edtGetTokenPassword.Text;
                xtblUser.grant_type = "password";

                // Get a new token
                var xResponse = await API.GetAccessToken(zBaseURI, xtblUser);
                edtGetTokenToken.Text = xResponse;
            }
            catch 
            {
                edtGetTokenToken.Text = "Error";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edtGetUnitListToken.Text = edtGetTokenToken.Text;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<tblListBoxItem> xtblListBoxItem = new List<tblListBoxItem>();

                // Get data
                xtblListBoxItem = await API.GetUnitList(zBaseURI, edtGetUnitListToken.Text);
                grdGetUnitList.DataSource = xtblListBoxItem;
            }
            catch
            {
                edtGetTokenToken.Text = "Error";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            edtGetUnitStatesToken.Text = edtGetTokenToken.Text;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                List<tblUnitState> xtblUnitState = new List<tblUnitState>();



                // Get data
                xtblUnitState = await API.GetUnitStates(zBaseURI, edtGetUnitStatesToken.Text, "");
                grdGetUnitStates.DataSource = xtblUnitState;
            }
            catch
            {
                edtGetTokenToken.Text = "Error";
            }
        }
    }
}
