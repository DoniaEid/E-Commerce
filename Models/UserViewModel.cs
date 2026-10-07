using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class UserViewModel
    {
        [Required]
        public string First_Name { get; set; }

        [Required]
        public string Last_Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string password { get; set; }

        public string? Address { get; set; }
        public string? PhoneNumber{ get; set; }

    }
}
