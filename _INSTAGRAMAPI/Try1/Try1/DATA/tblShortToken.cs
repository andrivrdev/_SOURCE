using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try1.DATA
{
    public class tblShortToken
    {
        public string access_token { get; set; }
        public string user_id { get; set; }

        public tblShortToken GetTokenAndUserIdFromCode(string URI_access_token, string client_id, string client_secret, string redirect_uri, string code)
        {
            var client = new RestClient(URI_access_token);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("client_id", client_id);
            request.AddParameter("client_secret", client_secret);
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("redirect_uri", redirect_uri);
            request.AddParameter("code", code);
            IRestResponse response = client.Execute(request);

            tblShortToken xtblToken = new tblShortToken();
            xtblToken = JsonConvert.DeserializeObject<tblShortToken>(response.Content);

            return xtblToken;
        }

    }
}
