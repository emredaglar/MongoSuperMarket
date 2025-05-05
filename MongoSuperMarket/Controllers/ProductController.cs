using Microsoft.AspNetCore.Mvc;
using MongoSuperMarket.Services;

namespace MongoSuperMarket.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return RedirectToAction("Index");
            }

            var searchResults = await _productService.SearchProductsAsync(query);
            return View("Index", searchResults);
        }
    }
}
