using Shop.Core.Utilities.Results.Abstract;
using Shop.DTO.GetDTO;
using Shop.DTO.PostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Services.Interfaces
{
    public interface IReviewService
    {
        public Task<IResult> CreateAsync(PostReviewDTO dto);

        public Task<IResult> RemoveAsync(int id);

        public Task<IResult> UpdateAsync(int id, PostReviewDTO dto);
        public Task<IDataResult<GetReviewDTO>> GetAsync(int id);
    }
}
