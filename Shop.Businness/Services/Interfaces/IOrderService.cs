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
    public interface IOrderService
    {
        public Task<IResult> CreateAsync(PostOrderDTO dto);

        public Task<IResult> RemoveAsync(int id);

        public Task<IResult> UpdateAsync(int id, PostOrderDTO dto);
        public Task<IDataResult<GetOrderDTO>> GetAsync(int id);
    }

}
