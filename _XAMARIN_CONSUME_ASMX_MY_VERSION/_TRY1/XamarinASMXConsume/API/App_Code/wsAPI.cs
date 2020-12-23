using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for wsAPI
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class wsAPI : System.Web.Services.WebService
{

    public wsAPI()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
        
    }

    [WebMethod]
    public List<Customer> GetAllCustomers()
    {
        return new List<Customer>()
            {
                new Customer() { Id = "1", Name = "Customer 1" },
                new Customer() { Id = "2", Name = "Customer 2" },
                new Customer() { Id = "3", Name = "Customer 3" }
            };
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

}
