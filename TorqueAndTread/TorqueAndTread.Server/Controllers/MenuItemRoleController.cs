using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TorqueAndTread.Server.Context;
using TorqueAndTread.Server.DTOs;
using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    [Authorize]
    public class MenuItemRoleController: ControllerBase
    {

        private readonly TorqueDbContext context;

        public MenuItemRoleController(TorqueDbContext context)
        {
            this.context = context;
        }

        private int? GetCurrentUserID()
        {
            var userIdValue = User.FindFirstValue("userId");
            if (string.IsNullOrEmpty(userIdValue))
            {
                return null;
            }
            Console.WriteLine($"User id from:{userIdValue} ");
            return int.Parse(userIdValue);
        }

        private User GetCurrentUser()
        {
            var userId = GetCurrentUserID();
            if (!userId.HasValue)
            {
                return null;
            }
            return context.Users.FirstOrDefault(u => u.UserId == userId.Value);
        }

        [HttpPost("{id}/roles")]
        public async Task<IActionResult> AddRoleToMenuItem(int id, [FromBody] int roleId)
        {
            Console.WriteLine($"Received menuItemId : {id}, roleId: {roleId}");
            var menuItem = await context.MenuItems.Include(m => m.Roles).FirstOrDefaultAsync(m => m.MenuItemId == id);
            if (menuItem == null)
            {
                return NotFound(new { message = "Menu item not found" });
            }

            var role = await context.Roles.FindAsync(roleId);
            if (role == null)
            {
                return NotFound(new { message = "Role not found" });
            }

            if (menuItem.Roles.Any(r => r.RoleId == roleId))
            {
                return BadRequest(new { message = "Role is already associated with this menu item" });
            }

            var currentUser = GetCurrentUser();
            if (currentUser == null)
            {
                return BadRequest();
            }

            var menuItemRole = new MenuItemRole
            {
                MenuItemId = id,
                RoleId = roleId,
                CreatedBy = currentUser,
                LastUpdatedBy = currentUser,
                CreatedOn = DateTime.UtcNow,
                LastUpdatedOn = DateTime.UtcNow,
                Active = true,
            };

            context.MenuItemRoles.Add(menuItemRole); 
            try
            {
                
                await context.SaveChangesAsync();
                return Ok(new { message = "Role added" });
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}/roles/{roleId}")]
        public async Task<IActionResult> RemoveRoleFromMenuItem(int id, int roleId)
        {
            var menuItem = context.MenuItems.Include(m => m.Roles).FirstOrDefault(m => m.MenuItemId == id);
            if (menuItem == null)
            {
                return NotFound(new { message = "Menu item not found" });
            }

            var role = context.MenuItemRoles.FirstOrDefault(mr => mr.MenuItemId == id && mr.RoleId == roleId); 
            if (role == null)
            {
                return NotFound(new { message = "Role not found on this menu item" });
            }
            else
            {

                role.LastUpdatedOn = DateTime.UtcNow;
                role.LastUpdatedBy = menuItem.LastUpdatedBy;
                role.Active = false;
            }
           
            context.MenuItemRoles.Remove(role);
            try
            {
                await context.SaveChangesAsync();
                return Ok(new { message = "Role removed successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
