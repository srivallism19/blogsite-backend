using System.ComponentModel.DataAnnotations;

namespace UserBlogSite.Models
{
    public class Blog
    {
        public int BlogId { get; set; }

        [Required, MinLength(20, ErrorMessage = "BlogName should be minimum of 20 characters")]
        public string BlogName { get; set; }

        [Required, MinLength(20, ErrorMessage = "Category should be minimum of 20 characters")]
        public string Category { get; set; }

        [Required, MinLength(10, ErrorMessage = "Article should be minimum of 10 characters")]
        public string Article { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
