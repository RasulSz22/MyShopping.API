using Shop.Core.Entities.Enums;
using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.PutDTO
{
    public record PutPaymentDTO
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public string AppUserId { get; set; }
    }
}
