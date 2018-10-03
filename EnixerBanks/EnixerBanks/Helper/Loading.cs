using System;
using Xamarin.Forms;

namespace EnixerBanks
{
    public static class Loading
    {
        public static void Start(ActivityIndicator Loader, Label background)
        {
            Loader.IsVisible = true;
            Loader.IsRunning = true;
            background.IsVisible = true;
        }

        public static void Stop(ActivityIndicator Loader, Label background)
        {
            Loader.IsVisible = false;
            Loader.IsRunning = false;
            background.IsVisible = false;
        }
    }
}
