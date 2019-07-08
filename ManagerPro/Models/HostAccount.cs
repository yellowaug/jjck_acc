using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ManagerPro.Models
{
    public class HostAccount
    {
        [Key]
        public int HostID { get; set; }
        [Required,StringLength(100,MinimumLength =1,ErrorMessage ="虚拟机名称不能超过100个字符")]
        [Display(Name ="虚拟机名称")]
        public string HostName { get; set; }
        [Required,StringLength(50,MinimumLength =1,ErrorMessage ="主机地址不能超过50个字符")]
        [Display(Name ="主机地址")]
        public string HostAddress { get; set; }
        [Required, StringLength(50, MinimumLength = 1, ErrorMessage = "账号不能超过50个字符")]
        [Display(Name ="主机登录账号")]
        public string HostAccountNum { get; set; }
        [Required, StringLength(50, MinimumLength = 1, ErrorMessage = "密码不能超过50个字符")]
        [Display(Name ="主机登录密码")]
        public string HostAccountPas { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        [Display(Name ="录入时间")]
        public DateTime InputDate { get; set; }
        [Display(Name ="备注")]
        public string HostNote { get; set; }
    }
}