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
    public class ProductImageService : IProductImagesService
    {
        public async Task<IResult> CreateAsync(PostProductİmageDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<PagginatedResponse<GetProductİmageDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 6)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<GetProductİmageDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> UpdateAsync(int id, PostProductİmageDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
