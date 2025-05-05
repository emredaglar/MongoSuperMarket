using Microsoft.AspNetCore.Mvc;

namespace MongoSuperMarket.ViewComponents.Default
{
	public class _SvgLayout:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
