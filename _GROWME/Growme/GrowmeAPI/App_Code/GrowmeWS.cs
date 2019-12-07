using Shared.CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for GrowmeWS
/// </summary>
[WebService(Namespace = clsGlobal.gWebServiceNamespace)]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class GrowmeWS : System.Web.Services.WebService
{

    public GrowmeWS()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string DoWork(string xData)
    {
        //var xMessage = xData.Remove(0, 1);
        var xMessage = xData;

        clsSE xclsSE = new clsSE();
        xMessage = xclsSE.DecodeMessage(xMessage);

        if (xMessage.Contains("Test" + clsGlobal.gMessageCommandSeperator))
        {
            return xclsSE.EncodeMessage("Response", "Test received");
        }

        return "Error";
    }

}
