using Shop.Businness.Responses;
using Shop.Core.Entities.Models;
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
    public interface IAddressService
    {
        public Task<PagginatedResponse<GetAddressDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 5);
        public Task<IResult> CreateAsync(PostAddressDTO dto);
        public Task<IResult> RemoveAsync(int id);
        public Task<IResult> UpdateAsync(int id, PostAddressDTO dto);
        public Task<IDataResult<GetAddressDTO>> GetAsync(int id);
    }
}
