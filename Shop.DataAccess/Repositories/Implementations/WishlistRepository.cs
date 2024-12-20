using Shop.Core.Entities.Models;
using Shop.DataAccess.Contexts;
using Shop.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repositories.Implementations
{
    public class WishlistRepository:EFRepositoryBase<Wishlist>,IWishlistRepository
    {
        public WishlistRepository(MyShoppingAPIDbContext context) : base(context)
        {
            
        }
    }
}
