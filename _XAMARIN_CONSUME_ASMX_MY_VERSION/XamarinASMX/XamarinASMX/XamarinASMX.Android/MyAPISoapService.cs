using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinASMX.Droid
{

   
    public sealed class MyAPISoapService : IMyAPISoapService
    {
        srMyAPI.wsAPISoapClient service;
        //CustomersWs.Customers service;

        public MyAPISoapService()
        {
            service = new srMyAPI.wsAPISoapClient()
            {
                Url = "http://localhost/FSL.WS/Customers.asmx"
            };
        }

        public async Task<List<ICustomer>> GetAllCustomers(string criteria = null)
        {
            return await Task.Run(() =>
            {
                var result = service.GetAllCustomers();

                return new List<ICustomer>(result);
            });
        }
    }
}