using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entites
{
    public class User : BaseEntity
    {
        public User()
        {
            IsActive = true;
            SecurityStamp = Guid.NewGuid();
        }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }
        [Required]
        [StringLength(500)]
        public string PasswordHash { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }
        public Guid SecurityStamp { get; set; }

        public int RoleId { get; set; }

        public Role RoleUser { get; set; }

        public ICollection<UserPermission> UserPermissions { get; set; }



    }
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(p => p.RoleUser).WithMany(c => c.Users).HasForeignKey(p => p.RoleId);
        }
    }

    public enum GenderType
    {
        [Display(Name = "مرد")]
        Male = 1,

        [Display(Name = "زن")]
        Female = 2
    }
}
