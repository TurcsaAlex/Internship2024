using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TorqueAndTread.Server.DTOs;
using TorqueAndTread.Server.Services;

namespace TorqueAndTread.Server.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            return Ok(user);
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var username = HttpContext.Items["Username"] as string;
            var userId = int.Parse(HttpContext.Items["UserId"] as string);
            if (userId == null)
            {
                return Unauthorized();
            }

            var userDTO = await _userService.GetUser(userId);
            return Ok(userDTO.First());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserAbvrDTO userAbvrDTO)
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }

            await _userService.EditUser(userAbvrDTO, username);
            return Ok(new { Message = "success" });
        }
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserCreateDTO userAbvrDTO)
        {
            await _userService.CreateUser(userAbvrDTO, -1);
            return Ok(new { Message = "success" });
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.SoftDeleteUser(id,-1);
            return Ok(new { Message = "success" });

        }
    }
}
