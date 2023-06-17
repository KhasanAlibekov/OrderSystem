using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordersystem.API.Dto;
using Ordersystem.Services;

namespace Ordersystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class API_OrderDetailController : ControllerBase
    {
        IOrderDetailService _orderDetailService;
        IProductService _serviceProduct;
        IOrderService _serviceOrder;
        public API_OrderDetailController(IOrderDetailService orderDetailService, IProductService serviceProduct, IOrderService serviceOrder)
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
                });


                return CreatedAtAction("GetById", new { id = CreatedOrderDetail.OrderDetailID }, CreatedOrderDetail);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }
    }
}
