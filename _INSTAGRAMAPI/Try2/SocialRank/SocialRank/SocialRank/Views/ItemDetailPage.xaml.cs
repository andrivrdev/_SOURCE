using SocialRank.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SocialRank.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}