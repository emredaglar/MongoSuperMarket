using Microsoft.AspNetCore.Mvc;

namespace MongoSuperMarket.ViewComponents.Default
{
	public class _MailViewComponents:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
