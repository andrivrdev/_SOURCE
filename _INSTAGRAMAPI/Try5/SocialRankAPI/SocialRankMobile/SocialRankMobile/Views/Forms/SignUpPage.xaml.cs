using SocialRankMobile.SHARED;
using System.Collections.Generic;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SocialRankMobile.Views.Forms
{
    /// <summary>
    /// Page to sign in with user details.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpPage" /> class.
        /// </summary>
        public SignUpPage()
        {
            InitializeComponent();
        }

        async void SfButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Views.Forms.LoginPage());

        }

        private void btnRegister_Clicked(object sender, System.EventArgs e)
        {
            var xData = new List<string>();

            xData.Add(NameEntry.Text);
            xData.Add(EmailEntry.Text);
            xData.Add(PasswordEntry.Text);

            clsSEMobile xclsSE = new clsSEMobile();
            //var xresult = xclsSE.Send("Test", xData);
            var xresult = xclsSE.Send("frmRegister_RegisterUser", xData);
            //xresult = xclsSE.DecodeMessage(xresult);
            var xx = NameEntry.Text;
            var yy = EmailEntry.Text;
            lblResponse.Text = xresult.ToString();
        }
    }
}