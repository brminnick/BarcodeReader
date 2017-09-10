using UIKit;
using Foundation;

namespace BarcodeReader.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();
            ZXing.Net.Mobile.Forms.iOS.Platform.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
