using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EnixerBanks.ModelApp;

namespace EnixerBanks.RegisterCardView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetupUserDetailRegisPage : ContentPage
    {
        AccountInfo AccountInfo;
        VM.SetupUserDetailRegisVM VM;

        public SetupUserDetailRegisPage()
        {
            InitializeComponent();
        }

        public SetupUserDetailRegisPage(AccountInfo account)
        {
            InitializeComponent();
            AccountInfo = account;
            VM = new VM.SetupUserDetailRegisVM(AccountInfo);
            BindingContext = VM;

        }


    }
}