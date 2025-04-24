using Microsoft.AspNetCore.Mvc;
using MongoSuperMarket.Dtos.DiscountDtos;
using MongoSuperMarket.Services;
using System.Threading.Tasks;

namespace MongoSuperMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _discountService.GetAllAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateDiscount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            await _discountService.CreateAsync(createDiscountDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(string id)
        {
            var value=await _discountService.GetByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            await _discountService.UpdateAsync(updateDiscountDto);
            return RedirectToAction("Index");
        }

    }
}
