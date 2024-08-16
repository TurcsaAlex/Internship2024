using TorqueAndTread.Server.Context;
using TorqueAndTread.Server.DTOs;
using TorqueAndTread.Server.Helpers;
using TorqueAndTread.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TorqueAndTread.Server.Services
{
    public class UserService
    {

        private readonly UserDbContext _authContext;
        private IConfiguration _config;
        public UserService(UserDbContext authContext,IConfiguration config)
        {
            _config = config;
            _authContext = authContext;
        }
        public async Task<AuthDTO> Authenticate(User userObj)
        {
            var user = await _authContext.Users.FirstOrDefaultAsync(x => x.UserName == userObj.UserName);
            if (user == null)
                return new AuthDTO(404);

            if (!PasswordHasher.VerifyPassword(userObj.Password, user.Password))
                return new AuthDTO(500);

            var token = GenerateJSONWebToken(user);

            return new AuthDTO(200, token);
        }

        public async Task<int> RegisterUser(User userObj)
        {
            userObj.Password = PasswordHasher.HashPassword(userObj.Password);
            await _authContext.Users.AddAsync(userObj);
            var saveResp=await _authContext.SaveChangesAsync();
            return saveResp;
        }
        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("username",userInfo.UserName)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
