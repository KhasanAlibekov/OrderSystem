﻿using Microsoft.AspNetCore.Mvc;
using Ordersystem.DataObjects;
using Ordersystem.Services;

namespace Ordersystem.Web.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            this._service = service;
        }
        [Route("Category")]
        public IActionResult Index()
        {
            var data = _service.GetAllCategories();
            return View(data);
        }

        public IActionResult Edit(int id)
        {
            var data = _service.GetCategoryByID(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category objCategory)
        {
            var data = _service.GetCategoryByID(id);
            await TryUpdateModelAsync(data);
            _service.Update(data);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category objCategory)
        {
            if (ModelState.IsValid)
            {
               _service.Create(objCategory);
                TempData["succes"] = "Category created succesfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var data = _service.GetCategoryByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id, Category objCategory)
        {
            _service.Delete(id);
            TempData["succes"] = "Category deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}