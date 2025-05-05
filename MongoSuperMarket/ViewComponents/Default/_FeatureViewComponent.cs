using MongoSuperMarket.Services;
using Microsoft.AspNetCore.Mvc;

namespace MongoSuperMarket.ViewComponents.Default
{
	public class _FeatureViewComponents:ViewComponent
	{
		private readonly IFeatureService _featureService;

		public _FeatureViewComponents(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var features = await _featureService.GetAllAsync();
			return View(features);
		}
	}
}
