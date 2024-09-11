using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TorqueAndTread.Server.DTOs;

namespace TorqueAndTread.Server.Models
{
    public class Container
    {

        [Key]
        public int ContainerId { get; set; }
        [Required]
        public string Name { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string ContainerCode { get; set; }


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

        public Nullable<int> BOMId { get; set; }
        public Nullable<int> UOMId { get; set; }
        public BOM BOM { get; set; }
        [ForeignKey("UOMId")]
        public UOM UOM { get; set; }
        public Nullable<int> ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public ContainerType ContainerType { get; set; }
        public Container()
        {
            
        }
        public Container(ContainerCreateDTO containerDTO)
        {
            Name = containerDTO.Name;
            Quantity = containerDTO.Quantity;
            ContainerCode = containerDTO.ContainerCode;
        }
    }
}
