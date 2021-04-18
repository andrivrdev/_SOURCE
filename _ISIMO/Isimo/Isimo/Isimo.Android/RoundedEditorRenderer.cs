using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Isimo;
using Isimo.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundedEditor), typeof(RoundedEditorRenderer))]
namespace Isimo.Droid
{
    public class RoundedEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Gravity = GravityFlags.CenterVertical;
                Control.Background = Xamarin.Forms.Forms.Context.GetDrawable(Resource.Drawable.RoundedEditText);
            }
        }
    }
}