using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.Seed
{
    public class ContainerTypeSeedObject
    {
        public int ContainerTypeId { get; set; }
        public string ContainerTypeName { get; set; }
        public bool Active { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastUpdatedById { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
