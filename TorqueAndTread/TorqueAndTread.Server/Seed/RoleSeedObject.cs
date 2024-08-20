namespace TorqueAndTread.Server.Seed
{
    public class RoleSeedObject
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastUpdatedById { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
