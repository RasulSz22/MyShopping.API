﻿using Microsoft.AspNetCore.Http;
using Shop.Core.Entities;
using Shop.Core.Entities.Models;
using Shop.DTO.GetDTO;
using Shop.DTO.PostDTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.CreateDTO
{
    public record PostProductDTO
    {
        //public int ProductId {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public List<IFormFile>? ProductImages { get; set; }
        public IFormFile? MainImage {  get; set; }
    }
}
