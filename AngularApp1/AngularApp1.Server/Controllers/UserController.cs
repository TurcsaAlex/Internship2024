using AngularApp1.Server.Context;
using AngularApp1.Server.Helpers;
using AngularApp1.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AngularApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _authContext;
        private IConfiguration _config;
        public UserController(UserDbContext userDbContext, IConfiguration config)
        {
            _authContext = userDbContext;
            _config = config;
        }

        [HttpGet("test")]
        [Authorize]
        public async Task<IActionResult> Test()
        {
            return Ok(new { Message = "Ok" });
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();
            var user = await _authContext.Users.FirstOrDefaultAsync( x => x.UserName == userObj.UserName);
            if (user == null)
                return NotFound(new { Message = "User not found" });
            
            if(!PasswordHasher.VerifyPassword(userObj.Password,user.Password))
                return BadRequest(new {Message="Incorrect password"});

            var token=GenerateJSONWebToken(user);

            return Ok(new { Message = "Login Success!", Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if(userObj== null) { return BadRequest();}
            if (string.IsNullOrEmpty(userObj.UserName) || string.IsNullOrEmpty(userObj.Password)) { return BadRequest(); }
            userObj.Password = PasswordHasher.HashPassword(userObj.Password);
            userObj.Role = "User";
            userObj.Token = "";
            await _authContext.Users.AddAsync(userObj);
            await _authContext.SaveChangesAsync();
            return Ok(new { Message = "User registered!" });
        }
        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("username",userInfo.UserName),
                new Claim (ClaimTypes.Role,userInfo.Role),
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
