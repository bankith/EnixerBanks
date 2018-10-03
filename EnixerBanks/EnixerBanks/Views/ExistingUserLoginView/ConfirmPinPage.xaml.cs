using EnixerBank.Models;
using EnixerBanks;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EnixerBanks.ExistingUserLoginView
{
    public partial class ConfirmPinPage : ContentPage
    {
        GreenBank_UserProfile user;
        String firstPin;

        public ConfirmPinPage()
        {
            InitializeComponent();
        }

        public ConfirmPinPage(String firstPin):this()
        {
            this.firstPin = firstPin;
        }



        public ConfirmPinPage(String firstPin, GreenBank_UserProfile user) : this(firstPin)
        {
            this.user = user;
        }



        protected override void OnAppearing()
        {
            InitializeComponent();
            base.OnAppearing();

            this.BindingContext = this;

        }




        public  int countClick = 0; //count click number pin
        public  string numPin; //number pin

        public static readonly BindableProperty BGColor1Property = BindableProperty.Create("BGColor1", typeof(string), typeof(OTPPage), "White");
        public string BGColor1
        {
            get { return (String)GetValue(BGColor1Property); }
            set { SetValue(BGColor1Property, value); }
        }

        public static readonly BindableProperty BGColor2Property = BindableProperty.Create("BGColor2", typeof(string), typeof(OTPPage), "White");
        public string BGColor2
        {
            get { return (String)GetValue(BGColor2Property); }
            set { SetValue(BGColor2Property, value); }
        }

        public static readonly BindableProperty BGColor3Property = BindableProperty.Create("BGColor3", typeof(string), typeof(OTPPage), "White");
        public string BGColor3
        {
            get { return (String)GetValue(BGColor3Property); }
            set { SetValue(BGColor3Property, value); }
        }

        public static readonly BindableProperty BGColor4Property = BindableProperty.Create("BGColor4", typeof(string), typeof(OTPPage), "White");
        public string BGColor4
        {
            get { return (String)GetValue(BGColor4Property); }
            set { SetValue(BGColor4Property, value); }
        }

        public static readonly BindableProperty BGColor5Property = BindableProperty.Create("BGColor5", typeof(string), typeof(OTPPage), "White");
        public string BGColor5
        {
            get { return (String)GetValue(BGColor5Property); }
            set { SetValue(BGColor5Property, value); }
        }

        public static readonly BindableProperty BGColor6Property = BindableProperty.Create("BGColor6", typeof(string), typeof(OTPPage), "White");
        public string BGColor6
        {
            get { return (String)GetValue(BGColor6Property); }
            set { SetValue(BGColor6Property, value); }
        }


       
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            numberPinAsync(1);
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            numberPinAsync(2);


        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            numberPinAsync(3);

        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            numberPinAsync(4);

        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            numberPinAsync(5);

        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            numberPinAsync(6);

        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            numberPinAsync(7);

        }

        private void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            numberPinAsync(8);

        }

        private void TapGestureRecognizer_Tapped_8(object sender, EventArgs e)
        {
            numberPinAsync(9);

        }

        private void TapGestureRecognizer_Tapped_9(object sender, EventArgs e)
        {
            numberPinAsync(0);

        }

        private void TapGestureRecognizer_Tapped_10(object sender, EventArgs e)
        {
            delectPin();
        }

        private void delectPin()
        {
            if (countClick < 0)
            {
                countClick = 0;
                return;
            }
            switch (countClick)
            {
                case 1:
                    BGColor1 = "White";
                    numPin = "";
                    break;
                case 2:
                    BGColor2 = "White";
                    numPin = numPin.Substring(0, 1);
                    break;
                case 3:
                    BGColor3 = "White";
                    numPin = numPin.Substring(0, 2);
                    break;
                case 4:
                    BGColor4 = "White";
                    numPin = numPin.Substring(0, 3);
                    break;
                case 5:
                    BGColor5 = "White";
                    numPin = numPin.Substring(0, 4);
                    break;
                case 6:
                    BGColor6 = "White";
                    numPin = numPin.Substring(0, 5);
                    break;
            }
            countClick -= 1;
        }

        //method
        private async void numberPinAsync(int v)
        {

            if (countClick < 6)
            {

                numPin += v.ToString();
                countClick += 1;
                switch (countClick)
                {
                    case 1: BGColor1 = "Black"; break;
                    case 2: BGColor2 = "Black"; break;
                    case 3: BGColor3 = "Black"; break;
                    case 4: BGColor4 = "Black"; break;
                    case 5: BGColor5 = "Black"; break;
                    case 6: BGColor6 = "Black"; break;
                }

                if(numPin==firstPin){


                    if (this.user == null)
                    {

                        Loading.Start(Loader, LoaderBackground);
                        bool Succeed = await Services.UpdatePin(App.User.ID, numPin);
                        LocalDB.Save(App.User.Username, App.User.Password);
                        if (!Succeed)
                        {
                            await DisplayAlert("SomethingWrong", "You can't change Pin", "OK");
                        }
                        Loading.Stop(Loader, LoaderBackground);

                        // App.User.Pin = numPin;
                        //await App.User.Update( Loader,LoaderBackground);
                        //LocalDB.InsertPhoneNO(this.user.MobileNumber);
                        //await Navigation.PushAsync(new PinChangeSuccessPage());
                        await Navigation.PushAsync(new EnableTouchIDPage());

                    }
                    else
                    {


                        // this.user.Pin = numPin;
                        //await this.user.Insert(Loader,LoaderBackground);
                        //App.User = this.user;
                        //LocalDB.InsertPhoneNO(this.user.MobileNumber);
                        // Application.Current.MainPage = new NavigationPage( new MainLoginPage() );
                        await DisplayAlert("Error", "plase enter", "OK");
                    }


                }
            }
            else
            {
                await DisplayAlert("Error", "Error", "OK");
            }

        }

        private void StartLoader()
        {
            Loader.IsVisible = true;
            Loader.IsRunning = true;
        }
        private void StopLoader()
        {
            Loader.IsVisible = false;
            Loader.IsRunning = false;
        }
    }
}
