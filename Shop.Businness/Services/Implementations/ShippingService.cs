using AutoMapper;
using Shop.Businness.Services.Interfaces;
using Shop.Core.Entities.Models;
using Shop.Core.Utilities.Results.Abstract;
using Shop.Core.Utilities.Results.Concrete.ErrorResults;
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

        public async Task<IDataResult<GetShippingDTO>> GetAsync(int id)
        {
            var Shipping = _shippingRepository.GetAsync(x => !x.IsDeleted && x.Id == id).Result;
            if (Shipping == null)
            {
                return new ErrorDataResult<GetShippingDTO>("Shipping Not Found");
            }
            GetShippingDTO dto = new GetShippingDTO()
            {
                Id = Shipping.Id,
                Status = Shipping.Status,
            };
            return new SuccessDataResult<GetShippingDTO>(dto, "Get Shipping");
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            Shipping shipping = await _shippingRepository.GetAsync(x => !x.IsDeleted && x.Id == id);
            if (shipping == null)
            {
                return new ErrorResult("Shipping Not Found");
            }
            shipping.IsDeleted = true;
            return new SuccessResult("Shipping Removed");
        }

        public async Task<IResult> UpdateAsync(int id, PostShippingDTO dto)
        {
            Shipping shipping = await _shippingRepository.GetAsync(x => !x.IsDeleted && x.Id == id, "Product");
            if (shipping == null)
            {
                return new ErrorResult("Shipping Not Found");
            }
            shipping.Status = dto.Status;
            await _shippingRepository.UpdateAsync(shipping);
            return new SuccessResult("Shipping Successfuly Updated");
        }
    }
}
