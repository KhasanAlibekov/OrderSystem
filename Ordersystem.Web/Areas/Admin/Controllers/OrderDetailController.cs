using Microsoft.AspNetCore.Mvc;

namespace Ordersystem.Web.Areas.Admin.Controllers
{
    public class OrderDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
