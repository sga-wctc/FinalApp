using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new LogEntryListPage())
            MainPage = new NavigationPage(new Home());
            //{
            //    BarTextColor = Color.White,
            //    BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"]
            //};
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
