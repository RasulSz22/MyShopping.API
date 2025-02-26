﻿using Microsoft.AspNetCore.Identity;
using Shop.Core.Entities.Common;

namespace Shop.Core.Entities.Models
{
    public class AppUser : IdentityUser
    {
        public bool IsActive { get; set; } = true;
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<Order> Orders { get; set; }
        public List<CartItem> CartItems { get; set; }

        public List<Review> Reviews { get; set; }
        public List<Payment> Payments { get; set; }
        public List<Address> Addresses { get; set; }

        public AppUser()
        {
            Orders = new List<Order>();
            CartItems = new List<CartItem>();
            Reviews = new List<Review>();
            Payments = new List<Payment>();
            Addresses = new List<Address>();
        }
    }
}
