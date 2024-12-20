using Shop.Core.Entities.Common;

namespace Shop.Core.Entities.Models
{
    public class Discount : BaseEntity
    {
        public string Promocode { get; set; } 
        public int ProductId {  get; set; }
        public Product Product { get; set; }
        public decimal DiscountPercentage { get; set; } 
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}
