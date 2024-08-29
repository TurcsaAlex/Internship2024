using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TorqueAndTread.Server.Context;
using TorqueAndTread.Server.DTOs;
using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly TorqueDbContext context; 
        public MenuItemController(TorqueDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems()
        {
            var menuItems = await context.MenuItems.Select(
                m => new MenuItemDTO
                {
                    MenuItemId = m.MenuItemId,
                    Name = m.Name,
                    OrderNo = m.OrderNo,
                    IconClass = m.IconClass,
                    Active = m.Active,
                    Link = m.Link,
                }).ToListAsync();
            return Ok(menuItems);

            //return await context.MenuItems.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<MenuItem>> GetMenuItem(int id)
        {
            var menuItem = await context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return Ok(menuItem);
        }

        [HttpPost]
        public async Task<ActionResult<MenuItem>> PostMenuItem([FromBody] MenuItemDTO menuItemDTO)
        {
            //menuItemDTO.CreatedOn = DateTime.Now;

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
                //CreatedBy = createdBy,
                //CreatedOn = DateTime.UtcNow,
                Active = true,
                LastUpdatedBy = createdBy,
                LastUpdatedOn = DateTime.UtcNow,
            };
            if (!isUpdated)
            {
                menuItem.CreatedBy = createdBy;
                menuItem.CreatedOn = DateTime.UtcNow;
                context.MenuItems.Add(menuItem);

            }
            else
            {

                context.MenuItems.Update(menuItem);
                menuItem.CreatedBy = createdBy;
            }   await context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetMenuItem), new { id = menuItem.MenuItemId }, menuItem);
            }

        [HttpPut("{id}")]

        public async Task<IActionResult> PutMenuItem(int id, [FromBody] MenuItemDTO menuItemDTO)
        {

            var existingMenuItem = context.MenuItems.FirstOrDefault(m => m.MenuItemId == id);
            if (existingMenuItem == null)
            {
                return NotFound();
            }
            existingMenuItem.Name = menuItemDTO.Name;
            existingMenuItem.OrderNo = menuItemDTO.OrderNo;
            existingMenuItem.IconClass = menuItemDTO.IconClass;
            existingMenuItem.Link = menuItemDTO.Link;

            try
            {
                context.Entry(existingMenuItem).State = EntityState.Modified;
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

            menuItem.Active = true;
            menuItem.LastUpdatedOn = DateTime.Now;
            menuItem.LastUpdatedBy = menuItem.LastUpdatedBy;
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
