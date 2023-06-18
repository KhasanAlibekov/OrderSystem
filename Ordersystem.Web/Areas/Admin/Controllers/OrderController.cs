using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ordersystem.DataObjects;
using Ordersystem.Services;

namespace Ordersystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ApplicationRoles.Role_Admin)]
    public class OrderController : Controller
    {
        IOrderService _serviceOrder;
        public OrderController(IOrderService service)
        {
            _serviceOrder = service;
        }

        [Route("orders")]
        public IActionResult Index()
        {
            var data = _serviceOrder.GetAllOrders();
            return View(data);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null)
            {
                // Create
                return View(new Order());
            }
            else
            {
                // Edit
                Order orderObj = _serviceOrder.GetOrderByID(id.Value);
                if (orderObj == null)
                {
                    return NotFound();
                }
                return View(orderObj);
            }
        }

        [HttpPost]
        public IActionResult Upsert(int? id, Order objOrder)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    // Create product
                    _serviceOrder.Create(objOrder);
                    TempData["succes"] = "Supplier created succesfully";
                }
                else
                {
                    // Edit product
                    var existingOrder = _serviceOrder.GetOrderByID(id.Value);
                    if (existingOrder == null)
                    {
                        return NotFound();
                    }

                    existingOrder.OrderCount = objOrder.OrderCount;
                    existingOrder.OrderDate = objOrder.OrderDate;
                    
                    _serviceOrder.Update(id.Value, existingOrder);
                    TempData["succes"] = "Supplier updated succesfully";
                }
                return RedirectToAction("Index");
            }

            return View(objOrder);
        }

        public IActionResult Edit(int id)
        {
            var data = _serviceOrder.GetOrderByID(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Order objOrder)
        {
            var data = _serviceOrder.GetOrderByID(id);
            await TryUpdateModelAsync(data);
            _serviceOrder.Update(id, data);
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
                _serviceOrder.Create(objOrder);
                TempData["succes"] = "Order created succesfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var data = _serviceOrder.GetOrderByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id, Order objOrder)
        {
            _serviceOrder.Delete(id);
            TempData["succes"] = "Order deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}
