using Shop.Core.Entities.Models;
using Shop.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Services.Interfaces
{
    public interface IProductImageService 
    {
        public Task<IResult> RemoveAsync(int id);
    }
}
