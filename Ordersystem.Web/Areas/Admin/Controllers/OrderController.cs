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
                    objOrder.OrderDate = DateTime.Now;

                    _serviceOrder.Create(objOrder);
                    TempData["succes"] = "Order created succesfully";
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
                    existingOrder.OrderStatus = objOrder.OrderStatus;
                    existingOrder.PaymentStatus = objOrder.PaymentStatus;

                    existingOrder.OrderDate = DateTime.Now;

                    _serviceOrder.Update(id.Value, existingOrder);
                    TempData["succes"] = "Order updated succesfully";
                }
                return RedirectToAction("Index");
            }

            return View(objOrder);
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
