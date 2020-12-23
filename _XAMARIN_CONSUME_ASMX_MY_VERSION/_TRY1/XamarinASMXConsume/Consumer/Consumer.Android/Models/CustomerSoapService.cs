using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Consumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Droid.Models
{
    public sealed class CustomerSoapService : ICustomerSoapService
    {
        wrAPI.wsAPI service;
        //stomersWs.Customers service;

        public CustomerSoapService()
        {
            service = new wrAPI.wsAPI
            {
                
                //Url = "http://codefinal.com/FSL.ConsummingAsmxServicesInXamarinForms/Customers.asmx" //remote server
                Url = "http://192.168.1.15/API/wsAPI.asmx" //localserver - mobile does not understand "localhost", just that ip address
            };
        }

        public async Task<List<ICustomer>> GetAllCustomers(string criteria = null)
        {
            return await Task.Run(() =>
            {
                var result = service.GetAllCustomers();

                return new List<ICustomer>((IEnumerable<ICustomer>)result);
            });
        }
    }
}