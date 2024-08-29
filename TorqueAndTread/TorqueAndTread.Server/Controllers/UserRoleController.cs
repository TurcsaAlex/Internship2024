using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TorqueAndTread.Server.DTOs;
using TorqueAndTread.Server.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TorqueAndTread.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private RoleService _roleService;
        public UserRoleController(RoleService roleService) {
            _roleService = roleService;
        }
        // GET: api/<RoleController>
        [HttpGet("all/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var list = await _roleService.GetRolesByUserId(userId);
            return Ok(list);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<IActionResult> PostUserRole(PostUserRoleDTO userRoleDTO)
        {
            _roleService.PostUserRole(userRoleDTO,-1);
            return Ok(new { message = "success" });
        }

        // DELETE api/<RoleController>/5
        [HttpDelete]
        public async Task<IActionResult> DeleteUserRole(PostUserRoleDTO userRoleDTO)
        {
            _roleService.DeleteUserRole(userRoleDTO, -1);
            return Ok(new { message = "success" });
        }
    }
}
