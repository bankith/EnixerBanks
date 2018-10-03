
using EnixerBank;
using EnixerBank.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EnixerBanks
{
    public partial class App : Application
    {
        public static string DBPath;
        public static UserProfile User;

        public static GreenBank_BillerCompany Company;
        public static FavoritedBillInfo FavoruSelected;
        public static bool Check;

        public App()
        {
            InitializeComponent();


            LoadDataBaseSQLite();

            //TestDataUser();

            //LocalDB.Save(username: "tata05", password: "123456");
            MainPage = new NavigationPage(new LoadPage());




        }

        private void TestDataUser()
        {
            User = new UserProfile()
            {
                ID = 3,
                MobileNo = "0830170707"
            };
        }

        public void LoadDataBaseSQLite()
        {

            DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyDBbApp2.db");
            using (SQLiteConnection conn = new SQLiteConnection(DBPath))
            {
                conn.CreateTable<LocalDB>();
                conn.CreateTable<LocalManu>();
            }
        }



        protected override void OnStart()
        {
            // Handle when your app starts
            InternetCheckHandle();
        }

        public static bool InternetCheckHandle()
        {
            var current = Connectivity.NetworkAccess;

            Connectivity.ConnectivityChanged += (e, network) =>
            {
                if (network.NetworkAccess == NetworkAccess.None)
                {
                    Application.Current.MainPage.Navigation.PushAsync(new NoInternetPage());
                }
                else
                {
                    Application.Current.MainPage.Navigation.PopAsync();
                }
            };

            if (current == NetworkAccess.None)
            {
                Application.Current.MainPage.Navigation.PushAsync(new NoInternetPage());
            }


            return true;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
