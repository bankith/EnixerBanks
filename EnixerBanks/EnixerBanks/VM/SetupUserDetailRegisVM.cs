using EnixerBanks.ModelApp;
using EnixerBanks.RegisterCardView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EnixerBanks.VM
{
    class SetupUserDetailRegisVM : BindableObject
    {
        AccountInfo AccountInfo;
        private static UserProfile UserProfile;
        private static string USERNAME;
        private static string PASSWORD;
        private static string CONPASSWORD;
        public ICommand Next_Btn { private set; get; }

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

        public static readonly BindableProperty UsernameBindingProperty = BindableProperty.Create("UsernameBinding", typeof(string), typeof(SetupUserDetailRegisVM), "", BindingMode.TwoWay, null, UsernameBindingPropertyChangedDelegate);
        public string UsernameBinding
        {
            get { return (String)GetValue(UsernameBindingProperty); }
            set { SetValue(UsernameBindingProperty, value); }
        }

        public static readonly BindableProperty PasswordBindingProperty = BindableProperty.Create("PasswordBinding", typeof(string), typeof(SetupUserDetailRegisVM), "", BindingMode.TwoWay, null, PasswordBindingPropertyChangedDelegate);
        public string PasswordBinding
        {
            get { return (String)GetValue(PasswordBindingProperty); }
            set { SetValue(PasswordBindingProperty, value); }
        }

        public static readonly BindableProperty ConPasswordBindingProperty = BindableProperty.Create("ConPasswordBinding", typeof(string), typeof(SetupUserDetailRegisVM), "", BindingMode.TwoWay, null, ConPasswordPasswordBindingPropertyChangedDelegate);
        public string ConPasswordBinding
        {
            get { return (String)GetValue(ConPasswordBindingProperty); }
            set { SetValue(ConPasswordBindingProperty, value); }
        }

        public static readonly BindableProperty IsUsernameValidateBindingProperty = BindableProperty.Create("IsUsernameValidate", typeof(bool), typeof(SetupUserDetailRegisVM), false);
        public bool IsUsernameValidate
        {
            get { return (bool)GetValue(IsUsernameValidateBindingProperty); }
            set { SetValue(IsUsernameValidateBindingProperty, value); }
        }



        public SetupUserDetailRegisVM(AccountInfo account)
        {
            AccountInfo = account;
            Next_Btn = new Command(execute: PushNavigate);
        }



        static async void UsernameBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {

            String Usename = (string)newValue;
            var result = await Services.UserNameValidate(Usename); // Validate Username
            var vm = (SetupUserDetailRegisVM)bindable;

            if (result == true)
            {
                USERNAME = Usename;
                vm.IsUsernameValidate = true;
                Oparation(vm);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "This Username can Not be use", "OK");
            }
        }


        static void PasswordBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {

            String Password = (string)newValue;
            var vm = (SetupUserDetailRegisVM)bindable;
            PASSWORD = Password;
            Oparation(vm);

        }

        static void ConPasswordPasswordBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {

            String ConPassword = (string)newValue;
            var vm = (SetupUserDetailRegisVM)bindable;
            CONPASSWORD = ConPassword;
            Oparation(vm);

        }

        private static void Oparation(SetupUserDetailRegisVM VM)
        {
            bool isnullPass = string.IsNullOrEmpty(PASSWORD);
            bool isnullConPass = string.IsNullOrEmpty(CONPASSWORD);

            if (VM.IsUsernameValidate == true)
            {
                if (isnullPass == false && isnullConPass == false)
                {
                    if (PASSWORD == CONPASSWORD)
                    {

                        UserProfile = new UserProfile()
                        {
                            Username = USERNAME,
                            Password = PASSWORD
                        };

                        VM.CanClickBinding = true;
                        VM.NextBtnColorBinding = "#347555";
                    }

                }
            }
            else
            {
                VM.CanClickBinding = false;
                VM.NextBtnColorBinding = "Silver";
            }
        }

        private void PushNavigate(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new SelectLoneAccRegisPage(AccountInfo, UserProfile));
        }


    }
}
