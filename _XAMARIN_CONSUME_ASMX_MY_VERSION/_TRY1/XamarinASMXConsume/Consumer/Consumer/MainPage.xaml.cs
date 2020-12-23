using Consumer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Consumer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void btnTestAPI_Clicked(object sender, EventArgs e)
       
        {
            var customers = await App.CustomerSoapService.GetAllCustomers();
            lblResult.Text = customers.ToString();
        }
    }
}
