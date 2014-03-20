using System;
using System.Linq;
using Empleado;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        private UIWindow _window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
           // StartTest();
          StartUI();

            return true;
        }

        //private void StartTest()
        //{
        //    var p = new Proxy();
        //    var rawesults = p.GetActive();
        //    var results = rawesults.ToList();

        //    Console.WriteLine(results.Count);
        //    foreach(var post in results)
        //    {
        //        Console.WriteLine("{0} {1}", post.title,post.description_clean);
        //    }
        //}

        private void StartUI()
        {
            _window = new UIWindow(UIScreen.MainScreen.Bounds);
            SetupTelemetry();
            var viewController = new TechPepper();
            _window.RootViewController = viewController;

            _window.MakeKeyAndVisible();
        }

        void SetupTelemetry()
        {
            HockeyApp.BITHockeyManager.SharedHockeyManager.Configure("e5dce637af3d8ef4251787997dc91d92", null);
			HockeyApp.BITHockeyManager.SharedHockeyManager.StartManager ();

        }
    }
}