using AutoMapper;
using Shop.Businness.Responses;
using Shop.Businness.Services.Interfaces;
using Shop.Core.Entities.Models;
using Shop.Core.Utilities.Results.Abstract;
using Shop.Core.Utilities.Results.Concrete.SuccessResults;
using Shop.DataAccess.Repositories.Interfaces;
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
        readonly IAddressRepository _addressRepository;
        readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateAsync(GetAddressDTO dto)
        {
            Address address = _mapper.Map<Address>(dto);
            await _addressRepository.AddAsync(address);
            return new SuccessResult("Address Successfully Added");
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