using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ManagerPro.Models
{
    public class AccountList
    {
        public int ID { get; set; }
        [StringLength(50,MinimumLength =1,ErrorMessage ="账号名称不允许超过50个字符"),Required]
        public string AccountName { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "账号名称不允许超过50个字符"),Required]
        public string AccountNum { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "账号名称不允许超过50个字符"),Required]
        public string AccountPassW { get; set; }
        [DataType(DataType.Date),Required]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime CreateTime { get; set; }
        public string Note { get; set; }
        public virtual WebList WebList { get; set; }
        public virtual Urllist Urllist { get; set; }
    }
}