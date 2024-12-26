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
    public interface ICartItemService
    {
        public Task<PagginatedResponse<GetCartItemDTO>> GetAllAsync(int pageNumber = 1,int pageSize = 6);
        public Task<IResult> CreateAsync(PostCartItemDTO dto);
        public Task<IResult> UpdateAsync(int id, PostCartItemDTO dto);
        public Task<IDataResult<GetCartItemDTO>> GetAsync(int id);
    }
}
