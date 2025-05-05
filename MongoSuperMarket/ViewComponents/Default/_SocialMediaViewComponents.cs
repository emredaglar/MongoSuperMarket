using Microsoft.AspNetCore.Mvc;

namespace MongoSuperMarket.ViewComponents.Default
{
	public class _SocialMediaViewComponents:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
