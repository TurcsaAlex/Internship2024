using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorqueAndTread.Server.Models
{
    public class Container
    {

        [Key]
        public int ContainerId { get; set; }

        [Required]
        public int BOMId { get; set; }

        [Required]
        public int UOMId { get; set; }

        [Required]

        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }


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

        public BOM BOM { get; set; }
        public UOM UOM { get; set; }

    }
}
