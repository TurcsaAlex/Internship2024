using Microsoft.EntityFrameworkCore;
using TorqueAndTread.Server.Context;
using TorqueAndTread.Server.DTOs;
using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.Services
{
    public class ContainerService
    {
        private readonly TorqueDbContext _dbContext;
        public ContainerService(TorqueDbContext dbContext)
        {
           _dbContext = dbContext;
        }
        public async Task<IList<ContainerDTO>> GetAllContainers()
        {
            var containers = await _dbContext.Containers
                .Include(c=>c.UOM)
                .Include(t=>t.ContainerType)
                .Include(p=>p.Product)
                .Where(c => c.Active).Select(c=>new ContainerDTO(c)).ToListAsync();
            return containers;
        }
        public async Task<IList<string>> GetAllContainerCodes()
        {
            var containers = await _dbContext.Containers
                .Select(c => c.ContainerCode).ToListAsync();
            return containers;
        }

        public async Task<IList<ContainerTypeDTO>> GetAllContainerTypes()
        {
            var containers = _dbContext.ContainerTypes
                .Where(p => p.Active == true)
                .Select(p => new ContainerTypeDTO()
                {
                    ContainerTypeId = p.ContainerTypeId,
                    ContainerTypeName = p.ContainerTypeName,
                });

            return await containers.ToListAsync();
        }
        public async Task<ContainerDTO> GetContainer(int containerId)
        {
            var activeContainers = await _dbContext.Containers
                .Where(u => u.ContainerId == containerId)
                .Include(c => c.UOM)
                .Include(t => t.ContainerType)
                .Include(p => p.Product)
                .Select(u => new ContainerDTO(u)).ToListAsync();
            return activeContainers.First();
        }
        public async Task EditContainer(ContainerEditDTO container, string updatingContainername)
        {
            var whoUpdatesTheContainer = _dbContext.Users.FirstOrDefault(u => u.UserName == updatingContainername);
            if (whoUpdatesTheContainer == null) { return; }

            var containerToUpdate = _dbContext.Containers.FirstOrDefault(u => u.ContainerId == container.ContainerId);
            if (containerToUpdate == null) { return; }



            var type = await _dbContext.ContainerTypes.FirstOrDefaultAsync(u => u.ContainerTypeId == container.ContainerTypeId && u.Active);
            if (type == null) { return; }

            var product = await _dbContext.Products.FirstOrDefaultAsync(u => u.ProductId == container.ProductId && u.Active);
            if (product != null)
            {
                var uom = await _dbContext.UOMs.FirstOrDefaultAsync(u => u.UOMId == container.UOMId && u.Active);
                if (uom == null) { return; }
                containerToUpdate.UOM = uom;
                containerToUpdate.Product = product;
            }

            if (containerToUpdate == null) { return; }

            containerToUpdate.ContainerType = type;
            containerToUpdate.Name = container.Name;
            containerToUpdate.Quantity=container.Quantity;
            containerToUpdate.LastUpdatedOn = DateTime.Now;
            containerToUpdate.LastUpdatedBy = whoUpdatesTheContainer;
            _dbContext.Containers.Update(containerToUpdate);
            if (product != null)
            {
                product.Container = containerToUpdate;
                _dbContext.Products.Update(product);
            }
            await _dbContext.SaveChangesAsync();
            return;
        }

        public async Task CreateContainer(ContainerCreateDTO container, string updatingUserUsername)
        {
            var whoCreatesTheContainer = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == updatingUserUsername);
            if (whoCreatesTheContainer == null) { return; }

            var containerToBeCreated = new Container(container);

            var type = await _dbContext.ContainerTypes.FirstOrDefaultAsync(u => u.ContainerTypeId == container.ContainerTypeId && u.Active);
            if (type == null) { return; }

            var product = await _dbContext.Products.FirstOrDefaultAsync(u => u.ProductId == container.ProductId && u.Active);
            if (product != null){
                var uom = await _dbContext.UOMs.FirstOrDefaultAsync(u => u.UOMId == container.UOMId && u.Active);
                if (uom == null) { return; }
                containerToBeCreated.UOM = uom;
                containerToBeCreated.Product = product;
            }


            containerToBeCreated.ContainerType = type;
            containerToBeCreated.CreatedOn = DateTime.UtcNow;
            containerToBeCreated.LastUpdatedOn = DateTime.UtcNow;
            containerToBeCreated.CreatedBy = whoCreatesTheContainer;
            containerToBeCreated.LastUpdatedBy = whoCreatesTheContainer;
            containerToBeCreated.Active = true;
            await _dbContext.Containers.AddAsync(containerToBeCreated);
            if (product != null) {
                product.Container = containerToBeCreated;
                _dbContext.Products.Update(product);
            }
            await _dbContext.SaveChangesAsync();
            return;
        }

        public async Task SoftDeleteContainer(int containerId, string updatingUserUsername)
        {
            var whoUpdatesTheContainer = _dbContext.Users.FirstOrDefault(u => u.UserName == updatingUserUsername);
            if (whoUpdatesTheContainer == null) { return; }

            var containerToUpdate = _dbContext.Containers.FirstOrDefault(u => u.ContainerId == containerId);


            if (containerToUpdate == null) { return; }

            containerToUpdate.LastUpdatedOn = DateTime.Now;
            containerToUpdate.LastUpdatedBy = whoUpdatesTheContainer;
            containerToUpdate.Active = false;
            _dbContext.Containers.Update(containerToUpdate);
            await _dbContext.SaveChangesAsync();
            return;
        }

    }
}
