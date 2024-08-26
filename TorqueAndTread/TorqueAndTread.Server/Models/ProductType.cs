using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TorqueAndTread.Server.Models

{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }

        [Required]

        public string ProductTypeName { get; set; }

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
        public Product Product { get; set; } //the relation for one-to-one for Product



    }
}
