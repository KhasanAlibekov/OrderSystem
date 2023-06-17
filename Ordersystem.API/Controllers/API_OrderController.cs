using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordersystem.API.Dto;
using Ordersystem.Services;

namespace Ordersystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class API_OrderController : ControllerBase
    {
        IOrderService _orderService;

        public API_OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        //[Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listOrder = _orderService.GetAllOrders();

                return Ok(listOrder);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var order = _orderService.GetOrderByID(id);

                if (order == null)
                {
                    return NotFound("Order not found");
                }

                return Ok(order);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpGet("byid")]
        public IActionResult GetByIdQueryParam(int orderId, string? personalMessage)
        {
            try
            {
                if (string.IsNullOrEmpty(personalMessage))
                {
                    personalMessage = "This is your personal message";
                }

                var order = _orderService.GetOrderByID(orderId);

                if (order == null)
                {
                    return NotFound("Order not found");
                }
                return Ok(new { order, personalMessage });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] OrderDto order)
        {
            try
            {
                var CreatedOrder = _orderService.Create(new Ordersystem.DataObjects.Order
                {
                    OrderCount = order.OrderCount,
                });

                return CreatedAtAction("GetById", new { id = CreatedOrder.OrderID }, CreatedOrder);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] OrderDto order)
        {
            try
            {
                var orderToUpdate = _orderService.Update(id, new Ordersystem.DataObjects.Order
                {
                    OrderCount = order.OrderCount,
                });

                if (orderToUpdate == null)
                {
                    return NotFound("Order not found");
                }

                return CreatedAtAction("GetById", new { id = orderToUpdate.OrderID }, orderToUpdate);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var isDeleted = _orderService.Delete(id);

                if (isDeleted)
                {
                    return Ok(new { Message = "Order deleted successfully" });
                }

                return BadRequest(new { Message = "Something went wrong trying to delete order." });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }
    }
}
