using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TorqueAndTread.Server.Context;
using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.Seed
{
    public class SeedData
    {
        
        //public static void Initialize(TorqueDbContext context)
        //{
        //    if (context.Users.Any())
        //    {
        //        return;
        //    }
        //    var userSeed = LoadUserSeedDataFromFile1();
        //    foreach (var u in userSeed) {
        //        context.Users.Add(new User() {
        //            Name = u.Name,
        //            UserName = u.UserName,
        //            Password = u.Password,
        //            Email = u.Email,
        //            CreatedOn = u.CreatedOn,
        //            CreatedBy =u,
        //            LastUpdatedBy =u,
        //            LastUpdatedOn=u.LastUpdatedOn,
        //            Active = u.Active
        //        });
        //    }
        //    context.SaveChanges();
        //}
        public static void Initialize(ModelBuilder modelBuilder) {
            var userSeed = LoadUserSeedDataFromFile();
            modelBuilder.Entity<User>().HasData(userSeed);
            var roleSeed= LoadRoleSeedDataFromFile();
            modelBuilder.Entity<Role>().HasData(roleSeed);
            var userRoleSeed = LoadUserRoleSeedDataFromFile();
            modelBuilder.Entity<UserRole>().HasData(userRoleSeed);
            var productTypeSeed = LoadProductTypeSeedDataFromFile();
            modelBuilder.Entity<ProductType>().HasData(productTypeSeed);
            var uomSeed=LoadUOMSeedDataFromFile();
            modelBuilder.Entity<UOM>().HasData(uomSeed);
            var menuItemSeed = LoadMenuItemSeedDataFile();
            modelBuilder.Entity<MenuItem>().HasData(menuItemSeed);
        }
        private static List<UserSeedObject> LoadUserSeedDataFromFile()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seed\\Users.json");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Seed data file not found", filePath);
            }

            var jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<UserSeedObject>>(jsonData);
        }
        private static List<RoleSeedObject> LoadRoleSeedDataFromFile()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seed\\Roles.json");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Seed data file not found", filePath);
            }

            var jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<RoleSeedObject>>(jsonData);
        }

        private static List<UserRoleSeedObject> LoadUserRoleSeedDataFromFile()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seed\\UserRoles.json");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Seed data file not found", filePath);
            }

            var jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<UserRoleSeedObject>>(jsonData);
        }

        private static List<ProductTypeSeedObject> LoadProductTypeSeedDataFromFile()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seed\\ProductTypes.json");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Seed data file not found", filePath);
            }

            var jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<ProductTypeSeedObject>>(jsonData);
        }

        private static List<UOMSeedObject> LoadUOMSeedDataFromFile()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seed\\UOMs.json");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Seed data file not found", filePath);
            }

            var jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<UOMSeedObject>>(jsonData);
        }

        private static List<User> LoadUserSeedDataFromFile1()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seed\\Users.json");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Seed data file not found", filePath);
            }

            var jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<User>>(jsonData);
        }

        private static List<MenuItemSeedObject> LoadMenuItemSeedDataFile()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seed\\MenuItem.json");
            if(!File.Exists(filePath))
            {
                throw new FileNotFoundException("Seed data file not found", filePath);
            }

            var jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<MenuItemSeedObject>>(jsonData);
        }
    }
}
