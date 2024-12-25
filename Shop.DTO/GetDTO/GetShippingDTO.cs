using Shop.Core.Entities.Enums;
using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.GetDTO
{
    public record GetShippingDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public ShippingTypes ShippingMethod { get; set; }
        public string TrackingNumber { get; set; }
        public string Status { get; set; }
    }
}
