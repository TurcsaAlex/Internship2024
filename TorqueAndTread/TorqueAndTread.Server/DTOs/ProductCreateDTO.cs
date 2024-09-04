namespace TorqueAndTread.Server.DTOs
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public string ProductCodeName { get; set; }
        public int ProductTypeId { get; set; }
        public int UOMId { get; set;}
    }
}
