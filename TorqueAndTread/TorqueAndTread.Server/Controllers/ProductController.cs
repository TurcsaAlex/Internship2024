using Microsoft.AspNetCore.Mvc;
using TorqueAndTread.Server.DTOs;
using TorqueAndTread.Server.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TorqueAndTread.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductService _productService; 
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("types")]
        public async Task<IActionResult> GetAllProductTypes()
        {
            var productTypes = await _productService.getAllProductTypes();
            return Ok(productTypes);
        }
        [HttpGet("UOM")]
        public async Task<IActionResult> GetAllProductUOM()
        {
            var productTypes = await _productService.getAllUOMS();
            return Ok(productTypes);
        }
        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
           return Ok(await _productService.GetProduct(id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductCreateDTO productDTO)
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }

            await _productService.CreateProduct(productDTO,username);

            return Ok(new { message= "OK"});
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductEditDTO productDTO)
        {
            var username = HttpContext.Items["Username"] as string;
            if (username == null)
            {
                return Unauthorized();
            }

            await _productService.EditProduct(productDTO, username);

            return Ok(new { message = "OK" });
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
