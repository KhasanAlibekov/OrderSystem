using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ordersystem.DataObjects;
using Ordersystem.Services;
using Ordersystem.Web.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Ordersystem.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var productList = _productService.GetAllProducts();
            return View(productList);
        }

        public IActionResult Details(int id)
        {
            OrderDetail order = new()
            {
                Product = _productService.GetProductByID(id),
                Quantity = 1,
                ProductID = id

            };
            return View(order);
        }

        //[HttpPost]
        //[Authorize]
        //public IActionResult Details(OrderDetail orderDetail)
        //{
        //    var identity = (ClaimsIdentity)User.Identity;
        //    var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    orderDetail.ApplicationUserID = userId;

        //    //_productService.Create(orderDetail);
        //    return View(orderDetail);
        //}
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}