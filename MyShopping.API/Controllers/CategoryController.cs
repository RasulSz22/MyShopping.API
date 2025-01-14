using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Businness.Services.Interfaces;
using Shop.Core.Entities.Models;
using Shop.DataAccess.Contexts;
using Shop.DTO.PostDTO;

namespace MyShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;
        private readonly MyShoppingAPIDbContext _context;

        public CategoryController(
            ICategoryService categoryService,
            UserManager<AppUser> userManager,
            MyShoppingAPIDbContext context)
        {
            _categoryService = categoryService;
            _userManager = userManager;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] PostCategoryDTO dto)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            //if (currentUser == null)
            //{
            //    return Unauthorized("User not logged in");
            //}

            var result = await _categoryService.CreateAsync(dto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 6)
        {
            var result = await _categoryService.GetAllAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _categoryService.GetAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] PostCategoryDTO dto)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Unauthorized("User not logged in");
            }

            var result = await _categoryService.UpdateAsync(id, dto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return NotFound(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Unauthorized("User not logged in");
            }

            var result = await _categoryService.RemoveAsync(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return NotFound(result.Message);
        }
    }

}
