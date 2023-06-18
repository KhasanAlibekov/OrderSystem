using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ordersystem.DataObjects;
using Ordersystem.Services;
using System.Data;

namespace Ordersystem.Web.Areas.Employee.Controllerr
{
    [Area("Employee")]
    [Authorize(Roles = ApplicationRoles.Role_Employee)]
    public class MessageEmployeeController : Controller
    {
        IMessageService _serviceMessage;
        public MessageEmployeeController(IMessageService service)
        {
            _serviceMessage = service;
        }

        public IActionResult Index()
        {
            var message = _serviceMessage.GetAllMessages();
            return View(message);
        }

        public IActionResult Details(int id)
        {
            var message = _serviceMessage.GetMessageByID(id);
            return View(message);
        }
    }
}
