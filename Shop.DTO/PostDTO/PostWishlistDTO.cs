using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.PostDTO
{
    public record PostWishlistDTO
    {
        public string AppUserId { get; set; }
        public List<WishlistItem> WishListItems { get; set; }
    }
}
