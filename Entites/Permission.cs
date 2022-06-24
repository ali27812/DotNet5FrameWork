using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entites
{
    public class Permission : BaseEntity
    {
        [Required]
        public string Permiss { get; set; }

        public string Description { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; }


    }
}
