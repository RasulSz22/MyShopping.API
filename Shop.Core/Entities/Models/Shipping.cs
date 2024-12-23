using Shop.Core.Entities.Common;
using Shop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities.Models
{
    public class Shipping : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public ShippingTypes ShippingMethod { get; set; }
        public string TrackingNumber { get; set; } 
        public string Status { get; set; } 
    }
}
