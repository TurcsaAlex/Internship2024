using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.Seed
{
    public class UserRoleSeedObject
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }


        public bool Active { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastUpdatedById { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
