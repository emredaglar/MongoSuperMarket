using Microsoft.AspNetCore.Mvc;

namespace MongoSuperMarket.ViewComponents.Default
{
	public class _FooterViewComponents : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
