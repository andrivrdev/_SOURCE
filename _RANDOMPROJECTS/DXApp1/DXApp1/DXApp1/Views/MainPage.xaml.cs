using DevExpress.XamarinForms.Navigation;
using DXApp1.ViewModels;
using System;
using System.Linq;

namespace DXApp1.Views
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
