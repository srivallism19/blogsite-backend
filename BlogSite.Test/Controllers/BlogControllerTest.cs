using Moq;
using UserBlogSite.Controllers;
using UserBlogSite.Interfaces.Services;
using UserBlogSite.Models;

namespace UserBlogSite.Test.Controllers
{
    public class BlogControllerTest
    {
        private readonly Mock<IBlogService> mockBlogService;
        private BlogController blogController;
        public BlogControllerTest()
        {
            mockBlogService = new Mock<IBlogService>();
            blogController = new BlogController(mockBlogService.Object);
        }

        [Test]
        public async Task GetCategoryAsyncTest()
        {
            mockBlogService.Setup(x => x.GetCategoryAsync(It.IsAny<string>())).ReturnsAsync(new List<Blog> { new Blog() { Article = "test" } });
            var res = await blogController.GetCategoryAsync("test");
            Assert.NotNull(res);
        }

        [Test]
        public async Task GetCategoryAsync_ExceptionTest()
        {
            mockBlogService.Setup(x => x.GetCategoryAsync(It.IsAny<string>())).ThrowsAsync(new Exception());
            var res = await blogController.GetCategoryAsync("test");
            Assert.NotNull(res);
        }

        [Test]
        public async Task GetCategoryDurationAsyncTest()
        {
            mockBlogService.Setup(x => x.GetCategoryDurationAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new List<Blog> { new Blog() { Article = "test" } });
            var res = await blogController.GetCategoryDurationAsync("test", "", "");
            Assert.NotNull(res);
        }

        [Test]
        public async Task GetCategoryDurationAsync_ExceptionTest()
        {
            mockBlogService.Setup(x => x.GetCategoryDurationAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ThrowsAsync(new Exception());
            var res = await blogController.GetCategoryDurationAsync("test", "", "");
            Assert.NotNull(res);
        }
    }
}
