using Shop.Core.Entities.Enums;
using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.GetDTO
{
    public record GetPaymentDTO
    {
        public int Id { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public string AppUserId { get; set; }
        public string AppUserName { get; set; }
    }
}
