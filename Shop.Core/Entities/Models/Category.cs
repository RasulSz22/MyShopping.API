using Shop.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities.Models
{
    public class Category : BaseEntity
    {
        [ForeignKey("ParentId")]
        public string? Name { get; set; }
        public int ParentId {  get; set; }
        public Category Parent { get; set; }
        public List<Category> Children { get; set; }
        public ICollection<Product> Products { get; set; }
        public Category()
        {
            Children = new List<Category>();
        }
    }
}