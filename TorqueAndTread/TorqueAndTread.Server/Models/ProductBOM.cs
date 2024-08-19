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

        public string CreatedBy { get; set; }

        [Required]

        public DateTime CreatedOn { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedOn { get; set; }

        [ForeignKey("ProductId")]

        public Product Product { get; set; }

        [ForeignKey("BOMId")]

        public BOM BOM { get; set; }
    }
}
