using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Application = Android.App.Application;

[assembly: ExportRenderer(typeof(SocialRankMobile.Controls.BorderlessEntry), typeof(SocialRankMobile.Droid.BorderlessEntryRenderer))]

namespace SocialRankMobile.Droid
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessEntryRenderer() : base(Application.Context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
                this.Control.SetBackground(null);
                Control.Gravity = GravityFlags.CenterVertical;
                Control.SetPadding(0, 0, 0, 0);
            }
        }
    }
}