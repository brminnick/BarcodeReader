using System;
using System.Collections.Generic;

using Xamarin.Forms;

using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace BarcodeReader
{
    public class ScanBarcodePage : ContentPage
    {
        #region Constant Fields
        readonly Button _scanBarcodeButton;
        readonly Label _scanResultsLabel;
        readonly ZXingScannerPage _scanPage;
        #endregion

        #region Constructors
        public ScanBarcodePage()
        {
            var options = new MobileBarcodeScanningOptions
            {
                AutoRotate = true,
                TryHarder = true,
                PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.All_1D }
            };

            _scanPage = new ZXingScannerPage(options)
            {
                DefaultOverlayTopText = "Align the barcode within the frame",
                DefaultOverlayBottomText = string.Empty,
                DefaultOverlayShowFlashButton = true
            };

            _scanBarcodeButton = new Button { Text = "Scan Barcode" };
            _scanBarcodeButton.Clicked += HandleScanBarcodeButtonClicked;

            _scanResultsLabel = new Label();

            Title = "Barcode Scan";

            Content = new StackLayout
            {
                Children = {
                    _scanResultsLabel,
                    _scanBarcodeButton
                }
            };

            _scanPage.OnScanResult += HandleScanPageOnScanResult;
        }
        #endregion

        #region Methods
        void HandleScanPageOnScanResult(Result result)
        {
            _scanPage.IsScanning = false;

            Device.BeginInvokeOnMainThread(async () =>
            {
                _scanResultsLabel.Text = result.Text;
                await Navigation.PopAsync();
            });
        }

        void HandleScanBarcodeButtonClicked(object sender, EventArgs e)
        {
            _scanPage.IsScanning = true;

            Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(_scanPage));
        }
        #endregion
    }
}
