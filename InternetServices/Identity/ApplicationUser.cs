using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace InternetServices.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; } = string.Empty;
    }
}
