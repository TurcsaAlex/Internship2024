using Microsoft.EntityFrameworkCore;
using TorqueAndTread.Server.Context;
using TorqueAndTread.Server.DTOs;
using TorqueAndTread.Server.Helpers;
using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.Services
{
    public class UserService
    {
        private readonly TorqueDbContext _context;
        private IConfiguration _config;
        public UserService(TorqueDbContext context, IConfiguration configuration)
        {
            _config = configuration;
            _context = context;
        }

        public async Task<IList<UserAbvrDTO>> GetAllUsers()
        {
            var activeUsers = _context.Users.Select(u => new UserAbvrDTO(u));
            var userList = new List<UserAbvrDTO>(activeUsers);
            return userList;
        }

        public async Task<IList<UserAbvrDTO>> GetUser(int userId)
        {
            var activeUsers = _context.Users.Where(u => u.UserId == userId).Select(u => new UserAbvrDTO(u));
            var userList = new List<UserAbvrDTO>(activeUsers);
            return userList;
        }
        public async Task EditUser(UserAbvrDTO user, string updatingUsername)
        {
            var whoUpdatesTheUser = _context.Users.FirstOrDefault(u => u.UserName == updatingUsername);
            if (whoUpdatesTheUser == null) { return; }

            var userToUpdate = _context.Users.FirstOrDefault(u => u.UserId == user.UserId);


            if (userToUpdate == null) { return; }

            userToUpdate.ProfilePicturePath = user.ProfilePicturePath;
            userToUpdate.UserName = user.UserName;
            userToUpdate.Email = user.Email;
            userToUpdate.Name = user.Name;
            userToUpdate.LastUpdatedOn = DateTime.Now;
            userToUpdate.LastUpdatedBy = whoUpdatesTheUser;
            userToUpdate.Active = user.Active;
            _context.Users.Update(userToUpdate);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task CreateUser(UserCreateDTO user, int updatingUserId)
        {
            var whoCreatesTheUser = _context.Users.FirstOrDefault(u => u.UserId == updatingUserId);
            if (whoCreatesTheUser == null) { return; }

            var userToBeCreated = new User(user);


            userToBeCreated.Password = PasswordHasher.HashPassword(userToBeCreated.Password);
            userToBeCreated.CreatedOn = DateTime.UtcNow;
            userToBeCreated.LastUpdatedOn = DateTime.UtcNow;
            userToBeCreated.CreatedBy = whoCreatesTheUser;
            userToBeCreated.LastUpdatedBy = whoCreatesTheUser;

            await _context.Users.AddAsync(userToBeCreated);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task SoftDeleteUser(int userId, int updatingUserId)
        {
            var whoUpdatesTheUser = _context.Users.FirstOrDefault(u => u.UserId == updatingUserId);
            if (whoUpdatesTheUser == null) { return; }

            var userToUpdate = _context.Users.FirstOrDefault(u => u.UserId == userId);


            if (userToUpdate == null) { return; }

            userToUpdate.LastUpdatedOn = DateTime.Now;
            userToUpdate.LastUpdatedBy = whoUpdatesTheUser;
            userToUpdate.Active = false;
            _context.Users.Update(userToUpdate);
            await _context.SaveChangesAsync();
            return;
        }

    }
}
