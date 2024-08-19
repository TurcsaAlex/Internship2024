using TorqueAndTread.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace TorqueAndTread.Server.Context
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductBOM> ProductBOMs { get; set; }

        public DbSet<BOM> BOMs { get; set; }

        public DbSet<UOM> UOMs { get; set; }

        public DbSet<Container> Containers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");

            modelBuilder.Entity<Product>().HasOne(p => p.ProductType).WithOne(pt => pt.Product).HasForeignKey<Product>(p => p.ProductTypeId);

            modelBuilder.Entity<Product>().Property(p => p.ProductCodeName).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.Active).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.CreatedBy).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.CreatedOn).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.LastUpdatedBy).IsRequired(false);

            modelBuilder.Entity<Product>().Property(p => p.LastUpdatedOn).IsRequired(false);

            //Required fields for ProductType

            modelBuilder.Entity<ProductType>().Property(pt => pt.ProductTypeName).IsRequired();

            modelBuilder.Entity<ProductType>().Property(pt => pt.Active).IsRequired();

            modelBuilder.Entity<ProductType>().Property(pt => pt.CreatedBy).IsRequired();

            modelBuilder.Entity<ProductType>().Property(pt => pt.CreatedOn).IsRequired();

            modelBuilder.Entity<ProductType>().Property(pt => pt.LastUpdatedBy).IsRequired(false);

            modelBuilder.Entity<ProductType>().Property(pt => pt.LastUpdatedOn).IsRequired(false);

            //Required fields for ProductBOM

            modelBuilder.Entity<Product>().HasMany(p => p.ProductBOMs).WithOne(pb => pb.Product).HasForeignKey(pb => pb.ProductId);

            modelBuilder.Entity<ProductBOM>().Property(pb => pb.Active).IsRequired();

            modelBuilder.Entity<ProductBOM>().Property(pb => pb.CreatedBy).IsRequired();

            modelBuilder.Entity<ProductBOM>().Property(pb => pb.CreatedOn).IsRequired();

            modelBuilder.Entity<ProductBOM>().Property(pb => pb.LastUpdatedBy).IsRequired(false);

            modelBuilder.Entity<ProductBOM>().Property(pb => pb.LastUpdatedOn).IsRequired(false);

            //Required fields for BOM

            modelBuilder.Entity<BOM>().HasMany(b => b.ProductBOM).WithOne(pb => pb.BOM).HasForeignKey(pb =>  pb.BOMId);
            
            modelBuilder.Entity<BOM>().Property(pb => pb.Active).IsRequired();

            modelBuilder.Entity<BOM>().Property(pb => pb.CreatedBy).IsRequired();

            modelBuilder.Entity<BOM>().Property(pb => pb.CreatedOn).IsRequired();

            modelBuilder.Entity<BOM>().Property(pb => pb.LastUpdatedBy).IsRequired(false);

            modelBuilder.Entity<BOM>().Property(pb => pb.LastUpdatedOn).IsRequired(false);

            //Required fields for Container
            
            modelBuilder.Entity<BOM>().HasMany(b => b.Containers).WithOne(c => c.BOM).HasForeignKey(c => c.BOMId);

            //Required fields for UOM

            modelBuilder.Entity<UOM>().HasOne(u => u.Container).WithOne(c => c.UOM).HasForeignKey<Container>(c => c.UOMId);

        }

    }
}
