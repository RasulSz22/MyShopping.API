using Shop.Businness.Responses;
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
    public class AddressService : IAddressService
    {


        public Task<IResult> CreateAsync(GetAddressDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<PagginatedResponse<GetAddressDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 5)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<GetAddressDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(int id, PostAddressDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}