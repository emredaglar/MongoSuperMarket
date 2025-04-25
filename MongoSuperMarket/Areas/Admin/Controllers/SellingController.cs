﻿using Microsoft.AspNetCore.Mvc;
using MongoSuperMarket.Dtos.SellingDtos;
using MongoSuperMarket.Services;

namespace MongoSuperMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SellingController : Controller
    {
        private readonly ISellingService _sellingService;

        public SellingController(ISellingService sellingService)
        {
            _sellingService = sellingService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _sellingService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSelling()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSelling(CreateSellingDto createSellingDto)
        {
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
