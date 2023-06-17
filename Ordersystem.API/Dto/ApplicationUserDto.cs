using System.ComponentModel.DataAnnotations;

namespace Ordersystem.API.Dto
{
    public class ApplicationUserDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
