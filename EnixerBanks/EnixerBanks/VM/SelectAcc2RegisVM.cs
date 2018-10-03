using EnixerBanks.ModelApp;
using EnixerBanks.RegisterCardView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EnixerBanks.VM
{
    class SelectAcc2RegisVM : BindableObject
    {
        AccountInfo AccountInfo;
        UserProfile UserProfile;
        public ICommand Next_Btn { private set; get; }

        public static readonly BindableProperty AccountTypeBinding = BindableProperty.Create("AccountTyp", typeof(string), typeof(SelectAcc2RegisVM), "My Account");
        public string AccountTyp
        {
            get { return (String)GetValue(AccountTypeBinding); }
            set { SetValue(AccountTypeBinding, value); }
        }

        public static readonly BindableProperty AccountNumBinding = BindableProperty.Create("AccNumber", typeof(string), typeof(SelectAcc2RegisVM), "My AccountNumber");
        public string AccNumber
        {
            get { return (String)GetValue(AccountNumBinding); }
            set { SetValue(AccountNumBinding, value); }
        }

        public static readonly BindableProperty CardTypeBinding = BindableProperty.Create("CardTyp", typeof(string), typeof(SelectAcc2RegisVM), "My Card");
        public string CardTyp
        {
            get { return (String)GetValue(CardTypeBinding); }
            set { SetValue(CardTypeBinding, value); }
        }

        public static readonly BindableProperty CardNumBinding = BindableProperty.Create("CardNumber", typeof(string), typeof(SelectAcc2RegisVM), "My CardNumber");
        public string CardNumber
        {
            get { return (String)GetValue(CardNumBinding); }
            set { SetValue(CardNumBinding, value); }
        }


        public SelectAcc2RegisVM(AccountInfo account, UserProfile user)
        {
            AccountInfo = account;
            UserProfile = user;
            Loaddata();
            Next_Btn = new Command(execute: PushNavigate);
        }


        private void Loaddata()
        {
            this.AccountTyp = AccountInfo.AccountType;
            var ss = AccountInfo.AccountType;
            this.AccNumber = AccountInfo.AccountNumber;
            this.CardTyp = AccountInfo.CardType;
            var ww = AccountInfo.CardType;
            this.CardNumber = AccountInfo.CardNumber;

            Console.WriteLine(AccountInfo.CardNumber);

        }

        private async void PushNavigate()
        {
            // To Call service and Register
            UserProfile user = new UserProfile()
            {
                ID = AccountInfo.ID,
                Prefix = AccountInfo.Prefix,
                ProfilePic = AccountInfo.ProfilePic,
                Firstname = AccountInfo.FirstName,
                Lastname = AccountInfo.FirstName,
                MobileNo = AccountInfo.MobileNumber,
                UserEmail = AccountInfo.Email,
                CitizenID = AccountInfo.CitizenID,
                Birthdate = (DateTime)AccountInfo.BirthDate,
                ReferenceNO = AccountInfo.ReferenceNO,
                Password = UserProfile.Password,
                Username = UserProfile.Username
            };

            var result = await Services.RegisterNonConfirmUser(AccountInfo.ID, AccountInfo.ReferenceNO);
            var result2 = await Services.RegisterOnlineAccount(user);
            Console.WriteLine(AccountInfo.ReferenceNO);
            Console.WriteLine(result.ToString());
            App.User = user;

            await App.Current.MainPage.Navigation.PushAsync(new RegisSuccPage(user));
        }




    }
}
