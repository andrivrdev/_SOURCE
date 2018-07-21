using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for CalculatorWebService
/// </summary>
[WebService(Namespace = "http://localhost/calculator/api")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class CalculatorWebService : System.Web.Services.WebService
{

    public CalculatorWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public int Add(int xNumA, int xNumB)
    {
        return xNumA + xNumB;
    }

}
