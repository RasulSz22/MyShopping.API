using Shop.Core.Entities;
using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.GetDTO
{
    public record GetProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int DiscountId { get; set; }

        public List<string> ProductImages { get; set; }
        public List<int> OrderItemIds { get; set; }

        public GetProductDTO()
        {
            ProductImages = new List<string>();
            OrderItemIds = new List<int>();
        }
    }
}
