using System.ComponentModel.DataAnnotations;

namespace TorqueAndTread.Server.Models
{
    public class BOM
    {
        [Key]

        public int BOMId { get; set; }

        [Required]

        public string BOMName { get; set; }

        [Required]

        public int MaterialIdBOMCode { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]

        public string CreatedBy { get; set; }

        [Required]

        public DateTime CreatedOn { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedOn { get; set; }

        public ICollection<ProductBOM> ProductBOM { get; set; } // the relation for one-to-many with ProductBOM 

        public ICollection<Container> Containers { get; set; } // the relation one-to-many with BOM
    }
}
