using Shop.Core.Entities.Common;
using Shop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities.Models
{
    public class AppUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public bool IsActive {  get; set; } = true;
        public string Address {  get; set; }
        public string PhoneNumber {  get; set; }
        public List<Order> Orders { get; set; }
        public List<CartItem> CartItems { get; set; }

        public List<Review> Reviews { get; set; }
        public List<Payment> Payments { get; set; }

        public AppUser() 
        {
            Orders = new List<Order>();
            CartItems = new List<CartItem>();
            Reviews = new List<Review>();
            Payments = new List<Payment>();
        }
    }
}
