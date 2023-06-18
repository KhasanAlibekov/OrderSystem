using Microsoft.AspNetCore.Mvc;
using Ordersystem.API.Dto;
using Ordersystem.Services;

namespace Ordersystem.API.Controllers
{
    #region Order API Controller Overview
    /// <summary>
    /// 1. **Dependencies:**
    /// The controller has a dependency on the `IOrderService` which is injected through the constructor.
    ///
    /// 2. **Routing and Attributes:** 
    /// The class is decorated with the `[Route]` and `[ApiController]` attributes, which define the base route for the controller and
    /// indicate that it is an API controller.
    ///
    /// 3. **Action Methods:**
    /// - `Get`: Handles the HTTP GET request to retrieve all orders. It calls the `GetAllOrders` method of the `_orderService` and
    ///          returns the retrieved orders.
    /// - `GetById`: Handles the HTTP GET request to retrieve a specific order by its ID. It calls the `GetOrderByID` method of the
    ///              `_orderService` and returns the retrieved order.
    /// - `GetByIdQueryParam`: Handles the HTTP GET request to retrieve a specific order by its ID, along with an optional personal 
    ///             message. It calls the `GetOrderByID` method of the `_orderService`, adds a personal message if provided, and returns the
    ///             order and the personal message.
    /// - `Create`: Handles the HTTP POST request to create a new order. It calls the `Create` method of the `_orderService` to create
    ///             the order, and returns the created order.
    /// - `Update`: Handles the HTTP PUT request to update an existing order by its ID. It calls the `Update` method of the
    ///             `_orderService` to update the order, and returns the updated order.
    /// - `Delete`: Handles the HTTP DELETE request to delete an order by its ID. It calls the `Delete` method of the `_orderService`
    ///             and returns a success message if the deletion is successful.
    ///
    /// 4. **Exception Handling:**
    /// The action methods include exception handling code within a try-catch block. If an exception occurs during the execution of an
    /// action, it returns an appropriate HTTP status code and an error message indicating that something went wrong.
    /// </summary>
    #endregion

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;

        public OrderController(IOrderService orderService)
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
