using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Shop.Core.Entities.Models;
using Shop.DTO.CreateDTO;
using Shop.DTO.GetDTO;
using Shop.DTO.PostDTO;
using Shop.DTO.PutDTO;

namespace Shop.Businness.Mappers
{
    public class GlobalMapping : Profile
    {
        public GlobalMapping()
        {
            CreateMap<Address, GetAddressDTO>().ReverseMap();
            CreateMap<Address, PostAddressDTO>().ReverseMap();

            CreateMap<Order, GetOrderDTO>().ReverseMap();
            CreateMap<Order, PostOrderDTO>().ReverseMap();

            CreateMap<Product, GetProductDTO>().ReverseMap();
            CreateMap<Product, PostProductDTO>().ReverseMap();
            CreateMap<PostProductDTO, Product>()
           .ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => ConvertFilesToProductImages(src.ProductImages)));

            CreateMap<OrderItem, GetOrderItemDTO>().ReverseMap();
            CreateMap<OrderItem, PostOrderItemDTO>().ReverseMap();

            CreateMap<CartItem, GetCartItemDTO>().ReverseMap();
            CreateMap<CartItem, PostCartItemDTO>().ReverseMap();

            CreateMap<Category, GetCategoryDTO>().ReverseMap();
            CreateMap<Category, PostCategoryDTO>().ReverseMap();

            CreateMap<Discount, GetDiscountDTO>().ReverseMap();
            CreateMap<Discount, PostDiscountDTO>().ReverseMap();

            CreateMap<Payment, GetPaymentDTO>().ReverseMap();
            CreateMap<Payment, PostPaymentDTO>().ReverseMap();

            CreateMap<Review, GetReviewDTO>().ReverseMap();
            CreateMap<Review, PostReviewDTO>().ReverseMap();

            CreateMap<Shipping, GetShippingDTO>().ReverseMap();
            CreateMap<Shipping, PostShippingDTO>().ReverseMap();

            CreateMap<Wishlist, GetWishlistDTO>().ReverseMap();
            CreateMap<Wishlist, PostWishlistDTO>().ReverseMap();

            CreateMap<WishlistItem, GetWishlistItemDTO>().ReverseMap();
            CreateMap<WishlistItem, PostWishlistItemDTO>().ReverseMap();
        }
        private List<ProductImage> ConvertFilesToProductImages(List<IFormFile>? files)
        {
            var productImages = new List<ProductImage>();
            if (files != null)
            {
                foreach (var file in files)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        productImages.Add(new ProductImage
                        {
                            Image = memoryStream.ToString(),
                        });
                    }
                }
            }
            return productImages;
        }
    }
}
