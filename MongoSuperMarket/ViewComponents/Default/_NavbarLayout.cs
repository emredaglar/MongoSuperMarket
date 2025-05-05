using Microsoft.AspNetCore.Mvc;

namespace MongoSuperMarket.ViewComponents.Default
{
	public class _NavbarLayout:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
