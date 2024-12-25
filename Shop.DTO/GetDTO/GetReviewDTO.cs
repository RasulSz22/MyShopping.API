using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.GetDTO
{
    public record GetReviewDTO
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string AppUserId { get; set; }
        public string AppUserName { get; set; }
    }
}
