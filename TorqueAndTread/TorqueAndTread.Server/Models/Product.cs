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

        [Required]

        public string ProductTypeIdName { get; set; }

        [Required]

        public string ProductCodeName { get; set; }

        [Required]

        public bool Active { get; set; }

        [Required]

        public string CreatedBy { get; set; }

        [Required]

        public DateTime CreatedOn { get; set; } 

        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedOn { get; set; }

        public int ProductTypeId { get; set; }

        [ForeignKey("ProductTypeId")]

        public ProductType ProductType { get; set; } //navigation for ProductType
    }
}
