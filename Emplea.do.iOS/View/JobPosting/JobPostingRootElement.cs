using System;
using System.Drawing;
using Framework.iOS.MTD;
using MonoTouch.Dialog;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using RestSharp.Contrib;
using iOS.View.Detail;

namespace iOS.View.JobPosting
{
    public class JobPostingRootElement : RootElement, IElementSizing
    {
        private readonly NSString _cellKey = new NSString("JobPostingCell");
        private const string Jobpostingpath = "http://www.emplea.do/jobs/{0}";
        private readonly IModelBasedCellFactory<Model.JobPosting> _factory;
        private readonly Model.JobPosting _model;

        public JobPostingRootElement(Model.JobPosting model, bool showIndicator,
                                     Func<RootElement, UIViewController> createScreen)
            : this(model, new JobPostingCellFactory(){ShowIndicator = showIndicator}, createScreen)
        {
        }

        public JobPostingRootElement(Model.JobPosting model, 
            IModelBasedCellFactory<Model.JobPosting> factory,
            Func<RootElement, UIViewController> createScreen
            )
            : base(model.title, createScreen)
        {
            
            _model = model;
            _factory = factory;
            
        }

        protected override NSString CellKey
        {
            get { return _cellKey; }
        }

        public override void Selected(DialogViewController dvc, UITableView tableView, NSIndexPath path)
        {
            //base.Selected(dvc, tableView, path);
            UIApplication.SharedApplication.OpenUrl(new NSUrl(string.Format(Jobpostingpath, _model.id)));

        }

        public float GetHeight(UITableView tableView, NSIndexPath indexPath)
        {
    //        UITextView *calculationView = [[UITextView alloc] init];
    //[calculationView setAttributedText:text];
    //CGSize size = [calculationView sizeThatFits:CGSizeMake(width, FLT_MAX)];
    //return size.height;

            var label = new UILabel();
            label.Lines = 3;
            label.Text = HttpUtility.HtmlDecode(_model.description_clean);
            var size = label.SizeThatFits(new SizeF(320 - 40, 70));
            return size.Height + 54;

        }

        public override UITableViewCell GetCell(UITableView tv)
        {
            ModelBasedCell<Model.JobPosting> cell = _factory.BuildCell(CellKey);
            cell.Update(_model);
            return cell;
        }
    }
}