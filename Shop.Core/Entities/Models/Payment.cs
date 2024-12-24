using Shop.Core.Entities.Common;
using Shop.Core.Entities.Enums;

namespace Shop.Core.Entities.Models
{
    public class Payment : BaseEntity
    {
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
