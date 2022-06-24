using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entites
{
    public class Order: BaseEntity
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
        [Display(Name = "تاریخ ثبت")]
        [Required]
        public DateTime DateTimeCreate { get; set; }
        [Display(Name = "تاریخ ویرایش")]
        public DateTime DateTimeUpdate { get; set; }
        [Display(Name = "ارسال شده")]
        [Required]
        public int IsSend { get; set; }
        [Display(Name = "وضعیت پرداخت")]
        [Required]
        public int StatusPay { get; set; }
        [Display(Name = "توضیحات")]
        [MaxLength]
        public string BankComment { get; set; }
        public string RRN { get; set; }


    }
    public enum TypeAccount
    {
        [Display(Name = "همکار")]
        Servant = 1,
        [Display(Name = "شرکت")]
        Company = 2,
        [Display(Name = "مرکز")]
        Center = 3,
        [Display(Name = "مالیات")]
        Tax = 4
    }
}
