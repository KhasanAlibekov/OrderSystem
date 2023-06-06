using Microsoft.AspNetCore.Mvc;
using Ordersystem.DataObjects;
using Ordersystem.Services;

namespace Ordersystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [Route("Product")]
        public IActionResult Index()
        {
            var data = _service.GetAllProducts();
            return View(data);
        }

        public IActionResult Edit(int id)
        {
            var data = _service.GetProductByID(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product objProduct)
        {
            var data = _service.GetProductByID(id);
            await TryUpdateModelAsync(data);
            _service.Update(id, data);
            TempData["succes"] = "Product updated succesfully";
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product objProduct)
        {
            if (ModelState.IsValid)
            {
                _service.Create(objProduct);
                TempData["succes"] = "Product created succesfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var data = _service.GetProductByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id, Product objProduct)
        {
            _service.Delete(id);
            TempData["succes"] = "Product deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}
