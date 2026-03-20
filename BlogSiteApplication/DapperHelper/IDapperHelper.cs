namespace UserBlogSite.DapperHelper
{
    public interface IDapperHelper
    {
        Task<IList<T>> QueryAsync<T>(string query, object parameters = null);

        Task<int> ExecuteAsync<T>(string query, object parameters = null);
    }
}
