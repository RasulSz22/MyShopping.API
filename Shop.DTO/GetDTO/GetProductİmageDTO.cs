using Shop.Core.Entities;
using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.GetDTO
{
    public record GetProductİmageDTO
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public bool IsMain { get; set; }
        public string FileType { get; set; }
        public int ProductId { get; set; }
    }
}
