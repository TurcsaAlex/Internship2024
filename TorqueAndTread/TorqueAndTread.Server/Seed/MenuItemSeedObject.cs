namespace TorqueAndTread.Server.Seed
{
    public class MenuItemSeedObject
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public int OrderNo { get; set; }
        public string IconClass { get; set; }
        public string Link { get; set; }
        public bool Active { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }

        public int LastUpdatedById { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
