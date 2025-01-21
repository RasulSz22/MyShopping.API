using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.PostDTO
{
    public class PostCategoryDTO
    {
        public string Name {  get; set; }
        public int? ParentId { get; set; }
    }
}
