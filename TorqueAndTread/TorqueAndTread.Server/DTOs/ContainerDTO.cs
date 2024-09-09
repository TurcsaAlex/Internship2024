using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.DTOs
{
    public class ContainerDTO
    {
        public int ContainerId { get; set; }
        public Nullable<int> BOMId { get; set; }
        public Nullable<int> UOMId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Quantity { get; set; }
        public bool Active { get; set; }
        public string UOMName { get; set; }
        public string ContainerCode { get; set; }
        public int ContainerTypeId { get; set; }
        public string ContainerTypeName { get; set; }
        public int ProductId { get; set; }

        public string ProductCode { get; set; }
        public ContainerDTO(){}
        public ContainerDTO(Container container)
        {
            ContainerTypeId = container.ContainerType.ContainerTypeId;
            ContainerTypeName = container.ContainerType.ContainerTypeName;
            ContainerId = container.ContainerId;
            BOMId = container.BOMId;
            UOMId = container.UOMId;
            if (container.UOM != null)
            {
                UOMName = container.UOM.UOMName;
            }
            if(container.Product != null)
            {
                ProductCode = container.Product.ProductCodeName;
                ProductId = container.Product.ProductId;
            }
            Name = container.Name;
            Quantity = container.Quantity;
            Active = container.Active;
            ContainerCode = container.ContainerCode;
        }
    }
}
