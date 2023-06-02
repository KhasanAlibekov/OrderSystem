using System.ComponentModel.DataAnnotations;

namespace Ordersystem.API.Dto
{
    public class CategoryDto
    {
        [Required(ErrorMessage = "Please provide a category name")]
        public string CategoryName { get; set; }
    }
}
