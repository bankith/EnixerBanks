using EnixerBanks;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using EnixerBanks.ModelApp;
using SQLite;

namespace EnixerBanks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPage : ContentPage
    {
        public static readonly BindableProperty Menu1ImgProperty = BindableProperty.Create("Menu1Img", typeof(string), typeof(MainMenuPage), "ManuIMG1");
        public string Menu1Img
        {
            get { return (String)GetValue(Menu1ImgProperty); }
            set { SetValue(Menu1ImgProperty, value); }
        }

        public static readonly BindableProperty Menu1TextProperty = BindableProperty.Create("Menu1Text", typeof(string), typeof(MainMenuPage), "Tex1");
        public string Menu1Text
        {
            get { return (String)GetValue(Menu1TextProperty); }
            set { SetValue(Menu1TextProperty, value); }
        }



        public static readonly BindableProperty Menu2ImgProperty = BindableProperty.Create("Menu2Img", typeof(string), typeof(MainMenuPage), "");
        public string Menu2Img
        {
            get { return (String)GetValue(Menu2ImgProperty); }
            set { SetValue(Menu2ImgProperty, value); }
        }



        public static readonly BindableProperty Menu2TextProperty = BindableProperty.Create("Menu2Text", typeof(string), typeof(MainMenuPage), "");
        public string Menu2Text
        {
            get { return (String)GetValue(Menu2TextProperty); }
            set { SetValue(Menu2TextProperty, value); }
        }

        public static readonly BindableProperty Menu3ImgProperty = BindableProperty.Create("Menu3Img", typeof(string), typeof(MainMenuPage), "");
        public string Menu3Img
        {
            get { return (String)GetValue(Menu3ImgProperty); }
            set { SetValue(Menu3ImgProperty, value); }
        }

        public static readonly BindableProperty Menu3TextProperty = BindableProperty.Create("Menu3Text", typeof(string), typeof(MainMenuPage), "");
        public string Menu3Text
        {
            get { return (String)GetValue(Menu3TextProperty); }
            set { SetValue(Menu3TextProperty, value); }
        }



        public static readonly BindableProperty Menu4ImgProperty = BindableProperty.Create("Menu4Img", typeof(string), typeof(MainMenuPage), "");
        public string Menu4Img
        {
            get { return (String)GetValue(Menu4ImgProperty); }
            set { SetValue(Menu4ImgProperty, value); }
        }

        public static readonly BindableProperty Menu4TextProperty = BindableProperty.Create("Menu4Text", typeof(string), typeof(MainMenuPage), "");
        public string Menu4Text
        {
            get { return (String)GetValue(Menu4TextProperty); }
            set { SetValue(Menu4TextProperty, value); }
        }



        public static readonly BindableProperty Menu5ImgProperty = BindableProperty.Create("Menu5Img", typeof(string), typeof(MainMenuPage), "");
        public string Menu5Img
        {
            get { return (String)GetValue(Menu5ImgProperty); }
            set { SetValue(Menu5ImgProperty, value); }
        }

        public static readonly BindableProperty Menu5TextProperty = BindableProperty.Create("Menu5Text", typeof(string), typeof(MainMenuPage), "");
        public string Menu5Text
        {
            get { return (String)GetValue(Menu5TextProperty); }
            set { SetValue(Menu5TextProperty, value); }
        }


        public static readonly BindableProperty Menu6ImgProperty = BindableProperty.Create("Menu6Img", typeof(string), typeof(MainMenuPage), "");
        public string Menu6Img
        {
            get { return (String)GetValue(Menu6ImgProperty); }
            set { SetValue(Menu6ImgProperty, value); }
        }

        public static readonly BindableProperty Menu6TextProperty = BindableProperty.Create("Menu6Text", typeof(string), typeof(MainMenuPage), "");
        public string Menu6Text
        {
            get { return (String)GetValue(Menu6TextProperty); }
            set { SetValue(Menu6TextProperty, value); }
        }



        public static readonly BindableProperty Menu7ImgProperty = BindableProperty.Create("Menu7Img", typeof(string), typeof(MainMenuPage), "");
        public string Menu7Img
        {
            get { return (String)GetValue(Menu7ImgProperty); }
            set { SetValue(Menu7ImgProperty, value); }
        }

        public static readonly BindableProperty Menu7TextProperty = BindableProperty.Create("Menu7Text", typeof(string), typeof(MainMenuPage), "");
        public string Menu7Text
        {
            get { return (String)GetValue(Menu7TextProperty); }
            set { SetValue(Menu7TextProperty, value); }
        }



        public static readonly BindableProperty Menu8ImgProperty = BindableProperty.Create("Menu8Img", typeof(string), typeof(MainMenuPage), "");
        public string Menu8Img
        {
            get { return (String)GetValue(Menu8ImgProperty); }
            set { SetValue(Menu8ImgProperty, value); }
        }

        public static readonly BindableProperty Menu8TextProperty = BindableProperty.Create("Menu8Text", typeof(string), typeof(MainMenuPage), "");
        public string Menu8Text
        {
            get { return (String)GetValue(Menu8TextProperty); }
            set { SetValue(Menu8TextProperty, value); }
        }


        public static readonly BindableProperty Menu9ImgProperty = BindableProperty.Create("Menu9Img", typeof(string), typeof(MainMenuPage), "");
        public string Menu9Img
        {
            get { return (String)GetValue(Menu9ImgProperty); }
            set { SetValue(Menu9ImgProperty, value); }
        }

        public static readonly BindableProperty Menu9TextProperty = BindableProperty.Create("Menu9Text", typeof(string), typeof(MainMenuPage), "");
        public string Menu9Text
        {
            get { return (String)GetValue(Menu9TextProperty); }
            set { SetValue(Menu9TextProperty, value); }
        }


        public static readonly BindableProperty Menu10ImgProperty = BindableProperty.Create("Menu10Img", typeof(string), typeof(MainMenuPage), "");
        public string Menu10Img
        {
            get { return (String)GetValue(Menu10TextProperty); }
            set { SetValue(Menu10TextProperty, value); }
        }

        public static readonly BindableProperty Menu10TextProperty = BindableProperty.Create("Menu10Text", typeof(string), typeof(MainMenuPage), "");
        public string Menu10Text
        {
            get { return (String)GetValue(Menu10TextProperty); }
            set { SetValue(Menu10TextProperty, value); }
        }


        public static readonly BindableProperty Menu11ImgProperty = BindableProperty.Create("Menu11Img", typeof(string), typeof(MainMenuPage), "");
        public string Menu11Img
        {
            get { return (String)GetValue(Menu11ImgProperty); }
            set { SetValue(Menu11ImgProperty, value); }
        }

        public static readonly BindableProperty Menu11TextProperty = BindableProperty.Create("Menu11Text", typeof(string), typeof(MainMenuPage), "");
        public string Menu11Text
        {
            get { return (String)GetValue(Menu11TextProperty); }
            set { SetValue(Menu11TextProperty, value); }
        }



        public MainMenuPage()
        {
            InitializeComponent();

            //Load();
            BindingContext = this;
        }


        async protected override void OnAppearing()
        {
            base.OnAppearing();

            Load();
            BindingContext = this;

            var myAccounts = await Services.GetAccountsFromUserID(App.User.ID);

            var balance = await Services.GetAccountBalance(myAccounts.FirstOrDefault().AccountNumber);

            var info = new FullUserInformation()
            {
                Firstname = App.User.Firstname,
                AvailableBalance = balance.AvailableBalance,
                AccountNumber = balance.AccountNumber,
                Currency = balance.Currency
            };

            userInfoShow.BindingContext = info;

        }


        async private void Load()
        {
            /*   user = await (new User()).GetUser(LocalDB.GetPhoneNo().My_NumberPhone, Loader, LoaderBackground);

               Device.BeginInvokeOnMainThread(() => {
                   Balance.Text = user.Balance.ToString();
                   User.Text = $"Welcome {user.FirstName} {user.LastName}";
               });
               */


            SQLiteConnection conn = new SQLiteConnection(App.DBPath);
            List<LocalManu> db = conn.Table<LocalManu>().ToList();

            // LocalManu img = new LocalManu();
            if (db.Count >= 0 && db.Count < 11)
            {
                Menu1Img = "iconCards.png";
                Menu2Img = "iconCards.png";
                Menu3Img = "iconPromptPay.png";
                Menu4Img = "iconPhoneGray.png";
                Menu5Img = "iconBill.png";
                Menu6Img = "iconMarkFav";
                Menu7Img = "iconTransaction.png";
                Menu8Img = "iconWatch.png";
                Menu9Img = "iconPromptPay.png";
                Menu10Img = "iconSpeech.png";
                Menu11Img = "iconOneCard.png";

                Menu1Text = "Transfer Own Account";
                Menu2Text = "Transfer Other Account";
                Menu3Text = "Transfer PromptPay";
                Menu4Text = "Top Up";
                Menu5Text = "Pay Bill";
                Menu6Text = "Favorite";
                Menu7Text = "Transation History";
                Menu8Text = "Schedule List";
                Menu9Text = "Register PrompPay";
                Menu10Text = "Apply SMS Banking";
                Menu11Text = "Apply Autopay Debit";

            }
            else if (db.Count == 11)
            {
                var manu1 = db[0].ImgManu;
                var manu2 = db[1].ImgManu;
                var manu3 = db[2].ImgManu;
                var manu4 = db[3].ImgManu;
                var manu5 = db[4].ImgManu;
                var manu6 = db[5].ImgManu;
                var manu7 = db[6].ImgManu;
                var manu8 = db[7].ImgManu;
                var manu9 = db[8].ImgManu;
                var manu10 = db[9].ImgManu;
                var manu11 = db[10].TexManu;

                Menu1Img = manu1;
                Menu2Img = manu2;
                Menu3Img = manu3;
                Menu4Img = manu4;
                Menu5Img = manu5;
                Menu6Img = manu6;
                Menu7Img = manu7;
                Menu8Img = manu8;
                Menu9Img = manu9;
                Menu10Img = manu10;
                Menu11Img = manu11;


                var img1 = db[0].TexManu;
                var img2 = db[1].TexManu;
                var img3 = db[2].TexManu;
                var img4 = db[3].TexManu;
                var img5 = db[4].TexManu;
                var img6 = db[5].TexManu;
                var img7 = db[6].TexManu;
                var img8 = db[7].TexManu;
                var img9 = db[8].TexManu;
                var img10 = db[9].TexManu;
                var img11 = db[10].TexManu;

                Menu1Text = img1;
                Menu2Text = img2;
                Menu3Text = img3;
                Menu4Text = img4;
                Menu5Text = img5;
                Menu6Text = img6;
                Menu7Text = img7;
                Menu8Text = img8;
                Menu9Text = img9;
                Menu10Text = img10;
                Menu11Text = img11;
            }



        }



        private void manu1(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(App.DBPath);
            List<LocalManu> db = conn.Table<LocalManu>().ToList();

            string manu;
            if (db.Count == 0)
            {
                manu = "Transfer Own Account";
                NavigateTo(manu);

            }
            else
            {
                manu = db[0].TexManu;
                NavigateTo(manu);

            }
        }

        private void manu2(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(App.DBPath);
            List<LocalManu> db = conn.Table<LocalManu>().ToList();

            string manu;
            if (db.Count == 0)
            {
                manu = "Transfer Other Account";
                NavigateTo(manu);

            }
            else
            {
                manu = db[1].TexManu;
                NavigateTo(manu);
            }

        }

        private void manu3(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(App.DBPath);
            List<LocalManu> db = conn.Table<LocalManu>().ToList();


            string manu;
            if (db.Count == 0)
            {
                manu = "Transfer PromptPay";
                NavigateTo(manu);

            }
            else
            {
                manu = db[2].TexManu;
                NavigateTo(manu);
            }

        }

        private void manu4(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(App.DBPath);
            List<LocalManu> db = conn.Table<LocalManu>().ToList();


            string manu;
            if (db.Count == 0)
            {
                manu = "Top Up";
                NavigateTo(manu);

            }
            else
            {
                manu = db[3].TexManu;
                NavigateTo(manu);
            }

        }

        private void manu5(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(App.DBPath);
            List<LocalManu> db = conn.Table<LocalManu>().ToList();


            string manu;
            if (db.Count == 0)
            {
                manu = "Pay Bill";
                NavigateTo(manu);

            }
            else
            {
                manu = db[4].TexManu;
            }
            NavigateTo(manu);
        }

        private void manu6(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(App.DBPath);
            List<LocalManu> db = conn.Table<LocalManu>().ToList();


            string manu;
            if (db.Count == 0)
            {
                manu = "Favorite";
                NavigateTo(manu);

            }
            else
            {
                manu = db[5].TexManu;
                NavigateTo(manu);
            }

        }

        private void manu7(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(App.DBPath);
            List<LocalManu> db = conn.Table<LocalManu>().ToList();


            string manu;
            if (db.Count == 0)
            {
                manu = "Transation History";
                NavigateTo(manu);

            }
            else
            {
                manu = db[6].TexManu;
                NavigateTo(manu);
            }

        }

        private void manu8(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(App.DBPath);
            List<LocalManu> db = conn.Table<LocalManu>().ToList();


            string manu;
            if (db.Count == 0)
            {
                manu = "Schedule List";
                NavigateTo(manu);

            }
            else
            {
                manu = db[7].TexManu;
                NavigateTo(manu);
            }

        }

        private void manu9(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(App.DBPath);
            List<LocalManu> db = conn.Table<LocalManu>().ToList();


            string manu;
            if (db.Count == 0)
            {
                manu = "Register PrompPay";
                NavigateTo(manu);

            }
            else
            {
                manu = db[8].TexManu;
                NavigateTo(manu);
            }

        }

        private void manu10(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(App.DBPath);
            List<LocalManu> db = conn.Table<LocalManu>().ToList();


            string manu;
            if (db.Count == 0)
            {
                manu = "Apply SMS Banking";
                NavigateTo(manu);

            }
            else
            {
                manu = db[9].TexManu;
                NavigateTo(manu);
            }

        }

        private void manu11(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(App.DBPath);
            List<LocalManu> db = conn.Table<LocalManu>().ToList();


            string manu;
            if (db.Count == 0)
            {
                manu = "Apply Autopay Debit";
                NavigateTo(manu);

            }
            else
            {
                manu = db[10].TexManu;
                NavigateTo(manu);
            }

        }

        private void manu12(object sender, EventArgs e)
        {
            LocalManu.Delete();
            Navigation.PushAsync(new ChooseMenuPage());

        }

        private void NavigateTo(string manu)
        {
            switch (manu)
            {
                case "Transfer Own Account": break;
                case "Transfer Other Account": Navigation.PushAsync(new TransferView.TransferOtherPage()); break;
                case "Transfer PromptPay": break;
                case "Top Up": break;
                case "Pay Bill": Navigation.PushAsync(new PayBills2.PayBillsPage()); break;//
                case "Favorite": break;
                case "Transaction History": break;
                case "Schedule List": break;
                case "Register PromptPay": break;
                case "Apply SMS Banking": break;
                case "Apply Autopay Debit": break;
                default:
                    break;
            }
        }

        private void logoutBT_Clicked(object sender, EventArgs e)
        {
            Xamarin.Forms.Application.Current.MainPage = new NavigationPage(new EverLoginPage());
        }
    }
}