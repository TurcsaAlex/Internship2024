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
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductBOM> ProductBOMs { get; set; }

        public DbSet<BOM> BOMs { get; set; }

        public DbSet<UOM> UOMs { get; set; }

        public DbSet<Container> Containers { get; set; }

        public DbSet<LoginAttempt> LoginAttempts { get; set; }

        public DbSet<ContainerType> ContainerTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(e => e.Roles).WithMany(e => e.Users)
                .UsingEntity<UserRole>(
                j => j.HasOne(t => t.Role).WithMany(p => p.UserRoles),
                j => j.HasOne(t => t.User).WithMany(p => p.UserRoles));

            modelBuilder.Entity<MenuItem>().HasMany(e => e.Roles).WithMany(e => e.MenuItems)
                .UsingEntity<MenuItemRole>(
                j => j.HasOne(t => t.Role).WithMany(p => p.MenuItemRoles),
                j => j.HasOne(t => t.MenuItem).WithMany(p => p.MenuItemRoles));

            modelBuilder.Entity<ActionType>().HasMany(e => e.Roles).WithMany(e => e.ActionTypes)
                .UsingEntity<MenuItemActionRole>(
                j => j.HasOne(t => t.Role).WithMany(p => p.MenuItemActionRoles),
                j => j.HasOne(t => t.ActionType).WithMany(p => p.MenuItemActionRoles));
            //modelBuilder.Entity<UserRole>().HasOne(ur => ur.User).WithMany(u => u.UserRoles)
            //    .HasForeignKey(ur => ur.UserId); 
            //modelBuilder.Entity<UserRole>().HasOne(ur => ur.Role).WithMany(r => r.UserRoles)
            //    .HasForeignKey(ur => ur.RoleId);
            modelBuilder.Entity<UserRole>().HasKey(ur =>new{ ur.UserId, ur.RoleId });

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
            modelBuilder.Entity<User>().HasOne(e => e.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasOne(e => e.LastUpdatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UOM>().HasOne(e => e.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UOM>().HasOne(e => e.LastUpdatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Container>().HasOne(e => e.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Container>().HasOne(e => e.LastUpdatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LoginAttempt>().HasOne(e => e.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LoginAttempt>().HasOne(e => e.LastUpdatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ContainerType>().HasOne(e => e.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ContainerType>().HasOne(e => e.LastUpdatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);


            //modelBuilder.Entity<Product>().HasOne(p => p.ProductType).WithMany(pt => pt.Products).HasForeignKey<Product>(p => p.ProductTypeId);

            modelBuilder.Entity<Product>().Property(p => p.ProductCodeName).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.Active).IsRequired();

            modelBuilder.Entity<Product>().HasIndex(p => p.ProductCodeName).IsUnique();

            modelBuilder.Entity<Product>().HasOne(e => e.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>().HasOne(e => e.LastUpdatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>().HasOne(e => e.UOM).WithMany().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Product>().Property(p => p.CreatedOn).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.LastUpdatedOn).IsRequired(false);

            //Required fields for ProductType

            modelBuilder.Entity<ProductType>().Property(pt => pt.ProductTypeName).IsRequired();

            modelBuilder.Entity<ProductType>().Property(pt => pt.Active).IsRequired();

            modelBuilder.Entity<ProductType>().HasOne(e => e.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductType>().HasOne(e => e.LastUpdatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductType>().Property(pt => pt.CreatedOn).IsRequired();

            modelBuilder.Entity<ProductType>().Property(pt => pt.LastUpdatedOn).IsRequired(false);

            //Required fields for ProductBOM

            modelBuilder.Entity<Product>().HasMany(p => p.ProductBOMs).WithOne(pb => pb.Product).HasForeignKey(pb => pb.ProductId);

            modelBuilder.Entity<ProductBOM>().Property(pb => pb.Active).IsRequired();

            modelBuilder.Entity<ProductBOM>().HasOne(e => e.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductBOM>().HasOne(e => e.LastUpdatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductBOM>().Property(pb => pb.CreatedOn).IsRequired();

            modelBuilder.Entity<ProductBOM>().Property(pb => pb.LastUpdatedOn).IsRequired(false);

            //Required fields for BOM

            modelBuilder.Entity<BOM>().HasMany(b => b.ProductBOM).WithOne(pb => pb.BOM).HasForeignKey(pb => pb.BOMId);

            modelBuilder.Entity<BOM>().Property(pb => pb.Active).IsRequired();

            modelBuilder.Entity<BOM>().HasOne(e => e.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BOM>().HasOne(e => e.LastUpdatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<BOM>().Property(pb => pb.CreatedOn).IsRequired();

            modelBuilder.Entity<BOM>().Property(pb => pb.LastUpdatedOn).IsRequired(false);

            //Required fields for Container

            modelBuilder.Entity<BOM>().HasMany(b => b.Containers).WithOne(c => c.BOM).HasForeignKey(c => c.BOMId);


            //LoginResult

            modelBuilder.Entity<LoginAttempt>().HasOne(u => u.User).WithMany();

            //Container

            modelBuilder.Entity<Container>().HasIndex(c=>c.ContainerCode).IsUnique();

            //seeding

            SeedData.Initialize(modelBuilder);
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