using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.PostDTO
{
    public record PostWishlistItemDTO
    {
        public int WishlistId { get; set; }
        public int ProductId { get; set; }
        public bool IsLiked { get; set; }
    }
}
