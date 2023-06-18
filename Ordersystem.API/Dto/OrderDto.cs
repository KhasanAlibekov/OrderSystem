using System.ComponentModel.DataAnnotations;

namespace Ordersystem.API.Dto
{
    public class OrderDto
    {
        [Required(ErrorMessage = "Please provide an order count")]
        public int OrderCount { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderStatus { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
