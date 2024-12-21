using Shop.Core.Entities.Common;
using Shop.Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities.Models
{
    public class WishlistItem : BaseEntity
    {
        public int WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public bool IsLiked { get; set; }
    }
}
