using AngularApp1.Server.Context;
using AngularApp1.Server.Helpers;
using AngularApp1.Server.Models;
using AngularApp1.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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

        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
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
            var authResp= await _userService.Authenticate(userObj);
            switch (authResp.Code)
            {
                case 200:
                    return Ok(new { Message = "Login Success!", Token =authResp.Token });
                case 404:
                    return NotFound(new { Message = "User not found" });
                case 500:
                    return BadRequest(new { Message = "Incorrect password" });
                default:
                    return Problem();
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if(userObj== null) { return BadRequest();}
            if (string.IsNullOrEmpty(userObj.UserName) || string.IsNullOrEmpty(userObj.Password)) { return BadRequest(); }
            await _userService.RegisterUser(userObj);
            return Ok(new { Message = "User registered!" });
        }
    }
}
