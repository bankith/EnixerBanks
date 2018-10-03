using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Plugin.Fingerprint;

namespace EnixerBanks
{
    public partial class LoadPage : ContentPage
    {
        public LoadPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            LoadUser();

        }



        async public void LoadUser()
        {


            LocalDB db = LocalDB.GetUsernamePassword();

            if (db != null)
            {
                App.User = await Services.GetUserProfileFrom(db.Username, db.Password);

                if (App.User != null)
                {

                    App.User.Password = db.Password;
                    Console.WriteLine("User = " + App.User.Firstname);
                    Application.Current.MainPage = new NavigationPage(new EverLoginPage())
                    {
                        BarTextColor = Color.FromHex("#333"),
                        BarBackgroundColor = Color.Wheat,
                        Tint = Color.FromHex("#333")
                    };

                    return;
                }



                Console.WriteLine("locaDB can't load user from username password");
            }


            Application.Current.MainPage = new NavigationPage(new LoginPage())
            {
                BarTextColor = Color.FromHex("#333"),
                BarBackgroundColor = Color.Wheat,
                Tint = Color.FromHex("#333")
            };

        }
    }
}
