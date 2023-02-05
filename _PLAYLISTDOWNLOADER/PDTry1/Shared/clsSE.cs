using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Shared
{
    public class clsSE
    {
        public async Task<string> DoPost(string xCommand, string xxData)
        {
            try
            {
                List<string> cmdData = new List<string>();

                cmdData.Add(xxData);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(cmdData);

                clsAPIData xData = new clsAPIData();
                xData.Command = xCommand;
                xData.Data = JSONresult;
                JSONresult = JsonConvert.SerializeObject(xData);

                HttpClient client = new HttpClient();
                var values = new Dictionary<string, string>
                    {
                        { "thing1", "hello" },
                        { "thing2", "world" }
                    };

                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("https://localhost:7165/api/API?xData=" + JSONresult, content);

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }

        }
    }
}
