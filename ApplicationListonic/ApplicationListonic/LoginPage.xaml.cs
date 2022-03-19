using System;
using System.Threading.Tasks;
using ApplicationListonic.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApplicationListonic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }
        void Init()
        {
            BackgroundColor = Color.FromRgb(242, 243, 246);
            Lbl_Username.TextColor = Color.FromRgb(33, 34, 38);
            Entry_Username.PlaceholderColor = Color.FromRgb(33, 34, 38);
            Lbl_Password.TextColor = Color.FromRgb(33, 34, 38);
            Entry_Password.PlaceholderColor = Color.FromRgb(33, 34, 38);
            Btn_SignUp.IsVisible = false;
        }

        private void SignInFunction(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckInformation())
            {
                Lbl_Warrning.Text = "Login access";
                for (int i = 0; i <= 5; i++)
                {
                    if (i == 5)
                    {
                        Application.Current.MainPage = new ShellPage();
                    }
                }
            }
            else
            {
                Lbl_Warrning.Text = "Login fail, empty username or password";
                Btn_SignUp.IsVisible = true;
            }
        }
    }
}