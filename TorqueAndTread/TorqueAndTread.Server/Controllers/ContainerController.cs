using Microsoft.AspNetCore.Mvc;
using TorqueAndTread.Server.DTOs;
using TorqueAndTread.Server.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TorqueAndTread.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly ContainerService _containerService;
        public ContainerController(ContainerService containerService)
        {
            _containerService = containerService;
        }
        // GET: api/<ContainerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }
            var containerList = await _containerService.GetAllContainers();

            return Ok(containerList);
        }
        [HttpGet("codes")]
        public async Task<IActionResult> GetCodes()
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }
            var containerList = await _containerService.GetAllContainerCodes();

            return Ok(containerList);
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetTypes()
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }
            var containerList = await _containerService.GetAllContainerTypes();

            return Ok(containerList);
        }

        // GET api/<ContainerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }
            var container = await _containerService.GetContainer(id);
            return Ok(container);
        }

        // POST api/<ContainerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContainerCreateDTO containerCreateDTO)
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }
            await _containerService.CreateContainer(containerCreateDTO, username);
            return Ok();
        }

        // PUT api/<ContainerController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ContainerEditDTO containerDTO)
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }
            await _containerService.EditContainer(containerDTO, username);
            return Ok();
        }

        // DELETE api/<ContainerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }
            await _containerService.SoftDeleteContainer(id, username);
            return Ok();
        }
    }
}
