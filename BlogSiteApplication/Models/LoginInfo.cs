namespace UserBlogSite.Models
{
    public class LoginInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string JwtToken { get; set; }

        public string Message { get; set; }
    }
}
