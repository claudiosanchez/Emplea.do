using MonoTouch.Foundation;

namespace Framework.iOS.MTD
{

	public interface IModelBasedCellFactory<TModel> where TModel:class, new()
	{
		ModelBasedCell<TModel> BuildCell(NSString key);
	}
	
}
