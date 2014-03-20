using System.Drawing;
using Framework.iOS.MTD;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace iOS.View.Detail
{
    public class DetailCell : ModelBasedCell<Model.JobPosting>
    {
        //private const string Jobpostingpath = "http://www.emplea.do/jobs/{0}";
        //private UIWebView _webView;

        public DetailCell(NSString key) : base(key)
        {
        }

        public override void Update(Model.JobPosting source)
        {
           //// _webView.PaginationMode = UIWebPaginationMode.BottomToTop;
           // _webView.ScalesPageToFit = true;
           // _webView.LoadRequest(new NSUrlRequest(new NSUrl(string.Format(Jobpostingpath,source.id))));
        }

        protected override void CreateContent()
        {
            
            
            //_webView = new UIWebView(new RectangleF(0,0,320,500));
           // ContentView.AddSubview();
        }
    }
}