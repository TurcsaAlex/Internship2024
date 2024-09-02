namespace TorqueAndTread.Server.Seed
{
    public class UOMSeedObject
    {
        public int UOMId { get; set; }
        public string UOMName { get; set; }
        public bool Active { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastUpdatedById { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

    }
}
