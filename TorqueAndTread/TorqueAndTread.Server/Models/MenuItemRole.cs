using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorqueAndTread.Server.Models
{
    public class MenuItemRole
    {
        [Key]
        public int MenuItemRoleId { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }


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
