using Shop.Businness.Services.Interfaces;
using Shop.Core.Utilities.Results.Abstract;
using Shop.DTO.CreateDTO;
using Shop.DTO.GetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Services.Implementations
{
    public class ProductService : IProductService
    {
        public async Task<IResult> CreateAsync(PostProductDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<GetProductDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> UpdateAsync(int id, PostProductDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
