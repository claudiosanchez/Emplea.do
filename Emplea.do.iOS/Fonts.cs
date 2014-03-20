using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoTouch.UIKit;

namespace iOS.View
{
    public static class Fonts
    {
        public static UIFont PrimaryFont(float size)
        {
            return UIFont.SystemFontOfSize(size);
        }

        public static UIFont BoldPrimaryFont(float size)
        {
            return UIFont.BoldSystemFontOfSize(size);
        }
    }
}
