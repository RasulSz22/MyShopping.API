using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.UserDTO
{
    public record RegisterDTO
    {
        [Required(ErrorMessage = "Username must be entered!")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Username must be between 2 and 25 characters!")]
        public string Username { get; set; } = null;
        [Required(ErrorMessage = "Email must be entered!")]
        [StringLength(40, MinimumLength = 10, ErrorMessage = "Email must be between 10 and 40 characters!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Wrong Email!")]
        public string Email { get; set; } = null;
        [Required(ErrorMessage = "Password must be entered!")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 25 characters!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password!")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 25 characters!")]
        [Compare(nameof(Password), ErrorMessage = "Password must be the same!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string Role { get; init; }
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept terms!")]
        public bool Terms { get; set; }

    }
}
