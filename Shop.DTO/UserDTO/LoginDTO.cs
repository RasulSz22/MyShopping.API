using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.UserDTO
{
    public record LoginDTO
    {
        [Required(ErrorMessage = "Username or Email must be entered!")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Username or Email must be between 5 and 255 characters!")]
        [RegularExpression(@"^(?:(?![@._])[a-zA-Z0-9@._-]{3,})$|^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Wrong Format!")]
        public string UsernameOrEmail { get; set; } = null;
        [Required(ErrorMessage = "Password must be entered!")]
        [DataType(DataType.Password)]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 25 characters!")]
        public string Password { get; set; } = null;
        [Required]
        public bool RememberMe {  get; set; }
    }
}
