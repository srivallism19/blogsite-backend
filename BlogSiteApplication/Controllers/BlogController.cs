using Microsoft.AspNetCore.Mvc;
using UserBlogSite.Interfaces.Services;
using UserBlogSite.Models;

namespace UserBlogSite.Controllers
{
    [Route("api/v1.0/blogsite/blogs/")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            this._blogService = blogService;
        }

        [HttpGet("info/<category>")]
        /// <Summary>
        /// GetCategoryAsync
        /// </Summary>
        public async Task<IActionResult> GetCategoryAsync(string category)
        {
            try
            {
                var res = await _blogService.GetCategoryAsync(category);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get/<category>/<durationFromRange>/<durationToRange>")]
        /// <Summary>
        /// GetCategoryDurationAsync
        /// </Summary>
        public async Task<IActionResult> GetCategoryDurationAsync(string category, string startDate, string endDate)
        {
            try
            {
                var res = await _blogService.GetCategoryDurationAsync(category, startDate, endDate);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
