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
    public interface IPaymentService
    {
        public Task<IResult> CreateAsync(PostPaymentDTO dto);

        public Task<IResult> RemoveAsync(int id);

        public Task<IResult> UpdateAsync(int id, PostPaymentDTO dto);
        public Task<IDataResult<GetPaymentDTO>> GetAsync(int id);
    }
}
