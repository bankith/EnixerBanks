using System;
using Xamarin.Forms;

namespace EnixerBanks.VM
{
    public class ChangePasswordVM: BindableObject
    {

        public static readonly BindableProperty OldPasswordProperty = BindableProperty.Create("OldPassword", typeof(string), typeof(ChangePasswordVM), "", BindingMode.TwoWay, null, OldPasswordPropertyChangedDelegate);
        public static readonly BindableProperty NewPassword1Property = BindableProperty.Create("NewPassword1", typeof(string), typeof(ChangePasswordVM), "", BindingMode.TwoWay, null, NewPassword1PropertyChangedDelegate);
        public static readonly BindableProperty NewPassword2Property = BindableProperty.Create("NewPassword2", typeof(string), typeof(ChangePasswordVM), "", BindingMode.TwoWay, null, NewPassword2PropertyChangedDelegate);

        public static readonly BindableProperty NextEnableBackgroundcolorProperty = BindableProperty.Create("NextEnableBackgroundcolor", typeof(string), typeof(ChangePasswordVM), "Silver");
        public static readonly BindableProperty IsNextEnableProperty = BindableProperty.Create("IsNextEnable", typeof(bool), typeof(ChangePasswordVM), false);


        public string OldPassword { get { return (string)GetValue(OldPasswordProperty); } set { SetValue(OldPasswordProperty, value); } }
        public string NewPassword1 { get { return (string)GetValue(NewPassword1Property); } set { SetValue(NewPassword1Property, value); } }
        public string NewPassword2 { get { return (string)GetValue(NewPassword2Property); } set { SetValue(NewPassword2Property, value); } }

        public string NextEnableBackgroundcolor{ get { return (string)GetValue(NextEnableBackgroundcolorProperty); } set { SetValue(NextEnableBackgroundcolorProperty, value); } }
        public bool   IsNextEnable { get { return (bool)GetValue(IsNextEnableProperty); } set { SetValue(IsNextEnableProperty, value); } }



        static void OldPasswordPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            CheckEnableButton(bindable);
        }
        static void NewPassword1PropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            CheckEnableButton(bindable);
        }
        static void NewPassword2PropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            CheckEnableButton(bindable);
        }

        private static void CheckEnableButton(BindableObject bindable)
        {
            ChangePasswordVM vm = (ChangePasswordVM)bindable;

            if (String.IsNullOrEmpty(vm.OldPassword)) return;
            if (String.IsNullOrEmpty(vm.NewPassword1) || String.IsNullOrEmpty(vm.NewPassword2)) return;

            if (vm.NewPassword1.Length != vm.NewPassword2.Length) return;
            if (vm.NewPassword1 != vm.NewPassword2) return;

            vm.IsNextEnable = true;
            vm.NextEnableBackgroundcolor = "#347555";
        }


        public ChangePasswordVM()
        {

        }
    }
}
