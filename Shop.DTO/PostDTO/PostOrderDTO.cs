using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.CreateDTO
{
    public record PostOrderDTO
    {
        public int CustomerId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentStatus { get; set; }
        public DateTime? DeliveryTime { get; set; }
    }
}
