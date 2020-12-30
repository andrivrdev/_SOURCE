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
    public partial class UserMainPage : TabbedPage
    {
        public UserMainPage()
        {
            InitializeComponent();
        }

        async void btnLinkInstagram_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LinkInstagramPage());

        }
    }
}