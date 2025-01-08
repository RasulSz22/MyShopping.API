using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Businness.Services.Implementations;
using Shop.Businness.Services.Interfaces;
using Shop.Core.Entities.Models;
using Shop.DataAccess.Contexts;
using Shop.DTO.GetDTO;

namespace MyShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikedService _service;
        private readonly UserManager<AppUser> _userManager;
        private readonly MyShoppingAPIDbContext _context;

        public LikeController(ILikedService service, UserManager<AppUser> userManager, MyShoppingAPIDbContext context)
        {
            _service = service;
            _userManager = userManager;
            _context = context;
        }
        [HttpGet("wishlist")]
        public async Task<IActionResult> Wishlist()
        {
            GetWishlistDTO dto = await _service.GetWishlist();
            if(dto is null)
            {
                return NotFound(new { message = "Wishlist is empty or not found." });
            }
            return Ok(dto);
        }

        [HttpPost("wishlist/add")]
        public async Task<IActionResult> AddToWishlist(int itemId, string itemType)
        {
            try
            {
                await _service.AddToWishList(itemId, itemType);
                return Ok(new { message = "Product successfully added to wishlist." });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
