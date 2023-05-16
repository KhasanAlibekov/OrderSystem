using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordersystem.DataObjects
{
    [Table("TblOrder")]
    public class Order
    {
        [Key]
        [Column("Id")]
        public Guid OrderID { get; set; }
        public double OrderAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Shipped { get; set; }
        public bool PaymentReceived { get; set; }
    }
}
