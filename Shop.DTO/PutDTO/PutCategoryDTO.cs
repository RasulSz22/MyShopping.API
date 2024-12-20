using Shop.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DTO.PutDTO
{
    public class PutCategoryDTO
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryLogo {  get; set; }
        public List<Category> Categories { get; set; } 
    }
}
