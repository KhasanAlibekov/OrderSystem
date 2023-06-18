using System.ComponentModel.DataAnnotations;

namespace Ordersystem.API.Dto
{
    public class OrderDetailDto
    {
        [Required(ErrorMessage = "Please provide a Order Detail")]
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please provide a Order ID")]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Please provide a Product ID")]
        public int ProductID { get; set; }
    }
}
