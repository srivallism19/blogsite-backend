using Moq;
using UserBlogSite.DapperHelper;
using UserBlogSite.Models;
using UserBlogSite.Repositories;

namespace UserBlogSite.Test.Repositories
{
    public class BlogRepositoryTest
    {
        private readonly Mock<IDapperHelper> mockDapperHelper;
        private BlogRepository blogRepository;
        public BlogRepositoryTest()
        {
            mockDapperHelper = new Mock<IDapperHelper>();
            blogRepository = new BlogRepository(mockDapperHelper.Object);
        }

        [Test]
        public async Task GetCategoryAsyncTest()
        {
            mockDapperHelper.Setup(x => x.QueryAsync<Blog>(It.IsAny<string>(), It.IsAny<object>())).ReturnsAsync(new List<Blog> { new Blog() { Article = "test" } });
            var res = await blogRepository.GetCategoryAsync("test");
            Assert.NotNull(res);
        }

        [Test]
        public async Task GetCategoryDurationAsyncTest()
        {
            mockDapperHelper.Setup(x => x.QueryAsync<Blog>(It.IsAny<string>(), It.IsAny<object>())).ReturnsAsync(new List<Blog> { new Blog() { Article = "test" } });
            var res = await blogRepository.GetCategoryDurationAsync("test", "", "");
            Assert.NotNull(res);
        }
    }
}
