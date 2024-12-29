using Microsoft.AspNetCore.Identity;
using Shop.Businness.Services.Interfaces;
using Shop.Core.Entities.Models;
using Shop.DataAccess.Repositories.Interfaces;
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

        private readonly UserManager<AppUser> _userManager;
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IWishlistItemRepository _wishlistItemRepository;
        private readonly IProductRepository _productRepository;

        public LikedService(UserManager<AppUser> userManager, IWishlistRepository wishlistRepository, IWishlistItemRepository wishlistItemRepository, IProductRepository productRepository)
        {
            _userManager = userManager;
            _wishlistRepository = wishlistRepository;
            _wishlistItemRepository = wishlistItemRepository;
            _productRepository = productRepository;
        }

        public async Task AddToWishList(int itemId, string itemType)
        {
            throw new NotImplementedException();
        }

        public async Task<GetWishlistDTO> GetWishlist()
        {
            throw new NotImplementedException();
        }
    }
}
