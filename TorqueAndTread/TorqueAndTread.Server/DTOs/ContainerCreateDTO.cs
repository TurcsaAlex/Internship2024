namespace TorqueAndTread.Server.DTOs
{
    public class ContainerCreateDTO
    {
        public string Name { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string ContainerCode { get; set; }
        public Nullable<int> UOMId { get; set; }
        public int ContainerTypeId { get; set; }
        public Nullable<int> ProductId { get; set; }
    }
}
