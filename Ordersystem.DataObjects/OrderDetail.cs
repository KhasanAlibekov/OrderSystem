using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ordersystem.DataObjects
{
    [Table("TblOrderDetail")]
    public class OrderDetail
    {
        [Key]
        [Column("OrderDetail_Id")]
        public int OrderDetailID { get; set; }

        [DisplayName("Unit Price")]
        [Column("OrderDetail_UnitPrice")]
        public double UnitPrice { get; set; }

        [Column("OrderDetail_Quantity")]
        public int Quantity { get; set; }

        [ForeignKey("Order")]
        [ValidateNever]
        public int OrderID { get; set; }
        public Order Order { get; set; }

        [ForeignKey("Product")]
        [ValidateNever]
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
