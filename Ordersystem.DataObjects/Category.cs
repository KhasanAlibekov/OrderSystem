using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordersystem.DataObjects
{
    [Table("TblCategory")]
    public class Category
    {
        [Key]
        [Column("Category_ID")]
        public int CategoryID { get; set; }
        [Required]
        [MaxLength(30)]
        [Column("Category_Name")]
        [DisplayName("Category Name")] // Client UI side validation
        public string CategoryName { get; set; }
    }
}
