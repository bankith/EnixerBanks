using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace EnixerBanks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            LocalDB.Delete();
            login.Scale = 0;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            new Animation() {
                { 0, 1, new Animation (v => login.Scale = v, 0, 1) },
                { 0, 1, new Animation (v => login.Opacity = v, 0, 1) }
            }.Commit(this, "anime", 16, 2000, Easing.SpringOut, null, () => false);
        }

        async private void loginBT_Clicked(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(UsernameEntry.Text) && !string.IsNullOrEmpty(PasswordEnter.Text))
            {

                string Username = UsernameEntry?.Text;
                string Password = PasswordEnter?.Text;

                Loading.Start(Loader, LoaderBackground);
                UserProfile user = await Services.GetUserProfileFrom(Username, Password);

                Loading.Stop(Loader, LoaderBackground);
                if (user == null)
                {
                    await DisplayAlert("Wrong", "You Username Password not right", "OK");

                    return;
                }

                user.Password = Password;
                App.User = user;
                await Navigation.PushAsync(new ExistingUserLoginView.IntroNewLogin());

            }
            else
            {
                new Animation() {
                    { 0, 0.25, new Animation (v => loginBT.TranslationX = v, 0, 50) },
                    { 0.25, 0.75, new Animation (v => loginBT.TranslationX = v, 50, -50) },
                    { 0.75, 1, new Animation (v => loginBT.TranslationX = v, -50, 0) }
                 }.Commit(this, "anime2", 16, 1000, Easing.SpringOut, null, () => false);

                Vibration.Vibrate(); 
            }


        }

        void Register_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterNoCardView.Selectaccount());
        }
        void Temporary_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Log__in_with_temp_En.AgreemantForLogExPage());
        }
    }
}