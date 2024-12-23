using Shop.Core.Entities.Common;

namespace Shop.Core.Entities.Models
{
    public class Discount : BaseEntity
    {
        public string Promocode { get; set; }
        public decimal DiscountPercentage { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
