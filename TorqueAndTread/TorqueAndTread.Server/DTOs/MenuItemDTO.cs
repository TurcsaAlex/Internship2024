namespace TorqueAndTread.Server.DTOs
{
    public class MenuItemDTO
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public int OrderNo { get; set; }
        public string IconClass { get; set; }
        public string Link { get; set; }
        public bool Active { get; set; }
    }
}
