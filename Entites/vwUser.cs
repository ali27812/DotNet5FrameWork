using System;
using System.Collections.Generic;
using System.Text;

namespace Entites
{
    public class vwUser
    {        
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }
        public Guid SecurityStamp { get; set; }
        public int RoleId { get; set; }

    }
}
