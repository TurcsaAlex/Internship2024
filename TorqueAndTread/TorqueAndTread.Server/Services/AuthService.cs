using TorqueAndTread.Server.Context;
using TorqueAndTread.Server.DTOs;
using TorqueAndTread.Server.Helpers;
using TorqueAndTread.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

namespace TorqueAndTread.Server.Services
{
    public class AuthService
    {
        private readonly string TokenListCacheKey = "listkey";
        private readonly TorqueDbContext _authContext;
        private IConfiguration _config;
        private MailSender _mailSender;
        private readonly IMemoryCache _cache;
        public AuthService(TorqueDbContext authContext, IConfiguration config, MailSender mailSender, IMemoryCache cache)
        {
            _config = config;
            _authContext = authContext;
            _mailSender = mailSender;
            _cache = cache;
        }
        public async Task Logout(string token)
        {
            var tokenList = _cache.Get<List<string>>(TokenListCacheKey) ?? [];
            if (!tokenList.Any()) return;
            // Add the new token to the list
            tokenList.Remove(token);

            // Update the cache with the new list
            _cache.Set(TokenListCacheKey, tokenList, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(30)
            });
        }
        public async Task<AuthDTO> Authenticate(LoginDTO userObj)
        {
            //_mailSender.SendTest();
            var user = await _authContext.Users.FirstOrDefaultAsync(x => x.UserName == userObj.UserName && x.Active);
            var loginAttempt = GenerateEmptyLoginAttempt();
            if (user == null)
            {
                loginAttempt.LoginMessage = "User Not Found";
                loginAttempt.LoginAttemptResult = LoginAttemptResultEnum.UNSUCCESSFULL;
                loginAttempt.Username = userObj.UserName;
                await _authContext.LoginAttempts.AddAsync(loginAttempt);
                await _authContext.SaveChangesAsync();

                return new AuthDTO(404);
            }
                

            if (!PasswordHasher.VerifyPassword(userObj.Password, user.Password))
            {
                loginAttempt.LoginMessage = "Wrong Password";
                loginAttempt.LoginAttemptResult = LoginAttemptResultEnum.UNSUCCESSFULL;
                loginAttempt.Username = userObj.UserName;
                loginAttempt.User = user;
                await _authContext.LoginAttempts.AddAsync(loginAttempt);
                await _authContext.SaveChangesAsync();

                return new AuthDTO(500); 
            }

            var token = GenerateJSONWebToken(user);

            

            var tokenList = _cache.Get<List<string>>(TokenListCacheKey) ?? [];

            // Add the new token to the list
            tokenList.Add(token);

            // Update the cache with the new list
            _cache.Set(TokenListCacheKey, tokenList, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(30)
            });
            loginAttempt.LoginMessage = "Success!";
            loginAttempt.LoginAttemptResult = LoginAttemptResultEnum.SUCCESSFULL;
            loginAttempt.Username = userObj.UserName;
            loginAttempt.User = user;
            await _authContext.LoginAttempts.AddAsync(loginAttempt);
            await _authContext.SaveChangesAsync();
            

            var userRoles = _authContext.UserRoles.Where(ur => ur.UserId == user.UserId).Select(ur => new RoleDTO(ur.Role)).ToList(); // obtain roles of user and map to RoleDTO
            var menuItems = GetUserMenuItemsForRole(user.UserId); // obtain menus associated to roles of the user

