
using Shop.Businness.Mappers;
using Shop.DataAccess.ServiceRegistration;
using Shop.Businness.Registration;
using Shop.Core.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Shop.DataAccess.Contexts;
using Shop.Businness.Services.Interfaces;
using Shop.Businness.Services.Implementations;
namespace MyShopping.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();    
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(GlobalMapping));
            builder.Services.DataAccessServiceRegister(builder.Configuration);
            builder.Services.ServiceRegister();
            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<MyShoppingAPIDbContext>()
                .AddDefaultTokenProviders();
  
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }



            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
