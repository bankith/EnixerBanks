using System;
using Xamarin.Forms;

namespace EnixerBanks.VM
{
    public class UnlockpinwithDebitVM: BindableObject
    {
        public static readonly BindableProperty CardNOProperty = BindableProperty.Create("CardNO", typeof(string), typeof(UnlockpinwithDebitVM), "", BindingMode.TwoWay, null, CardNOPropertyChangedDelegate);
        public static readonly BindableProperty ATMpinProperty = BindableProperty.Create("ATMpin", typeof(string), typeof(UnlockpinwithDebitVM), "", BindingMode.TwoWay, null, ATMpinPropertyChangedDelegate);
        public static readonly BindableProperty AccountNOProperty = BindableProperty.Create("AccountNO", typeof(string), typeof(UnlockpinwithDebitVM), "", BindingMode.TwoWay, null, AccountNOPropertyChangedDelegate);
        public static readonly BindableProperty BirthDayProperty = BindableProperty.Create("BirthDay", typeof(string), typeof(UnlockpinwithDebitVM), "BirthDay", BindingMode.TwoWay,null, BirthDayPropertyChangedDelegate);
        public static readonly BindableProperty PassbookNOProperty = BindableProperty.Create("PassbookNO", typeof(string), typeof(UnlockpinwithDebitVM), "", BindingMode.TwoWay, null , PassbookNOPropertyChangedDelegate);
        public static readonly BindableProperty CitizenIDProperty = BindableProperty.Create("CitizenID", typeof(string), typeof(UnlockpinwithDebitVM), "", BindingMode.TwoWay, null, CitizenIDPropertyChangedDelegate);


        public static readonly BindableProperty NextEnableBackgroundcolorProperty = BindableProperty.Create("NextEnableBackgroundcolor", typeof(string), typeof(ChangePasswordVM), "Silver");
        public static readonly BindableProperty IsNextEnableProperty = BindableProperty.Create("IsNextEnable", typeof(bool), typeof(ChangePasswordVM), false);


        public string CardNO { get { return (string)GetValue(CardNOProperty); } set { SetValue(CardNOProperty, value); } }
        public string ATMpin { get { return (string)GetValue(ATMpinProperty); } set { SetValue(ATMpinProperty, value); } }
        public string AccountNO { get { return (string)GetValue(AccountNOProperty); } set { SetValue(AccountNOProperty, value); } }
        public string BirthDay { get { return (string)GetValue(BirthDayProperty); } set { SetValue(BirthDayProperty, value); } }
        public string PassbookNO { get { return (string)GetValue(PassbookNOProperty); } set { SetValue(PassbookNOProperty, value); } }
        public string CitizenID { get { return (string)GetValue(CitizenIDProperty); } set { SetValue(CitizenIDProperty, value); } }


        public string NextEnableBackgroundcolor { get { return (string)GetValue(NextEnableBackgroundcolorProperty); } set { SetValue(NextEnableBackgroundcolorProperty, value); } }
        public bool IsNextEnable { get { return (bool)GetValue(IsNextEnableProperty); } set { SetValue(IsNextEnableProperty, value); } }


        static void CardNOPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            CheckEnableButton(bindable);
        }
        static void ATMpinPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            CheckEnableButton(bindable);
        }
        static void AccountNOPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            CheckEnableButton(bindable);
        }
        static void PassbookNOPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
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
            UnlockpinwithDebitVM vm = (UnlockpinwithDebitVM)bindable;



            if (String.IsNullOrEmpty(vm.CardNO)) return;
            if (String.IsNullOrEmpty(vm.ATMpin)) return;
            if (String.IsNullOrEmpty(vm.AccountNO)) return;
            if (String.IsNullOrEmpty(vm.CitizenID)) return;
            if (String.IsNullOrEmpty(vm.PassbookNO)) return;
            if (String.IsNullOrEmpty(vm.BirthDay)) return;


            if (vm.CardNO.Length != 16) return;
            if (vm.AccountNO.Length != 10) return;
            if (vm.ATMpin.Length != 6) return;

            if (vm.PassbookNO.Length != 10) return;
            if (vm.CitizenID.Length != 13) return;
            if (vm.BirthDay.Length < 10) return;

            vm.IsNextEnable = true;
            vm.NextEnableBackgroundcolor = "#347555";
        }


        public UnlockpinwithDebitVM()
        {

        }
    }
}
