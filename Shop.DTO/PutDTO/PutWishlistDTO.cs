﻿using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.PutDTO
{
    public record PutWishlistDTO
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
    }
}
