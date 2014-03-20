using Framework.iOS.MTD;
using MonoTouch.Foundation;

namespace iOS.View.JobPosting
{
    public class JobPostingCellFactory : IModelBasedCellFactory<Model.JobPosting>
    {
        public bool ShowIndicator { get; set; }
        public ModelBasedCell<Model.JobPosting> BuildCell(NSString key)
        {
            return new JobPostingCell(key, ShowIndicator);
        }
    }
}