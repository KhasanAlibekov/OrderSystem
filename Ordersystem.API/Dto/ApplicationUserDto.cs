using System.ComponentModel.DataAnnotations;

namespace Ordersystem.API.Dto
{
    #region User Infromation
    /// <summary>
    /// The `ApplicationUserDto` class is a data transfer object (DTO) that represents the data structure used for transferring user
    /// information in the application. It typically serves as a lightweight container for data that needs to be transferred between
    /// different layers or components of the application, such as between the client and server.
    /// 
    /// In this specific class, the `ApplicationUserDto` has several properties that represent user-related information, including:
    ///     - `UserName`: The username of the user.
    ///     - `Password`: The password of the user.
    ///     - `Email`: The email address of the user.
    ///     - `Name`: The name of the user.
    ///     - `StreetAddress`: The street address of the user.
    ///     - `City`: The city of residence of the user.
    ///     - `PostalCode`: The postal code or ZIP code of the user's location.
    /// </summary> 
    #endregion
    public class ApplicationUserDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
    }
}
