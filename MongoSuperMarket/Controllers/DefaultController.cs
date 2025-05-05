using Microsoft.AspNetCore.Mvc;

namespace MongoSuperMarket.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
