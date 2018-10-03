using EnixerBank.Models;
using EnixerBanks.RegisterCardView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EnixerBanks.VM
{
    class PinSetupPageRegisEnVM:BindableObject
    {
        GreenBank_UserProfile user;
        UserProfile UserProfile;
        String FirstTimePin;
        string firstTimePin;
        ContentPage NextPage;

        public ICommand PinCickComamd { private set; get; }
        public ICommand DeleteComand { private set; get; }


        public int countClick = 0; //count click number pin
        public string numPin; //number pin

        #region
        public static readonly BindableProperty BGColor1Property = BindableProperty.Create("BGColor1", typeof(string), typeof(PinSetupPageRegisEnVM), "White");
        public string BGColor1
        {
            get { return (String)GetValue(BGColor1Property); }
            set { SetValue(BGColor1Property, value); }
        }

        public static readonly BindableProperty BGColor2Property = BindableProperty.Create("BGColor2", typeof(string), typeof(PinSetupPageRegisEnVM), "White");
        public string BGColor2
        {
            get { return (String)GetValue(BGColor2Property); }
            set { SetValue(BGColor2Property, value); }
        }

        public static readonly BindableProperty BGColor3Property = BindableProperty.Create("BGColor3", typeof(string), typeof(PinSetupPageRegisEnVM), "White");
        public string BGColor3
        {
            get { return (String)GetValue(BGColor3Property); }
            set { SetValue(BGColor3Property, value); }
        }

        public static readonly BindableProperty BGColor4Property = BindableProperty.Create("BGColor4", typeof(string), typeof(PinSetupPageRegisEnVM), "White");
        public string BGColor4
        {
            get { return (String)GetValue(BGColor4Property); }
            set { SetValue(BGColor4Property, value); }
        }

        public static readonly BindableProperty BGColor5Property = BindableProperty.Create("BGColor5", typeof(string), typeof(PinSetupPageRegisEnVM), "White");
        public string BGColor5
        {
            get { return (String)GetValue(BGColor5Property); }
            set { SetValue(BGColor5Property, value); }
        }

        public static readonly BindableProperty BGColor6Property = BindableProperty.Create("BGColor6", typeof(string), typeof(PinSetupPageRegisEnVM), "White");
        public string BGColor6
        {
            get { return (String)GetValue(BGColor6Property); }
            set { SetValue(BGColor6Property, value); }
        }


        public PinSetupPageRegisEnVM(UserProfile user)
        {
            UserProfile = user;
            PinCickComamd = new Command<string>(execute: NumPinClink);
            DeleteComand = new Command(execute: delectPin);

           // GetOTPFromService();
        }

        public PinSetupPageRegisEnVM(String Firstpin, UserProfile user)
        {
            UserProfile = user;
            FirstTimePin = Firstpin;
            PinCickComamd = new Command<string>(execute: NumPinClink);
            DeleteComand = new Command(execute: delectPin);
        }

        //private async System.Threading.Tasks.Task GetOTPFromService()
        //{
        //    // Loading.Start(Loader, LoaderBackground);
        //    //var OTP = await Services.SendOTP(App.User.ID, App.User.MobileNo);
        //    var OTP = await Services.SendOTP(3, "0830170707");
        //    await App.Current.PinSetupPageRegisEnVM.DisplayAlert("OTP", OTP, "OK");
        //    // Loading.Stop(Loader, LoaderBackground);
        //}
        #endregion


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
        private async void NumPinClink(string v)
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


                if (countClick == 6) //check OTP
                {
                    firstTimePin = numPin;

                    if (FirstTimePin == null)  // SetUP first time
                    {
                        await App.Current.MainPage.Navigation.PushAsync(new ConfirnPinSetupPageRegisEn(firstTimePin, UserProfile));
                    }
                    else if(FirstTimePin != null) //ConfirmPin
                    {
                        if(numPin == FirstTimePin)
                        {
                            //Call Sevice Save Pin
                            UserProfile.PIN = FirstTimePin;
                            Console.WriteLine("User Pin " + UserProfile.PIN.ToString());
                            var resualt = await Services.SavePin(UserProfile.ID, UserProfile.PIN);
                            await App.Current.MainPage.Navigation.PushAsync(new EnableThudIDRegisEnPage());
                        }
                        else
                        {
                            Reset();
                            return;
                        }
                    }

                   
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Error", "OK");
            }
        }
        private async void Reset()
        {
            //Vibration.Vibrate();
            await App.Current.MainPage.DisplayAlert("Wrong Pin", "Enter again", "OK");
            countClick = 0;
            numPin = "";
            BGColor1 = "White";
            BGColor2 = "White";
            BGColor3 = "White";
            BGColor4 = "White";
            BGColor5 = "White";
            BGColor6 = "White";
        }
    }
}
