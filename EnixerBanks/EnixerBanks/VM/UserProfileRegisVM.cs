using EnixerBanks.ModelApp;
using EnixerBanks.RegisterCardView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EnixerBanks.VM
{
    class UserProfileRegisVM : BindableObject
    {
        AccountInfo AccountInfo;
        public ICommand Next_Btn { private set; get; }


        public static readonly BindableProperty FullnameBinding = BindableProperty.Create("Fullname", typeof(string), typeof(UserProfileRegisVM), "My CardNumber");
        public string Fullname
        {
            get { return (String)GetValue(FullnameBinding); }
            set { SetValue(FullnameBinding, value); }
        }

        public static readonly BindableProperty MobilNumberBinding = BindableProperty.Create("MobileNumber", typeof(string), typeof(UserProfileRegisVM), "My MobileNO");
        public string MobileNumber
        {
            get { return (String)GetValue(MobilNumberBinding); }
            set { SetValue(MobilNumberBinding, value); }
        }


        public static readonly BindableProperty EmailBinding = BindableProperty.Create("Email", typeof(string), typeof(UserProfileRegisVM), "My Email");
        public string Email
        {
            get { return (String)GetValue(EmailBinding); }
            set { SetValue(EmailBinding, value); }
        }



        public UserProfileRegisVM(AccountInfo account)
        {
            AccountInfo = account;
            Load();
            Next_Btn = new Command(execute: PushNavigate);
        }


        private void Load()
        {
            Fullname = AccountInfo.Prefix + " " + AccountInfo.FirstName + " " + AccountInfo.LastName;
            MobileNumber = AccountInfo.MobileNumber;
            Email = AccountInfo.Email;
        }

        private void PushNavigate(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new SetupUserDetailRegisPage(AccountInfo));
        }


    }
}
