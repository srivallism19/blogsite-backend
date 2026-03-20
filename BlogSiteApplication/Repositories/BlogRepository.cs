using Microsoft.AspNetCore.Mvc;
using UserBlogSite.DapperHelper;
using UserBlogSite.Interfaces.Repositories;
using UserBlogSite.Models;
using UserBlogSite.Queries;

namespace UserBlogSite.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IDapperHelper _dapperHelper;
        public BlogRepository(IDapperHelper dapperHelper)
        {
            this._dapperHelper = dapperHelper;
        }

        /// <Summary>
        /// GetCategoryAsync
        /// </Summary>
        public async Task<IList<Blog>> GetCategoryAsync(string category)
        {
           var res = await _dapperHelper.QueryAsync<Blog>(BlogQueries.GetBlogsOnCategory, new { Category = category });
            return res;
        }


        /// <Summary>
        /// GetCategoryDurationAsync
        /// </Summary>
        public async Task<IList<Blog>> GetCategoryDurationAsync(string category, string startDate, string endDate)
        {
            var res = await _dapperHelper.QueryAsync<Blog>(BlogQueries.GetBlogsOnCategoryDuration, new { Category = category, StartDate = startDate, EndDate = endDate });
            return res;
        }
    }
}
