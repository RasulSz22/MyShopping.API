using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        public Task AddAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task<T> GetAsync(Expression<Func<T, bool>> expression, params string[] Includes);
        public IQueryable<T> GetQuery(Expression<Func<T, bool>> expression);
        public Task RemoveAsync(T entity);
        public Task<int> SaveChangesAsync();
    }
}
