using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinASMX.Droid
{



    public interface IMyAPI
    {
        string Result { get; set; }
    }

    public interface IMyAPISoapService
    {
        Task<string> HellowWorld();
    }
}