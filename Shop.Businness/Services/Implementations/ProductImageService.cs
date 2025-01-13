using Shop.Businness.Services.Interfaces;
using Shop.Core.Entities.Models;
using Shop.Core.Utilities.Results.Abstract;
using Shop.Core.Utilities.Results.Concrete.ErrorResults;
using Shop.Core.Utilities.Results.Concrete.SuccessResults;
using Shop.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Businness.Services.Implementations
{
    public class ProductImageService : IProductImageService
    {
        readonly IProductImageRepository productImageRepository;

        public ProductImageService(IProductImageRepository productImageRepository)
        {
            this.productImageRepository = productImageRepository;
        }
        public async Task<IResult> RemoveAsync(int id)
        {
            var image = await productImageRepository.GetAsync(x => x.Id == id && x.IsDeleted == false);

            if (image == null)
            {
                return new ErrorResult("Product not found");
            }

            image.IsDeleted = true;
            await productImageRepository.UpdateAsync(image);
            await productImageRepository.SaveChangesAsync();
            return new SuccessResult("Product is Removed");
        }
    }
}
