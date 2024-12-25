using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.PostDTO
{
    public record PostOrderItemDTO
    {
        public string AppUserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public int PaymentId { get; set; }
    }
}
