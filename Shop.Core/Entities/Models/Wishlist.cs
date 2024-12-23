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

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<WishlistItem> WishListItems { get; set; }
    }
}
