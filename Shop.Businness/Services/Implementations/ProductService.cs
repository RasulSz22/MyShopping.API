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
using Shop.DTO.CreateDTO;
using Shop.DTO.GetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Services.Implementations
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _productRepository;
        readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateAsync(PostProductDTO dto)
        {
            Product product = _mapper.Map<Product>(dto);
            await _productRepository.AddAsync(product);
            return new SuccessResult("Produc Successfully created");
        }

        public async Task<PagginatedResponse<GetProductDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 6)
        {
            var query = _productRepository.GetQuery(x => !x.IsDeleted)
                .AsNoTrackingWithIdentityResolution()
                .Include(x => x.Category);
            var totalCount = await query.CountAsync();
            var paginatedProducts = await query.ToPagedListAsync(pageNumber, pageSize);
            var GetProductDtos = paginatedProducts.Datas.Select(x=>
            new GetProductDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Stock = x.Stock,
                Price = x.Price,
                CategoryId = x.CategoryId,
            }).ToList();
            var paginatetResponse = new PagginatedResponse<GetProductDTO>(
                GetProductDtos, paginatedProducts.PageNumber,
                paginatedProducts.PageSize,
                totalCount);
            return paginatetResponse;
        }

        public async Task<IDataResult<GetProductDTO>> GetAsync(int id)
        {
            var Product = _productRepository.GetAsync(x => !x.IsDeleted && x.Id == id).Result;
            if(Product == null)
            {
                return new ErrorDataResult<GetProductDTO>("Product Not Found");
            }

            GetProductDTO dto = new GetProductDTO()
            {
                Id = Product.Id,
                Name = Product.Name,
                Description = Product.Description,
                Price = Product.Price,
                Stock = Product.Stock,
                CategoryId = Product.CategoryId,
            };
            return new SuccessDataResult<GetProductDTO>(dto,"Get Product");
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            Product product = await _productRepository.GetAsync(x => !x.IsDeleted && x.Id == id);
            if(product == null)
            {
                return new ErrorResult("Product Not Found");
            }
            product.IsDeleted = true;
            await _productRepository.UpdateAsync(product);
            return new SuccessResult("Product Removed");
        }

        public async Task<IResult> UpdateAsync(int id, PostProductDTO dto)
        {
            Product product = await _productRepository.GetAsync(x => !x.IsDeleted && x.Id == id);
            if(product == null)
            {
                return new ErrorResult("Product Not Found");
            }
            _mapper.Map(dto, product);
            await _productRepository.UpdateAsync(product);
            return new SuccessResult("Product Successfully Updated");
        }
    }
}