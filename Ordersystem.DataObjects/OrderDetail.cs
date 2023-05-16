using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordersystem.DataObjects
{
    [Table("TblOrderDetail")]
    public class OrderDetail
    {
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(Order))]
        public int OrderID { get; set; }
        public Order Order { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
