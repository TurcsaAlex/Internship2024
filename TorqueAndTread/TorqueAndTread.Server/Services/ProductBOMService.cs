using Microsoft.EntityFrameworkCore;
using TorqueAndTread.Server.Context;
using TorqueAndTread.Server.DTOs;
using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.Services
{
    public class ProductBOMService
    {
        private readonly TorqueDbContext _dbContext;
        public ProductBOMService(TorqueDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<ProductDTO>> GetProductsByBom(int bomId)
        {
            var userRoleList = _dbContext.ProductBOMs
                .Where(ur => ur.BOM.BOMId == bomId && ur.Active == true)
                .Select(p => new ProductDTO()
                {
                    ProductId = p.Product.ProductId,
                    ProductCodeName = p.Product.ProductCodeName,
                    LastUpdatedOn = p.Product.LastUpdatedOn,
                    CreatedOn = p.Product.CreatedOn,
                    Active = p.Product.Active,
                    Name = p.Product.Name,
                    ProductTypeName = p.Product.ProductType.ProductTypeName,
                    UOMName = p.Product.UOM.UOMName,
                    UOMId = p.Product.UOM.UOMId,
                    Quantity = p.Quantity
                }
                );
            return await userRoleList.ToListAsync();
        }

        public async Task PostProductBOM(ProductBOMDTO productBOMDTO, string creatingUserId)
        {
            var productId = productBOMDTO.ProductId;
            var bomId = productBOMDTO.BOMId;
            var whoUpdates = _dbContext.Users.FirstOrDefault(u => u.UserName == creatingUserId);
            if (whoUpdates == null) { return; }
            var exitingProductBOM = _dbContext.ProductBOMs
                .FirstOrDefault(ur => ur.ProductId == productId && ur.BOMId == bomId);
            if (exitingProductBOM == null)
            {

                var productBOM = new ProductBOM();

                var product = _dbContext.Products.FirstOrDefault(u => u.ProductId == productId);
                if (product == null) { return; }
                var bom = _dbContext.BOMs.FirstOrDefault(u => u.BOMId == bomId);
                if (bom == null) { return; }

                productBOM.ProductId = productId;
                productBOM.BOMId = bomId;
                productBOM.Quantity = productBOMDTO.Quantity;
                productBOM.Product = product;
                productBOM.BOM = bom;
                productBOM.CreatedBy = whoUpdates;
                productBOM.LastUpdatedBy = whoUpdates;
                productBOM.CreatedOn = DateTime.Now;
                productBOM.LastUpdatedOn = DateTime.Now;
                productBOM.Active = true;
                await _dbContext.ProductBOMs.AddAsync(productBOM);
            }
            else
            {
                exitingProductBOM.Active = true;
                exitingProductBOM.LastUpdatedOn = DateTime.Now;
                _dbContext.ProductBOMs.Update(exitingProductBOM);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductBOM(ProductBOMDTO productBomDTO, string deletingUserId)
        {
            var productId = productBomDTO.ProductId;
            var bomId = productBomDTO.BOMId;
            var whoUpdates = _dbContext.Users.FirstOrDefault(u => u.UserName == deletingUserId);
            if (whoUpdates == null) { return; }
            var exitingProductBom = _dbContext.ProductBOMs
                .FirstOrDefault(ur => ur.ProductId == productId && ur.BOMId == bomId);
            if (exitingProductBom == null) { return; }
            else
            {
                exitingProductBom.Active = false;
                exitingProductBom.LastUpdatedOn = DateTime.Now;
                _dbContext.ProductBOMs.Update(exitingProductBom);
            }

            await _dbContext.SaveChangesAsync();
        }
        public async Task EditProductBOM(ProductBOMDTO productBomDTO, string deletingUserId)
        {
            var productId = productBomDTO.ProductId;
            var bomId = productBomDTO.BOMId;
            var whoUpdates = _dbContext.Users.FirstOrDefault(u => u.UserName == deletingUserId);
            if (whoUpdates == null) { return; }
            var exitingProductBom = _dbContext.ProductBOMs
                .FirstOrDefault(ur => ur.ProductId == productId && ur.BOMId == bomId);
            if (exitingProductBom == null) { return; }
            else
            {
                exitingProductBom.Quantity = productBomDTO.Quantity;
                exitingProductBom.LastUpdatedOn = DateTime.Now;
                _dbContext.ProductBOMs.Update(exitingProductBom);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
