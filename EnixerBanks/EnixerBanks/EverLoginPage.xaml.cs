using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Fingerprint;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Screenshot;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace EnixerBanks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EverLoginPage : ContentPage
    {

        public EverLoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            var a = App.User;
            this.BindingContext = App.User;
            login.Scale = 0;

        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();


            new Animation() {
                { 0, 1, new Animation (v => login.Scale = v, 0, 1) },
                { 0, 1, new Animation (v => login.Opacity = v, 0, 1) }
            }.Commit(this, "anime", 16, 2000, Easing.SpringOut, null, () => false);

            if (Device.RuntimePlatform == Device.Android)
            {

                bool result2 = await DependencyService.Get<IScanFinger>().Scan();
                if (result2 == false)
                {
                    Vibration.Vibrate();
                    return;
                }

                await Navigation.PushAsync(new TabPage());

            }
        }

        async private void LoginPIN_BT_Clicked(object sender, EventArgs e)
        {




            await Navigation.PushAsync(new PINLoginPage());

        }

        async void NotYOU_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }

        async void TouchID_Clicked(object sender, System.EventArgs e)
        {


            if (LocalDB.TouchIDEnable())
            {

                if (Device.RuntimePlatform == Device.iOS)
                {
                    var result = await CrossFingerprint.Current.AuthenticateAsync("Prove you have fingers!");
                    if (result == null) return;

                    if (result.Authenticated)
                    {
                        await Navigation.PushAsync(new TabPage());
                    }
                    else
                    {
                        Vibration.Vibrate();
                    }
                }
                else if (Device.RuntimePlatform == Device.Android)
                {

                    bool result2 = await DependencyService.Get<IScanFinger>().Scan();
                    if (result2 == false)
                    {
                        Vibration.Vibrate();
                        return;
                    }

                    await Navigation.PushAsync(new TabPage());

                }








            }


        }
    }
}