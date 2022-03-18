using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ApplicationListonic.Views;

namespace ApplicationListonic
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ShellPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            ApplicationListonic.MainPage.SaveData();
        }

        protected override void OnResume()
        {
        }
    }
}
