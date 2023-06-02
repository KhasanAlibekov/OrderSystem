using Microsoft.AspNetCore.Mvc;
using Ordersystem.DataObjects;
using Ordersystem.Services;

namespace Ordersystem.Web.Controllers
{
    public class SupplierController : Controller
    {
        ISupplierService _service;
        public SupplierController(ISupplierService service)
        {
            this._service = service;
        }
        [Route("Supplier")]
        public IActionResult Index()
        {
            var data = _service.GetAllSuppliers();
            return View(data);
        }

        public IActionResult Edit(int id)
        {
            var data = _service.GetSupplierByID(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Supplier objSupplier)
        {
            var data = _service.GetSupplierByID(id);
            await TryUpdateModelAsync(data);
            _service.Update(id, data);
            TempData["succes"] = "Supplier updated succesfully";
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Supplier objSupplier)
        {
            if (ModelState.IsValid)
            {
                _service.Create(objSupplier);
                TempData["succes"] = "Supplier created succesfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var data = _service.GetSupplierByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id, Supplier objSupplier)
        {
            _service.Delete(id);
            TempData["succes"] = "Supplier deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}
