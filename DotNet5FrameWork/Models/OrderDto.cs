using Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Api;

namespace DotNet5FrameWork.Models
{
    public class OrderDto : BaseDto<OrderDto,Order, int>, IValidatableObject
    {
        [Display(Name = "سفارش")]
        [Required]
        public int IdOrder { get; set; }
        [Display(Name = "جلسه")]
        public int IdSession { get; set; }
        [Display(Name = "شهر")]
        [Required]
        public int IdCity { get; set; }
        [Display(Name = "خدمت")]
        [Required]
        public int IdService { get; set; }
        [Display(Name = "کدسفارش")]
        [Required]
        [StringLength(150)]
        public string TrackingCode { get; set; }
        [Display(Name = "کد خدمت")]
        [Required]
        [StringLength(150)]
        public string ServiceCode { get; set; }
        [Display(Name = "همکار")]
        public int IdServant { get; set; }
        [Display(Name = "کد شبا")]
        [Required]
        [StringLength(150)]
        public string ShabaId { get; set; }
        [Display(Name = "شرکت")]
        public int IdCompany { get; set; }
        [Display(Name = "نوع اکانت")]
        [Required]
        public TypeAccount TypeAccountPay { get; set; }
        [Display(Name = "کد تراکنش")]
        [Required]
        [StringLength(150)]
        public string SpecialCode { get; set; }
        [Display(Name = "هزینه")]
        [Required]
        public int Amount { get; set; }    
        [Display(Name = "ارسال شده")]
        [Required]
        public int IsSend { get; set; }       
        [Display(Name = "توضیحات")]
        [MaxLength]
        public string BankComment { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IdOrder==0)
                yield return new ValidationResult("شماره سفارش نمیتواند 0 باشد");
            
        }

        //public override void CustomMappings(IMappingExpression<Order, OrderDto> mappingExpression)
        //{
        //    mappingExpression.ForMember(
        //            dest => dest.FullTitle,
        //            config => config.MapFrom(src => $"{src.Title} ({src.Category.Name})"));
        //}

    }
}
