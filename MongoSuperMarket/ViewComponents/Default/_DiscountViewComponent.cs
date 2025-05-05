﻿using MongoSuperMarket.Services;
using Microsoft.AspNetCore.Mvc;

namespace MongoSuperMarket.ViewComponents.Default
{
	public class _DiscountViewComponents : ViewComponent
	{
		private readonly IDiscountService _discountService;

		public _DiscountViewComponents(IDiscountService discountService)
		{
			_discountService = discountService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _discountService.GetAllAsync();
			return View(values);
		}
	}
}
