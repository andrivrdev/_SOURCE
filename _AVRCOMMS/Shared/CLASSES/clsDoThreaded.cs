using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.CLASSES
{
    public class clsDoThreaded
    {
        public string Send(string xData)
        {
            try
            {

                var remoteAddress = new System.ServiceModel.EndpointAddress("http://localhost/Server/wsServer.asmx");
                //var remoteAddress = new System.ServiceModel.EndpointAddress("http://41.180.72.26/wsServer/wsServer.asmx");

                using (var xwsServerSoapClient = new wsServer.wsServerSoapClient(new System.ServiceModel.BasicHttpBinding(), remoteAddress))
                {
                    //set timeout
                    xwsServerSoapClient.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 1000);

                    //call web service method
                    return xwsServerSoapClient.GetWork(xData);
                }
            }
            catch (Exception Ex)
            {
                clsSE.WriteLog(1, Ex.Message, "clsSE", "Send");
                return "";
            }
        }



    }
}
