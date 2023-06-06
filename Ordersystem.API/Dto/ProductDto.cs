using System.ComponentModel.DataAnnotations;

namespace Ordersystem.API.Dto
{
    public class ProductDto
    {
        [Required(ErrorMessage = "Please provide a product name")]
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int UnitInStock { get; set; }
        public string ImageUrl { get; set; }
    }
}
