using Shop.Businness.Mappers;
using Shop.DataAccess.ServiceRegistration;
using Shop.Businness.Registration;
using Shop.Core.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Shop.DataAccess.Contexts;
using Shop.Businness.Services.Interfaces;
using Shop.Businness.Services.Implementations;
using Shop.Core.Helper.MailHelper;
using Microsoft.OpenApi.Models;
using MyShopping.API.Filter;
using NETCore.MailKit.Core;
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
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<IEmailHelper, EmailHelper>();

            builder.Services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "My Shopping API",
                    Description = "ASP.NET Core 8 Web API"
                });

                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });

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
