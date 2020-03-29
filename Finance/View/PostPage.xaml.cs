using System;
using System.Collections.Generic;
using Finance.Model;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace Finance.View
{
    public partial class PostPage : ContentPage
    {
        public PostPage()
        {
            InitializeComponent();
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
        }

        public PostPage(Item item)
        {
            InitializeComponent();

            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
            webView.Source = item.ItemLink;

            //#37 test tracking exeption on AppCenter
            try
            {
                //#37
                //throw (new Exception("Test exeption!!"));
                //#38
                var errors = new Dictionary<string, string>
                {
                    {"Blog_post", $"{item.Title}"}
                };
                TrackEvent(errors);
            }
            catch (Exception ex)
            {
                //option 1
                //Crashes.TrackError(ex);

                //option 2 advanced
                var errors = new Dictionary<string, string>
                {
                    {"Blog_post", $"{item.Title}"}
                };
                TrackError(ex, errors);
            }
        }

        //#38
        private async void TrackEvent(Dictionary<string, string> details)
        {
            if(await Analytics.IsEnabledAsync())
                Analytics.TrackEvent("Blog_post_Opend", details);
        }
        //#39
        private async void TrackError(Exception ex, Dictionary<string, string> details)
        {
            if (await Analytics.IsEnabledAsync())
                Crashes.TrackError(ex, details);
        }
    }
}
