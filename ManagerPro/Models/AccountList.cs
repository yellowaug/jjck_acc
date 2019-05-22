using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ManagerPro.Models
{
    public class AccountList
    {
        public int ID { get; set; }
        [StringLength(50,MinimumLength =1,ErrorMessage ="账号名称不允许超过50个字符"),Required]
        [Display(Name ="账号名称")]
        public string AccountName { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "账号名称不允许超过50个字符"),Required]
        [Display(Name ="账号")]
        public string AccountNum { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "账号名称不允许超过50个字符"),Required]
        [Display(Name ="密码")]
        public string AccountPassW { get; set; }
        [DataType(DataType.Date),Required]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        [Display(Name ="创建时间")]
        public DateTime CreateTime { get; set; }
        [Display(Name ="账号说明")]
        public string Note { get; set; }
        public virtual WebList WebList { get; set; }
        public virtual Urllist Urllist { get; set; }
    }
}