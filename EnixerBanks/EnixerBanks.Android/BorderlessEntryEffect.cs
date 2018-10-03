using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Bankgreen.Droid;
using EnixerBanks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ResolutionGroupName("MyEffect")]
[assembly: ExportEffect(typeof(BorderlessEntryEffect), "BorderlessEntry")]
namespace Bankgreen.Droid
{
    class BorderlessEntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var control = Control as Android.Widget.EditText;
            var effect = (BorderlessEntry)Element.Effects.FirstOrDefault(x => x is BorderlessEntry);
            if (effect != null)
            {

                control.SetBackgroundColor(Android.Graphics.Color.Transparent);



            }

        }
        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }

    }
}