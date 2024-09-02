using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.DTOs
{
    public class ProductTypeDTO
    {
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }

    }
}
