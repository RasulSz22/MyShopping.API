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
    public class DiscountService : IDiscountService
    {
        readonly IDiscountRepository _discountRepository;
        readonly IMapper _mapper;

        public async Task<IResult> CreateAsync(PostDiscountDTO dto)
        {
            Discount discount = _mapper.Map<Discount>(dto);
            await _discountRepository.AddAsync(discount);
            return new SuccessResult("Discount Successfully Added");
        }

        public Task<IDataResult<GetDiscountDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(int id, PostDiscountDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
