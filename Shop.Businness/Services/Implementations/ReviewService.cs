using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class ReviewService : IReviewService
    {
        readonly IReviewRepository _reviewRepository;
        readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateAsync(PostReviewDTO dto)
        {
            Review review = _mapper.Map<Review>(dto);
            await _reviewRepository.AddAsync(review);
            return new SuccessResult("Review Successfully Added");
        }

        public async Task<IDataResult<GetReviewDTO>> GetAsync(int id)
        {
            var Review = _reviewRepository.GetAsync(x=>!x.IsDeleted && x.Id == id).Result;
            if(Review == null)
            {
                return new ErrorDataResult<GetReviewDTO>("Review Not Found");
            }
            GetReviewDTO dto = new GetReviewDTO()
            {
                Id = Review.Id,
                ProductId = Review.ProductId,
                AppUserId = Review.AppUserId,
            };
            return new SuccessDataResult<GetReviewDTO>(dto,"Get Review");
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            Review review = await _reviewRepository.GetAsync(x => !x.IsDeleted && x.Id == id, "Product");

            if (review == null) 
            {
                return new ErrorResult("Review Not Found");
            }
            review.IsDeleted = true;
            await _reviewRepository.UpdateAsync(review);
            return new SuccessResult("Review Removed Successfully");
        }

        public async Task<IResult> UpdateAsync(int id, PostReviewDTO dto)
        {
            Review review = await _reviewRepository.GetAsync(x => !x.IsDeleted && x.Id == id);
            if (review == null)
            {
                return new ErrorResult("Review Not Found");
            }
            review.Content = dto.Content;
            review.AppUserId = dto.AppUserId;
            review.ProductId = dto.ProductId;
            await _reviewRepository.UpdateAsync(review);
            return new SuccessResult("Review Successfully Updated");
        }
    }
}
