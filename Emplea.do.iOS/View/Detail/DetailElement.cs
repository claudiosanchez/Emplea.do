using Framework.iOS.MTD;
using iOS.View.JobPosting;

namespace iOS.View.Detail
{
    public class DetailElement : ModelBasedElement<Model.JobPosting, DetailCell>
    {
        public DetailElement(Model.JobPosting model)
            : this(model, model.title, new DetailCellFactory())
        {
        }

        public DetailElement(Model.JobPosting model, string caption, IModelBasedCellFactory<Model.JobPosting> cellFactory)
            : base(model, caption, cellFactory)
        {
        }
    }
}