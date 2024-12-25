using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.PostDTO
{
    public record PostProductİmageDTO
    {
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public bool IsMain { get; set; }
        public string FileType { get; set; }
        public int ProductId { get; set; }
    }
}
