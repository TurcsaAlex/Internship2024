using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

    public class MenuItemController : ControllerBase
    {
        private readonly TorqueDbContext context; 
        public MenuItemController(TorqueDbContext context)
        {
            this.context = context;
        }

        private int GetCurrentUserID()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        private User GetCurrentUser()
        {
            var userId = GetCurrentUserID();
            return context.Users.FirstOrDefault(u => u.UserId == userId);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItemDTO>>> GetMenuItems()
        {
            var menuItems = await context.MenuItems.Include(m=> m.Roles).Select(
                m => new MenuItemDTO
                {
                    MenuItemId = m.MenuItemId,
                    Name = m.Name,
                    OrderNo = m.OrderNo,
                    IconClass = m.IconClass,
                    Active = m.Active,
                    Link = m.Link,
                    LastUpdatedOn = m.LastUpdatedOn,
                    CreatedOn = m.CreatedOn,
                    Roles = m.Roles.Select(r=> new RoleDTO
                    {
                        RoleId = r.RoleId,
                        Name=r.Name
                    }).ToList()
                }).ToListAsync();
            return Ok(menuItems);

        }


        [HttpGet("{id}")]

        public async Task<ActionResult<MenuItemDTO>> GetMenuItems(int id)
        {

            var menuItem = context.MenuItems.Include( m => m.Roles).FirstOrDefault(m => m.MenuItemId == id);
            if (menuItem == null)
            {
                return NotFound();
            }

            var menuItemDTO = new MenuItemDTO
            {
                MenuItemId = menuItem.MenuItemId,
                Name = menuItem.Name,
                OrderNo = menuItem.OrderNo,
                IconClass = menuItem.IconClass,
                Active = menuItem.Active,
                Link = menuItem.Link,
                LastUpdatedOn = menuItem.LastUpdatedOn,
                CreatedOn = menuItem.CreatedOn,
                Roles = menuItem.Roles.Select( r=> new RoleDTO
                {
                    RoleId= r.RoleId,
                    Name = r.Name
                }).ToList()
            };

            return Ok(menuItemDTO);
        }


        [HttpPost]
        public async Task<ActionResult<MenuItem>> PostMenuItem([FromBody] MenuItemDTO menuItemDTO)
        {
         
            var currentUser = GetCurrentUser();
            
            var isUpdated = false;
            if (menuItemDTO.MenuItemId != null && menuItemDTO.MenuItemId > 0)
            {
                isUpdated = true;
            }

            //var createdBy = context.Users.FirstOrDefault(u => u.UserId == -1); // get user from token
            var menuItem = new MenuItem
            {
                Name = menuItemDTO.Name,
                OrderNo = menuItemDTO.OrderNo,
                IconClass = menuItemDTO.IconClass,
                Link = menuItemDTO.Link,
                //CreatedBy = createdBy,
                CreatedOn = DateTime.UtcNow,
                Active = true,
                LastUpdatedBy = currentUser,
                LastUpdatedOn = DateTime.UtcNow,
            };
            if (!isUpdated)
            {
                menuItem.CreatedBy = currentUser;
                menuItem.CreatedOn = DateTime.UtcNow;
                context.MenuItems.Add(menuItem);

            }
            else
            {

                context.MenuItems.Update(menuItem);
            }   await context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetMenuItems), new { id = menuItem.MenuItemId }, menuItem);
            }


        [HttpPut("{id}")]

        public async Task<IActionResult> PutMenuItem(int id, [FromBody] MenuItemDTO menuItemDTO)
        {

            var existingMenuItem = context.MenuItems.Include(m=>m.Roles).FirstOrDefault(m=>m.MenuItemId == id);
            if (existingMenuItem == null)
            {
                return NotFound();
            }

            var currentUser = GetCurrentUser();

            existingMenuItem.Name = menuItemDTO.Name;
            existingMenuItem.OrderNo = menuItemDTO.OrderNo;
            existingMenuItem.IconClass = menuItemDTO.IconClass;
            existingMenuItem.Link = menuItemDTO.Link;
            existingMenuItem.LastUpdatedBy = currentUser;
            existingMenuItem.LastUpdatedOn = DateTime.UtcNow;


            var existingRoleIds = existingMenuItem.Roles.Select(mr => mr.RoleId).ToList();
            var newRoleIds = menuItemDTO.Roles.Select( r=> r.RoleId).ToList();  // actualise roles

            var rolesToAdd = menuItemDTO.Roles.Where( r=> ! existingRoleIds.Contains(r.RoleId ) ).ToList(); // add new roles which are not associated

            foreach (var roleDTO in rolesToAdd)
            {
                var role = await context.Roles.FindAsync(roleDTO.RoleId);
                if (role != null) 
                {
                    existingMenuItem.Roles.Add(role);
                }
            }

            //delete roles that are not associated

            var rolesToRemove = existingMenuItem.Roles.Where(mr => !newRoleIds.Contains(mr.RoleId)).ToList();
            foreach (var role in rolesToRemove)
            {
                existingMenuItem.Roles.Remove(role);
            }

            try
            {
               
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return Ok(existingMenuItem);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var menuItem = await context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            var currentUser = GetCurrentUser();

            menuItem.Active = false;
            menuItem.LastUpdatedOn = DateTime.Now;
            menuItem.LastUpdatedBy = currentUser;
            context.MenuItems.Update(menuItem);

            await context.SaveChangesAsync();
            return Ok(menuItem);
        }

        private bool MenuItemExists(int id)
        {
            return context.MenuItems.Any(e => e.MenuItemId == id);
        }
    }
}
