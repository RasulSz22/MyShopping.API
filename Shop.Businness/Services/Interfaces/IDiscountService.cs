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
    public interface IDiscountService
    {
        public Task<IResult> CreateAsync(PostDiscountDTO dto);

        public Task<IResult> RemoveAsync(int id);

        public Task<IResult> UpdateAsync(int id, PostDiscountDTO dto);
        public Task<IDataResult<GetDiscountDTO>> GetAsync(int id);
    }
}
