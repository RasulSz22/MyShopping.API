﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.PutDTO
{
    public record PutAddressDTO
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string AppUserId { get; set; }
    }
}
