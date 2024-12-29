using AutoMapper;
using Shop.Businness.Responses;
using Shop.Businness.Services.Interfaces;
using Shop.Core.Entities.Models;
using Shop.Core.Utilities.Results.Abstract;
using Shop.Core.Utilities.Results.Concrete.ErrorResults;
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

        public async Task<IResult> CreateAsync(PostAddressDTO dto)
        {
            Address address = _mapper.Map<Address>(dto);
            await _addressRepository.AddAsync(address);
            return new SuccessResult("Address Successfully Added");
        }

        public async Task<PagginatedResponse<GetAddressDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 5)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<GetAddressDTO>> GetAsync(int id)
        {
            var Address = _addressRepository.GetAsync(x=> !x.IsDeleted && x.Id == id).Result;
            if (Address == null)
            {
                return new ErrorDataResult<GetAddressDTO>("Address Not Found");
            }
            GetAddressDTO dto = new GetAddressDTO()
            {
                Id = Address.Id,
                Street = Address.Street,
                City = Address.City,
                PostalCode = Address.PostalCode,
            };
            return new SuccessDataResult<GetAddressDTO>(dto,"Get Address");
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            Address address = await _addressRepository.GetAsync(x => !x.IsDeleted && x.Id == id);
            if (address == null) 
            {
                return new ErrorResult("Address Not Found");
            }
            address.IsDeleted = true;
            await _addressRepository.UpdateAsync(address);
            return new SuccessResult("Address Removed");
        }

        public async Task<IResult> UpdateAsync(int id, PostAddressDTO dto)
        {
            Address address = await _addressRepository.GetAsync(x => !x.IsDeleted && x.Id == id, "User");
            if (address == null) 
            {
                return new ErrorResult("Address Not Found");
            }
            address.Street = dto.Street;
            address.City = dto.City;
            address.PostalCode = dto.PostalCode;
            address.AppUserId = dto.AppUserId;
            await _addressRepository.UpdateAsync(address);
            return new SuccessResult("Address Successfully Updated");
        }
    }
}