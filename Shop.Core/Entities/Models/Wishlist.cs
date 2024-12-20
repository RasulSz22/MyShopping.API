using Shop.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities.Models
{
    public class Wishlist : BaseEntity
    {
 
        public ICollection<WishlistItem> WishlistItems { get; set; }
    }
}
