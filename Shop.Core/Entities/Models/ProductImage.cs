using Shop.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities.Models
{
    public class ProductImage : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public bool IsMain { get; set; }
        public string FileType { get; set; }
        public Product Product { get; set; }
        public int ProductId {  get; set; }
    }
}
