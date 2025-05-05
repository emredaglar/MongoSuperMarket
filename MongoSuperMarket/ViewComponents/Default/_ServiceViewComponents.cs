using Microsoft.AspNetCore.Mvc;

namespace MongoSuperMarket.ViewComponents.Default
{
	public class _ServiceViewComponents:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
