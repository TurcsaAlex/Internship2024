using Microsoft.EntityFrameworkCore;
using TorqueAndTread.Server.Context;
using TorqueAndTread.Server.DTOs;
using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.Services
{
    public class BOMService
    {
        private readonly TorqueDbContext _dbContext;
        public BOMService(TorqueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<BOMDTO>> GetAllBoms()
        {
            return await _dbContext.BOMs
                .Where(b=>b.Active)
                .Include(b=>b.Material)
                .Select(b=>new BOMDTO(b))
                .ToListAsync();
        }
        public async Task<BOMDTO> GetBomById(int id)
        {
            var bom = await _dbContext.BOMs
                .Where(b => b.Active && b.BOMId == id)
                .Include(b => b.Material)
                .Select(b => new BOMDTO(b))
                .ToListAsync();
            return bom.First();
        }

        public async Task<IList<string>> GetAllBomCodes()
        {
            var bomCodes = await _dbContext.BOMs
                .Where(b => b.Active )
                .Select(b =>b.BOMCode)
                .ToListAsync();
            return bomCodes;
        }

        public async Task CreateBOM(BOMCreateDTO bOMCreate,string creatingUsername) {
            var whoCreatesTheBOM = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == creatingUsername);
            if (whoCreatesTheBOM == null) { return; }
            var createdBom = new BOM(bOMCreate);
            if (bOMCreate.MaterialId != null)
            {
                var material = await _dbContext.Products.FirstOrDefaultAsync(b => b.Active);
                if(material == null) { return; }
                createdBom.Material = material;
            }
            createdBom.LastUpdatedOn = DateTime.Now;
            createdBom.LastUpdatedBy = whoCreatesTheBOM;
            createdBom.CreatedBy = whoCreatesTheBOM;
            createdBom.CreatedOn=DateTime.Now;
            createdBom.Active = true;
            await _dbContext.BOMs.AddAsync(createdBom);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateBOM(BOMUpdateDTO bomUpdate, string creatingUsername) 
        {
            var whoCreatesTheBOM = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == creatingUsername);
            if (whoCreatesTheBOM == null) { return; }
            var updatedBom = await _dbContext.BOMs.FirstOrDefaultAsync(b=>b.BOMId==bomUpdate.BOMId && b.Active);
            if (updatedBom == null) { return; }
            if (bomUpdate.MaterialId != null)
            {
                var material = await _dbContext.Products.FirstOrDefaultAsync(b => b.Active && b.ProductId==bomUpdate.MaterialId);
                if (material == null) { return; }
                updatedBom.Material = material;
            }

            updatedBom.BOMCode=bomUpdate.BOMCode;
            updatedBom.BOMName=bomUpdate.BOMName;
            updatedBom.LastUpdatedOn = DateTime.Now;
            updatedBom.LastUpdatedBy = whoCreatesTheBOM;
            updatedBom.Active = true;
            _dbContext.BOMs.Update(updatedBom);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SoftDeleteBOM(int BOMId, string updatingUserUsername)
        {
            var whoUpdatesTheBOM = _dbContext.Users.FirstOrDefault(u => u.UserName == updatingUserUsername);
            if (whoUpdatesTheBOM == null) { return; }

            var BOMToUpdate = _dbContext.BOMs.FirstOrDefault(u => u.BOMId == BOMId);


            if (BOMToUpdate == null) { return; }

            BOMToUpdate.LastUpdatedOn = DateTime.Now;
            BOMToUpdate.LastUpdatedBy = whoUpdatesTheBOM;
            BOMToUpdate.Active = false;
            _dbContext.BOMs.Update(BOMToUpdate);
            await _dbContext.SaveChangesAsync();
            return;
        }
    }
}
