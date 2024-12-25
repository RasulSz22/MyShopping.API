using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.CreateDTO
{
    public record PostOrderDTO
    {
        public string AppUserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        public int PaymentId { get; set; }
        public string? DeliveryStatus { get; set; }
        public DateTime? DeliveryTime { get; set; }
    }
}
