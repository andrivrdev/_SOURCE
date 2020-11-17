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
        string zCurrenttblUserID = "";
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

                    tblUsernameAndMediaCount xtblUsernameAndMediaCount = new tblUsernameAndMediaCount();
                    xtblUsernameAndMediaCount = xtblUsernameAndMediaCount.GetUsernameAndMediaCount(clsGlobal.g_URI_Me_UsernameAndMediaCount, xtblLongToken.access_token);


                    //Save to Database
                    List<string> fFields = new List<string>();
                    List<string> vValues = new List<string>();

                    fFields.Add("01_BasicDisplayAPI");
                    fFields.Add("01_Client_id");
                    fFields.Add("01_Redirect_uri");
                    fFields.Add("01_URI_GetCode");
                    fFields.Add("01_URI_ResponseAfterGetCode");
                    fFields.Add("02_URI_access_token");
                    fFields.Add("02_Client_secret");
                    fFields.Add("02_Code");
                    fFields.Add("02_S_access_token");
                    fFields.Add("02_S_user_id");
                    fFields.Add("03_URI_long_access_token");
                    fFields.Add("03_L_access_token");
                    fFields.Add("03_L_token_type");
                    fFields.Add("03_L_expires_in");
                    fFields.Add("04_username");
                    fFields.Add("04_media_count");

                    vValues.Add(edtBasicDisplayAPI.Text);
                    vValues.Add(edtclient_id.Text);
                    vValues.Add(edtredirect_uri.Text);
                    vValues.Add(edtResultURI.Text);
                    vValues.Add(webBrowser1.Url.ToString());
                    vValues.Add(edtURI_access_token.Text);
                    vValues.Add(edtclient_secret.Text);
                    vValues.Add(xCode);
                    vValues.Add(xtblShortToken.access_token);
                    vValues.Add(xtblShortToken.user_id);
                    vValues.Add(edtURI_long_access_token.Text);
                    vValues.Add(xtblLongToken.access_token);
                    vValues.Add(xtblLongToken.token_type);
                    vValues.Add(xtblLongToken.expires_in.ToString());
                    vValues.Add(xtblUsernameAndMediaCount.username);
                    vValues.Add(xtblUsernameAndMediaCount.media_count);

                    //Add or Update the record
                    tblInstagramUser xtblInstagramUser = new tblInstagramUser();
                    DataRow dataRow = xtblInstagramUser.dtInstagramUser.AsEnumerable().FirstOrDefault(r => r["02_S_user_id"].ToString() == xtblShortToken.user_id);
                    if (dataRow != null)
                    {
                        clsSQLiteDB.UpdateRec("tblUser", fFields, vValues, "02_S_user_id = " + xtblShortToken.user_id);
                    }
                    else
                    {
                        clsSQLiteDB.InsertRec("tblUser", fFields, vValues);

                    }

                    /*
                    DataRow[] rows = xtblInstagramUser.dtInstagramUser.Select("02_S_user_id = " + xtblShortToken.user_id);

                    if (rows.Count() > 0)
                    {

                        clsSQLiteDB.UpdateRec("tblUser", fFields, vValues, "02_S_user_id = " + xtblShortToken.user_id);
                    }
                    else
                    */
                }
            }
        }

        private void GetCurrentURI()
        {
            if (!(webBrowser1.Url is null))
            {
                edtBrowserURI.Text = webBrowser1.Url.ToString();
                LookForCode();
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

        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUsers();
        }

        private void UpdateUsers()
        {
            lbUser.Items.Clear();
            tblInstagramUser xTbl = new tblInstagramUser();

            foreach (DataRow xRow in xTbl.dtInstagramUser.Rows)
            {
                lbUser.Items.Add(xRow["04_username"].ToString());

            }

        }

        private void lbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMediaID();

        }

        private void lbUser_Click(object sender, EventArgs e)
        {
            GetMediaID();

        }

        private void GetMediaID()
        {
            if (!(lbUser.SelectedItem is null))
            {
                tblInstagramUser xtblInstagramUser = new tblInstagramUser();
                DataRow dataRow = xtblInstagramUser.dtInstagramUser.AsEnumerable().FirstOrDefault(r => r["04_username"].ToString() == lbUser.SelectedItem.ToString());
                if (dataRow != null)
                {
                    zCurrenttblUserID = dataRow["ID"].ToString();
                    tblMediaID xtblMediaID = new tblMediaID();
                    xtblMediaID.GetMediaID(clsGlobal.g_URI_Me_MediaID, dataRow["03_L_access_token"].ToString(), zCurrenttblUserID);
                    //clsSQLiteDB.UpdateRec("tblUser", fFields, vValues, "02_S_user_id = " + xtblShortToken.user_id);
                }
            }

        }
    }
}
