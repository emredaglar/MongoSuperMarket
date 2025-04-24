using Microsoft.AspNetCore.Mvc;
using MongoSuperMarket.Dtos.FeatureDtos;
using MongoSuperMarket.Services;
using System.Threading.Tasks;

namespace MongoSuperMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _featureService.GetAllAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateAsync(createFeatureDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            var value = await _featureService.GetByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateAsync(updateFeatureDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
