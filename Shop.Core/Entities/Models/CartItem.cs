using Shop.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities.Models
{
    public class CartItem : BaseEntity
    {
        public Cart Cart { get; set; }
        public int CartId {  get; set; }
        public int Quantity { get; set; }
    }
}
