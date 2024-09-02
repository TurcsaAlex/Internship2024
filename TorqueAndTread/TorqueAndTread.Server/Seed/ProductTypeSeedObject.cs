using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.Seed
{
    public class ProductTypeSeedObject
    {
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public bool Active { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastUpdatedById { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

    }
}
