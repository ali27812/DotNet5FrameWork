using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entites
{
    public class RolePermission : BaseEntity
    {
        [Required]
        public int RoleId { get; set; }        
        [Required]
        public int PermissionId { get; set; }
        public Role RolePermissionUser { get; set; }
        public Permission RolePermissionPermission { get; set; }

    }
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasOne(p => p.RolePermissionUser).WithMany(c => c.RolePermissions).HasForeignKey(p => p.RoleId);
            builder.HasOne(p => p.RolePermissionPermission).WithMany(c => c.RolePermissions).HasForeignKey(p => p.PermissionId);

        }
    }
}
