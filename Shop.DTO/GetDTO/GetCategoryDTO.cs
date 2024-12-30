using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.GetDTO
{
    public class GetCategoryDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ParentId { get; set; }
        public List<int> ChildrenIds { get; set; }
        public List<int> ProductIds { get; set; }
        public List<Category> Children { get; set; }

        public GetCategoryDTO()
        {
            Children = new List<Category>();
            ChildrenIds = new List<int>();
            ProductIds = new List<int>();
        }
    }
}
