using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.GetDTO
{
    public record GetDiscountDTO
    {
        public int Id {  get; set; }
        public string Promocode { get; set; }
        public decimal DiscountPercentage { get; set; }
        public List<int> ProductId { get; set; }
        public GetDiscountDTO()
        {
            ProductId = new List<int>();
        }
    }
}
