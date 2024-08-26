using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TorqueAndTread.Server.Models
{
    public class ProductBOM
    {

        [Key]
        public int ProductBOMId { get; set; }

        [Required]
        public int ProductId { get; set; }


        [Required]

        public int BOMId { get; set; }

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
        public DateTime? LastUpdatedOn { get; set; }

        [ForeignKey("ProductId")]

        public Product Product { get; set; }

        [ForeignKey("BOMId")]

        public BOM BOM { get; set; }
    }
}
