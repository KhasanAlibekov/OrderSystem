using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

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

        [Column("Order_ShippingDate")]
        [DisplayName("Shipping Date")]
        public DateTime ShippingDate { get; set; }
        public bool OrderStatus { get; set; }
        public bool PaymentStatus { get; set; }

        public string ApplicationUserID { get; set; }
        [ForeignKey("ApplicationUserID")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set;}

        //[ForeignKey("Product_ID")]
        //[ValidateNever]
        //public int ProductID { get; set; }
        //public Product Product { get; set; }
    }
}
