
using EnixerBanks;
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
    public partial class PINLoginPage : ContentPage
    {
        int countClick;
        public PINLoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

        }

        protected override void OnAppearing()
        {

            base.OnAppearing();
            countClick = 0;
            numPin = "";
            this.BindingContext = this;



        }
        public static string numPin; //number pin

        public static readonly BindableProperty BGColor1Property = BindableProperty.Create("BGColor1", typeof(string), typeof(PINLoginPage), "#347555");
        public string BGColor1
        {
            get { return (String)GetValue(BGColor1Property); }
            set { SetValue(BGColor1Property, value); }
        }

        public static readonly BindableProperty BGColor2Property = BindableProperty.Create("BGColor2", typeof(string), typeof(PINLoginPage), "#347555");
        public string BGColor2
        {
            get { return (String)GetValue(BGColor2Property); }
            set { SetValue(BGColor2Property, value); }
        }

        public static readonly BindableProperty BGColor3Property = BindableProperty.Create("BGColor3", typeof(string), typeof(PINLoginPage), "#347555");
        public string BGColor3
        {
            get { return (String)GetValue(BGColor3Property); }
            set { SetValue(BGColor3Property, value); }
        }

        public static readonly BindableProperty BGColor4Property = BindableProperty.Create("BGColor4", typeof(string), typeof(PINLoginPage), "#347555");
        public string BGColor4
        {
            get { return (String)GetValue(BGColor4Property); }
            set { SetValue(BGColor4Property, value); }
        }

        public static readonly BindableProperty BGColor5Property = BindableProperty.Create("BGColor5", typeof(string), typeof(PINLoginPage), "#347555");
        public string BGColor5
        {
            get { return (String)GetValue(BGColor5Property); }
            set { SetValue(BGColor5Property, value); }
        }

        public static readonly BindableProperty BGColor6Property = BindableProperty.Create("BGColor6", typeof(string), typeof(PINLoginPage), "#347555");
        public string BGColor6
        {
            get { return (String)GetValue(BGColor6Property); }
            set { SetValue(BGColor6Property, value); }
        }

        void Forgot_Clicked(object sender, System.EventArgs e)
        {
            // Navigation.PushAsync(new ForgotPIN());
        }


        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            numberPin(1);
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            numberPin(2);


        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            numberPin(3);

        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            numberPin(4);

        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            numberPin(5);

        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            numberPin(6);

        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            numberPin(7);

        }

        private void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            numberPin(8);

        }

        private void TapGestureRecognizer_Tapped_8(object sender, EventArgs e)
        {
            numberPin(9);

        }

        private void TapGestureRecognizer_Tapped_9(object sender, EventArgs e)
        {
            numberPin(0);

        }

        private void TapGestureRecognizer_Tapped_10(object sender, EventArgs e)
        {
            delectPin();
        }

        private void delectPin()
        {
            if (countClick <= 0)
            {
                countClick = 0;
                return;
            }
            switch (countClick)
            {
                case 1:
                    BGColor1 = "#347555";
                    numPin = "";
                    break;
                case 2:
                    BGColor2 = "#347555";
                    numPin = numPin.Substring(0, 1);
                    break;
                case 3:
                    BGColor3 = "#347555";
                    numPin = numPin.Substring(0, 2);
                    break;
                case 4:
                    BGColor4 = "#347555";
                    numPin = numPin.Substring(0, 3);
                    break;
                case 5:
                    BGColor5 = "#347555";
                    numPin = numPin.Substring(0, 4);
                    break;
                case 6:
                    BGColor6 = "#347555";
                    numPin = numPin.Substring(0, 5);
                    break;
            }
            countClick -= 1;
        }

        //method
        async private void numberPin(int v)
        {



            if (countClick < 6)
            {

                numPin += v.ToString();
                countClick += 1;
                switch (countClick)
                {
                    case 1: BGColor1 = "White"; break;
                    case 2: BGColor2 = "White"; break;
                    case 3: BGColor3 = "White"; break;
                    case 4: BGColor4 = "White"; break;
                    case 5: BGColor5 = "White"; break;
                    case 6: BGColor6 = "White"; break;
                }

                if (countClick == 6)
                {
                    Loading.Start(Loader, LoaderBackground);
                    bool PinExist = await Services.IsPINExist(App.User.ID, numPin);
                    Loading.Stop(Loader, LoaderBackground);
                    if (!PinExist)
                    {
                        await DisplayAlert("Wrong", "Not right PIN", "OK");

                        Vibration.Vibrate();
                        await DisplayAlert("Wrong Pin", "Enter again", "OK");
                        countClick = 0;  //reset ค่าให้กดหใหม่
                        numPin = "";
                        BGColor1 = "#347555";
                        BGColor2 = "#347555";
                        BGColor3 = "#347555";
                        BGColor4 = "#347555";
                        BGColor5 = "#347555";
                        BGColor6 = "#347555";
                        return;
                    }
                    //  await Navigation.PushAsync(new WelcomePage());
                    Application.Current.MainPage = new NavigationPage(new TabPage())
                    {
                        BarTextColor = Color.FromHex("#333"),
                        BarBackgroundColor = Color.White
                    };

                }


            }
            else
            {
                await DisplayAlert("Error", "Error", "OK");
            }



        }

        private void BlackToLoginBT_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            // App.Current.MainPage = new NavigationPage(new EverLoginPage());
        }
    }
}