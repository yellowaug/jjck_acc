using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ManagerPro.ViewModel
{
    public class UserDetails
    {
        [StringLength(10,MinimumLength =2,ErrorMessage ="用户名长度不能超过少于2个或者大于10个字符")]
        [Required(ErrorMessage ="用户名不许为空")]
        [Display(Name ="用户名")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="密码不允许为空")]
        [Display(Name ="密码")]
        public string PassWord { get; set; }
    }
}