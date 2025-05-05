using Microsoft.AspNetCore.Mvc;

namespace MongoSuperMarket.ViewComponents.Default
{
	public class _BasketCanvasLayout:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
