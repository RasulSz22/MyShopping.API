using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.GetDTO
{
    public record GetWishlistDTO
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public string AppUserName { get; set; }
        public List<GetWishlistItemDTO> WishListItems { get; set; }
        public GetWishlistDTO()
        {
            WishListItems = new List<GetWishlistItemDTO>();
        }
    }
}
