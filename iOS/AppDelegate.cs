using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Google.Maps;
using UIKit;

namespace BloodDonate.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            var apikey = "AIzaSyC-HHfSqamKxBaPtm7Rk0FY1TRGiWHguBQ";
            PlacesClient.ProvideApiKey(apikey);
            MapServices.ProvideAPIKey(apikey);
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
