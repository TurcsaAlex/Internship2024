using Microsoft.AspNetCore.Mvc;
using TorqueAndTread.Server.DTOs;
using TorqueAndTread.Server.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TorqueAndTread.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BOMController : ControllerBase
    {
        private readonly BOMService _bomService;
        public BOMController(BOMService bomService)
        {
            _bomService = bomService;
        }
        // GET: api/<BOMController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }
            var boms = await _bomService.GetAllBoms();
            return Ok(boms);
        }
        [HttpGet("codes")]
        public async Task<IActionResult> GetCodes()
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }
            var boms = await _bomService.GetAllBomCodes();
            return Ok(boms);
        }

        // GET api/<BOMController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }
            var bom = await _bomService.GetBomById(id);
            return Ok(bom);
        }

        // POST api/<BOMController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BOMCreateDTO bomCreate)
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }
            await _bomService.CreateBOM(bomCreate,username);
            return Ok();
        }

        // PUT api/<BOMController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BOMUpdateDTO bomUpdate)
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }
            await _bomService.UpdateBOM(bomUpdate, username);
            return Ok();
        }

        // DELETE api/<BOMController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }
            await _bomService.SoftDeleteBOM(id, username);
            return Ok();
        }
    }
}
