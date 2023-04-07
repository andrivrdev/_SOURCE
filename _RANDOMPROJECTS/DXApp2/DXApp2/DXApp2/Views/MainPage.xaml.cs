using DevExpress.XamarinForms.Navigation;
using DXApp2.ViewModels;
using System;
using System.Linq;

namespace DXApp2.Views
{
    public partial class MainPage : TabPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
