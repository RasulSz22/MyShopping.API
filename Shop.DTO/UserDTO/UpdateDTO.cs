using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.UserDTO
{
    public record UpdateDTO
    {
        [Required(ErrorMessage = "Username must be entered!")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Username must be between 2 and 25 characters")]
        public string UserName { get; set; } = null!;
        [DataType(DataType.Password)]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 25 characters")]
        public string? OldPassword { get; set; }
        [DataType(DataType.Password)]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 25 characters")]
        public string? NewPassword { get; set; }
    }
}
