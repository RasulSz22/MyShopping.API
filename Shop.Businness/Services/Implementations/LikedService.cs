using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Businness.Services.Interfaces;
using Shop.Core.Entities.Models;
using Shop.Core.Utilities.Results.Abstract;
using Shop.Core.Utilities.Results.Concrete.ErrorResults;
using Shop.Core.Utilities.Results.Concrete.SuccessResults;
using Shop.DataAccess.Repositories.Implementations;
using Shop.DataAccess.Repositories.Interfaces;
using Shop.DTO.GetDTO;
using Shop.DTO.PostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Shop.Core.Utilities.Results.Abstract.IResult;

namespace Shop.Businness.Services.Implementations
{
    public class LikedService : ILikedService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IWishlistItemRepository _wishlistItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IHttpContextAccessor _http;
        private readonly IMapper _mapper;

        public LikedService(UserManager<AppUser> userManager, IWishlistRepository wishlistRepository, IWishlistItemRepository wishlistItemRepository, IProductRepository productRepository, IHttpContextAccessor http, IMapper mapper)
        {
            _userManager = userManager;
            _wishlistRepository = wishlistRepository;
            _wishlistItemRepository = wishlistItemRepository;
            _productRepository = productRepository;
            _http = http;
            _mapper = mapper;
        }

        public async Task<GetWishlistDTO> GetWishlist()
        {
            if (!_http.HttpContext.User.Identity.IsAuthenticated)
            {
                throw new UnauthorizedAccessException("User is not authenticated.");
            }

            var username = _http.HttpContext.User.Identity.Name;
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                throw new Exception("User not found.");
            }

            var wishlist = await _wishlistRepository.GetAsync(x => x.AppUserId == appUser.Id);
            if (wishlist == null)
            {
                return new GetWishlistDTO
                {
                    Id = 0,
                    AppUserId = appUser.Id,
                    AppUserName = appUser.UserName,
                    WishListItems = new List<GetWishlistItemDTO>()
                };
            }

            var wishlistItems = await _wishlistItemRepository.GetListAsync(
                x => x.WishlistId == wishlist.Id,
                include: i => i.Include(wi => wi.Product)
            );


            var itemDtos = wishlistItems.Select(x => new GetWishlistItemDTO
            {
                ProductId = x.Product.Id,
                ProductName = x.Product.Name,
                ProductDescription = x.Product.Description,
                ProductPrice = x.Product.Price,
                ProductStock = x.Product.Stock
            }).ToList();

            return new GetWishlistDTO
            {
                Id = wishlist.Id,
                AppUserId = appUser.Id,
                AppUserName = appUser.UserName,
                WishListItems = itemDtos
            };
        }

        public async Task<IResult> AddToWishList(PostWishlistDTO dto)
        {
            try
            {
                var wishlist = _mapper.Map<Wishlist>(dto);
                await _wishlistRepository.AddAsync(wishlist);
                await _wishlistRepository.SaveChangesAsync();
                return new SuccessResult("Wishlist created successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult("Failed to create shipping.");
            }
        }

        Task<Core.Utilities.Results.Abstract.IResult> ILikedService.AddToWishList(PostWishlistDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
