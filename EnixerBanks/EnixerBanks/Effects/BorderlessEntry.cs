using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EnixerBanks
{
   public class BorderlessEntry : RoutingEffect
    {
        public bool IsBorder { get; set; }

        public BorderlessEntry() : base("MyEffect.BorderlessEntry")
        {

        }
    }
}
