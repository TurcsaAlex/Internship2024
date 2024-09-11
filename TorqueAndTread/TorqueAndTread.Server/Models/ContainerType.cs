using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TorqueAndTread.Server.Models
{
    public class ContainerType
    {
        [Key]
        public int ContainerTypeId { get; set; }

        [Required]

        public string ContainerTypeName { get; set; }

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
        public DateTime? LastUpdatedOn { get; set; }
        public IList<Container> Containers { get; set; }
    }
}
