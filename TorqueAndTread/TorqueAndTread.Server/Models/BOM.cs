using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TorqueAndTread.Server.DTOs;

namespace TorqueAndTread.Server.Models
{
    public class BOM
    {
        [Key]

        public int BOMId { get; set; }

        [Required]
        public string BOMName { get; set; }
        public int MaterialId { get; set; }
        public string BOMCode { get; set; }

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
        public DateTime? LastUpdatedOn { get; set; }


        public ICollection<ProductBOM> ProductBOM { get; set; } // the relation for one-to-many with ProductBOM 
        public ICollection<Container> Containers { get; set; } // the relation one-to-many with BOM
        [ForeignKey("MaterialId")]
        public Product Material { get; set; }
        public BOM(){}
        public BOM(BOMCreateDTO bomCreate)
        {
            BOMName = bomCreate.BOMName;
            MaterialId=bomCreate.MaterialId;
            BOMCode = bomCreate.BOMCode;
        }
    }
}
