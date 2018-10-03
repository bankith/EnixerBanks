using System;
using Xamarin.Forms;

namespace EnixerBanks.VM
{
    public class EnixerAccountRegisterVM: BindableObject
    {
        public static readonly BindableProperty CountryCodeProperty = BindableProperty.Create("CountryCode", typeof(string), typeof(EnixerAccountRegisterVM), "Thailand (+66)", BindingMode.TwoWay, null, CountryCodePropertyChangedDelegate);
        public static readonly BindableProperty EmailProperty = BindableProperty.Create("Email", typeof(string), typeof(EnixerAccountRegisterVM), "", BindingMode.TwoWay, null, EmailPropertyChangedDelegate);
        public static readonly BindableProperty AccountNOProperty = BindableProperty.Create("AccountNO", typeof(string), typeof(EnixerAccountRegisterVM), "", BindingMode.TwoWay, null, AccountNOPropertyChangedDelegate);
        public static readonly BindableProperty BirthDayProperty = BindableProperty.Create("BirthDay", typeof(string), typeof(EnixerAccountRegisterVM), "BirthDay", BindingMode.TwoWay, null, BirthDayPropertyChangedDelegate);
        public static readonly BindableProperty MobileNOProperty = BindableProperty.Create("MobileNO", typeof(string), typeof(EnixerAccountRegisterVM), "", BindingMode.TwoWay, null, MobileNOPropertyChangedDelegate);
        public static readonly BindableProperty CitizenIDProperty = BindableProperty.Create("CitizenID", typeof(string), typeof(EnixerAccountRegisterVM), "", BindingMode.TwoWay, null, CitizenIDPropertyChangedDelegate);


        public static readonly BindableProperty NextEnableBackgroundcolorProperty = BindableProperty.Create("NextEnableBackgroundcolor", typeof(string), typeof(EnixerAccountRegisterVM), "Silver");
        public static readonly BindableProperty IsNextEnableProperty = BindableProperty.Create("IsNextEnable", typeof(bool), typeof(EnixerAccountRegisterVM), false);


        public string CountryCode { get { return (string)GetValue(CountryCodeProperty); } set { SetValue(CountryCodeProperty, value); } }
        public string Email { get { return (string)GetValue(EmailProperty); } set { SetValue(EmailProperty, value); } }
        public string AccountNO { get { return (string)GetValue(AccountNOProperty); } set { SetValue(AccountNOProperty, value); } }
        public string BirthDay { get { return (string)GetValue(BirthDayProperty); } set { SetValue(BirthDayProperty, value); } }
        public string MobileNO { get { return (string)GetValue(MobileNOProperty); } set { SetValue(MobileNOProperty, value); } }
        public string CitizenID { get { return (string)GetValue(CitizenIDProperty); } set { SetValue(CitizenIDProperty, value); } }


        public string NextEnableBackgroundcolor { get { return (string)GetValue(NextEnableBackgroundcolorProperty); } set { SetValue(NextEnableBackgroundcolorProperty, value); } }
        public bool IsNextEnable { get { return (bool)GetValue(IsNextEnableProperty); } set { SetValue(IsNextEnableProperty, value); } }


        static void CountryCodePropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {


            CheckEnableButton(bindable);
        }
        static void EmailPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            CheckEnableButton(bindable);
        }
        static void AccountNOPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            CheckEnableButton(bindable);
        }
        static void MobileNOPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            CheckEnableButton(bindable);
        }
        static void CitizenIDPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            CheckEnableButton(bindable);
        }
        static void BirthDayPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {

            CheckEnableButton(bindable);
        }

        private static void CheckEnableButton(BindableObject bindable)
        {
            EnixerAccountRegisterVM vm = (EnixerAccountRegisterVM)bindable;


            if (String.IsNullOrEmpty(vm.CountryCode)) return;
            if (String.IsNullOrEmpty(vm.Email)) return;
            if (String.IsNullOrEmpty(vm.AccountNO)) return;
            if (String.IsNullOrEmpty(vm.CitizenID)) return;
            if (String.IsNullOrEmpty(vm.MobileNO)) return;
            if (String.IsNullOrEmpty(vm.BirthDay)) return;


            if (vm.CountryCode.Length != 3) return;
            if (vm.Email.Length != 4 && !vm.Email.Contains("@") ) return;
            if (vm.AccountNO.Length != 10) return;
            if (vm.MobileNO.Length != 10) return;
            if (vm.CitizenID.Length != 13) return;
            if (vm.BirthDay.Length < 10) return;


            vm.IsNextEnable = true;
            vm.NextEnableBackgroundcolor = "#347555";


        }


        public EnixerAccountRegisterVM()
        {
        }
    }
}
