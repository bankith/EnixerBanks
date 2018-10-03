using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using EnixerBanks.ModelApp;
using EnixerBanks.RegisterCardView;

namespace EnixerBanks.VM
{
    public class CarddetailRegisVM : BindableObject
    {

       public ICommand Next_Btn { private set; get; }
       private static AccountInfo UserInformation;

       private static AccountInfo DataFromService;

        private static string Account_NO;
        private static string Card_No;
        private static string ATM_PIN;
        private static DateTime Bdate;
        private static string Cid_Or_Passpost;
        private static int User_ID;
        private static string RefNO;


        #region
        public static readonly BindableProperty AccNoBindingProperty = BindableProperty.Create("AccNoBinding", typeof(string), typeof(CarddetailRegisVM), "", BindingMode.TwoWay, null, AccNoBindingPropertyChangedDelegate);
        public string AccNoBinding
        {
            get { return (String)GetValue(AccNoBindingProperty); }
            set { SetValue(AccNoBindingProperty, value); }
        }

        public static readonly BindableProperty CardNoBindingProperty = BindableProperty.Create("CardNoBinding", typeof(string), typeof(CarddetailRegisVM), "", BindingMode.TwoWay, null, CardNoBindingPropertyChangedDelegate);
        public string CardNoBinding
        {
            get { return (String)GetValue(CardNoBindingProperty); }
            set { SetValue(CardNoBindingProperty, value); }
        }

        public static readonly BindableProperty AtmPinBindingProperty = BindableProperty.Create("AtmPinBinding", typeof(string), typeof(CarddetailRegisVM), "", BindingMode.TwoWay, null, AtmPinBindingPropertyChangedDelegate);
        public string AtmPinBinding
        {
            get { return (String)GetValue(AtmPinBindingProperty); }
            set { SetValue(AtmPinBindingProperty, value); }
        }

        public static readonly BindableProperty BdateBindingProperty = BindableProperty.Create("BdateBinding", typeof(DateTime), typeof(CarddetailRegisVM), DateTime.Now, BindingMode.TwoWay, null, BdateBindingPropertyChangedDelegate);
        public DateTime BdateBinding
        {
            get { return (DateTime)GetValue(BdateBindingProperty); }
            set { SetValue(BdateBindingProperty, value); }
        }

        public static readonly BindableProperty CID_PassNoBindingProperty = BindableProperty.Create("CID_PassNoBinding", typeof(string), typeof(CarddetailRegisVM), "", BindingMode.TwoWay, null, CID_PassNoBindingPropertyChangedDelegate);
        public string CID_PassNoBinding
        {
            get { return (String)GetValue(CID_PassNoBindingProperty); }
            set { SetValue(CID_PassNoBindingProperty, value); }
        }


        public static readonly BindableProperty NextBtnColorBindingProperty = BindableProperty.Create("NextBtnColorBinding", typeof(string), typeof(CarddetailRegisVM), "Gray");
        public string NextBtnColorBinding
        {
            get { return (string)GetValue(NextBtnColorBindingProperty); }
            set { SetValue(NextBtnColorBindingProperty, value); }
        }

        public static readonly BindableProperty CanClickBindingProperty = BindableProperty.Create("CanClickBinding", typeof(bool), typeof(CarddetailRegisVM), false);
        public bool CanClickBinding
        {
            get { return (bool)GetValue(CanClickBindingProperty); }
            set { SetValue(CanClickBindingProperty, value); }
        }

        public static readonly BindableProperty IsCardNOCheckBindingProperty = BindableProperty.Create("IsCardNOCheck", typeof(bool), typeof(CarddetailRegisVM), false);
        public bool IsCardNOCheck
        {
            get { return (bool)GetValue(IsCardNOCheckBindingProperty); }
            set { SetValue(IsCardNOCheckBindingProperty, value); }
        }

        public static readonly BindableProperty IsATMPinCheckBindingProperty = BindableProperty.Create("IsATMPinCheck", typeof(bool), typeof(CarddetailRegisVM), false);
        public bool IsATMPinCheck
        {
            get { return (bool)GetValue(IsATMPinCheckBindingProperty); }
            set { SetValue(IsATMPinCheckBindingProperty, value); }
        }

        public static readonly BindableProperty IsBdateCheckBindingProperty = BindableProperty.Create("IsBdateCheck", typeof(bool), typeof(CarddetailRegisVM), false);
        public bool IsBdateCheck
        {
            get { return (bool)GetValue(IsBdateCheckBindingProperty); }
            set { SetValue(IsBdateCheckBindingProperty, value); }
        }

