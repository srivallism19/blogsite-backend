using Microsoft.AspNetCore.Mvc;
using UserBlogSite.DapperHelper;
using UserBlogSite.Interfaces.Repositories;
using UserBlogSite.Models;
using UserBlogSite.Queries;

namespace UserBlogSite.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDapperHelper _dapperHelper;
        public UserRepository(IDapperHelper dapperHelper)
        {
            this._dapperHelper = dapperHelper;
        }

        /// <Summary>
        /// UserRegister
        /// </Summary>
        public async Task<int> UserRegisterAsync(User user)
        {
            var res = await _dapperHelper.ExecuteAsync<int>(UserQueries.UserRegister, user);
            return res;
        }

        /// <Summary>
        /// UserRegister
        /// </Summary>
        public async Task<User> UserLoginAsync(string userEmail)
        {
            var res = await _dapperHelper.QueryAsync<User>(UserQueries.UserLogin, new { UserEmail = userEmail });
            return res?.FirstOrDefault();
        }


        /// <Summary>
        /// UserRegister
        /// </Summary>
        public async Task<IList<Blog>> GetAllBlogsAsync(int userId)
        {
            var res = await _dapperHelper.QueryAsync<Blog>(BlogQueries.GetAllBlogs, new { UserId = userId });
            return res;
        }



        /// <Summary>
        /// UserRegister
        /// </Summary>
        public async Task<int> DeleteBlogAsync(string blogName, int authorId)
        {
            var res = await _dapperHelper.ExecuteAsync<int>(BlogQueries.DeleteBlog, new { BlogName = blogName, AuthorId = authorId});
            return res;
        }


        /// <Summary>
        /// UserRegister
        /// </Summary>
        public async Task<int> AddBlogAsync([FromBody] Blog blog)
        {
            var res = await _dapperHelper.ExecuteAsync<int>(BlogQueries.AddBlog, blog);
            return res;
        }


        /// <Summary>
        /// UserRegister
        /// </Summary>
        public async Task<int> UpdateBlogAsync(int blogId, Blog blog)
        {
            var res = await _dapperHelper.ExecuteAsync<int>(BlogQueries.UpdateBlog, new { BlogId = blogId, blog.BlogName, blog.Category, blog.Article, blog.AuthorId});
            return res;
        }
    }
}
