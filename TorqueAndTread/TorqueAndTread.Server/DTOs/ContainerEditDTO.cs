using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.DTOs
{
    public class ContainerEditDTO
    {
        public int ContainerId { get; set; }
        public Nullable<int> BOMId { get; set; }
        public Nullable<int> UOMId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string ContainerCode { get; set; }
        public int ContainerTypeId { get; set; }
        public int ProductId { get; set; }

    }
}
