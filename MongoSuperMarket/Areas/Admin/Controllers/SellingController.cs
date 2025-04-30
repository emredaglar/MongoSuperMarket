using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoSuperMarket.Dtos.SellingDtos;
using MongoSuperMarket.Services;
using System.Globalization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MongoSuperMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SellingController : Controller
    {
        private readonly ISellingService _sellingService;
        private  readonly IProductService _productService;

        public SellingController(ISellingService sellingService, IProductService productService)
        {
            _sellingService = sellingService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _sellingService.GetAllSellingWithProductNameAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSelling()
        {
            var products=await _productService.GetAllAsync();
            ViewBag.Products = products.Select(prd => new SelectListItem
            {
                Value = prd.ProductId.ToString(),
                Text = $"{prd.ProductName}|{prd.ProductPrice.ToString("F2", CultureInfo.InvariantCulture)}"
            }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSelling(CreateSellingDto createSellingDto)
        {
            if (createSellingDto.SellingDate == DateTime.MinValue)
            {
                createSellingDto.SellingDate = DateTime.Now;
            }
            await _sellingService.CreateAsync(createSellingDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSelling(string id)
        {
            var values = await _sellingService.GetByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSelling(UpdateSellingDto updateSellingDto)
        {
            await _sellingService.UpdateAsync(updateSellingDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSelling(string id)
        {
            await _sellingService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
