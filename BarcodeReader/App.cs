using System;

using Xamarin.Forms;

namespace BarcodeReader
{
    public class App: Application
    {
        public App() => MainPage = new NavigationPage(new ScanBarcodePage());
    }
}
