using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SocialRankMobile.Views.Forms
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage" /> class.
        /// </summary>
        public LoginPage()
        {
            InitializeComponent();
        }

        async void SfButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Views.Forms.SignUpPage());
        }
    }
}