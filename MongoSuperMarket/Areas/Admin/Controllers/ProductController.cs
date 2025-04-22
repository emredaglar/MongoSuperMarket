using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoSuperMarket.Dtos.ProductDtos;
using MongoSuperMarket.Services;
using System;

namespace MongoSuperMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        //task ve await hakkında;

        //        Diyelim ki sen bir market çalışanısın ve kasadasın.
        //        Bir müşteri geliyor ve sana diyor ki:

        //"Kasada sıra beklemeden 20 koli süt alabilir miyim?"

        //Sen de gidip arka depoya inip tek tek 20 koli süt taşımaya başlarsan, arkadaki işle mi uğraşırsın yoksa kasadaki diğer müşterileri mi beklersin?
        //Eğer hemen çıkıp arkaya gidersen, kasada kuyruk oluşur, sistem tıkanır.

        //Ama sen akıllıca bir şey yaparsan:

        //Depocuya "Git sütleri hazırla" dersin(arka planda başlatırsın)

        //Bu sırada kasadaki diğer müşterilere hizmet vermeye devam edersin(sistem çalışır)

        //Sütler hazır olunca depocu sana haber verir, sen de müşteriye verirsin

        //İşte bu sistem yazılımda şöyle işler:


        //Gerçek Hayat    Yazılımdaki Karşılığı
        //Depoya iş vermek await + async fonksiyon
        //Depocuya görev vermek   Task(arka planda çalışacak iş)
        //Kasada işine devam etmek    Ana işlem kilitlenmeden devam eder
        public async Task<IActionResult> Index()
        {
            var values = await _productService.GetAllAsync();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateAsync(createProductDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var values=_productService.GetByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateAsync(updateProductDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
