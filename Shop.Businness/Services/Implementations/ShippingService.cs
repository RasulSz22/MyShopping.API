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
    public class ShippingService : IShippingService
    {
        public Task<IResult> CreateAsync(PostShippingDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<GetShippingDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(int id, PostShippingDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
