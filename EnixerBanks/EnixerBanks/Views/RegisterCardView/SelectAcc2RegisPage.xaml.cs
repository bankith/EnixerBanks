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
    public partial class SelectAcc2RegisPage : ContentPage
    {
        AccountInfo AccountInfo;
        UserProfile UserProfile;
        VM.SelectAcc2RegisVM VM;

        public SelectAcc2RegisPage()
        {
            InitializeComponent();
            BindingContext = this;
           
        }

        public SelectAcc2RegisPage(AccountInfo account, UserProfile user)
        {
            InitializeComponent();
            AccountInfo = account;
            UserProfile = user;
            VM = new VM.SelectAcc2RegisVM(AccountInfo,UserProfile);
            BindingContext = VM;
            
        }

        
    }
}