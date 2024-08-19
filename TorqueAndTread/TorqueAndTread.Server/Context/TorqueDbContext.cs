using TorqueAndTread.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TorqueAndTread.Server.Seed;

namespace TorqueAndTread.Server.Context
{
    public class TorqueDbContext:DbContext
    {
        public TorqueDbContext(DbContextOptions<TorqueDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemRole> MenuItemRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(e=>e.Roles).WithMany(e=>e.Users)
                .UsingEntity<UserRole>(
                j=>j.HasOne(t=>t.Role).WithMany(p=>p.UserRoles),
                j=>j.HasOne(t=>t.User).WithMany(p=>p.UserRoles));

            modelBuilder.Entity<MenuItem>().HasMany(e => e.Roles).WithMany(e => e.MenuItems)
                .UsingEntity<MenuItemRole>(
                j => j.HasOne(t => t.Role).WithMany(p => p.MenuItemRoles),
                j => j.HasOne(t => t.MenuItem).WithMany(p => p.MenuItemRoles));

            modelBuilder.Entity<ActionType>().HasMany(e=>e.Roles).WithMany(e=>e.ActionTypes)
                .UsingEntity<MenuItemActionRole>(
                j => j.HasOne(t => t.Role).WithMany(p => p.MenuItemActionRoles),
                j => j.HasOne(t => t.ActionType).WithMany(p => p.MenuItemActionRoles));

            modelBuilder.Entity<ActionType>().HasMany(e => e.MenuItems).WithMany(e => e.ActionTypes)
                .UsingEntity<MenuItemActionRole>(
                j => j.HasOne(t => t.MenuItem).WithMany(p => p.MenuItemActionRoles),
                j => j.HasOne(t => t.ActionType).WithMany(p => p.MenuItemActionRoles));

            modelBuilder.Entity<Role>().HasOne(e => e.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Role>().HasOne(e => e.LastUpdatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserRole>().HasOne(e => e.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserRole>().HasOne(e => e.LastUpdatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MenuItem>().HasOne(e => e.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MenuItem>().HasOne(e => e.LastUpdatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MenuItemRole>().HasOne(e => e.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MenuItemRole>().HasOne(e => e.LastUpdatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ActionType>().HasOne(e => e.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ActionType>().HasOne(e => e.LastUpdatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MenuItemActionRole>().HasOne(e => e.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MenuItemActionRole>().HasOne(e => e.LastUpdatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);


            //seeding

            var userSeed=LoadUserSeedDataFromFile();
            modelBuilder.Entity<User>().HasData(userSeed);
        }
        private List<UserSeedObject> LoadUserSeedDataFromFile()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seed\\Users.json");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Seed data file not found", filePath);
            }

            var jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<UserSeedObject>>(jsonData);
        }
    }
}