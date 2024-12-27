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
    public interface IShippingService
    {
        public Task<IResult> CreateAsync(PostShippingDTO dto);

        public Task<IResult> RemoveAsync(int id);

        public Task<IResult> UpdateAsync(int id, PostShippingDTO dto);
        public Task<IDataResult<GetShippingDTO>> GetAsync(int id);
    }
}
