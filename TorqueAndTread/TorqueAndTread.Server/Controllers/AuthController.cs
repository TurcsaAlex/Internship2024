using TorqueAndTread.Server.Context;
using TorqueAndTread.Server.Helpers;
using TorqueAndTread.Server.Models;
using TorqueAndTread.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TorqueAndTread.Server.DTOs;

namespace TorqueAndTread.Server.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly AuthService _authService;
        public AuthController(AuthService userService)
        {
            _authService = userService;
        }

        [HttpGet("test")]
        [Authorize]
        public async Task<IActionResult> Test()
        {
            var username = HttpContext.Items["Username"] as string;

            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized("Username not found in token");
            }

            // Your logic here
            return Ok(new { Username = username });
        }

        [HttpPost("login", Name ="LoginUser")]
        public async Task<IActionResult> Authenticate([FromBody] LoginDTO loginDTO)
        {
            if (loginDTO == null)
                return BadRequest();
            var authResp= await _authService.Authenticate(loginDTO);
            switch (authResp.Code)
            {
                case 200:
                    return Ok(authResp);
                case 404:
                    return NotFound(new { Message = "User not found" });
                case 500:
                    return BadRequest(new { Message = "Incorrect password" });
                default:
                    return Problem();
            }
        }

        [HttpPost("register",Name ="RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDTO registerDTO)
        {
            if(registerDTO== null) { return BadRequest();}
            if (string.IsNullOrEmpty(registerDTO.UserName) || string.IsNullOrEmpty(registerDTO.Password)) { 
                return BadRequest(); 
            }
            await _authService.RegisterUser(registerDTO);
            return Ok(new { Message = "User registered!" });
        }
    }
}
