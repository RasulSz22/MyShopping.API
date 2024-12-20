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
        public int UserId { get; set; }
        public string? Address { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        public Address? ShippingAdress { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Order() 
        {
            OrderItems = new List<OrderItem>();
        }
        public Payment? Payment { get; set; }
        public string? DeliveryStatus { get; set; }
        public DateTime? DeliveryTime { get; set; }
    }
}
