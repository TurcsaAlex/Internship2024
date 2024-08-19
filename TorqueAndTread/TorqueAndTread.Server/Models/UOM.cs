using System.ComponentModel.DataAnnotations;

namespace TorqueAndTread.Server.Models
{
    public class UOM
    {
        [Key]
        public int UOMId { get; set; }

        [Required]

        public string UOMName { get; set; }

        [Required]

        public bool Active { get; set; }

        [Required]

        public string CreatedBy { get; set; }

        [Required]

        public DateTime CreatedOn { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedOn { get; set; }

        public Container Container { get; set; }
    }
}
