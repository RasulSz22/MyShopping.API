//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Core.Entities.Identity;
using Shop.DataAccess.Contexts;
using Shop.DataAccess.Repositories.Implementations;
using Shop.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.ServiceRegistration
{
    public static class DataAccessServiceRegistration
    {
        public static void DataAccessServiceRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyShoppingAPIDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddScoped<IProductRepository, ProductReposiroty>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IShippingRepository,ShippingRepository>();
            services.AddScoped<IWishlistRepository,WishlistRepository>();
            services.AddScoped<IWishlistItemRepository, WishlistItemRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();


            //services.AddIdentity<AppUser, IdentityRole>(opt =>
            //{
            //    opt.User.RequireUniqueEmail = true;
            //    opt.Lockout.MaxFailedAccessAttempts = 5;
            //    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            //    opt.SignIn.RequireConfirmedEmail = true;
            //    opt.Lockout.AllowedForNewUsers = true;
            //})
            //    .AddEntityFrameworkStores<MyShoppingAPIDbContext>()
            //    .AddDefaultTokenProviders();
        }
    }
}
