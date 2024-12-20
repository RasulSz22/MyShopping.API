using Shop.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities.Models
{
    public class Shipping : BaseEntity
    {
        public Order OrderId { get; set; }
        public string ShippingMethod { get; set; }
        public string TrackingNumber { get; set; } 
        public DateTime ShippedDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public string Status { get; set; } 
    }
}
