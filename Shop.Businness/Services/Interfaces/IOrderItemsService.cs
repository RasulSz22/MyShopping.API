using Shop.Businness.Responses;
using Shop.Core.Utilities.Results.Abstract;
using Shop.DTO.GetDTO;
using Shop.DTO.PostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Services.Interfaces
{
    public interface IOrderItemsService
    {
        public Task<List<GetOrderItemDTO>> GetAllAsync();
        public Task<IResult> CreateAsync(PostOrderItemDTO dto);
        public Task<IResult> RemoveAsync(int id);
        public Task<IResult> UpdateAsync(int id, PostOrderItemDTO dto);
        public Task<IDataResult<GetOrderItemDTO>> GetAsync(int id);
    }
}
