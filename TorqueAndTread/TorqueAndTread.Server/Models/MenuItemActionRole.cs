using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TorqueAndTread.Server.Models
{
    public class MenuItemActionRole
    {

        [Key]
        public int MenuItemActionRoleId { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int ActionTypeId { get; set; }
        public ActionType ActionType { get; set; }

        public bool ReqSuperVisorApproval { get; set; }

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
