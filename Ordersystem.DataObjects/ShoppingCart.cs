using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordersystem.DataObjects
{
    public class ShoppingCart
    {
        [Key] public int Id { get; set; }
        public int ShoppingCartID { get; set; }
        public string ApplicationUserID { get; set; }
        public ApplicationUser? ApplicationUser { get;}
        public OrderDetail OrderDetail { get; set; }
        public int OrderDetailID { get; set; }
    }
}
