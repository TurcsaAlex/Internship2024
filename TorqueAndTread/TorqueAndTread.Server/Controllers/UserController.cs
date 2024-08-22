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

        [HttpPost("login", Name ="LoginUser")]
        public async Task<IActionResult> Authenticate([FromBody] LoginDTO loginDTO)
        {
            if (loginDTO == null)
                return BadRequest();
            var authResp= await _userService.Authenticate(loginDTO);
            switch (authResp.Code)
            {
                case 200:
                    return Ok(new { Token =authResp.Token });
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
            await _userService.RegisterUser(registerDTO);
            return Ok(new { Message = "User registered!" });
        }
    }
}
