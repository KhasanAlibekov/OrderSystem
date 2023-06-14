using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ordersystem.DataObjects;
using Ordersystem.Services;

namespace Ordersystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = ApplicationRoles.Role_Admin)]
    public class CategoryController : Controller
    {
        ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [Route("Category")]
        // This is an endpoint of an action method, how will this endpoint be triggered?
        public IActionResult Index()
        {
            List<Category> objCategoryList = _service.GetAllCategories();
            return View(objCategoryList);
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
            _service.Update(id, data);
            TempData["succes"] = "Category updated succesfully";
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
                return RedirectToAction("Index", "Category");
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
