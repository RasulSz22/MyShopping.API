using Shop.Businness.Responses;
using Shop.Businness.Services.Interfaces;
using Shop.Core.Utilities.Results.Abstract;
using Shop.DTO.GetDTO;
using Shop.DTO.PostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Services.Implementations
{
    public class OrderItemsService : IOrderItemsService
    {
        public async Task<IResult> CreateAsync(PostOrderItemDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<PagginatedResponse<GetOrderDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 6)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<GetOrderItemDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> UpdateAsync(int id, PostOrderItemDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<PagginatedResponse<GetOrderItemDTO>> IOrderItemsService.GetAllAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
