using Shared.CLASSES;
using Shared.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Server
{
    /// <summary>
    /// Summary description for wsServer
    /// </summary>
    [WebService(Namespace = "http://avrcomms/server/api")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class wsServer : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetWork(string xData)
        {
            if (!clsSQLiteDB.CheckIfDBExist(1, false))
            {
                clsSQLiteDB.CreateDB(1);
            }

            clsGlobal.gDebugLog = true;

            string result = clsSE.Decrypt(xData);
            clsSE.WriteLog(3, "Received:" + result, "wsServer", "GetWork");

            clsSE.WriteLog(3, "Sending response", "wsServer", "GetWork");


            //Decide what to respond


            tblServerDetail xtblServerDetail = new tblServerDetail();
            return clsSE.Pack("Server_Heartbeat", xtblServerDetail.dtServerDetail);
        }
    }
}
