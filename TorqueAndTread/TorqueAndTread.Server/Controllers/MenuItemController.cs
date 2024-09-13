using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
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
            if(!userId.HasValue)
            {
                return null;
            }
            return context.Users.FirstOrDefault(u => u.UserId == userId.Value);
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
                        Name=r.Name,
                        Active = r.Active,
                        LastUpdatedOn = r.LastUpdatedOn,
                        CreatedOn = r.CreatedOn
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
                    Name = r.Name,
                    Active = r.Active,
                    LastUpdatedOn = r.LastUpdatedOn,
                    CreatedOn = r.CreatedOn
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

            var createdBy = context.Users.FirstOrDefault(u => u.UserId == -1); // get user from token
            var menuItem = new MenuItem
            {
                Name = menuItemDTO.Name,
                OrderNo = menuItemDTO.OrderNo,
                IconClass = menuItemDTO.IconClass,
                Link = menuItemDTO.Link,
                CreatedBy = createdBy,
                CreatedOn = DateTime.UtcNow,
                Active = true,
                LastUpdatedBy = currentUser,
                LastUpdatedOn = DateTime.UtcNow,
            };

            if (menuItemDTO.Roles != null && menuItemDTO.Roles.Any())
            {
                var roleIds = menuItemDTO.Roles.Select(r=> r.RoleId).ToList();
                var rolesToAdd = await context.Roles.Where(r => roleIds.Contains(r.RoleId)).ToListAsync();
                if (rolesToAdd.Any())
                {
                    foreach (var role in rolesToAdd)
                    {
                        menuItem.Roles.Add(role);
                    }
                }
            }
           
            if (isUpdated)
            {
                menuItem.CreatedBy = currentUser;
                menuItem.CreatedOn = DateTime.UtcNow;
                context.MenuItems.Add(menuItem);

            }
            //else
            //{

            //    context.MenuItems.Update(menuItem);
            //    await context.SaveChangesAsync();
            //}  

            //    return CreatedAtAction(nameof(GetMenuItems), new { id = menuItem.MenuItemId }, menuItem);

            try
            {
                context.MenuItems.Add(menuItem);
                await context.SaveChangesAsync();
                return Ok(menuItemDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            }

       


        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuItem(int id, [FromBody] MenuItemDTO menuItemDTO)
        {

            var existingMenuItem = context.MenuItems.Include(m=>m.MenuItemRoles).Include(m=> m.Roles).FirstOrDefault(m=>m.MenuItemId == id);
            if (existingMenuItem == null)
            {
                return NotFound();
            }

            var currentUserId = GetCurrentUserID();

            var currentUser = await context.Users.FirstOrDefaultAsync(u => u.UserId == currentUserId.Value);
           

            existingMenuItem.Name = menuItemDTO.Name;
            existingMenuItem.OrderNo = menuItemDTO.OrderNo;
            existingMenuItem.IconClass = menuItemDTO.IconClass;
            existingMenuItem.Link = menuItemDTO.Link;
            existingMenuItem.LastUpdatedBy = currentUser;
            existingMenuItem.LastUpdatedOn = DateTime.UtcNow;

            if(existingMenuItem.CreatedBy == null || existingMenuItem.CreatedBy.UserId == 0)
            {
                existingMenuItem.CreatedBy = currentUser;
            }


            var existingRoleIds = existingMenuItem.MenuItemRoles.Select(mr => mr.RoleId).ToList();
            var newRoleIds = menuItemDTO.Roles.Select(r=> r.RoleId).ToList();
            Console.WriteLine($"Received roles count: , {menuItemDTO.Roles?.Count ?? 0}");

            var rolesToAdd = newRoleIds.Except(existingRoleIds).ToList();

            //foreach (var roleId in rolesToAdd)
            //{
            //    Console.WriteLine($"adding role {roleId} to MenuItem");
                
            //        var role = await context.Roles.FindAsync(roleId);
            //        if (role != null)
            //        {

            //            var menuItemRole = new MenuItemRole
            //            {
            //                MenuItemId = existingMenuItem.MenuItemId,
            //                RoleId = roleId,
            //                CreatedBy = currentUser,
            //                CreatedOn = DateTime.UtcNow,
            //                LastUpdatedBy = currentUser,
            //                LastUpdatedOn = DateTime.UtcNow,
            //                Active = true
            //            };
            //            existingMenuItem.MenuItemRoles.Add(menuItemRole);

            //        }
            //        else
            //        {
            //            Console.WriteLine($"Role with Id {roleId} not found");
            //        }
                
            //}

            //delete roles that are not associated

            //var rolesToRemove = existingRoleIds.Except(newRoleIds).ToList();
            //foreach (var roleId in rolesToRemove)
            //{
            //    var menuItemRole = existingMenuItem.MenuItemRoles.FirstOrDefault(mr => mr.RoleId == roleId);
            //    if(menuItemRole != null)
            //    {
            //        existingMenuItem.MenuItemRoles.Remove(menuItemRole);
            //    }
                
            //}

            try
            {
               
                await context.SaveChangesAsync();
                return Ok(existingMenuItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            
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
