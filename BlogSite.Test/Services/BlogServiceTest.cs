using Moq;
using UserBlogSite.Interfaces.Repositories;
using UserBlogSite.Models;
using UserBlogSite.Services;

namespace UserBlogSite.Test.Services
{
    public class BlogServiceTest
    {
        private readonly Mock<IBlogRepository> mockBlogRepository;
        private BlogService blogService;
        public BlogServiceTest()
        {
            mockBlogRepository = new Mock<IBlogRepository>();
            blogService = new BlogService(mockBlogRepository.Object);
        }

        [Test]
        public async Task GetCategoryAsyncTest()
        {
            mockBlogRepository.Setup(x => x.GetCategoryAsync(It.IsAny<string>())).ReturnsAsync(new List<Blog> { new Blog() { Article = "test" } });
            var res = await blogService.GetCategoryAsync("test");
            Assert.NotNull(res);
        }

        [Test]
        public async Task GetCategoryDurationAsyncTest()
        {
            mockBlogRepository.Setup(x => x.GetCategoryDurationAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new List<Blog> { new Blog() { Article = "test" } });
            var res = await blogService.GetCategoryDurationAsync("test", "", "");
            Assert.NotNull(res);
        }
    }
}
