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
        public Category Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public OrderItem OrderItem { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public List<ProductImage> ProductImages {  get; set; }
    }
}
