using EnixerBanks;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EnixerBanks.AddAcountView
{
    public partial class OTPPage : ContentPage
    {
        public OTPPage()
        {
            InitializeComponent();

        }

        public OTPPage(string accountNO)
        {
            this.accountNO = accountNO;
        }

        public static int countClick = 0; //count click number pin
        public static string numPin; //number pin
        private string accountNO;
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


        protected override void OnAppearing()
        {
            InitializeComponent();
            base.OnAppearing();
            countClick = 0;
            numPin = "";
            this.BindingContext = this;
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
            if (countClick <= 0)
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



                if ("111111" == numPin && countClick == 6) //check OTP
                {
                    Loading.Start(Loader, LoaderBackground);
                    var Succeed = await Services.AddAccounts(accountNO, App.User.ID);
                    if( !Succeed )
                    {
                        await DisplayAlert("SomethingWrong", "Can't Add Accounts", "OK");
                        return;
                    }
                    Loading.Start(Loader, LoaderBackground);


                    await Navigation.PushAsync(new AddAcountView.AddSavingAccountSuccess());
                }
                else
                {

                }
            }
            else
            {
                await DisplayAlert("Error", "Error", "OK");
            }



        }
    }
}
