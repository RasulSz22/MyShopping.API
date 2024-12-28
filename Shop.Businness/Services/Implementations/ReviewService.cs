using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public Task<IDataResult<GetReviewDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(int id, PostReviewDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
