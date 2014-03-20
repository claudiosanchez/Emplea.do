using Framework.iOS.MTD;
using MonoTouch.Foundation;

namespace iOS.View.Detail
{
    public class DetailCellFactory : IModelBasedCellFactory<Model.JobPosting>
    {
        public ModelBasedCell<Model.JobPosting> BuildCell(NSString key)
        {
            return new DetailCell(key);
        }
    }
}