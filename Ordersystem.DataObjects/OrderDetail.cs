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
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than zero.")]
        public double UnitPrice { get; set; }

        [Column("OrderDetail_Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int Quantity { get; set; }

        [ForeignKey("Order")]
        [ValidateNever]
        public int OrderID { get; set; }
        public Order? Order { get; set; }

        [ForeignKey("Product")]
        [ValidateNever]
        public int ProductID { get; set; }
        public Product? Product { get; set; }
    }
}
