using Microsoft.AspNetCore.Mvc;

namespace MongoSuperMarket.Areas.Admin.Controllers
{
    public class DiscountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
