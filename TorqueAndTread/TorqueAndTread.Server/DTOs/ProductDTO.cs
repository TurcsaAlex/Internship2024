using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductCodeName { get; set; }
        public bool Active { get; set; }
        public int ProductTypeId { get; set; }
        public int UOMId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string ProductTypeName { get; set; } 
        public string UOMName { get; set; }
        public Nullable<int> Quantity { get; set; }

    }
}
