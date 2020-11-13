using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Try1.CLASSES;
using Try1.DATA;

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

        private void frmMain_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void LoadDefaults()
        {
            //Load Defaults
            edtBasicDisplayAPI.Text = clsGlobal.g_BasicDisplayAPI;
            edtclient_id.Text = clsGlobal.g_client_id;
            edtredirect_uri.Text = clsGlobal.g_redirect_uri;

            edtURI_access_token.Text = clsGlobal.g_URI_access_token;
            edtclient_secret.Text = clsGlobal.g_client_secret;

            edtURI_long_access_token.Text = clsGlobal.g_URI_long_access_token;
        }

        private void BuildResultURI()
        {
            string xURI = edtBasicDisplayAPI.Text + "?client_id=" + edtclient_id.Text + "&redirect_uri=" +
                edtredirect_uri.Text + "&scope=user_profile,user_media&response_type=code";
            edtResultURI.Text = xURI;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadDefaults();
        }

        private void edtredirect_uri_TextChanged(object sender, EventArgs e)
        {
            BuildResultURI();
        }

        private void edtclient_id_TextChanged(object sender, EventArgs e)
        {
            BuildResultURI();
        }

        private void edtBasicDisplayAPI_TextChanged(object sender, EventArgs e)
        {
            BuildResultURI();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            GetCurrentURI();
        }

        private void LookForCode()
        {
            if (!(webBrowser1.Url is null))
            {
                string xCode = HttpUtility.ParseQueryString(webBrowser1.Url.Query).Get("code");

                if (!(xCode is null))
                {
                    tblShortToken xtblShortToken = new tblShortToken();
                    xtblShortToken = GetShortToken(xCode);

                    tblLongToken xtblLongToken = new tblLongToken();
                    xtblLongToken = GetLongToken(xtblShortToken.access_token);


                }
            }
        }

        private void GetCurrentURI()
        {
            if (!(webBrowser1.Url is null))
            {
                edtBrowserURI.Text = webBrowser1.Url.ToString();
            }
        }

        private tblShortToken GetShortToken(string xCode)
        {
            tblShortToken xData = new tblShortToken();

            xData = xData.GetTokenAndUserIdFromCode(edtURI_access_token.Text, edtclient_id.Text, edtclient_secret.Text, edtredirect_uri.Text, xCode);

            return xData;
        }
        private tblLongToken GetLongToken(string xShortToken)
        {
            tblLongToken xData = new tblLongToken();

            xData = xData.GetLongToken(edtURI_long_access_token.Text, edtclient_secret.Text, xShortToken);

            return xData;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (!clsSQLiteDB.CheckIfDBExist(false))
            {
                MessageBox.Show("A new database must be created! This will be done automatically when you continue.");
                clsSQLiteDB.CreateDB();
            }

            LoadDefaults();

            //this.Enabled = true;
        }
    }
}
