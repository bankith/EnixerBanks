using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EnixerBanks.ModelApp;
using EnixerBanks;
using SQLite;

namespace EnixerBanks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseMenuPage : ContentPage
    {
        private int count = 0;
       

        private List<LocalManu> SelectManu = new List<LocalManu>();


        public ChooseMenuPage()
        {
            InitializeComponent();

            

            btnDone.IsEnabled = false;
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            count = 0;
            this.BindingContext = this;
        }

        public static readonly BindableProperty Menu1ImgProperty = BindableProperty.Create("Menu1Img", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu1Img
        {
            get { return (String)GetValue(Menu1ImgProperty); }
            set { SetValue(Menu1ImgProperty, value);
               
            }
        }

        public static readonly BindableProperty Menu1TextProperty = BindableProperty.Create("Menu1Text", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu1Text
        {
            get { return (String)GetValue(Menu1TextProperty); }
            set { SetValue(Menu1TextProperty, value);
               
            }
        }

        public static readonly BindableProperty Menu1ImgCheckProperty = BindableProperty.Create("Menu1ImgCheck", typeof(string), typeof(ChooseMenuPage), "iconUnCheck");
        public string Menu1ImgCheck
        {
            get { return (String)GetValue(Menu1ImgCheckProperty); }
            set { SetValue(Menu1ImgCheckProperty, value); }
        }

        public static readonly BindableProperty Menu2ImgProperty = BindableProperty.Create("Menu2Img", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu2Img
        {
            get { return (String)GetValue(Menu2ImgProperty); }
            set { SetValue(Menu2ImgProperty, value);
               
            }
        }

        public static readonly BindableProperty Menu2ImgCheckProperty = BindableProperty.Create("Menu2ImgCheck", typeof(string), typeof(ChooseMenuPage), "iconUnCheck");
        public string Menu2ImgCheck
        {
            get { return (String)GetValue(Menu2ImgCheckProperty); }
            set { SetValue(Menu2ImgCheckProperty, value); 
                }
        }

        public static readonly BindableProperty Menu2TextProperty = BindableProperty.Create("Menu2Text", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu2Text
        {
            get { return (String)GetValue(Menu2TextProperty); }
            set { SetValue(Menu2TextProperty, value);
                
            }
        }

        public static readonly BindableProperty Menu3ImgProperty = BindableProperty.Create("Menu3Img", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu3Img
        {
            get { return (String)GetValue(Menu3ImgProperty); }
            set { SetValue(Menu3ImgProperty, value);
                
            }
        }

        public static readonly BindableProperty Menu3TextProperty = BindableProperty.Create("Menu3Text", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu3Text
        {
            get { return (String)GetValue(Menu3TextProperty); }
            set { SetValue(Menu3TextProperty, value);
               
            }
        }

        public static readonly BindableProperty Menu3ImgCheckProperty = BindableProperty.Create("Menu3ImgCheck", typeof(string), typeof(ChooseMenuPage), "iconUnCheck");
        public string Menu3ImgCheck
        {
            get { return (String)GetValue(Menu3ImgCheckProperty); }
            set { SetValue(Menu3ImgCheckProperty, value); }
        }

        public static readonly BindableProperty Menu4ImgProperty = BindableProperty.Create("Menu4Img", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu4Img
        {
            get { return (String)GetValue(Menu4ImgProperty); }
            set { SetValue(Menu4ImgProperty, value); }
        }

        public static readonly BindableProperty Menu4TextProperty = BindableProperty.Create("Menu4Text", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu4Text
        {
            get { return (String)GetValue(Menu4TextProperty); }
            set { SetValue(Menu4TextProperty, value); }
        }

        public static readonly BindableProperty Menu4ImgCheckProperty = BindableProperty.Create("Menu4ImgCheck", typeof(string), typeof(ChooseMenuPage), "iconUnCheck");
        public string Menu4ImgCheck
        {
            get { return (String)GetValue(Menu4ImgCheckProperty); }
            set { SetValue(Menu4ImgCheckProperty, value); }
        }

        public static readonly BindableProperty Menu5ImgProperty = BindableProperty.Create("Menu5Img", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu5Img
        {
            get { return (String)GetValue(Menu5ImgProperty); }
            set { SetValue(Menu5ImgProperty, value); }
        }

        public static readonly BindableProperty Menu5TextProperty = BindableProperty.Create("Menu5Text", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu5Text
        {
            get { return (String)GetValue(Menu5TextProperty); }
            set { SetValue(Menu5TextProperty, value); }
        }

        public static readonly BindableProperty Menu5ImgCheckProperty = BindableProperty.Create("Menu5ImgCheck", typeof(string), typeof(ChooseMenuPage), "iconUnCheck");
        public string Menu5ImgCheck
        {
            get { return (String)GetValue(Menu5ImgCheckProperty); }
            set { SetValue(Menu5ImgCheckProperty, value); }
        }

        public static readonly BindableProperty Menu6ImgProperty = BindableProperty.Create("Menu6Img", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu6Img
        {
            get { return (String)GetValue(Menu6ImgProperty); }
            set { SetValue(Menu6ImgProperty, value); }
        }

        public static readonly BindableProperty Menu6TextProperty = BindableProperty.Create("Menu6Text", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu6Text
        {
            get { return (String)GetValue(Menu6TextProperty); }
            set { SetValue(Menu6TextProperty, value); }
        }

        public static readonly BindableProperty Menu6ImgCheckProperty = BindableProperty.Create("Menu6ImgCheck", typeof(string), typeof(ChooseMenuPage), "iconUnCheck");
        public string Menu6ImgCheck
        {
            get { return (String)GetValue(Menu6ImgCheckProperty); }
            set { SetValue(Menu6ImgCheckProperty, value); }
        }

        public static readonly BindableProperty Menu7ImgProperty = BindableProperty.Create("Menu7Img", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu7Img
        {
            get { return (String)GetValue(Menu7ImgProperty); }
            set { SetValue(Menu7ImgProperty, value); }
        }

        public static readonly BindableProperty Menu7TextProperty = BindableProperty.Create("Menu7Text", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu7Text
        {
            get { return (String)GetValue(Menu7TextProperty); }
            set { SetValue(Menu7TextProperty, value); }
        }

        public static readonly BindableProperty Menu7ImgCheckProperty = BindableProperty.Create("Menu7ImgCheck", typeof(string), typeof(ChooseMenuPage), "iconUnCheck");
        public string Menu7ImgCheck
        {
            get { return (String)GetValue(Menu7ImgCheckProperty); }
            set { SetValue(Menu7ImgCheckProperty, value); }
        }

        public static readonly BindableProperty Menu8ImgProperty = BindableProperty.Create("Menu8Img", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu8Img
        {
            get { return (String)GetValue(Menu8ImgProperty); }
            set { SetValue(Menu8ImgProperty, value); }
        }

        public static readonly BindableProperty Menu8TextProperty = BindableProperty.Create("Menu8Text", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu8Text
        {
            get { return (String)GetValue(Menu8TextProperty); }
            set { SetValue(Menu8TextProperty, value); }
        }

        public static readonly BindableProperty Menu8ImgCheckProperty = BindableProperty.Create("Menu8ImgCheck", typeof(string), typeof(ChooseMenuPage), "iconUnCheck");
        public string Menu8ImgCheck
        {
            get { return (String)GetValue(Menu8ImgCheckProperty); }
            set { SetValue(Menu8ImgCheckProperty, value); }
        }

        public static readonly BindableProperty Menu9ImgProperty = BindableProperty.Create("Menu9Img", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu9Img
        {
            get { return (String)GetValue(Menu9ImgProperty); }
            set { SetValue(Menu9ImgProperty, value); }
        }

        public static readonly BindableProperty Menu9TextProperty = BindableProperty.Create("Menu9Text", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu9Text
        {
            get { return (String)GetValue(Menu9TextProperty); }
            set { SetValue(Menu9TextProperty, value); }
        }

        public static readonly BindableProperty Menu9ImgCheckProperty = BindableProperty.Create("Menu9ImgCheck", typeof(string), typeof(ChooseMenuPage), "iconUnCheck");
        public string Menu9ImgCheck
        {
            get { return (String)GetValue(Menu9ImgCheckProperty); }
            set { SetValue(Menu9ImgCheckProperty, value); }
        }

        public static readonly BindableProperty Menu10ImgProperty = BindableProperty.Create("Menu10Img", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu10Img
        {
            get { return (String)GetValue(Menu10ImgProperty); }
            set { SetValue(Menu10ImgProperty, value); }
        }

        public static readonly BindableProperty Menu10TextProperty = BindableProperty.Create("Menu10Text", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu10Text
        {
            get { return (String)GetValue(Menu10TextProperty); }
            set { SetValue(Menu10TextProperty, value); }
        }

        public static readonly BindableProperty Menu10ImgCheckProperty = BindableProperty.Create("Menu10ImgCheck", typeof(string), typeof(ChooseMenuPage), "iconUnCheck");
        public string Menu10ImgCheck
        {
            get { return (String)GetValue(Menu10ImgCheckProperty); }
            set { SetValue(Menu10ImgCheckProperty, value); }
        }

        public static readonly BindableProperty Menu11ImgProperty = BindableProperty.Create("Menu11Img", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu11Img
        {
            get { return (String)GetValue(Menu11ImgProperty); }
            set { SetValue(Menu11ImgProperty, value); }
        }

        public static readonly BindableProperty Menu11TextProperty = BindableProperty.Create("Menu11Text", typeof(string), typeof(ChooseMenuPage), "");
        public string Menu11Text
        {
            get { return (String)GetValue(Menu11TextProperty); }
            set { SetValue(Menu11TextProperty, value); }
        }

        public static readonly BindableProperty Menu11ImgCheckProperty = BindableProperty.Create("Menu11ImgCheck", typeof(string), typeof(ChooseMenuPage), "iconUnCheck");
        public string Menu11ImgCheck
        {
            get { return (String)GetValue(Menu11ImgCheckProperty); }
            set { SetValue(Menu11ImgCheckProperty, value); }
        }

        private void Menu1(object sender, EventArgs e)
        {
            SetMenu("iconCards.png", "Transfer Own Account", 1);
        }

        private void Menu2(object sender, EventArgs e)
        {
            SetMenu("iconCards.png", "Transfer Other Account", 2);
        }

        private void Menu3(object sender, EventArgs e)
        {
            SetMenu("iconPayGray", "Transfer PromptPay", 3);
        }

        private void Menu4(object sender, EventArgs e)
        {
            SetMenu("iconPhoneGray", "Top Up", 4);
        }

        private void Menu5(object sender, EventArgs e)
        {
            SetMenu("iconBill.png", "Pay Bill", 5);
        }

        private void Menu6(object sender, EventArgs e)
        {
            SetMenu("iconMarkFav", "Favorite", 6);
        }

        private void Menu7(object sender, EventArgs e)
        {
            SetMenu("iconTransaction", "Transaction History", 7);
        }

        private void Menu8(object sender, EventArgs e)
        {
            SetMenu("iconWatch", "Schedule List", 8);
        }

        private void Menu9(object sender, EventArgs e)
        {
            SetMenu("iconPayGray", "Register PromptPay", 9);
        }

        private void Menu10(object sender, EventArgs e)
        {
            SetMenu("iconSpeech", "Apply SMS Banking", 10);
        }

        private void Menu11(object sender, EventArgs e)
        {
            SetMenu("iconOneCard", "Apply Autopay Debit", 11);
        }

        private void SetMenu(string imgName, string text, int imageIndex)
        {
            SQLiteConnection conn = new SQLiteConnection(App.DBPath);

            SelectManu = conn.Table<LocalManu>().ToList();

            var item = SelectManu.Where(x => x.TexManu.Contains(text)).ToList();

            var oldItem = conn.Table<LocalManu>().ToList();


            if(oldItem.Count == 11)
            {
                LocalManu.Delete();
            }
            

            
            if (item.Count > 0)
            {
                //DisplayAlert("Failed!", "คุณเลือกเมนูซ้ำ", "OK");
                //To delete item


                return;
            }
            count += 1;

            if(count == 11)
            {
                btnDone.IsEnabled = true;
            }
           

            LocalManu.SaveImgManu(imgName, text); //save Manu And img


            if (count > 0)
            {
                labelShow.IsVisible = false;
            }
            if (count <= 11)
            {
                switch (count)
                {
                    case 1:
                        Menu1Img = imgName;
                        Menu1Text = text;              
                        break;
                    case 2:
                        Menu2Img = imgName;
                        Menu2Text = text;
                        break;
                    case 3:
                        Menu3Img = imgName;
                        Menu3Text = text;
                        break;
                    case 4:
                        Menu4Img = imgName;
                        Menu4Text = text;
                        break;
                    case 5:
                        Menu5Img = imgName;
                        Menu5Text = text;
                        break;
                    case 6:
                        Menu6Img = imgName;
                        Menu6Text = text;
                        break;
                    case 7:
                        Menu7Img = imgName;
                        Menu7Text = text;
                        break;
                    case 8:
                        Menu8Img = imgName;
                        Menu8Text = text;
                        break;
                    case 9:
                        Menu9Img = imgName;
                        Menu9Text = text;
                        break;
                    case 10:
                        Menu10Img = imgName;
                        Menu10Text = text;
                        break;
                    case 11:
                        Menu11Img = imgName;
                        Menu11Text = text;
                        break;
                }
                SetCheckedIcon(imageIndex);
            }
        }

        private void SetCheckedIcon(int imageIndex)
        {
            switch (imageIndex)
            {
                case 1: Menu1ImgCheck = "iconCheck"; break;
                case 2: Menu2ImgCheck = "iconCheck"; break;
                case 3: Menu3ImgCheck = "iconCheck"; break;
                case 4: Menu4ImgCheck = "iconCheck"; break;
                case 5: Menu5ImgCheck = "iconCheck"; break;
                case 6: Menu6ImgCheck = "iconCheck"; break;
                case 7: Menu7ImgCheck = "iconCheck"; break;
                case 8: Menu8ImgCheck = "iconCheck"; break;
                case 9: Menu9ImgCheck = "iconCheck"; break;
                case 10: Menu10ImgCheck = "iconCheck"; break;
                case 11: Menu11ImgCheck = "iconCheck"; break;
            }
        }

        private void Done_btn(object sender, EventArgs e)
        {
            //foreach (var item in lsMenu)
            //{
            //    LocalManu.SaveImgManu(item.ImgManu, item.TexManu);
            //}
            Navigation.PopAsync();
        }

        //public void OnClick_AddMenu(string imagePath , string imageName, int id)
        //{
        //    bool isExist = false;
        //    int indexOfMenu = 0;
        //    for (int i = 0; i < lsMenu.Count; i++)
        //    {
        //        indexOfMenu = i;
        //        isExist = true;
        //    }

        //    if (isExist)
        //    {
        //        lsMenu.RemoveAt(indexOfMenu);
        //    }
        //    else
        //    {
        //        LocalManu menu = new LocalManu()
        //        {
        //            ImgManu = imageName,
        //            TexManu = imagePath
        //        };
        //        lsMenu.Add(menu);
        //    }


        //}
    }
}