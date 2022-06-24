using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entites
{
    public class UserPermission : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PermissionId { get; set; }

        public User UserPermissionUser { get; set; }
        //public Permission PermissionPermissionUser { get; set; }
        public Permission UserPermissionPermission { get; set; }

    }
    public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.HasOne(p => p.UserPermissionUser).WithMany(c => c.UserPermissions).HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.UserPermissionPermission).WithMany(c => c.UserPermissions).HasForeignKey(p => p.PermissionId);

        }
    }
}
