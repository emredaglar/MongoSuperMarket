using Microsoft.AspNetCore.Mvc;

namespace MongoSuperMarket.ViewComponents.Default
{
	public class _SearchCanvasLayout:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
