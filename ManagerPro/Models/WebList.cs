using System.ComponentModel.DataAnnotations;
namespace ManagerPro.Models
{
    public class WebList
    {
        public int ID { get; set; }
        [Required,Display(Name ="网站名称")]
        [StringLength(50,MinimumLength =1,ErrorMessage ="你的网站名称太长，请重新输入")]
        public string Website { get; set; }
        [Required,Display(Name ="网站URL")]
        [StringLength(200,MinimumLength =1,ErrorMessage ="你的URL地址过长，请重新输入")]
        public string WebsiteUrl { get; set; }
        [Display(Name ="备注")]
        public string Note { get; set; }
    }
}