using Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Api;

namespace DotNet5FrameWork.Models
{
    public class UserDto : BaseDto<UserDto, User, int>, IValidatableObject
    {
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (UserName.Equals("test", StringComparison.OrdinalIgnoreCase))
                yield return new ValidationResult("نام کاربری نمیتواند Test باشد", new[] { nameof(UserName) });
            if (Password.Length<6)
                yield return new ValidationResult("طول رمز عبور نمیتواند کمتر از 6 رقم باشد", new[] { nameof(Password) });
            if (Gender == GenderType.Male && Age > 70)
                yield return new ValidationResult("آقایان بیشتر از 70 سال معتبر نیستند", new[] { nameof(Gender), nameof(Age) });
        }
    }
}
