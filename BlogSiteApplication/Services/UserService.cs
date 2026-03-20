using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserBlogSite.Interfaces.Repositories;
using UserBlogSite.Interfaces.Services;
using UserBlogSite.Models;

namespace UserBlogSite.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        /// <Summary>
        /// UserRegister
        /// </Summary>
        public async Task<int> UserRegisterAsync(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var res = await _userRepository.UserRegisterAsync(user);
            return res;
        }

        /// <Summary>
        /// UserRegister
        /// </Summary>
        public async Task<LoginInfo> UserLoginAsync(string userEmail, string password)
        {
            User user = await _userRepository.UserLoginAsync(userEmail);
            if(user == null || user.UserId == 0 || user.Password == null)
            {
                return GetUserDetails(user, "User doesn't exist", "");
            }
            bool valid = BCrypt.Net.BCrypt.Verify(password, user.Password);
            var pwd = BCrypt.Net.BCrypt.HashPassword(password);

            var jwtToken = GenerateToken(user.UserName);

            if (valid)
            {
                return GetUserDetails(user, "User logged in successfully", jwtToken);
            }
            return GetUserDetails(user, "Unable to login", "");
        }


        /// <Summary>
        /// UserRegister
        /// </Summary>
        public async Task<IList<Blog>> GetAllBlogsAsync(int userId)
        {
            var res = await _userRepository.GetAllBlogsAsync(userId);
            return res;
        }



        /// <Summary>
        /// UserRegister
        /// </Summary>
        public async Task<string> DeleteBlogAsync(string blogName, int authorId)
        {
            var res = await _userRepository.DeleteBlogAsync(blogName, authorId);
            return res > 0 ? "Deleted the blog succesfully" : "Unable to delete the Blog"; ;
        }


        /// <Summary>
        /// UserRegister
        /// </Summary>
        public async Task<string> AddBlogAsync([FromBody] Blog blog)
        {
            var res = await _userRepository.AddBlogAsync(blog);
            return res > 0 ? "Added the blog succesfully" : "Unable to add the Blog";
        }


        /// <Summary>
        /// UserRegister
        /// </Summary>
        public async Task<string> UpdateBlogAsync(int blogId, Blog blog)
        {
            var res = await _userRepository.UpdateBlogAsync(blogId, blog);
            return res > 0 ? "Updated the blog succesfully" : "Unable to update the Blog";
        }

        private LoginInfo GetUserDetails(User user, string message, string jwtToken)
        {
            return new LoginInfo()
            {
                UserId = user != null ? user.UserId : 0,
                UserName = user?.UserName,
                UserEmail = user?.UserEmail,
                Message = message,
                JwtToken = jwtToken
            };
        }

        public string GenerateToken(string userName)
        {
            string _secretKey = "X9f!7kLz@2qP#vT8rW$1mN^dG*4hJ&6b"; // keep safe!
            string _issuer = "BlogSite";
            string _audience = "BlogSiteUsers";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Add claims (you can add more like roles, email, etc.)
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, userName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // token expiry
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
