using SocialRankAndroid.SHARED.CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialRankAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            lblResend.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnlblResendClick()));
            lblForgotPassword.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnlblForgotPasswordClick()));

        }

        async void OnlblResendClick()
        {
            await Navigation.PushModalAsync(new ResendActivationEmailPage());
        }

        async void OnlblForgotPasswordClick()
        {
            await Navigation.PushModalAsync(new ForgotPasswordPage());
        }

        async void btnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage());
        }
    }
}