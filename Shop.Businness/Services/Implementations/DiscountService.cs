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
    public class DiscountService : IDiscountService
    {
        public Task<IResult> CreateAsync(PostDiscountDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<GetDiscountDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(int id, PostDiscountDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
