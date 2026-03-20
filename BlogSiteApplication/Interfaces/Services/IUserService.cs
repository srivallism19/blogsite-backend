using Microsoft.AspNetCore.Mvc;
using UserBlogSite.Models;

namespace UserBlogSite.Interfaces.Services
{
    public interface IUserService
    {
        Task<int> UserRegisterAsync(User user);
        Task<LoginInfo> UserLoginAsync(string userEmail, string password);
        Task<IList<Blog>> GetAllBlogsAsync(int userId);
        Task<string> DeleteBlogAsync(string blogName, int authorId);
        Task<string> AddBlogAsync([FromBody] Blog blog);
        Task<string> UpdateBlogAsync(int blogId, Blog blog);
    }
}
