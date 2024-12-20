using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.GetDTO
{
    public record GetOrderDTO
    {
        public int ID { get; set; }
        public int CustomerId { get; set; }
        public string? Address { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        public Address? ShippingAdress { get; set; }
        public List<Product>? OrderItems { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentStatus { get; set; }
        public DateTime? DeliveryTime { get; set; }
    }
}
