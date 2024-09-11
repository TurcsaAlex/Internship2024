using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TorqueAndTread.Server.Context;
using TorqueAndTread.Server.DTOs;

namespace TorqueAndTread.Server.Services
{
    public class LoginAttemptService
    {
        private readonly TorqueDbContext _context;

        public LoginAttemptService(TorqueDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetLoginAttempts(DateTime start, DateTime stop)
        {
            var loginAttempts = _context.LoginAttempts.Where(l => l.Active == true && (l.CreatedOn < stop && l.CreatedOn > start))
                .Select(l => new LoginAttemptDTO()
                {
                    Username = l.Username,
                    LoginAttemptId = l.LoginAttemptId,
                    LoginAttemptResult = l.LoginAttemptResult.ToString(),
                    LoginMessage = l.LoginMessage,
                });
            return loginAttempts;
        }

        public async Task<object> GetLoginAttemptsForGraph(DateTime start, DateTime stop)
        {
            var loginAttempts = _context.LoginAttempts.Where(l => l.Active == true && (l.CreatedOn < stop && l.CreatedOn > start))
                .Select(l => new LoginAttemptDTO()
                {
                    Username = l.Username,
                    LoginAttemptId = l.LoginAttemptId,
                    LoginAttemptResult = l.LoginAttemptResult.ToString(),
                    LoginMessage = l.LoginMessage,
                });
            var allLoginList = await _context.LoginAttempts.ToListAsync();
            var x = _context.LoginAttempts.FirstOrDefault();
            var loginList = allLoginList.Where(l => l.Active == true && (l.CreatedOn < stop && l.CreatedOn > start));
            var loginsByDayLoginMap = new Dictionary<DateTime, LoginDayEntryDTO>();
            var userWithRoles = new Dictionary<string, int>();
            var successfull = 0;
            var unsuccessfull = 0;
            foreach (var item in loginList)
            {
                if (item.LoginAttemptResult == LoginAttemptResultEnum.SUCCESSFULL)
                    successfull++;
                else
                    unsuccessfull++;
                if (item.User != null)
                {
                    var roles = item.User.Roles.Select(r => r.Name);
                    foreach (var role in roles)
                    {
                        if (userWithRoles.ContainsKey(role))
                        {
                            userWithRoles[role]++;
                        }
                        else
                        {
                            userWithRoles.Add(role, 1);
                        }
                    }
                }


                if (!loginsByDayLoginMap.ContainsKey(item.CreatedOn.Date))
                {
                    loginsByDayLoginMap.Add(item.CreatedOn.Date, new LoginDayEntryDTO()
                    {
                        LoginAttemptNr = 1,
                        //LoginAttemptResult = item.LoginAttemptResult,
                        LoginTime = item.CreatedOn.Date,
                    });
                }
                else
                {
                    loginsByDayLoginMap[item.CreatedOn.Date].LoginAttemptNr++;
                }
            }

            return new{
                successfull,
                unsuccessfull,
                userWithRoles,
                loginAttempts,
                loginGraph = loginsByDayLoginMap.ToList().Select(l => l.Value)
            };
        }
    }
}
