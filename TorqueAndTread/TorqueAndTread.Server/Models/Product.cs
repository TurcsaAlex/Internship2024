using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
namespace TorqueAndTread.Server.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        [Required]
        public string ProductCodeName { get; set; }


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


        [ForeignKey("ProductTypeId")]
        public ProductType ProductType { get; set; }

        [ForeignKey("DefaultUOMId")]
        public UOM UOM { get; set; }
        public Nullable<int> ContainerId { get; set; }
        [ForeignKey("ContainerId")]
        public  Container Container { get; set; }
        public ICollection<ProductBOM> ProductBOMs { get; set; } //navigation for ProductBOM, one-to-many relation

    }
}
