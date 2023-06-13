using Microsoft.AspNetCore.Mvc;
using Ordersystem.DataObjects;
using Ordersystem.Services;
using Ordersystem.Web.Models;
using System.Diagnostics;

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
            Product product = _productService.GetProductByID(id);
            return View(product);
        }

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