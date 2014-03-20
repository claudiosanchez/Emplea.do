using System.Drawing;
using Framework.iOS.Infrastructure;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using iOS;

namespace Empleado
{
    public class SplashScreen : UIViewController
    {
      
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var bg = ScreenResolutionUtil.IsTall ? UIImage.FromBundle("Default-568h") : UIImage.FromBundle("Default");

            var bgView = new UIImageView(bg);

            var version =
                new UILabel(new RectangleF((View.Frame.Width - 75)/2, (View.Frame.Height/4)*3, View.Frame.Width, 20))
                    {
                        Text =
                            string.Format("{0} ({1})",
                                          NSBundle.MainBundle.InfoDictionary["CFBundleShortVersionString"],
                                          NSBundle.MainBundle.InfoDictionary["CFBundleVersion"]),
                    };

            View.AddSubviews(bgView, version);
        }

        public override void ViewDidAppear(bool animated)
        {
            var screen = new CurrentListScreen();

            UIApplication.SharedApplication.KeyWindow.RootViewController = new UINavigationController(screen);
        }
    }
}