            return new AuthDTO(200, token, menuItems, userRoles, user.ProfilePicturePath);
        }
        private LoginAttempt GenerateEmptyLoginAttempt()
        {
            var searchUser = _authContext.Users.Where(u => u.UserId == -1);
            var active0User = searchUser.First();
            return new LoginAttempt()
            {
                CreatedBy = active0User,
                LastUpdatedBy = active0User,
                CreatedOn = DateTime.Now,
                LastUpdatedOn = DateTime.Now,
                Active = true,
            };
        }

        public bool HasToken(string token) {
            var tokenList = _cache.Get<List<string>>(TokenListCacheKey);
            return tokenList != null && tokenList.Contains(token);
        }

        public async Task<int> RegisterUser(RegisterDTO registerDTO)
        {

            var searchUser = _authContext.Users.Where(u => u.UserId == -1);
            var active0User = searchUser.First();
            var userObj = new User(registerDTO);
            userObj.Password = PasswordHasher.HashPassword(userObj.Password);
            userObj.CreatedOn = DateTime.UtcNow;
            userObj.LastUpdatedOn = DateTime.UtcNow;
            userObj.CreatedBy = active0User;
            userObj.LastUpdatedBy = active0User;
            userObj.Active = false;
            await _authContext.Users.AddAsync(userObj);
            var saveResp = await _authContext.SaveChangesAsync();
            //_mailSender.SendActivationMail(userObj.Email);
            return saveResp;
        }
        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

       
            var claims = new[]
            {
                new Claim("username",userInfo.UserName),
                new Claim("userId",userInfo.UserId.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //private List<MenuItemDTO> GetUserMenuItemsForUser(string token)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var jwtToken = tokenHandler.ReadJwtToken(token);

        //    var userIdClaims = jwtToken.Claims.FirstOrDefault(c => c.Type == "userId");

        //    if (userIdClaims == null)
        //    {
        //        throw new Exception("User ID not found in token");
        //    }

        //    int userId = int.Parse(userIdClaims.Value);
        //    var menuItems = _authContext.MenuItems.Include(mi => mi.MenuItemRoles).ThenInclude(mr => mr.Role).Where(mi => mi.MenuItemRoles.Any(mr => mr.Role.UserRoles.Any(ur => ur.UserId == userId))).ToList(); //get all MenuItemRoles associated to current user by UserRoles and MenuItemRoles 

        //    var menuItemDTOs = menuItems.Select(mi => new MenuItemDTO
        //    {
        //        MenuItemId = mi.MenuItemId,
        //        Name = mi.Name,
        //        Link = mi.Link,
        //        IconClass = mi.IconClass,
        //        Roles = mi.MenuItemRoles.Select(mr => new RoleDTO
        //        {
        //            RoleId = mr.RoleId,
        //            Name = mr.Role.Name,
        //        }).ToList()
        //    }).ToList();

        //    return menuItemDTOs;
        //}

        private List<MenuItemDTO> GetUserMenuItemsForRole(int userId)
        {
            var userRoles = _authContext.UserRoles.Where(ur => ur.UserId == userId && ur.Active == true).Select(ur => ur.RoleId).ToList();

            //var x = _authContext.MenuItemRoles.Include(mr => mr.MenuItem).ToList();
            var menuItemsList = _authContext.MenuItemRoles.Include(mr => mr.MenuItem).Where(mr => userRoles.Contains(mr.RoleId)) //can change contains with any
                .Select(mr => new MenuItemDTO
                {
                    MenuItemId = mr.MenuItem.MenuItemId,
                    Name = mr.MenuItem.Name,
                    IconClass = mr.MenuItem.IconClass,
                    Link = mr.MenuItem.Link,
                    Active = mr.MenuItem.Active,
                    CreatedOn = mr.MenuItem.CreatedOn,
                    LastUpdatedOn = mr.MenuItem.LastUpdatedOn
                }).Distinct() // eliminate duplicates
                .ToList();

            return menuItemsList;
        }
    }

        //public List<MenuItemDTO> GetMenuItemsForUserWithCache(string token)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var jwtToken = tokenHandler.ReadJwtToken(token);


        //    var userIdClaims = jwtToken.Claims.FirstOrDefault(c => c.Type == "userId");

        //    if (userIdClaims == null)
        //    {
        //        throw new Exception("User ID not found in token");
        //    }

        //    int userId = int.Parse(userIdClaims.Value);
        //    string cacheKey = $"MenuItemsForUser_ {userId}";

        //    if(!_cache.TryGetValue(cacheKey, out List<MenuItemDTO> cacheMenuItems)) //verify if menus are stored in cache
        //    {
        //        cacheMenuItems = GetUserMenuItemsForUser(token); // if not in cache, we obtain them from database
        //        _cache.Set(cacheKey, cacheMenuItems, new MemoryCacheEntryOptions
        //        {
        //            SlidingExpiration = TimeSpan.FromMinutes(60)
        //        });
        //    }

        //    return cacheMenuItems;
        //}
       
    }

