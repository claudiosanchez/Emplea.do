using System.IO;
using MonoTouch.UIKit;

namespace Framework.iOS.Infrastructure
{
    public static class ScreenResolutionUtil
    {
        public static bool IsTall
        {
            get
            {
                return UIDevice.CurrentDevice.UserInterfaceIdiom
                    == UIUserInterfaceIdiom.Phone
                        && UIScreen.MainScreen.Bounds.Size.Height
                        * UIScreen.MainScreen.Scale >= 1136;
            }
        }

        public static int ScreenHeight
        {
            get
            {
                return (IsTall) ? 568 : 480;
            }

        }

        private static string tallMagic = "-568h@2x";
        public static UIImage FromBundle16x9(string path)
        {
            //adopt the -568h@2x naming convention
            if (IsTall)
            {
                var imagePath = Path.GetDirectoryName(path.ToString());
                var imageFile = Path.GetFileNameWithoutExtension(path.ToString());
                var imageExt = Path.GetExtension(path.ToString());
                imageFile = imageFile + tallMagic + imageExt;
                return UIImage.FromBundle(Path.Combine(imagePath, imageFile));
            }
            else
            {
                return UIImage.FromBundle(path.ToString());
            }
        }
    }
}
