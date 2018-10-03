using EnixerBanks.ModelApp;
using EnixerBanks.RegisterCardView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EnixerBanks.VM
{
    class SelectLoneAccRegisVM : BindableObject
    {
        AccountInfo AccountInfo;
        UserProfile UserProfile; 
        public ICommand Next_Btn { private set; get; }

        public static readonly BindableProperty AccountTypeBinding = BindableProperty.Create("AccountTyp", typeof(string), typeof(SelectLoneAccRegisVM), "My Account");
        public string AccountTyp
        {
            get { return (String)GetValue(AccountTypeBinding); }
            set { SetValue(AccountTypeBinding, value); }
        }

        public static readonly BindableProperty AccountNumBinding = BindableProperty.Create("AccNumber", typeof(string), typeof(SelectLoneAccRegisVM), "My AccountNumber");
        public string AccNumber
        {
            get { return (String)GetValue(AccountNumBinding); }
            set { SetValue(AccountNumBinding, value); }
        }


        public SelectLoneAccRegisVM(AccountInfo account, UserProfile user)
        {
            AccountInfo = account;
            UserProfile = user;
            LoadCardData();
            Next_Btn = new Command(execute: PushNavigate);
        }

        private void LoadCardData()
        {

            AccountTyp = AccountInfo.CardType;
            AccNumber = AccountInfo.AccountNumber;
        }

        private void PushNavigate(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new SelectAcc2RegisPage(AccountInfo, UserProfile));
        }


    }
}
