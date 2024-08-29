using TorqueAndTread.Server.Context;
using TorqueAndTread.Server.DTOs;
using TorqueAndTread.Server.Helpers;
using TorqueAndTread.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

namespace TorqueAndTread.Server.Services
{
    public class AuthService
    {
        private readonly string TokenListCacheKey = "listkey";
        private readonly TorqueDbContext _authContext;
        private IConfiguration _config;
        private MailSender _mailSender;
        private readonly IMemoryCache _cache;
        public AuthService(TorqueDbContext authContext, IConfiguration config, MailSender mailSender, IMemoryCache cache)
        {
            _config = config;
            _authContext = authContext;
            _mailSender = mailSender;
            _cache = cache;
        }
        public async Task<AuthDTO> Authenticate(LoginDTO userObj)
        {
            //_mailSender.SendTest();
            var user = await _authContext.Users.FirstOrDefaultAsync(x => x.UserName == userObj.UserName);
            if (user == null)
                return new AuthDTO(404);

            if (!PasswordHasher.VerifyPassword(userObj.Password, user.Password))
                return new AuthDTO(500);

            var token = GenerateJSONWebToken(user);

            var tokenList = _cache.Get<List<string>>(TokenListCacheKey) ?? new List<string>();

            // Add the new token to the list
            tokenList.Add(token);

            // Update the cache with the new list
            _cache.Set(TokenListCacheKey, tokenList, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(30)
            });

            return new AuthDTO(200, token);
        }

        public bool HasToken(string token) {
            var tokenList = _cache.Get<List<string>>(TokenListCacheKey);
            return tokenList != null && tokenList.Contains(token);
        }

        public async Task<int> RegisterUser(RegisterDTO registerDTO)
        {

            var searchUser = _authContext.Users.Where(u => u.UserId == -1);
            var active0User = searchUser.First();
            var userObj = new User(registerDTO);
            userObj.Password = PasswordHasher.HashPassword(userObj.Password);
            userObj.CreatedOn = DateTime.UtcNow;
            userObj.LastUpdatedOn = DateTime.UtcNow;
            userObj.CreatedBy = active0User;
            userObj.LastUpdatedBy = active0User;
            userObj.Active = true;
            await _authContext.Users.AddAsync(userObj);
            var saveResp = await _authContext.SaveChangesAsync();
            _mailSender.SendActivationMail(userObj.Email);
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
