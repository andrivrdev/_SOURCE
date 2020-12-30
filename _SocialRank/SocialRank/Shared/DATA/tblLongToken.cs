using CPShared;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DATA
{
    public class tblLongToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }

        public tblLongToken GetLongToken(string URI_long_access_token, string client_secret, string access_token)
        {
            string URI = URI_long_access_token + "client_secret=" + client_secret + "&access_token=" + access_token;
            var client = new RestClient(URI);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);


            tblLongToken xtblToken = new tblLongToken();
            xtblToken = JsonConvert.DeserializeObject<tblLongToken>(response.Content);

            return xtblToken;
        }

        public tblLongToken GetLongToken(string xShortToken)
        {
            tblLongToken xData = new tblLongToken();

            xData = xData.GetLongToken(clsGlobal.g_URI_long_access_token, clsGlobal.g_client_secret, xShortToken);

            return xData;
        }


    }
}
