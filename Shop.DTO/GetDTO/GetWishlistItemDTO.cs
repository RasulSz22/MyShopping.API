﻿using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.GetDTO
{
    public record GetWishlistItemDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public bool IsLiked { get; set; }
        public int ProductId { get; set; }       
        public string ProductDescription { get; set; } 
        public decimal ProductPrice { get; set; } 
        public int ProductStock { get; set; }
    }
}
