using Microsoft.EntityFrameworkCore;
using TorqueAndTread.Server.Context;
using TorqueAndTread.Server.DTOs;
using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.Services
{
    public class ProductService
    {
        private readonly TorqueDbContext _dbContext;
        public ProductService(TorqueDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<ProductDTO>> GetAllProducts()
        {
            var products = _dbContext.Products
                .Where(p => p.Active == true)
                .Select(p => new ProductDTO()
                {
                    ProductId = p.ProductId,
                    ProductCodeName = p.ProductCodeName,
                    LastUpdatedOn = p.LastUpdatedOn,
                    CreatedOn = p.CreatedOn,
                    Active = p.Active,
                    Name = p.Name,
                    ProductTypeName = p.ProductType.ProductTypeName,
                    UOMName = p.UOM.UOMName,
                    UOMId = p.UOM.UOMId,
                });

            return products.ToList();
        }
        public async Task<IList<string>> GetAllProductCodes()
        {
            var products = _dbContext.Products
                .Where(p => p.Active == true)
                .Select(p => p.ProductCodeName
                );

            return products.ToList();
        }

        public async Task<ProductDTO> GetProduct(int productId)
        {
            var products = _dbContext.Products
                .Where(p => p.Active == true && p.ProductId==productId)
                .Select(p => new ProductDTO()
                {
                    ProductId = p.ProductId,
                    ProductCodeName = p.ProductCodeName,
                    LastUpdatedOn = p.LastUpdatedOn,
                    CreatedOn = p.CreatedOn,
                    Active = p.Active,
                    Name = p.Name,
                    ProductTypeName = p.ProductType.ProductTypeName,
                    ProductTypeId=p.ProductType.ProductTypeId,
                    UOMName = p.UOM.UOMName,
                    UOMId = p.UOM.UOMId,
                });

            return products.First();
        }
        public async Task CreateProduct(ProductCreateDTO productDTO, string creatingUsername)
        {
            var creatingUser = _dbContext.Users.FirstOrDefault(u => u.UserName == creatingUsername);
            if (creatingUser == null) { return; }

            var producType = await _dbContext.ProductTypes.FirstOrDefaultAsync(pt => pt.ProductTypeId == productDTO.ProductTypeId);
            if(producType == null) { return; }

            var UOM = await _dbContext.UOMs.FirstOrDefaultAsync(pt => pt.UOMId == productDTO.UOMId);
            if (UOM == null) { return; }

            var newProduct = new Product()
            {
                Active = true,
                CreatedBy = creatingUser,
                LastUpdatedBy = creatingUser,
                CreatedOn = DateTime.Now,
                LastUpdatedOn = DateTime.Now,
                Name = productDTO.Name,
                ProductCodeName = productDTO.ProductCodeName,
                ProductType = producType,
                UOM=UOM,
            };
            await _dbContext.Products.AddAsync(newProduct);
            await _dbContext.SaveChangesAsync();
        }


        public async Task EditProduct(ProductEditDTO product, string updatingUsername)
        {
            var whoUpdatesTheUser = _dbContext.Users.FirstOrDefault(u => u.UserName == updatingUsername);
            if (whoUpdatesTheUser == null) { return; }

            var productToUpdate = _dbContext.Products.FirstOrDefault(u => u.ProductId == product.ProductId);
            if (productToUpdate == null) { return; }

            var producType = await _dbContext.ProductTypes.FirstOrDefaultAsync(pt => pt.ProductTypeId == product.ProductTypeId);
            if (producType == null) { return; }

            var UOM = await _dbContext.UOMs.FirstOrDefaultAsync(pt => pt.UOMId == product.UOMId);
            if (UOM == null) { return; }

            productToUpdate.ProductCodeName = product.ProductCodeName;
            productToUpdate.Name = product.Name;
            productToUpdate.ProductType = producType;
            productToUpdate.UOM = UOM;
            productToUpdate.LastUpdatedOn = DateTime.Now;
            productToUpdate.LastUpdatedBy = whoUpdatesTheUser;
            _dbContext.Products.Update(productToUpdate);
            await _dbContext.SaveChangesAsync();
            return;
        }


        public async Task DeleteProduct(int productId,string deletingUserUsername)
        {
            var whoUpdates = _dbContext.Users.FirstOrDefault(u => u.UserName == deletingUserUsername);
            if (whoUpdates == null) { return; }
            var product = _dbContext.Products
                .FirstOrDefault(p=>p.ProductId==productId);
            if (product == null)
            {
                return;
            }
            else
            {
                product.Active = false;
                product.LastUpdatedOn = DateTime.Now;
                _dbContext.Products.Update(product);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<ProductTypeDTO>> GetAllProductTypes() {
            var products = _dbContext.ProductTypes
                .Where(p => p.Active == true)
                .Select(p => new ProductTypeDTO()
                {
                    ProductTypeId = p.ProductTypeId,
                    ProductTypeName = p.ProductTypeName,
                });

            return products.ToList();
        }

        public async Task<IList<UOMDTO>> getAllUOMS()
        {
            var products = _dbContext.UOMs
                .Where(p => p.Active == true)
                .Select(p => new UOMDTO()
                {
                    UOMId = p.UOMId,
                    UOMName = p.UOMName,
                });

            return products.ToList();
        }
    }
}
