using Microsoft.AspNetCore.Mvc;
using UserBlogSite.Models;

namespace UserBlogSite.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<int> CheckUserExistsAsync(User user);
        Task<int> UserRegisterAsync(User user);
        Task<User> UserLoginAsync(string userEmail);
        Task<IList<Blog>> GetAllBlogsAsync(int userId);
        Task<int> DeleteBlogAsync(string blogName, int authorId);
        Task<int> AddBlogAsync([FromBody] Blog blog);
        Task<int> UpdateBlogAsync(int blogId, Blog blog);
    }
}
