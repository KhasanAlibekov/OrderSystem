using Microsoft.AspNetCore.Mvc;
using Ordersystem.API.Dto;
using Ordersystem.Services;

namespace Ordersystem.API.Controllers
{
    #region Order Detail API Controller Overview
    /// <summary>
    /// 1. **Dependencies:**
    /// The controller has dependencies on three services: `IOrderDetailService`, `IProductService`, and `IOrderService`. These services
    /// are injected through the constructor.
    ///
    /// 2. **Routing and Attributes:**
    /// The class is decorated with the `[Route]` and `[ApiController]` attributes, which define the base route for the controller and
    /// indicate that it is an API controller.
    ///
    /// 3. **Action Methods:**
    /// - `Get`: Handles the HTTP GET request to retrieve all order details. It calls the `GetAllOrderDetails` method of the
    ///             _orderDetailService` and returns the retrieved order details.
    /// - `GetById`: Handles the HTTP GET request to retrieve a specific order detail by its ID. It calls the `GetOrderDetailByID`
    ///              method of the `_orderDetailService` and returns the retrieved order detail.
    /// - `GetByIdQueryParam`: Handles the HTTP GET request to retrieve a specific order detail by its ID, along with an optional
    ///              personal message. It calls the `GetOrderDetailByID` method of the `_orderDetailService`, adds a personal message if
    ///              provided, and returns the order detail and the personal message.
    /// - `Create`: Handles the HTTP POST request to create a new order detail. It retrieves the product and order entities based on the
    ///             provided IDs, calls the `Create` method of the `_orderDetailService` to create the order detail, and returns the
    ///             created order detail.
    /// - `Delete`: Handles the HTTP DELETE request to delete an order detail by its ID. It calls the `Delete` method of the
    ///             `_orderDetailService` and returns a success message if the deletion is successful.
    ///
    /// 4. **Exception Handling:**
    /// The action methods include exception handling code within a try-catch block. If an exception occurs during the execution of an
    /// action, it returns an appropriate HTTP status code and an error message indicating that something went wrong.
    /// </summary>
    #endregion

    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
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

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listOrderDetail = _orderDetailService.GetAllOrderDetails();

                var listOrder = _serviceOrder.GetAllOrders();

                var ListProduct = _serviceProduct.GetAllProducts();
                return Ok(listOrderDetail);
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
                var orderDetail = _orderDetailService.GetOrderDetailByID(id);

                if (orderDetail == null)
                {
                    return NotFound("Order detail not found");
                }

                return Ok(orderDetail);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpGet("byid")]
        // Use this in URL after api/controller/ (byid?orderDetailId=1&personalMessage=Hello)
        public IActionResult GetByIdQueryParam(int orderDetailId, string? personalMessage)
        {
            try
            {
                if (string.IsNullOrEmpty(personalMessage))
                {
                    personalMessage = "This is your personal message";
                }

                var orderDetail = _orderDetailService.GetOrderDetailByID(orderDetailId);

                if (orderDetail == null)
                {
                    return NotFound("Order detail not found");
                }
                return Ok(new { orderDetail, personalMessage });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] OrderDetailDto orderDetail)
        {
            try
            {
                var product = _serviceProduct.GetProductByID(orderDetail.ProductID);
                if (product == null)
                    return BadRequest("Invalid Product ID");
                var order = _serviceOrder.GetOrderByID(orderDetail.OrderID);
                if (product == null)
                    return BadRequest("Invalid Order ID");

                var CreatedOrderDetail = _orderDetailService.Create(new Ordersystem.DataObjects.OrderDetail
                {
                    UnitPrice = orderDetail.UnitPrice,
                    Quantity = orderDetail.Quantity,
                    Product = product,
                    Order = order,
                });

                return CreatedAtAction("GetById", new { id = CreatedOrderDetail.OrderDetailID }, CreatedOrderDetail);
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
                var isDeleted = _orderDetailService.Delete(id);

                if (isDeleted)
                {
                    return Ok(new { Message = "Order detail deleted successfully" });
                }

                return BadRequest(new { Message = "Something went wrong trying to delete order detail." });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }
    }
}
