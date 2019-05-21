using System.ComponentModel.DataAnnotations;
namespace ManagerPro.Models
{
    public class WebList
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50,MinimumLength =1,ErrorMessage ="你的网站名称太长，请重新输入")]
        public string Website { get; set; }
        [Required]
        [StringLength(200,MinimumLength =1,ErrorMessage ="你的URL地址过长，请重新输入")]
        public string WebsiteUrl { get; set; }
        public string Note { get; set; }
    }
}