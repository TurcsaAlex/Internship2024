namespace TorqueAndTread.Server.DTOs
{
    public class BOMUpdateDTO
    {
        public int BOMId { get; set; }
        public string BOMName { get; set; }
        public Nullable<int> MaterialId { get; set; }
        public string BOMCode { get; set; }
    }
}
