using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.PutDTO
{
    public record PutProductİmageDTO
    {
        public int Id { get; set; }
        public Product ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public bool IsMain { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long FileSize { get; set; }
        public string FileType { get; set; }

    }
}
