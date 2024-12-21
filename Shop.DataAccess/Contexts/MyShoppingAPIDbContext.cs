using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities.Common;
using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Contexts
{
    public class MyShoppingAPIDbContext : DbContext //IdentityDbContext<AppUser>
    {
        public MyShoppingAPIDbContext(DbContextOptions<MyShoppingAPIDbContext> options) : base(options)
        {

        }
        public DbSet<Address> Address { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImageFiles { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Shipping> Shipping { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }
        public DbSet<WishlistItem> WishlistItem { get; set; }
        public DbSet<Review> Reviews { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow.AddHours(2);
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow.AddHours(2);
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<CartItem>()
            .Property(c => c.Price)
            .HasColumnType("decimal(18,2)");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<Discount>()
           .Property(d => d.DiscountPercentage)
           .HasColumnType("decimal(18,2)");

            builder.Entity<Order>()
           .Property(o => o.TotalAmount)
           .HasColumnType("decimal(18,2)");

            builder.Entity<OrderItem>()
           .Property(o => o.UnitPrice)
           .HasColumnType("decimal(18,2)");

            builder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");

        }
    }
}