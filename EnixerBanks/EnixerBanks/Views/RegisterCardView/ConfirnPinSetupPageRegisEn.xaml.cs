using EnixerBanks.ModelApp;
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
    public partial class ConfirnPinSetupPageRegisEn : ContentPage
    {
        UserProfile UserProfile;
        String FirstTimePin;
        VM.PinSetupPageRegisEnVM VM;


        public ConfirnPinSetupPageRegisEn()
        {
            InitializeComponent();
        }

        public ConfirnPinSetupPageRegisEn(String firstPin) : this()
        {
            this.FirstTimePin = firstPin;
        }
        public ConfirnPinSetupPageRegisEn(String firstPin, UserProfile user) : this(firstPin)
        {
            UserProfile = user;
            FirstTimePin = firstPin;
            VM = new VM.PinSetupPageRegisEnVM(FirstTimePin,UserProfile);
            BindingContext = VM;
        }
    }
}