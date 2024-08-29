using Microsoft.EntityFrameworkCore;
using TorqueAndTread.Server.Context;
using TorqueAndTread.Server.DTOs;
using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.Services
{
    public class RoleService
    {
        TorqueDbContext _torqueDbContext;
        public RoleService(TorqueDbContext dbContext) {
            _torqueDbContext = dbContext;
        }
        public async Task<IList<UserRolesDTO>> GetRolesByUserId(int userId)
        {
            var userRoleList = _torqueDbContext.UserRoles
                .Where(ur => ur.User.UserId == userId && ur.Active == true)
                .Select(ur => new UserRolesDTO(ur)
                {
                    Name = ur.Role.Name,
                });
            return userRoleList.ToList();
        }

        public async Task PostUserRole(PostUserRoleDTO userRoleDTO, int creatingUserId)
        {
            var userId = userRoleDTO.UserId;
            var roleId = userRoleDTO.RoleId;
            var whoUpdates = _torqueDbContext.Users.FirstOrDefault(u => u.UserId == creatingUserId);
            if (whoUpdates == null) { return; }
            var exitingUserRole = _torqueDbContext.UserRoles
                .FirstOrDefault(ur => ur.UserId == userId && ur.RoleId == roleId);
            if(exitingUserRole == null)
            {

                var userRoleToAdd = new UserRole();

                var user = _torqueDbContext.Users.FirstOrDefault(u => u.UserId == userId);
                if (user == null) {return; }
                var role = _torqueDbContext.Roles.FirstOrDefault(u => u.RoleId == roleId);
                if (role == null) { return; }

                userRoleToAdd.UserId = userId;
                userRoleToAdd.RoleId = roleId;
                userRoleToAdd.Role = role;
                userRoleToAdd.User = user;
                userRoleToAdd.CreatedBy = whoUpdates;
                userRoleToAdd.LastUpdatedBy = whoUpdates;
                userRoleToAdd.CreatedOn= DateTime.Now;
                userRoleToAdd.LastUpdatedOn= DateTime.Now;
                userRoleToAdd.Active = true;
                await _torqueDbContext.UserRoles.AddAsync(userRoleToAdd);
            }
            else
            {
                exitingUserRole.Active = true;
                exitingUserRole.LastUpdatedOn = DateTime.Now;
                _torqueDbContext.UserRoles.Update(exitingUserRole);
            }

            await _torqueDbContext.SaveChangesAsync();
        }

        public async Task DeleteUserRole(PostUserRoleDTO userRoleDTO, int deletingUserId)
        {
            var userId = userRoleDTO.UserId;
            var roleId = userRoleDTO.RoleId;
            var whoUpdates = _torqueDbContext.Users.FirstOrDefault(u => u.UserId == deletingUserId);
            if (whoUpdates == null) { return; }
            var exitingUserRole = _torqueDbContext.UserRoles
                .FirstOrDefault(ur => ur.UserId == userId && ur.RoleId == roleId);
            if (exitingUserRole == null)
            {
                return;
            }
            else
            {
                exitingUserRole.Active = false;
                exitingUserRole.LastUpdatedOn = DateTime.Now;
                _torqueDbContext.UserRoles.Update(exitingUserRole);
            }

            await _torqueDbContext.SaveChangesAsync();
        }

        public async Task<IList<RoleDTO>> GetAllRoles()
        {
            var roleList = _torqueDbContext.Roles
                .Where(r => r.Active == true)
                .Select(r=>new RoleDTO(r));
            return roleList.ToList();
        }


    }
}
