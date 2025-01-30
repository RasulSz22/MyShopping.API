using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Businness.Services.Implementations;
using Shop.Businness.Services.Interfaces;
using Shop.DTO.GetDTO;
using Shop.DTO.PostDTO;

namespace MyShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemsService _orderItemService;

        public OrderItemsController(IOrderItemsService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetOrderItemDTO>>> GetAll()
        {
            var result = await _orderItemService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetOrderItemDTO>> Get(int id)
        {
            var result = await _orderItemService.GetAsync(id);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PostOrderItemDTO dto)
        {
            var result = await _orderItemService.CreateAsync(dto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return CreatedAtAction(nameof(Get), new { id = dto.ProductId }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PostOrderItemDTO dto)
        {
            var result = await _orderItemService.UpdateAsync(id, dto);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _orderItemService.RemoveAsync(id);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return NoContent();
        }
    }
}