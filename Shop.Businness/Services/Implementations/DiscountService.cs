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

        public async Task<IDataResult<GetDiscountDTO>> GetAsync(int id)
        {
            var Discount = _discountRepository.GetAsync(x=>!x.IsDeleted && x.Id == id).Result;
            if(Discount == null)
            {
                return new ErrorDataResult<GetDiscountDTO>("Review Not Found");
            }

            GetDiscountDTO dto = new GetDiscountDTO()
            {
                Id = Discount.Id,
                Promocode = Discount.Promocode,
                DiscountPercentage = Discount.DiscountPercentage,
            };
            return new SuccessDataResult<GetDiscountDTO>(dto,"Get Discount");
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            Discount discount = await _discountRepository.GetAsync(x => !x.IsDeleted && x.Id == id);
            if (discount == null)
            {
                return new ErrorResult("Discount Not Found");
            }
            discount.IsDeleted = true;
            await _discountRepository.UpdateAsync(discount);
            return new SuccessResult("Discount Removed");
        }

        public async Task<IResult> UpdateAsync(int id, PostDiscountDTO dto)
        {
            Discount discount = await _discountRepository.GetAsync(x => !x.IsDeleted && x.Id == id, "Product");
            if(discount == null)
            {
                return new ErrorResult("Discount Not Found");
            }
            discount.Promocode = dto.Promocode;
            discount.DiscountPercentage = dto.DiscountPercentage;
            await _discountRepository.UpdateAsync(discount);
            return new SuccessResult("Discount Successfully Updated");
        }
    }
}
