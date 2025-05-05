using Microsoft.AspNetCore.Mvc;

namespace MongoSuperMarket.ViewComponents.Default
{
	public class _TagCloudViewComponents:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
