using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.DTOs
{
    public class UserRolesDTO
    {
        public string Name { get; set; }

        public int UserId { get; set; }
        public int RoleId { get; set; }


        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }

        public UserRolesDTO(UserRole userRole)
        {
            Active = userRole.Active;
            CreatedOn = userRole.CreatedOn;
            LastUpdatedOn = userRole.LastUpdatedOn;
            RoleId = userRole.RoleId;
            UserId = userRole.UserId;
        }
        public UserRolesDTO(){}
    }
}
