using Android.Graphics;
using Plugin.CurrentActivity;
using System.IO;
using Xamarin.Forms;
using XFScreenshot.Droid.Services;
using XFScreenshot.Interfaces;

[assembly: Dependency(typeof(ScreenshotService))]
namespace XFScreenshot.Droid.Services
{
    public class ScreenshotService : IScreenshotService
    {
        public byte[] CaptureScreen()
        {
            var view = CrossCurrentActivity.Current.Activity.Window.DecorView.RootView;

            using (var screenshot = Bitmap.CreateBitmap(view.Width, view.Height, Bitmap.Config.Argb8888))
            {
                var canvas = new Canvas(screenshot);
                view.Draw(canvas);

                using (var stream = new MemoryStream())
                {
                    screenshot.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
                    return stream.ToArray();
                }
            }
        }
    }
}