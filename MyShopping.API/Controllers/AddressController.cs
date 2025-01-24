using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Businness.Services.Interfaces;
using Shop.DTO.CreateDTO;

namespace MyShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync([FromBody] PostAddressDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _addressService.CreateAsync(dto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 5)
        {
            var result = await _addressService.GetAllAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _addressService.GetAsync(id);
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
            var result = await _addressService.RemoveAsync(id);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] PostAddressDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _addressService.UpdateAsync(id, dto);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Message);
        }
    }
}
