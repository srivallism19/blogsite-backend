using Microsoft.AspNetCore.Mvc;
using UserBlogSite.Interfaces.Services;
using UserBlogSite.Models;
using UserBlogSite.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserBlogSite.Controllers
{
    [Route("api/v1.0/blogsite/user/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("register")]
        /// <Summary>
        /// UserRegister
        /// </Summary>
        public async Task<IActionResult> UserRegisterAsync(User user)
        {
            try
            {
                var res = await _userService.UserRegisterAsync(user);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        /// <Summary>
        /// UserRegister
        /// </Summary>
        public async Task<IActionResult> UserLoginAsync(LoginReq loginReq)
        {
            try
            {
                var res = await _userService.UserLoginAsync(loginReq.UserEmail, loginReq.Password);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("getall")]
        /// <Summary>
        /// UserRegister
        /// </Summary>
        public async Task<IActionResult> GetAllBlogsAsync(int userId)
        {
            try
            {
                var res = await _userService.GetAllBlogsAsync(userId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("delete/<blogname>")]
        /// <Summary>
        /// UserRegister
        /// </Summary>
        public async Task<IActionResult> DeleteBlogAsync(string blogName, int authorId)
        {
            try
            {
                var res = await _userService.DeleteBlogAsync(blogName, authorId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("blogs/add/<blogname>")]
        /// <Summary>
        /// UserRegister
        /// </Summary>
        public async Task<IActionResult> AddBlogAsync([FromBody] Blog blog)
        {
            try
            {
                var res = await _userService.AddBlogAsync(blog);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("blogs/update/<id>")]
        /// <Summary>
        /// UserRegister
        /// </Summary>
        public async Task<IActionResult> UpdateBlogAsync(int blogId, Blog blog)
        {
            try
            {
                var res = await _userService.UpdateBlogAsync(blogId, blog);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
