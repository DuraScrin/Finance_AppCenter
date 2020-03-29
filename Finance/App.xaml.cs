using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Finance.View;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Finance
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            //#37,38
            string androidAppSecret = "71ff97da-347b-44b5-9e32-c3e5301d4e4b"; //this comes from AppCenter
            string iOSAppSecret = "f6919cdb-ea17-453f-aaa5-8204a5a8b8f5"; //this comes from AppCenter
            AppCenter.Start($"android={androidAppSecret};ios={iOSAppSecret}", typeof(Crashes), typeof(Analytics));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
