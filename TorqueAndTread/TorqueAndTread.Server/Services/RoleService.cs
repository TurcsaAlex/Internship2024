using TorqueAndTread.Server.Context;

namespace TorqueAndTread.Server.Services
{
    public class RoleService
    {
        TorqueDbContext _torqueDbContext;
        public RoleService(TorqueDbContext dbContext) {
            _torqueDbContext = dbContext;
        }

    }
}
