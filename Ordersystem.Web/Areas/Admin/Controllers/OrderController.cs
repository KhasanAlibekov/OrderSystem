using Microsoft.AspNetCore.Mvc;
using Ordersystem.DataObjects;
using Ordersystem.Services;

namespace Ordersystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [Route("orders")]
        public IActionResult Index()
        {
            var data = _service.GetAllOrders();
            return View(data);
        }

        public IActionResult Edit(int id)
        {
            var data = _service.GetOrderByID(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Order objOrder)
        {
            var data = _service.GetOrderByID(id);
            await TryUpdateModelAsync(data);
            _service.Update(id, data);
            TempData["succes"] = "Order updated succesfully";
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Order objOrder)
        {
            if (ModelState.IsValid)
            {
                _service.Create(objOrder);
                TempData["succes"] = "Order created succesfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var data = _service.GetOrderByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id, Order objOrder)
        {
            _service.Delete(id);
            TempData["succes"] = "Order deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}
