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
    public class PaymentService : IPaymentService
    {
        public async Task<IResult> CreateAsync(PostPaymentDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<GetPaymentDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> UpdateAsync(int id, PostPaymentDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
