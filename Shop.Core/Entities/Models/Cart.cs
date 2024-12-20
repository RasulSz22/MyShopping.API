using Shop.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities.Models
{
    public class Cart : BaseEntity
    {
        public User UserId { get; set; }
        public Cart Parent { get; set; }
        public int CartItemId {  get; set; }
        public ICollection<CartItem> CartItems { get; set; }

        public Cart() 
        {
            CartItems = new List<CartItem>();
        }
    }
}
