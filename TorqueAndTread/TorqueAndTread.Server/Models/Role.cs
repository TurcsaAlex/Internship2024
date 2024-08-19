using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorqueAndTread.Server.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }
        
        
        public List<User> Users { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<MenuItem> MenuItems { get; set; }
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
