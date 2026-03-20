using System.ComponentModel.DataAnnotations;

namespace UserBlogSite.Models
{
    public class LoginReq
    {
        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
