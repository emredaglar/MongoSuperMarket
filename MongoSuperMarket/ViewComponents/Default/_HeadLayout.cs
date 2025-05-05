using Microsoft.AspNetCore.Mvc;

namespace MongoSuperMarket.ViewComponents.Default
{
	public class _HeadLayout:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
