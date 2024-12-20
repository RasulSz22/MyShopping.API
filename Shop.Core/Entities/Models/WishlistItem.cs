using Shop.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities.Models
{
    public class WishlistItem : BaseEntity
    {
        public Wishlist WishlistId { get; set; }
        public Product ProductId { get; set; }
    }
}
