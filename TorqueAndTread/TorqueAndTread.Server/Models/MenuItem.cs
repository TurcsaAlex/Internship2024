using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TorqueAndTread.Server.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public int OrderNo { get; set; }
        public string IconClass { get; set; }
        public string Link { get; set; }


        public List<Role> Roles { get; set; }
        public List<MenuItemRole> MenuItemRoles { get; set; }
        public List<ActionType> ActionTypes { get; set; }
        public List<MenuItemActionRole> MenuItemActionRoles { get; set; }



        [Required]
        public bool Active { get; set; }
        [Required]
        [ForeignKey("CreatedById")]
        public User CreatedBy { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        [ForeignKey("LastUpdatedById")]
        public User LastUpdatedBy { get; set; }
        [Required]
        public DateTime LastUpdatedOn { get; set; }
    }
}
