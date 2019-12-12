using System;
using System.Collections.Generic;

namespace MotoPartsAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            Cart = new HashSet<Cart>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string Salt { get; set; }
        public int? RoleFk { get; set; }

        public virtual Roles RoleFkNavigation { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
    }
}
