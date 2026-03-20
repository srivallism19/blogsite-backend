using UserBlogSite.Models;

namespace UserBlogSite.Interfaces.Services
{
    public interface IBlogService
    {
        Task<IList<Blog>> GetCategoryAsync(string category);

        Task<IList<Blog>> GetCategoryDurationAsync(string category, string startDate, string endDate);
    }
}
