namespace UserBlogSite.Queries
{
    public static class BlogQueries
    {
        public static string AddBlog = @"insert into dbo.Blog(BlogName, Category, Article, AuthorId, CreatedDateTime) 
                                            values(@BlogName, @Category, @Article, @AuthorId, getdate())";

        public static string DeleteBlog = @"delete from Blog where BlogName = @BlogName and AuthorId = @AuthorId";

        public static string UpdateBlog = @"update Blog set BlogName = @BlogName, Category = @Category, Article = @Article
                                            where AuthorId = @AuthorId and BlogId = @BlogId";

        public static string GetAllBlogs = @"select b.BlogId, b.BlogName, b.Category,b.Article, b.AuthorId, ud.UserName as AuthorName, b.CreatedDateTime from Blog b inner join UserDetails ud on b.AuthorId = ud.UserId where b.AuthorId = @UserId";

        public static string GetBlogsOnCategory = @"select b.BlogId, b.BlogName, b.Category,b.Article, b.AuthorId, ud.UserName as AuthorName, b.CreatedDateTime from Blog b inner join UserDetails ud on b.AuthorId = ud.UserId where b.Category=@Category";

        public static string GetBlogsOnCategoryDuration = @"select b.BlogId, b.BlogName, b.Category,b.Article, b.AuthorId, ud.UserName as AuthorName, b.CreatedDateTime from Blog b inner join UserDetails ud on b.AuthorId = ud.UserId where b.Category=@Category and b.CreatedDateTime between @StartDate and @EndDate";
    }
}
