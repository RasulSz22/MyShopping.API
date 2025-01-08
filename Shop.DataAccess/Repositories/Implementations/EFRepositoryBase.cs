using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities.Common;
using Shop.DataAccess.Contexts;
using Shop.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repositories.Implementations
{
    public class EFRepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        readonly MyShoppingAPIDbContext _context;
        public EFRepositoryBase(MyShoppingAPIDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, params string[] Includes)
        {
            var query = _context.Set<T>().Where(expression);
            if (Includes != null)
            {
                foreach (string includes in Includes)
                {
                    query = query.Include(includes);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public IQueryable<T> GetQuery(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetListAsync(
       Expression<Func<T, bool>> filter = null,
       Func<IQueryable<T>, IQueryable<T>> include = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            return await query.ToListAsync();
        }

    }

}
