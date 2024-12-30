using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Businness.Extensions;
using Shop.Businness.Responses;
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
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository _categoryRepository;
        readonly IMapper _mapper;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<IResult> CreateAsync(PostCategoryDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Name))
            {
                return new ErrorResult("Category name is required!");
            }

            if (dto.ParentId != null)
            {
                var parentCategory = await _categoryRepository.GetAsync(x => x.Id == dto.ParentId);
                var subCategory = _mapper.Map<Category>(dto);
                subCategory.ParentId = parentCategory.Id;
                parentCategory.Children.Add(subCategory);
                await _categoryRepository.UpdateAsync(parentCategory);
            }
            else
            {
                var category = _mapper.Map<Category>(dto);
                category.ParentId = dto.ParentId;
                await _categoryRepository.AddAsync(category);
            }
            return new SuccessResult("Category Successfully Created");
        }

        public async Task<PagginatedResponse<GetCategoryDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 6)
        {
            var query = _categoryRepository.GetQuery(x => !x.IsDeleted)
                .AsNoTrackingWithIdentityResolution()
                .Include(x => x.Parent).ThenInclude(x => x.Children);
            var totalCount = await query.CountAsync();
            var paginatedCategories = await query.ToPagedListAsync(pageNumber, pageSize);
            var getDto = query.Select(x =>
            new GetCategoryDTO
            {
                Name = x.Name,
                ParentId = x.ParentId,
                Id = x.Id,
                Children = x.Children
            }).ToList();

            var getCategoryDtos = paginatedCategories.Datas.Select(x =>
           new GetCategoryDTO
           {
               Name = x.Name,
               ParentId = x.ParentId,
               Id = x.Id,
               Children = x.Children
           }).ToList();

            var paginatedResponse = new PagginatedResponse<GetCategoryDTO>(
                getCategoryDtos, paginatedCategories.PageNumber,
                paginatedCategories.PageSize,
                totalCount, getDto);
            return paginatedResponse;
        }

        public async Task<IDataResult<GetCategoryDTO>> GetAsync(int id)
        {
            Category category = await _categoryRepository.GetAsync(x => !x.IsDeleted && x.Id == id);

            if (category == null)
            {
                return new ErrorDataResult<GetCategoryDTO>("Category not found");
            }

            GetCategoryDTO getCategoryDTO = new GetCategoryDTO
            {
                Name = category.Name,
                ParentId = category.ParentId,
                Id = category.Id
            };
            return new SuccessDataResult<GetCategoryDTO>(getCategoryDTO, "Get Category Successfully");
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            Category category = await _categoryRepository.GetAsync(x => !x.IsDeleted && x.Id == id);

            if (category == null)
            {
                return new ErrorResult("Category Not Found");
            }
            category.IsDeleted = true;
            await _categoryRepository.UpdateAsync(category);
            return new SuccessResult("Category Removed Successfully");
        }

        public async Task<IResult> UpdateAsync(int id, PostCategoryDTO dto)
        {
            var categoryToUpdate = await _categoryRepository.GetAsync(x => x.Id == id);
            if(categoryToUpdate == null)
            {
                return new ErrorResult("Category Not Foud");
            }

            categoryToUpdate.Name = dto.Name;
            categoryToUpdate.ParentId = dto.ParentId;

            if(dto.ParentId != null)
            {
                categoryToUpdate.ParentId = dto.ParentId;
                var parentCategory = await _categoryRepository.GetAsync(x => x.ParentId == dto.ParentId);
                if(parentCategory != null)
                {
                    parentCategory.Children.Clear();
                    parentCategory.Children.Add(categoryToUpdate);
                    await _categoryRepository.UpdateAsync(parentCategory);
                    await _categoryRepository.UpdateAsync(categoryToUpdate);
                }
            }
            await _categoryRepository.UpdateAsync(categoryToUpdate);
            return new SuccessResult("Category Successfully Updated");
        }
    }
}
