using Microsoft.EntityFrameworkCore;
using Shop.Businness.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Extensions
{
    public static class PagesListQuerableExtension
    {
        public static async Task<PagginatedResponse<T>> ToPagedListAsync<T>(
          this IQueryable<T> source,
          int pageNumber,
          int pageSize)
        {
            var count = await source.CountAsync();
            if (count >= 0)
            {
                var items = await source
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
                var otherItems = await source.ToListAsync();

                return new PagginatedResponse<T>(items, pageNumber, pageSize, count, otherItems);
            }
            return new(null, 0, 0, 0);
        }
    }
}