        public static readonly BindableProperty IsCIDPassCheckBindingProperty = BindableProperty.Create("IsCIDPassCheck", typeof(bool), typeof(CarddetailRegisVM), false);
        public bool IsCIDPassCheck
        {
            get { return (bool)GetValue(IsCIDPassCheckBindingProperty); }
            set { SetValue(IsCIDPassCheckBindingProperty, value); }
        }

        public static readonly BindableProperty IsAccNOCheckBindingProperty = BindableProperty.Create("IsAccNOCheck", typeof(bool), typeof(CarddetailRegisVM), false);
        public bool IsAccNOCheck
        {
            get { return (bool)GetValue(IsAccNOCheckBindingProperty); }
            set { SetValue(IsAccNOCheckBindingProperty, value); }
        }

        #endregion

        public CarddetailRegisVM()
        {

            Next_Btn = new Command(execute: PushNavigate);

        }



        static async void AccNoBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {

            String AccountNO = (string)newValue;
            var vm = (CarddetailRegisVM)bindable;
            vm.IsAccNOCheck = AccountNO.Length == 10 ? true : false;

            if(vm.IsAccNOCheck == true)
            {
                // Call service
                AccountInfo data = await Services.GetAccountInfoByAccountNumber(AccountNO);

                if(data == null)
                {
                   await App.Current.MainPage.DisplayAlert("Error","Account Not Found","OK");
                }
                else if(data != null)
                {
                    DataFromService = data; // Keep value
                    
                }
            }
            Oparation(vm);
        }

        static void CardNoBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {

            String cardNo = (string)newValue;
            var vm = (CarddetailRegisVM)bindable;
            vm.IsCardNOCheck = cardNo.Length == 16 ? true : false;
            if(vm.IsCardNOCheck == true)
            {
                Card_No = cardNo;
            }
            Oparation(vm);
        }

        private static void AtmPinBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            String atmPin = (string)newValue;
            var vm = (CarddetailRegisVM)bindable;
            vm.IsATMPinCheck = atmPin.Length == 6 ? true : false;
            if(vm.IsATMPinCheck == true)
            {
                ATM_PIN = atmPin;
                Oparation(vm);

            }
        }


        private static void BdateBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            DateTime bdate = (DateTime)newValue;
            var vm = (CarddetailRegisVM)bindable;
            vm.IsBdateCheck = bdate.Date == DateTime.Now ? false : true;

            if(vm.IsBdateCheck == true)
            {
                Bdate = bdate;
                Oparation(vm);

            }
        }

        private  static void CID_PassNoBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            bool Result = false;
            String Value = (string)newValue;
            var vm = (CarddetailRegisVM)bindable;
            // vm.IsCIDPassCheck = CiD_Pass_Check();

            if (Value.Length < 13)
            {
                Result = false;
          
            }
            else if (Value.Length == 10)
            {

                Cid_Or_Passpost = Value;
                Result = true;
                vm.IsCIDPassCheck = Result;
                Oparation(vm);

            }
            else if (Value.Length == 13)
            {

                Cid_Or_Passpost = Value;
                Result = true;
                vm.IsCIDPassCheck = Result;
                Oparation(vm);
            }
        }


        private async static void Oparation(CarddetailRegisVM value)
        {
            if (value.IsAccNOCheck == true && value.IsATMPinCheck == true && value.IsBdateCheck == true && value.IsCardNOCheck == true && value.IsCIDPassCheck == true)
            {
                var Userdata = await Services.GetAccountInfoByCardNumber(Cid_Or_Passpost, Bdate, Account_NO, Card_No, ATM_PIN);
                AccountInfo Userinfo = new AccountInfo()
                {
                    ID = User_ID,
                    Prefix = DataFromService.Prefix,
                    ReferenceNO = DataFromService.ReferenceNO,
                    FirstName = DataFromService.FirstName,
                    LastName = DataFromService.LastName,
                    BirthDate = Bdate,
                    AccountType = DataFromService.AccountType,
                    AccountNumber = Account_NO,
                    CardType = DataFromService.CardType,
                    CardNumber = Card_No,
                    ATMPin = ATM_PIN,
                    CitizenID = Cid_Or_Passpost,
                    ProfilePic = DataFromService.ProfilePic,
                    MobileNumber = DataFromService.MobileNumber,
                    Email = DataFromService.Email,
                    
                };
                UserInformation = Userinfo;
                value.CanClickBinding = true;
                value.NextBtnColorBinding = "#347555";
            }
            else
            {
                value.CanClickBinding = false;
                value.NextBtnColorBinding = "Silver";
            }
        }

        private void PushNavigate()
        {
            App.Current.MainPage.Navigation.PushAsync(new UserProfileRegisPage(UserInformation));
             
        }
    }
}
