using Microsoft.Extensions.DependencyInjection;
using Shop.Businness.Services.Implementations;
using Shop.Businness.Services.Interfaces;
using Shop.DataAccess.Repositories.Implementations;
using Shop.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Registration
{
    public static class ServiceLayerServiceRegister
    {
        public static void ServiceRegister(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>),typeof(EFRepositoryBase<>));
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderItemsService, OrderItemsService>();
            services.AddScoped<IShippingService, ShippingService>();
            services.AddScoped<ILikedService, LikedService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IAccountService, AccountService>();
            //services.AddHttpContextAccessor();
        }
    }
}
