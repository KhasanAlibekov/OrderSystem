using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ordersystem.DataObjects;
using Ordersystem.Services;

namespace Ordersystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ApplicationRoles.Role_Admin)]
    public class CategoryController : Controller
    {
        ICategoryService _serviceCategory;
        public CategoryController(ICategoryService serviceCategory)
        {
            _serviceCategory = serviceCategory;
        }

        [Route("Category")]
        public IActionResult Index()
        {
            List<Category> objCategoryList = _serviceCategory.GetAllCategories();
            return View(objCategoryList);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null)
            {
                // Create
                return View(new Category());
            }
            else
            {
                // Edit
                Category categoryObj = _serviceCategory.GetCategoryByID(id.Value);
                if (categoryObj == null)
                {
                    return NotFound();
                }
                return View(categoryObj);
            }
        }

        [HttpPost]
        public IActionResult Upsert(int? id, Category objCategory)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    // Create 
                    _serviceCategory.Create(objCategory);
                    TempData["succes"] = "Category created succesfully";
                }
                else
                {
                    // Edit 
                    var existingCategory = _serviceCategory.GetCategoryByID(id.Value);
                    if (existingCategory == null)
                    {
                        return NotFound();
                    }

                    existingCategory.CategoryName = objCategory.CategoryName;

                    _serviceCategory.Update(id.Value, existingCategory);
                    TempData["succes"] = "Category updated succesfully";
                }
                return RedirectToAction("Index");
            }

            return View(objCategory);
        }

        public IActionResult Delete(int id)
        {
            var data = _serviceCategory.GetCategoryByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id, Category objCategory)
        {
            _serviceCategory.Delete(id);
            TempData["succes"] = "Category deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}
