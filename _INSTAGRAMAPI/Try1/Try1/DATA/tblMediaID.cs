using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Try1.CLASSES;

namespace Try1.DATA
{
    public class tblMediaID
    {
        

        public DataTable GetMediaID(string URI_Me_MediaID, string access_token, string xtblUserID)
        {
            string URI = URI_Me_MediaID + access_token;
            var client = new RestClient(URI);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var details = JObject.Parse(response.Content);
            var xData = details.First.First.First.ToString();
            var xBuilt = xData.Substring(xData.IndexOf('['), xData.IndexOf(']')- xData.IndexOf('[') + 1);

            /*
            xBuilt = xBuilt.Replace(Environment.NewLine, "");
            xBuilt = xBuilt.Replace(@"\", "");
            xBuilt = xBuilt.Replace(" ", "");
            */



            //var xTbl = new List<string>();
            //xTbl = JsonConvert.DeserializeObject< List<string>> (xBuilt.Trim());

            DataTable dt = new DataTable();
            dt = JsonConvert.DeserializeObject<DataTable>(xBuilt.Trim());

            //Save to Database
            foreach (DataRow xRow in dt.Rows)
            {
                List<string> fFields = new List<string>();
                List<string> vValues = new List<string>();

                fFields.Add("tblUserID");
                fFields.Add("MediaID");

                vValues.Add(xtblUserID);
                vValues.Add(xRow[0].ToString());

                //Add or Update the record
                tblUserMediaID xtblUserMediaID = new tblUserMediaID();
                DataRow dataRow = xtblUserMediaID.dtUserMediaID.AsEnumerable().FirstOrDefault(r => r["MediaID"].ToString() == xRow[0].ToString());
                if (dataRow != null)
                {
                    //clsSQLiteDB.UpdateRec("tblUser", fFields, vValues, "02_S_user_id = " + xtblShortToken.user_id);
                }
                else
                {
                    clsSQLiteDB.InsertRec("tblUserMediaID", fFields, vValues);

                }

            }

            tblUserMediaID xRefreshData = new tblUserMediaID();

            return xRefreshData.dtUserMediaID;

            //return xtblUsernameAndMediaCount;
        }

    }
}
