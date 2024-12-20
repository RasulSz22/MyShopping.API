using Shop.Core.Entities.Common;
using Shop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public UserRoles Role { get; set; }
    }
}
