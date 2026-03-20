namespace UserBlogSite.Queries
{
    public static class BlogQueries
    {
        public static string AddBlog = @"insert into dbo.Blog(BlogName, Category, Article, AuthorId, CreatedDateTime) 
                                            values(@BlogName, @Category, @Article, @AuthorId, getdate())";

        public static string DeleteBlog = @"delete from Blog where BlogName = @BlogName and AuthorId = @AuthorId";

        public static string UpdateBlog = @"update Blog set BlogName = @BlogName, Category = @Category, Article = @Article
                                            where AuthorId = @AuthorId and BlogId = @BlogId";

        public static string GetAllBlogs = @"select b.* from Blog b inner join UserDetails ud on b.AuthorId = ud.UserId where b.AuthorId = @UserId";

        public static string GetBlogsOnCategory = @"select * from Blog where Category = @Category";

        public static string GetBlogsOnCategoryDuration = @"select * from Blog where Category = @Category and CreatedDateTime between @StartDate and @EndDate";
    }
}
