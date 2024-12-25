using Shop.Core.Entities.Enums;
using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.PutDTO
{
    public record PutShippingDTO
    {
        public int Id { get; set; }
        public ShippingTypes ShippingMethod { get; set; }
        public string TrackingNumber { get; set; }
        public string Status { get; set; }
        public int OrderId {  get; set; }
    }
}
