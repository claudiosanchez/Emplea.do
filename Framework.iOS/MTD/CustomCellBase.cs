using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Framework.iOS.MTD
{
    public abstract class CustomCellBase : UITableViewCell
    {
        protected CustomCellBase(UITableViewCellStyle style, NSString key) : base(style, key)
        {
            CallLifeCycleEvents();
        }

        protected abstract void CreateContent();

        protected virtual void ApplyStyle()
        {
        }

        private void CallLifeCycleEvents()
        {
            CreateContent();
            ApplyStyle();
        }
    }

    public abstract class ModelBasedCell<T> : CustomCellBase
        where T : class,
            new() // TODO: Why do we need a parameterless constructor?
    {
        public ModelBasedCell(NSString key) : base(UITableViewCellStyle.Default, key)
        {
        }

        public abstract void Update(T source);
    }
}