using System;
using System.Collections.Generic;
using EnixerBanks.ModelApp;
using Xamarin.Forms;

namespace EnixerBanks.TransferView
{
    public partial class TransferAmountPage : ContentPage
    {
        public TransferAmountPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        
        public TransferAmountPage(FullUserInformation user, AccountInfo toAccountIno, BankInfo SelectedTransferToBank):this()
        {
            this.userInfo = user;
            this.toAccountInfo = toAccountIno;
            this.SelectedTransferToBank = SelectedTransferToBank;
        }

        int total;
        public int countClick = 0; //count click number pin
        public string numPin; //number pin
        public static string Balances; //number pin
        public string ToMobileNumber;
        private FullUserInformation userInfo;
        private AccountInfo toAccountInfo;
        private BankInfo SelectedTransferToBank;
        public static readonly BindableProperty BGColor1Property = BindableProperty.Create("BGColor1", typeof(string), typeof(TransferAmountPage), "");
        public string BGColor1
        {
            get { return (String)GetValue(BGColor1Property); }
            set { SetValue(BGColor1Property, value); }
        }

        public static readonly BindableProperty BGColor2Property = BindableProperty.Create("BGColor2", typeof(string), typeof(TransferAmountPage), "");
        public string BGColor2
        {
            get { return (String)GetValue(BGColor2Property); }
            set { SetValue(BGColor2Property, value); }
        }

        public static readonly BindableProperty BGColor3Property = BindableProperty.Create("BGColor3", typeof(string), typeof(TransferAmountPage), "");
        public string BGColor3
        {
            get { return (String)GetValue(BGColor3Property); }
            set { SetValue(BGColor3Property, value); }
        }

        public static readonly BindableProperty BGColor4Property = BindableProperty.Create("BGColor4", typeof(string), typeof(TransferAmountPage), "");
        public string BGColor4
        {
            get { return (String)GetValue(BGColor4Property); }
            set { SetValue(BGColor4Property, value); }
        }

        public static readonly BindableProperty BGColor5Property = BindableProperty.Create("BGColor5", typeof(string), typeof(TransferAmountPage), "");
        public string BGColor5
        {
            get { return (String)GetValue(BGColor5Property); }
            set { SetValue(BGColor5Property, value); }
        }

        public static readonly BindableProperty BGColor6Property = BindableProperty.Create("BGColor6", typeof(string), typeof(TransferAmountPage), "");
        public string BGColor6
        {
            get { return (String)GetValue(BGColor6Property); }
            set { SetValue(BGColor6Property, value); }
        }
        public static readonly BindableProperty BGColor7Property = BindableProperty.Create("BGColor7", typeof(string), typeof(TransferAmountPage), "");
        public string BGColor7
        {
            get { return (String)GetValue(BGColor7Property); }
            set { SetValue(BGColor7Property, value); }
        }
        public static readonly BindableProperty BGColor8Property = BindableProperty.Create("BGColor8", typeof(string), typeof(TransferAmountPage), "");
        public string BGColor8
        {
            get { return (String)GetValue(BGColor8Property); }
            set { SetValue(BGColor8Property, value); }
        }


        protected override void OnAppearing()
        {
            InitializeComponent();
            base.OnAppearing();

            this.BindingContext = this;


            ToBankLogo.Source = ImageSource.FromFile(SelectedTransferToBank.Img);

            namefrom.Text = userInfo.Firstname + " " + userInfo.LastName;
            numberfrom.Text = userInfo.AccountNumber;

            nameto.Text = toAccountInfo.FirstName + " " + toAccountInfo.LastName;
            numberto.Text = toAccountInfo.AccountNumber;

            MoneyLable.Text = userInfo.AvailableBalance +" "+ userInfo.Currency +"  Avaliable";



        }

        private void numberPin(int v)
        {

            if (countClick < 9)
            {

                numPin += v.ToString();
                countClick += 1;
                switch (countClick)
                {
                    case 1: BGColor1 = v.ToString(); break;
                    case 2: BGColor2 = v.ToString(); break;
                    case 3: BGColor3 = v.ToString(); break;
                    case 4: BGColor4 = v.ToString(); break;
                    case 5: BGColor5 = v.ToString(); break;
                    case 6: BGColor6 = v.ToString(); break;
                    case 7: BGColor7 = v.ToString(); break;
                    case 8: BGColor8 = v.ToString(); break;
                }

            }
            else
            {
                //await DisplayAlert("Error", "Error", "OK");
            }
        }

        private void Num1_Tapped(object sender, EventArgs e)
        {
            numberPin(1);
        }

        private void Num2_Tapped(object sender, EventArgs e)
        {
            numberPin(2);
        }

        private void Num3_Tapped(object sender, EventArgs e)
        {
            numberPin(3);

        }

        private void Num4_Tapped(object sender, EventArgs e)
        {
            numberPin(4);

        }

        private void Num5_Tapped(object sender, EventArgs e)
        {
            numberPin(5);

        }

        private void Num6_Tapped(object sender, EventArgs e)
        {
            numberPin(6);

        }

        private void Num7_Tapped(object sender, EventArgs e)
        {
            numberPin(7);

        }

        private void Num8_Tapped(object sender, EventArgs e)
        {
            numberPin(8);

        }

        private void Num9_Tapped(object sender, EventArgs e)
        {
            numberPin(9);

        }

        private void Numdot_Tapped(object sender, EventArgs e)
        {


        }

        private void Num0_Tapped(object sender, EventArgs e)
        {
            numberPin(0);

        }

        private void BackNum_Tapped(object sender, EventArgs e)
        {
            deletePin();
        }

        private void deletePin()
        {
            if (countClick <= 0)
            {
                countClick = 0;
                return;
            }
            switch (countClick)
            {
                case 1:
                    BGColor1 = "";
                    numPin = "";
                    break;
                case 2:
                    BGColor2 = "";
                    numPin = numPin.Substring(0, 1);
                    break;
                case 3:
                    BGColor3 = "";
                    numPin = numPin.Substring(0, 2);
                    break;
                case 4:
                    BGColor4 = "";
                    numPin = numPin.Substring(0, 3);
                    break;
                case 5:
                    BGColor5 = "";
                    numPin = numPin.Substring(0, 4);
                    break;
                case 6:
                    BGColor6 = "";
                    numPin = numPin.Substring(0, 5);
                    break;
                case 7:
                    BGColor7 = "";
                    numPin = numPin.Substring(0, 6);
                    break;
                case 8:
                    BGColor8 = "";
                    numPin = numPin.Substring(0, 7);
                    break;
            }
            countClick -= 1;
        }

        private async void NEXT_Clicked(object sender, EventArgs e)
        {
            // await App.Current.MainPage.Navigation.PushAsync(new PaybillConfirmAmountPage());
            var Amount = this.numPin;
            // await  DisplayAlert("test","Avalible total is "+total,"OK");
           

            if (numPin == "")
            {
                await DisplayAlert("Something wrong!!!", "Enter you money to Pay", "OK");
                return;
            }
            else
            {
                int INTnumPin = Convert.ToInt32(numPin);
                if (INTnumPin > userInfo.AvailableBalance)
                {
                    await DisplayAlert("Something wrong!!!", "Money Avaliable not enong", "OK");
                    return;
                }
                else if (INTnumPin == 0)
                {
                    await DisplayAlert("Something wrong!!!", "Enter Money more 0", "OK");
                    return;
                }

                await Navigation.PushAsync(new TransferView.Transfer2ndPage(Amount, this.userInfo, this.toAccountInfo, this.SelectedTransferToBank));
            }
        }

        private void backBT_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
