using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.PostDTO
{
    public record PostOrderItemDTO
    {
        public int ProductId {  get; set; }
      //  public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        //public string AppUserId { get; set; }
        //public OrderItem OrderItems { get; set; }
        //public Product Product { get; set; } 
    }
}
