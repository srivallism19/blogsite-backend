using UserBlogSite.Models;

namespace UserBlogSite.Interfaces.Repositories
{
    public interface IBlogRepository
    {
        Task<IList<Blog>> GetCategoryAsync(string category);

        Task<IList<Blog>> GetCategoryDurationAsync(string category, string startDate, string endDate);
    }
}
