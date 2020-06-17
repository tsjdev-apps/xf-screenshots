using System;
using System.Runtime.InteropServices;
using UIKit;
using Xamarin.Forms;
using XFScreenshot.Interfaces;
using XFScreenshot.iOS.Services;

[assembly: Dependency(typeof(ScreenshotService))]
namespace XFScreenshot.iOS.Services
{
    public class ScreenshotService : IScreenshotService
    {
        public byte[] CaptureScreen()
        {
            var view = UIScreen.MainScreen;
            var capture = view.Capture();
            
            using (var data = capture.AsJPEG())
            {
                var bytes = new byte[data.Length];
                Marshal.Copy(data.Bytes, bytes, 0, Convert.ToInt32(data.Length));
                return bytes;
            }
        }
    }
}