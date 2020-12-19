using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialRankMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            btnRegister.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnLabelClicked()));
        }

        async void OnLabelClicked()
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}