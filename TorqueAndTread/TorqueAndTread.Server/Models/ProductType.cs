using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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

        public string CreatedBy { get; set; }

        [Required]

        public DateTime CreatedOn { get; set; }

        public string LastUpdatedBy {  get; set; }

        public DateTime? LastUpdatedOn { get; set; }

        public Product Product { get; set; } //the relation for one-to-one for Product



    }
}
