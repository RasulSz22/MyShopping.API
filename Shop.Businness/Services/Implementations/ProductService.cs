using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Shop.Businness.Extensions;
using Shop.Businness.Responses;
using Shop.Businness.Services.Interfaces;
using Shop.Core.Entities.Models;
using Shop.Core.Helper;
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
        private readonly IWebHostEnvironment _env;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IWebHostEnvironment env, IProductRepository productRepository, IMapper mapper)
        {
            _env = env;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateAsync(PostProductDTO dto)
        {

            var product = _mapper.Map<Product>(dto);
            if (dto.MainImage == null)
            {
                return new ErrorResult ("The field image is required" );
            }
            if (dto.ProductImages == null || dto.ProductImages.Count() == 0)
            {
                return new ErrorResult("The field image is required");
            }
            if (!dto.MainImage.IsImage())
            {
                return new ErrorResult ("The image is not valid" );
            }
            if (dto.MainImage.IsSizeOk(1))
            {
                return new ErrorResult( "Size of image is not valid" );
            }

            string mainImage = dto.MainImage.SaveFile(_env.WebRootPath, "Images/Product");
            product.ProductImages.Add(new ProductImage
            {
                Image = mainImage,
                IsMain = true,
                Product = product,
            });


            foreach (var item in dto.ProductImages)
            {
                if (!item.IsImage())
                {
                    return new ErrorResult("The image is not valid");
                }
                if (item.IsSizeOk(1))
                {
                    return new ErrorResult("Size of Image is not valid");
                }
                string image = item.SaveFile(_env.WebRootPath, "Images/Product");
                product.ProductImages.Add(new ProductImage
                {
                    Image = image,
                    IsMain = false,
                    Product = product
                });
            }
            await _productRepository.AddAsync(product);
            return new SuccessResult("Product successfully created");
        }

        public async Task<PagginatedResponse<GetProductDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 6)
        {
            var query = _productRepository.GetQuery(x => !x.IsDeleted)
                .AsNoTrackingWithIdentityResolution()
                .Include(x => x.Category);
            var totalCount = await query.CountAsync();
            var paginatedProducts = await query.ToPagedListAsync(pageNumber, pageSize);

            var productDtos = paginatedProducts.Datas.Select(x => _mapper.Map<GetProductDTO>(x)).ToList();
            return new PagginatedResponse<GetProductDTO>(
                productDtos, paginatedProducts.PageNumber, paginatedProducts.PageSize, totalCount);
        }

        public async Task<IDataResult<GetProductDTO>> GetAsync(int id)
        {
            var product = await _productRepository.GetAsync(x => !x.IsDeleted && x.Id == id);
            if (product == null)
            {
                return new ErrorDataResult<GetProductDTO>("Product not found");
            }

            var dto = _mapper.Map<GetProductDTO>(product);
            return new SuccessDataResult<GetProductDTO>(dto, "Product retrieved successfully");
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            var product = await _productRepository.GetAsync(x => !x.IsDeleted && x.Id == id);
            if (product == null)
            {
                return new ErrorResult("Product not found");
            }

            product.IsDeleted = true;
            await _productRepository.UpdateAsync(product);
            return new SuccessResult("Product removed");
        }

        public async Task<IResult> UpdateAsync(int id, PostProductDTO dto)
        {
            var product = await _productRepository.GetAsync(x => !x.IsDeleted && x.Id == id);
            if (product == null)
            {
                return new ErrorResult("Product not found");
            }

            _mapper.Map(dto, product);
            await _productRepository.UpdateAsync(product);
            return new SuccessResult("Product updated successfully");
        }
    }

}