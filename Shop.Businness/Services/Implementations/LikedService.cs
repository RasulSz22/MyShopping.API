using Shop.Businness.Services.Interfaces;
using Shop.DTO.GetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Services.Implementations
{
    public class LikedService : ILikedService
    {
        public Task AddToWishList(int itemId, string itemType)
        {
            throw new NotImplementedException();
        }

        public Task<GetWishlistDTO> GetWishlist()
        {
            throw new NotImplementedException();
        }
    }
}
