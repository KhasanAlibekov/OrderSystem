﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ordersystem.DataObjects;
using Ordersystem.Services;
using System.Data;

namespace Ordersystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ApplicationRoles.Role_Admin)]
    public class OrderDetailController : Controller
    {
        IOrderDetailService _orderDetailService;
        IProductService _serviceProduct;
        IOrderService _serviceOrder;
        public OrderDetailController(IOrderDetailService orderDetailService, IProductService serviceProduct, IOrderService serviceOrder)
        {
            this._orderDetailService = orderDetailService;
            this._serviceProduct = serviceProduct;
            this._serviceOrder = serviceOrder;
        }

        [Route("OrderDetail")]
        public IActionResult Index()
        {
            var orderDetailList = _orderDetailService.GetAllOrderDetails();

            return View(orderDetailList);
        }

        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> ProductList = _serviceProduct.GetAllProducts().Select(u => new SelectListItem
            {
                Text = u.Title,
                Value = u.ProductID.ToString(),
            });

            ViewBag.ProductList = ProductList;

            IEnumerable<SelectListItem> OrderList = _serviceOrder.GetAllOrders().Select(u => new SelectListItem
            {
                Text = u.OrderDate.ToString(),
                Value = u.OrderID.ToString(),
            });

            ViewBag.OrderList = OrderList;

            if (id == null)
            {
                // Create
                return View(new OrderDetail());
            }
            else
            {
                // Edit
                var data = _orderDetailService.GetOrderDetailByID(id.Value);
                if (data == null)
                {
                    return NotFound();
                }
                return View(data);
            }
        }

        [HttpPost]
        public IActionResult Upsert(int? id, OrderDetail objOrderDetail)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    // Create product
                    _orderDetailService.Create(objOrderDetail);
                    TempData["succes"] = "Detail order created succesfully";
                }
                else
                {
                    // Edit product
                    var existingOrderDetail = _orderDetailService.GetOrderDetailByID(id.Value);
                    if (existingOrderDetail == null)
                    {
                        return NotFound();
                    }
                  
                    existingOrderDetail.ProductID = objOrderDetail.ProductID;
                    existingOrderDetail.OrderID = objOrderDetail.OrderID;

                    if (objOrderDetail.UnitPrice <= 0)
                    {
                        ModelState.AddModelError("UnitPrice", "Unit price must be greater than 0.");
                    }

                    if (objOrderDetail.Quantity <= 0)
                    {
                        ModelState.AddModelError("Quantity", "Quantity must be greater than 0.");
                    }

                    existingOrderDetail.UnitPrice = objOrderDetail.UnitPrice;
                    existingOrderDetail.Quantity = objOrderDetail.Quantity;

                    _orderDetailService.Update(id.Value, existingOrderDetail);
                    TempData["succes"] = "Detail order updated succesfully";
                }
                return RedirectToAction("Index");
            }

            // If model state is not valid, re-render the view with validation errors

            IEnumerable<SelectListItem> ProductList = _serviceProduct.GetAllProducts().Select(u => new SelectListItem
            {
                Text = u.Title,
                Value = u.ProductID.ToString(),
            });

            ViewBag.ProductList = ProductList;

            IEnumerable<SelectListItem> OrderList = _serviceOrder.GetAllOrders().Select(u => new SelectListItem
            {
                Text = u.OrderDate.ToString(),
                Value = u.OrderID.ToString(),
            });

            ViewBag.OrderList = OrderList;

            return View(objOrderDetail);
        }
    }
}
