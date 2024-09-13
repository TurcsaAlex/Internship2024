using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.DTOs
{
    public class MenuItemDTO
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public int OrderNo { get; set; }
        public string IconClass { get; set; }
        public string Link { get; set; }
        public bool Active { get; set; }

        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }

        public List<RoleDTO> Roles { get; set; }

        //public MenuItemDTO(MenuItem menuItem)
        //{
        //    MenuItemId = menuItem.MenuItemId;
        //    Name = menuItem.Name;
        //    IconClass = menuItem.IconClass;
        //    Link = menuItem.Link;
        //    Active = menuItem.Active;
        //}
      
    }
}
