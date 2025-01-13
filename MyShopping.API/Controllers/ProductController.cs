using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Businness.Services.Interfaces;
using Shop.Core.Entities.Models;
using Shop.DataAccess.Contexts;
using Shop.DTO.CreateDTO;
using Shop.DTO.GetDTO;

namespace MyShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;
        private readonly MyShoppingAPIDbContext _context;

        public ProductController(IProductService productService, UserManager<AppUser> userManager, MyShoppingAPIDbContext context)
        {
            _productService = productService;
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllAsync();
            if (products == null)
            {
                return NotFound(new { Message = "No products found." });
            }
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _productService.GetAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(new { Message = result.Message });
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] PostProductDTO productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _productService.CreateAsync(productDto);
            if (result.Success)
            {
                return CreatedAtAction(nameof(GetProductById), new { id = productDto.ProductId }, productDto);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.RemoveAsync(id);
            if (result.Success)
            {
                return NoContent();
            }
            return NotFound(new { Message = "Product not found." });
        }
    }

}
