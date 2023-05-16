using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordersystem.DataObjects
{
    public class OrderDetail
    {
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
