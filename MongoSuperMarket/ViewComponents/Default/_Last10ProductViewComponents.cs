using MongoSuperMarket.Services;
using Microsoft.AspNetCore.Mvc;

namespace MongoSuperMarket.ViewComponents.Default
{
	public class _Last10ProductViewComponents : ViewComponent
	{
		private readonly IProductService _productService;

		public _Last10ProductViewComponents(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var products = await _productService.GetAllAsync();
			return View(products);
		}
	}
}
