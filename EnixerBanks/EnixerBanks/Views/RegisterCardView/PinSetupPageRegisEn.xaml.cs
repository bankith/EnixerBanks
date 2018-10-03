using EnixerBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnixerBanks.RegisterCardView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PinSetupPageRegisEn : ContentPage
	{
        GreenBank_UserProfile user;
        UserProfile UserProfile;
        String FirstTimePin;
        VM.PinSetupPageRegisEnVM VM;

        public PinSetupPageRegisEn()
        {
            InitializeComponent();
        }

        public PinSetupPageRegisEn(UserProfile userProfile)
        {
            InitializeComponent();
            UserProfile = userProfile;
            VM = new VM.PinSetupPageRegisEnVM(UserProfile);
            BindingContext = VM; 
        }

    }
}