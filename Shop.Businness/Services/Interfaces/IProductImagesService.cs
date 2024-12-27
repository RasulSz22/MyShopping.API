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
    public interface IProductImagesService
    {
        public Task<PagginatedResponse<GetProductİmageDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 6);
        public Task<IResult> CreateAsync(PostProductİmageDTO dto);
        public Task<IResult> RemoveAsync(int id);
        public Task<IResult> UpdateAsync(int id, PostProductİmageDTO dto);
        public Task<IDataResult<GetProductİmageDTO>> GetAsync(int id);

    }
}
