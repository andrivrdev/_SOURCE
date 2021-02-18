using CPShared;
using Newtonsoft.Json;
using SocialRankAndroid.SHARED.CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CPShared.clsGlobal;

namespace SocialRankAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LinkInstagramPage : ContentPage
    {
        public LinkInstagramPage()
        {
            InitializeComponent();

            webView.Source = g_BasicDisplayAPI + "?client_id=" + g_client_id + "&redirect_uri=" + g_redirect_uri + "&scope=user_profile,user_media&response_type=code";
        }

        private void webView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            try
            {
                if (!(e.Url is null))
                {

                    string xCode = e.Url;
                    if (xCode.StartsWith(g_redirect_uri + "?code="))
                    {
                        xCode = xCode.Replace(g_redirect_uri + "?code=", "");
                        xCode = xCode.Replace("#_", "");
                        LinkInstagram(xCode);
                    }
                }
            }
            catch (Exception Ex)
            {

            }
        }

        async void LinkInstagram(string xCode)
        {
            if (!(xCode is null))
            {
                var xData = new List<string>();

                xData.Add(xCode);
                xData.Add(clsCurrentUser.Id.ToString());

                clsSE xclsSE = new clsSE();

                var xresult = xclsSE.Send("LinkInstagramPage_LinkInstagram", xData);
                xresult = xclsSE.DecodeMessage(xresult);
                //lblResult.Text = xResult;

                if (xresult.Contains("Success" + clsGlobal.gMessageCommandSeperator))
                {
                    await Navigation.PushModalAsync(new UserMainPage());

                }
                else
                {
                    int xAlert = Convert.ToInt32(gMessages.Error);

                    if (g_DebugMode)
                    {
                        var xMessage = xresult.Replace("Error" + clsGlobal.gMessageCommandSeperator, "");

                        var dData = JsonConvert.DeserializeObject<List<string>>(xMessage);

                        string xLines = "";
                        foreach (var xLine in dData)
                        {
                            xLines += xLine + Environment.NewLine;
                        }

                        DisplayAlert("DEBUGMODE", xLines, "OK");
                    }

                    DisplayAlert(gclsMessages[xAlert].Title, gclsMessages[xAlert].Message, gclsMessages[xAlert].Button);

                }
            }
        }
            /*
                private void LookForCode()
            {
                if (!(webView.Source is null))
                {
                    string xCode = webView.Source.ToString(); // HttpUtility.ParseQueryString(webView.Ur).Get("code");
    /*
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
                    }
    */
        

    }
}