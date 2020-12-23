using Consumer.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Consumer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        private static ICustomerSoapService _customerSoapService;
        public static ICustomerSoapService CustomerSoapService
        {
            get
            {
                if (_customerSoapService == null)
                {
                    _customerSoapService = DependencyService.Get<ICustomerSoapService>();
                }

                return _customerSoapService;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
