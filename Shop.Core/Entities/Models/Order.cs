using Shop.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities.Models
{
    public class Order : BaseEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string? Address { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public int PaymentId {  get; set; }
        public string? DeliveryStatus { get; set; }
        public DateTime? DeliveryTime { get; set; }
    }
}
