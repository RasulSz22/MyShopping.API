using Shop.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Product Parent { get; set; }
        public Category Category { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public int DiscountId {  get; set; }
        public Discount Discount { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }

        public Product()
        {
            ProductImages = new List<ProductImage>();
        }
    }
}
