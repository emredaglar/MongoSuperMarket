using Microsoft.AspNetCore.Mvc;

namespace MongoSuperMarket.ViewComponents.Default
{
	public class _ScriptsViewComponents:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
