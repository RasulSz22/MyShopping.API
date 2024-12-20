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
    public class WishlistItemRepository : EFRepositoryBase<WishlistItem>,IWishlistItemRepository
    {
        public WishlistItemRepository(MyShoppingAPIDbContext context) : base(context)
        {
            
        }
    }
}
