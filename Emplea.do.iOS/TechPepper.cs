using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoTouch.Dialog;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Empleado
{
    public class TechPepper : DialogViewController
    {
        public TechPepper()
            : base(UITableViewStyle.Plain, new RootElement("TechPepper"), true)
        {
        }
     
        public override void ViewDidLoad()
        {
          //  var feed = new Argotic.Syndication.RssFeed(new Uri("http://techpepper.org/index.php/rss?format=feed"),"TechPepper");


        }
    }
  
}