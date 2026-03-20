using UserBlogSite.Interfaces.Repositories;
using UserBlogSite.Interfaces.Services;
using UserBlogSite.Models;

namespace UserBlogSite.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            this._blogRepository= blogRepository;
        }

        /// <Summary>
        /// GetCategoryAsync
        /// </Summary>
        public async Task<IList<Blog>> GetCategoryAsync(string category)
        {
            var res = await _blogRepository.GetCategoryAsync(category);
            return res;
        }


        /// <Summary>
        /// GetCategoryDurationAsync
        /// </Summary>
        public async Task<IList<Blog>> GetCategoryDurationAsync(string category, string startDate, string endDate)
        {
            var res = await _blogRepository.GetCategoryDurationAsync(category, startDate, endDate);
            return res;
        }
    }
}
