using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.PostDTO
{
    public record PostReviewDTO
    {
        public int Rating { get; set; } 
        public string Content { get; set; } 
        public int ProductId { get; set; } 
        public string AppUserId { get; set; }
    }
}
