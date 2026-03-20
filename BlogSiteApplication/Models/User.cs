using System.ComponentModel.DataAnnotations;

namespace UserBlogSite.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required, EmailAddress]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com)$", ErrorMessage = "Email id should contain @ and end with .com")]
        public string UserEmail { get; set; }

        [Required, MinLength(8)]
        [RegularExpression(@"^[A-Za-z0-9]{8,}$", ErrorMessage = "Password must be alphanumeric and atleast 8 characters")]
        public string Password { get; set; }
    }
}
