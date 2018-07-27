using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using IntelligenAPICaller.DATA;
using IntelligenAPICaller.HELPERS;
using Newtonsoft.Json;

namespace IntelligenAPICaller
{
    public static class API
    {
        public static async Task<string> GetAccessToken(string xBaseURI, object xObj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(xBaseURI);

                // We want the response to be JSON.
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Build up the data to POST.
                List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
                clsHelper xclsHelper = new clsHelper();
                postData = xclsHelper.ToKeyValuePair(xObj);

                FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

                // Post to the Server and parse the response.
                HttpResponseMessage response = await client.PostAsync("api/token", content);
                string jsonString = await response.Content.ReadAsStringAsync();
                object responseData = JsonConvert.DeserializeObject(jsonString);

                // return the Access Token.
                return ((dynamic)responseData).access_token;
            }
        }

        public static async Task<List<tblListBoxItem>> GetUnitList(string xBaseURI, string xToken)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(xBaseURI);
                List<tblListBoxItem> xtblListBoxItem = new List<tblListBoxItem>();

                // We want the response to be JSON.
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Auth with token
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + xToken);

                // Get from the Server and parse the response.
                HttpResponseMessage response = await client.GetAsync("api/GetUnitList");

                //Populate class
                if (response.IsSuccessStatusCode)
                {
                    xtblListBoxItem = await response.Content.ReadAsAsync<List<tblListBoxItem>>();
                }

                return xtblListBoxItem;
            }
        }

        public static async Task<List<tblUnitState>> GetUnitStates(string xBaseURI, string xToken, string xUnitIDs)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(xBaseURI);
                List<tblUnitState> xtblUnitState = new List<tblUnitState>();

                // We want the response to be JSON.
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Auth with token
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + xToken);

                // Get from the Server and parse the response.
                HttpResponseMessage response = await client.GetAsync("api/GetUnitStates");

                //Populate class
                if (response.IsSuccessStatusCode)
                {
                    xtblUnitState = await response.Content.ReadAsAsync<List<tblUnitState>>();
                }

                return xtblUnitState;
            }
        }


    }
}
