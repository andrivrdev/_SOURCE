using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try1.DATA
{
    public class tblUsernameAndMediaCount
    {
        public string id { get; set; }
        public string username { get; set; }
        public string media_count { get; set; }

        public tblUsernameAndMediaCount GetUsernameAndMediaCount(string URI_Me_UsernameAndMediaCount, string access_token)
        {
            string URI = URI_Me_UsernameAndMediaCount + access_token;
            var client = new RestClient(URI);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            tblUsernameAndMediaCount xtblUsernameAndMediaCount = new tblUsernameAndMediaCount();
            xtblUsernameAndMediaCount = JsonConvert.DeserializeObject<tblUsernameAndMediaCount>(response.Content);

            return xtblUsernameAndMediaCount;
        }

    }
}
