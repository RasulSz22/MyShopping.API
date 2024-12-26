using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.UserDTO
{
    public record ResetPasswordDTO

    {
        [Required(ErrorMessage = "Email must be entered!")]
        [StringLength(40, MinimumLength = 10, ErrorMessage = "Email must be between 10 and 40 characters")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Wrong Email!")]
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
        [Required(ErrorMessage = "New Password must be entered!")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "New Password must be between 8 and 25 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
