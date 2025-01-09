using Shop.Core.Utilities.Results.Abstract;
using Shop.DTO.GetDTO;
using Shop.DTO.PostDTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Services.Interfaces
{
    public interface ILikedService
    {
        public Task<GetWishlistDTO> GetWishlist();
        //public Task AddToWishList(int itemId, string itemType);
        public Task<IResult> AddToWishList(PostWishlistDTO dto);
    }
}
