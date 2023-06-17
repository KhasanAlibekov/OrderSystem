using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ordersystem.DataObjects;
using Ordersystem.Services;

namespace Ordersystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        IMessageService _serviceMessage;
        public MessageController(IMessageService service)
        {
            _serviceMessage = service;
        }

        [Route("Message")]
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

        [Authorize(Roles = ApplicationRoles.Role_Admin)]
        public IActionResult Upsert(int? id)
        {
            if (id == null)
            {
                // Create
                return View(new Message());
            }
            else
            {
                // Edit
                Message objMessage = _serviceMessage.GetMessageByID(id.Value);
                if (objMessage == null)
                {
                    return NotFound();
                }
                return View(objMessage);
            }
        }

        [Authorize(Roles = ApplicationRoles.Role_Admin)]
        [HttpPost]
        public IActionResult Upsert(int? id, Message objMessage)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    // Create product
                    _serviceMessage.Create(objMessage);
                    TempData["succes"] = "Message created succesfully";
                }
                else
                {
                    // Edit product
                    var existingMessage = _serviceMessage.GetMessageByID(id.Value);
                    if (existingMessage == null)
                    {
                        return NotFound();
                    }

                    existingMessage.Title = objMessage.Title;
                    existingMessage.Content = objMessage.Content;
                    existingMessage.Date = DateTime.Now;

                    _serviceMessage.Update(id.Value, existingMessage);
                    TempData["succes"] = "Message updated succesfully";
                }
                return RedirectToAction("Index");
            }
            return View(objMessage);
        }

        [Authorize(Roles = ApplicationRoles.Role_Admin)]
        public IActionResult Delete(int id)
        {
            var data = _serviceMessage.GetMessageByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id, Message objMessage)
        {
            _serviceMessage.Delete(id);
            TempData["succes"] = "Message deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}
