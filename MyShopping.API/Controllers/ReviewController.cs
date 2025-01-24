using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Businness.Services.Interfaces;
using Shop.DTO.PostDTO;

namespace MyShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        [Authorize] 
        public async Task<IActionResult> CreateAsync([FromBody] PostReviewDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _reviewService.CreateAsync(dto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _reviewService.GetAsync(id);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpDelete("{id:int}")]
        [Authorize] 
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await _reviewService.RemoveAsync(id);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] PostReviewDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _reviewService.UpdateAsync(id, dto);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Message);
        }
    }
}
