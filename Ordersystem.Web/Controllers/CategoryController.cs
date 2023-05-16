using Microsoft.AspNetCore.Mvc;
using Ordersystem.Services;

namespace Ordersystem.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            this._service = service;
        }
        public IActionResult Index()
        {
            var data = _service.GetAllCategories();
            return View(data);
        }
    }
}
