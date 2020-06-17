using System;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;
using XFScreenshot.Interfaces;

namespace XFScreenshot
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void TakeScreenshotButtonOnClicked(object sender, EventArgs e)
        {
            // get screenshotservice
            var screenshotService = DependencyService.Get<IScreenshotService>();

            // take screenshot
            var imageBytes = screenshotService.CaptureScreen();

            // show image
            ScreenshotImage.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
        }
    }
}
