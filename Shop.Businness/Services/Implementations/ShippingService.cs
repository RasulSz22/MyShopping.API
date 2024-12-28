using AutoMapper;
using Shop.Businness.Services.Interfaces;
using Shop.Core.Entities.Models;
using Shop.Core.Utilities.Results.Abstract;
using Shop.Core.Utilities.Results.Concrete.SuccessResults;
using Shop.DataAccess.Repositories.Interfaces;
using Shop.DTO.GetDTO;
using Shop.DTO.PostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Services.Implementations
{
    public class ShippingService : IShippingService
    {
        readonly IShippingRepository _shippingRepository;
        readonly IMapper _mapper;

        public ShippingService(IShippingRepository shippingRepository, IMapper mapper)
        {
            _shippingRepository = shippingRepository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateAsync(PostShippingDTO dto)
        {
            Shipping shipping = _mapper.Map<Shipping>(dto);
            await _shippingRepository.AddAsync(shipping);
            return new SuccessResult("Shipping Successfully Added");
        }

        public Task<IDataResult<GetShippingDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(int id, PostShippingDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
