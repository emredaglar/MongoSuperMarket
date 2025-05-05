using Microsoft.AspNetCore.Mvc;
using MongoSuperMarket.Dtos.CategoryDtos;
using MongoSuperMarket.Services;
using X.PagedList.Extensions;

namespace MongoSuperMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IProductService _productService;

        public CategoryController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(string id)
        {
            var value = await _productService.GetProductsByCategoryIdAsync(id);
            return View(value);
        }
    }
}
