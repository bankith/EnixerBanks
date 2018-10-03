using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using EnixerBanks;
using Xamarin.Essentials;

namespace EnixerBanks.VM
{
    class OTPVM : BindableObject
    {
        public delegate void Del();

        public Del OnOTPCorrected;


        public ContentPage CurrentPage;

        public ICommand PinCickComamd { private set; get; }
        public ICommand DeleteComand { private set; get; }


        private Label LoadBackground;
        private ActivityIndicator LoadSpinner;
        public int countClick; //count click number pin
        public string numPin; //number pin

        #region Bindable
        public static readonly BindableProperty BGColor1Property = BindableProperty.Create("BGColor1", typeof(string), typeof(OTPVM), "White");
        public string BGColor1
        {
            get { return (String)GetValue(BGColor1Property); }
            set { SetValue(BGColor1Property, value); }
        }

        public static readonly BindableProperty BGColor2Property = BindableProperty.Create("BGColor2", typeof(string), typeof(OTPVM), "White");
        public string BGColor2
        {
            get { return (String)GetValue(BGColor2Property); }
            set { SetValue(BGColor2Property, value); }
        }

        public static readonly BindableProperty BGColor3Property = BindableProperty.Create("BGColor3", typeof(string), typeof(OTPVM), "White");
        public string BGColor3
        {
            get { return (String)GetValue(BGColor3Property); }
            set { SetValue(BGColor3Property, value); }
        }

        public static readonly BindableProperty BGColor4Property = BindableProperty.Create("BGColor4", typeof(string), typeof(OTPVM), "White");
        public string BGColor4
        {
            get { return (String)GetValue(BGColor4Property); }
            set { SetValue(BGColor4Property, value); }
        }

        public static readonly BindableProperty BGColor5Property = BindableProperty.Create("BGColor5", typeof(string), typeof(OTPVM), "White");
        public string BGColor5
        {
            get { return (String)GetValue(BGColor5Property); }
            set { SetValue(BGColor5Property, value); }
        }

        public static readonly BindableProperty BGColor6Property = BindableProperty.Create("BGColor6", typeof(string), typeof(OTPVM), "White");
        public string BGColor6
        {
            get { return (String)GetValue(BGColor6Property); }
            set { SetValue(BGColor6Property, value); }
        }

        public OTPVM(ContentPage CurrentPage)
        {

            PinCickComamd = new Command<string>(execute: NumPinClink);
            DeleteComand = new Command(execute: delectPin);

            this.CurrentPage = CurrentPage;

            Reset();

            bool SetupCompleted = SetupLoader();
            if (!SetupCompleted)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Not An AbsoluteLayout In this Content Page", "OK");
                return;
            }

            StartLoader();
            GetOTPFromService();
            StopLoader();

        }

        private async void GetOTPFromService()
        {

            var OTP = await Services.SendOTP(App.User.ID, App.User.MobileNo);
            await Application.Current.MainPage.DisplayAlert("OTP", OTP, "OK");

        }

        private bool SetupLoader()
        {
            if (!(CurrentPage.Content is AbsoluteLayout))
            {
                return false;
            }

            var layout = (AbsoluteLayout)CurrentPage.Content;

            LoadBackground = new Label()
            {
                IsVisible = false,
                BackgroundColor = new Color(0, 0, 0, 0.3)
            };

            LoadSpinner = new ActivityIndicator()
            {
                Color = Color.Yellow,
                IsRunning = false,
                IsVisible = false
            };

            layout.Children.Add(LoadBackground, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            layout.Children.Add(LoadSpinner, new Rectangle(0.5, 0.5, 50, 50), AbsoluteLayoutFlags.PositionProportional);


            return true;
        }

        public void StartLoader()
        {
            LoadSpinner.IsVisible = true;
            LoadSpinner.IsRunning = true;
            LoadBackground.IsVisible = true;
        }

        public void StopLoader()
        {
            LoadSpinner.IsVisible = false;
            LoadSpinner.IsRunning = false;
            LoadBackground.IsVisible = false;
        }

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
                    StartLoader();
                    bool isOTPcorrect = await Services.CheckOTP(App.User.ID, numPin);
                    StopLoader();

                    if (isOTPcorrect)
                    {
                        OnOTPCorrected?.Invoke();
                    }
                    else if (isOTPcorrect == false)
                    {
                        Vibration.Vibrate();
                        await Application.Current.MainPage.DisplayAlert("Wrong Pin", "Enter again", "OK");
                        Reset();
                        return;
                    }
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error", "OK");
            }
        }
        private void Reset()
        {
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
