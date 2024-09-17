using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TorqueAndTread.Server.Context;
using TorqueAndTread.Server.DTOs;
using TorqueAndTread.Server.Models;
using TorqueAndTread.Server.Services;

namespace TorqueAndTread.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginAttemptsController : ControllerBase
    {
        private readonly TorqueDbContext _context;
        private readonly LoginAttemptService _loginAttemptService;

        public LoginAttemptsController(TorqueDbContext context, LoginAttemptService loginAttemptService)
        {
            _context = context;
            _loginAttemptService = loginAttemptService;
        }

        // GET: api/LoginAttempts
        [HttpGet]
        public async Task<IActionResult> GetLoginAttempts(DateTime start, DateTime stop)
        {
            var loginAttempts = _context.LoginAttempts.Where(l => l.Active == true && (l.CreatedOn < stop && l.CreatedOn > start))
                .Select(l => new LoginAttemptDTO()
            {
                Username = l.Username,
                LoginAttemptId = l.LoginAttemptId,
                LoginAttemptResult=l.LoginAttemptResult.ToString(),
                LoginMessage = l.LoginMessage,
            });
            return Ok(loginAttempts);
        }

        [HttpGet("chart")]
        public async Task<IActionResult> GetLoginAttemptsForGraph(DateTime start,DateTime stop)
        {
            var loginAttempts = _context.LoginAttempts.Where(l => l.Active == true && (l.CreatedOn < stop && l.CreatedOn > start))
                .Select(l => new LoginAttemptDTO()
                {
                    Username = l.Username,
                    LoginAttemptId = l.LoginAttemptId,
                    LoginAttemptResult = l.LoginAttemptResult.ToString(),
                    LoginMessage = l.LoginMessage,
                    LoginDate = l.CreatedOn
                });
            
            var allLoginList = _context.LoginAttempts
                .Include(l=>l.User)
                .ThenInclude(u=>u.UserRoles)
                .ThenInclude(ur=>ur.Role)
                .Include(l => l.User)
                .ThenInclude(u => u.Roles)
                .ToList();
            var loginList = allLoginList.Where(l => l.Active == true && (l.CreatedOn < stop && l.CreatedOn > start));
            var loginsByDayLoginMap = new  Dictionary<DateTime,LoginDayEntryDTO>();
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
                    var roles = item.User.UserRoles.Where(ur => ur.Active).Select(r => r.Role.Name);
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
                        LoginAttemptSuccessfull = item.LoginAttemptResult == LoginAttemptResultEnum.SUCCESSFULL ? 1 : 0,
                        LoginAttemptUnsuccessfull = item.LoginAttemptResult == LoginAttemptResultEnum.UNSUCCESSFULL ? 1 : 0,

                    });
                }
                else
                {
                    loginsByDayLoginMap[item.CreatedOn.Date].LoginAttemptNr++;
                    if (item.LoginAttemptResult == LoginAttemptResultEnum.SUCCESSFULL)
                    {
                        loginsByDayLoginMap[item.CreatedOn.Date].LoginAttemptSuccessfull++;
                    }
                    else
                    {
                        loginsByDayLoginMap[item.CreatedOn.Date].LoginAttemptUnsuccessfull++;
                    }
                }
            }
            return Ok(new {
                successfull,
                unsuccessfull,
                userWithRoles,
                loginAttempts,
                loginGraph=loginsByDayLoginMap.ToList().Select(l=>l.Value)
                    });
        }
        // GET: api/LoginAttempts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginAttempt>> GetLoginAttempt(int id)
        {
            var loginAttempt = await _context.LoginAttempts.FindAsync(id);

            if (loginAttempt == null)
            {
                return NotFound();
            }

            return loginAttempt;
        }

        // PUT: api/LoginAttempts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginAttempt(int id, LoginAttempt loginAttempt)
        {
            if (id != loginAttempt.LoginAttemptId)
            {
                return BadRequest();
            }

            _context.Entry(loginAttempt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginAttemptExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LoginAttempts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoginAttempt>> PostLoginAttempt(LoginAttempt loginAttempt)
        {
            _context.LoginAttempts.Add(loginAttempt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoginAttempt", new { id = loginAttempt.LoginAttemptId }, loginAttempt);
        }

        // DELETE: api/LoginAttempts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginAttempt(int id)
        {
            var loginAttempt = await _context.LoginAttempts.FindAsync(id);
            if (loginAttempt == null)
            {
                return NotFound();
            }

            _context.LoginAttempts.Remove(loginAttempt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginAttemptExists(int id)
        {
            return _context.LoginAttempts.Any(e => e.LoginAttemptId == id);
        }
    }
}
