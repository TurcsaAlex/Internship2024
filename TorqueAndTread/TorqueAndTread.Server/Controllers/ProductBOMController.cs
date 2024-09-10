using Microsoft.AspNetCore.Mvc;
using TorqueAndTread.Server.DTOs;
using TorqueAndTread.Server.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TorqueAndTread.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBOMController : ControllerBase
    {
        private readonly ProductBOMService _productBOMService;
        public ProductBOMController(ProductBOMService productBOMService)
        {
            _productBOMService = productBOMService;
        }

        // GET: api/<ProductBOMController>
        [HttpGet("{bomId}")]
        public async Task<IActionResult> Get(int bomId)
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }
            var prods =await  _productBOMService.GetProductsByBom(bomId);
            return Ok(prods);
        }

       

        // POST api/<ProductBOMController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductBOMDTO productBOMDTO)
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }
            await _productBOMService.PostProductBOM(productBOMDTO,username);
            return Ok();
        }

        // PUT api/<ProductBOMController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductBOMDTO productBOMDTO)
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }
            await _productBOMService.EditProductBOM(productBOMDTO, username);
            return Ok();
        }

        // DELETE api/<ProductBOMController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ProductBOMDTO productBOMDTO)
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }
            await _productBOMService.DeleteProductBOM(productBOMDTO, username);
            return Ok();
        }
    }
}
