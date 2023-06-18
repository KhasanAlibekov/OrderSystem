using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ordersystem.DataObjects
{
    [Table("TblOrder")]
    public class Order
    {
        [Key]
        [Column("Order_Id")]
        public int OrderID { get; set; }

        [Range(1, 999, ErrorMessage = "Please enter a value between 1 and 999")]
        [Column("Order_OrderCount")]
        [DisplayName("Count")]
        public int OrderCount { get; set; }

        [Column("Order_OrderDate")]
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Order Status")]
        public bool OrderStatus { get; set; }

        [DisplayName("Payment Status")]
        public bool PaymentStatus { get; set; }
    }
}
