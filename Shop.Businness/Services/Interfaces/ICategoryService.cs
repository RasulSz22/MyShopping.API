using Shop.Businness.Responses;
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
    public interface ICategoryService
    {
        public Task<IResult> CreateAsync(PostCategoryDTO dto);
        public Task<IResult> UpdateAsync(int id,PostCategoryDTO dto);
        public Task<IResult> RemoveAsync(int id);
        public Task<IDataResult<GetCategoryDTO>> GetAsync(int id); 
    }
}
