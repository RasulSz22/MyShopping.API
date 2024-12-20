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
        public Order OrderId { get; set; }
        public User UserId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
