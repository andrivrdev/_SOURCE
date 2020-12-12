using SocialRank.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialRank.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            await label.RelRotateTo(360, 1000);
        }

        async void btnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new frmRegster());
        }
    }
}