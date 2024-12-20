using Shop.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities.Models
{
    public class Review : BaseEntity
    {
        public int Rating {  get; set; }
        public string Content {  get; set; }
        public int ProductId {  get; set; }
        public Product Product { get; set; }
        public string AppUserId {  get; set; }
        public AppUser AppUser { get; set; }
    }
}
