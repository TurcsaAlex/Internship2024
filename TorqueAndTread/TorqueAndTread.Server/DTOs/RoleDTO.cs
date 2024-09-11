using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.DTOs
{
    public class RoleDTO
    {
        public int RoleId { get; set; }
        public string Name { get; set; }

        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }

        public RoleDTO(){}

        public RoleDTO(Role role)
        {
            RoleId=role.RoleId;
            Name=role.Name;
            Active=true;
            CreatedOn = role.CreatedOn;
            LastUpdatedOn = role.LastUpdatedOn;
        }
    }
}
