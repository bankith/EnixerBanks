using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace EnixerBanks.VM
{
    public class AccountTypeVM:BindableObject
    {

        public ContentPage addAccountTypePage;

        public ICommand TypeClickCommand { private set; get; }

        #region Binding
        public static readonly BindableProperty isAccountInfoVisibleProperty = BindableProperty.Create("isAccountInfoVisible", typeof(bool), typeof(AccountType), false);
        public static readonly BindableProperty accountNOCheckImgVisibilityProperty = BindableProperty.Create("accountNOCheckImgVisibility", typeof(bool), typeof(AccountType), false);
        public static readonly BindableProperty serialNOCheckImgVisibilityProperty = BindableProperty.Create("serialNOCheckImgVisibility", typeof(bool), typeof(AccountType), false);
        public static readonly BindableProperty isNextEnableProperty = BindableProperty.Create("isNextEnable", typeof(bool), typeof(AccountType), false);
        public static readonly BindableProperty resultVisibilityProperty = BindableProperty.Create("resultVisibility", typeof(bool), typeof(AccountType), false);

        public static readonly BindableProperty accountTypeSelectedTextProperty = BindableProperty.Create("accountTypeSelectedText", typeof(string), typeof(AccountType), "Select Account Type");
        public static readonly BindableProperty accountNOProperty = BindableProperty.Create("accountNO", typeof(string), typeof(AccountType), "",BindingMode.TwoWay,null, accountNOPropertyChangedDelegate);
        public static readonly BindableProperty serialNOProperty = BindableProperty.Create("serialNO", typeof(string), typeof(AccountType), "", BindingMode.TwoWay, null, serialNOPropertyChangedDelegate);

        public static readonly BindableProperty NextEnableBackgroundcolorProperty = BindableProperty.Create("NextEnableBackgroundcolor", typeof(string), typeof(AccountType), "Silver");
        public static readonly BindableProperty NextTextProperty = BindableProperty.Create("NextText", typeof(string), typeof(AccountType), "NEXT");

        public static readonly BindableProperty resultAccountNumberProperty = BindableProperty.Create("resultAccountNumber", typeof(string), typeof(AccountType), "");
        public static readonly BindableProperty resultAccountNameProperty = BindableProperty.Create("resultAccountName", typeof(string), typeof(AccountType), "");










        public string accountTypeSelectedText
        {
            get { return (string)GetValue(accountTypeSelectedTextProperty); }
            set { SetValue(accountTypeSelectedTextProperty, value); }
        }
        public bool isAccountInfoVisible
        {
            get{ return (bool)GetValue(isAccountInfoVisibleProperty); }
            set{ SetValue(isAccountInfoVisibleProperty, value); }
        }
        public bool accountNOCheckImgVisibility
        {
            get { return (bool)GetValue(accountNOCheckImgVisibilityProperty); }
            set { SetValue(accountNOCheckImgVisibilityProperty, value); }
        }
        public bool serialNOCheckImgVisibility
        {
            get { return (bool)GetValue(serialNOCheckImgVisibilityProperty); }
            set { SetValue(serialNOCheckImgVisibilityProperty, value); }
        }
        public bool isNextEnable
        {
            get { return (bool)GetValue(isNextEnableProperty); }
            set { SetValue(isNextEnableProperty, value); }
        }
        public bool resultVisibility
        {
            get { return (bool)GetValue(resultVisibilityProperty); }
            set { SetValue(resultVisibilityProperty, value); }
        }



        public string accountNO
        {
            get { return (string)GetValue(accountNOProperty); }
            set { 
                if( value.Length > 10) SetValue(accountNOProperty, value.Substring(0,10));

                SetValue(accountNOProperty, value); }
        }
        public string serialNO
        {
            get { return (string)GetValue(serialNOProperty); }
            set { SetValue(serialNOProperty, value); }
        }
        public string resultAccountNumber
        {
            get { return (string)GetValue(resultAccountNumberProperty); }
            set { SetValue(resultAccountNumberProperty, value); }
        }
        public string resultAccountName
        {
            get { return (string)GetValue(resultAccountNameProperty); }
            set { SetValue(resultAccountNameProperty, value); }
        }

        public string NextEnableBackgroundcolor
        {
            get { return (string)GetValue(NextEnableBackgroundcolorProperty); }
            set { SetValue(NextEnableBackgroundcolorProperty, value); }
        }
        public string NextText
        {
            get { return (string)GetValue(NextTextProperty); }
            set { SetValue(NextTextProperty, value); }
        }



        public AccountTypeVM()
        {
            TypeClickCommand = new Command<string>(execute: AccountType_Clicked);
        }

        public AccountTypeVM(ContentPage addAccountTypePage) :this()
        {
            this.addAccountTypePage = addAccountTypePage;
        }

        #endregion

        static void accountNOPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {

            String newText = (string)newValue;
            var vm = (AccountTypeVM)bindable;

            vm.accountNOCheckImgVisibility = newText.Length == 10 ? true : false;

            CheckisNextEnableButton(vm);
        }

        static void serialNOPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {

            String newText = (string)newValue;
            var vm = (AccountTypeVM)bindable;

            vm.serialNOCheckImgVisibility = newText.Length == 10 ? true : false;

            CheckisNextEnableButton(vm);
        }

        private static void CheckisNextEnableButton(AccountTypeVM vm){

            if( vm.accountNOCheckImgVisibility && vm.serialNOCheckImgVisibility ){
                vm.isNextEnable = true;
                vm.NextEnableBackgroundcolor = "#347555";
            }else{
                vm.isNextEnable = false;
                vm.NextEnableBackgroundcolor = "Silver";
            }
        }


        async private void AccountType_Clicked(string type)
        {
            string selected = "";
            switch (type)
            {
                case "SavingsAccount":
                    selected = "Savings Account";
                    break;
                case "CurrentAccount":
                    selected = "Current Account";
                    break;
                case "FixedAccount":
                    selected = "Fixed Account";
                    break;
                case "ManualFund":
                    selected = "Manual Fund";
                    break;
                case "Securities":
                    selected = "Securities";
                    break;
                case "CreditCard":
                    selected = "Credit Card";
                    break;
                case "SaleFinance":
                    selected = "Sale Finance";
                    break;

                default:
                    break;                                                    
            }

            accountTypeSelectedText = selected;
            isAccountInfoVisible = true;
            await addAccountTypePage.Navigation.PopModalAsync();
        }
    }
}
