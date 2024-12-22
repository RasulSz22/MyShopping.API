using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Core.Entities.Models;
using Shop.DataAccess.Contexts;
using Shop.DataAccess.Repositories.Implementations;
using Shop.DataAccess.Repositories.Interfaces;


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


            services.AddIdentityCore<AppUser>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            })
     .AddRoles<IdentityRole>()
     .AddEntityFrameworkStores<MyShoppingAPIDbContext>();
        }
    }
}
