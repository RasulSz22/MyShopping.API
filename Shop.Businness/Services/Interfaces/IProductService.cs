using Shop.Businness.Responses;
using Shop.Core.Utilities.Results.Abstract;
using Shop.DTO.CreateDTO;
using Shop.DTO.GetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Services.Interfaces
{
    public interface IProductService
    {
        public Task<PagginatedResponse<GetProductDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 6);
        public Task<IResult> CreateAsync(PostProductDTO dto);
        public Task<IResult> RemoveAsync(int id);
        public Task<IResult> UpdateAsync(int id, PostProductDTO dto);
        public Task<IDataResult<GetProductDTO>> GetAsync(int id);
    }
}
