using Framework.iOS.MTD;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace iOS.View.JobPosting
{
    public class JobPostingElement : ModelBasedElement<Model.JobPosting, JobPostingCell>
    {
        public JobPostingElement(Model.JobPosting model)
            : this(model, model.title, new JobPostingCellFactory {ShowIndicator = true})
        {
        }

        public JobPostingElement(Model.JobPosting model, string caption, IModelBasedCellFactory<Model.JobPosting> cellFactory)
            : base(model, caption, cellFactory)
        {
        }

        public override float GetHeight(UITableView tableView, NSIndexPath indexPath)
        {
            return 80f;
        }
    }
}