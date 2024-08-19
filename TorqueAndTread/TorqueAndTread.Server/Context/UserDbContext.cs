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

        }

    }
}
