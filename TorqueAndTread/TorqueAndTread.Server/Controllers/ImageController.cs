using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TorqueAndTread.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public ImageController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            try
            {
                var uploadsFolder = Path.Combine(_environment.ContentRootPath, "Files\\uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                return Ok(new { FilePath = $"{uniqueFileName}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{fileName}")]
        public IActionResult GetImageByName(string fileName)
        {
            var uploadsFolder = Path.Combine(_environment.ContentRootPath, "Files\\uploads");
            var filePath = Path.Combine(uploadsFolder, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Image not found.");
            }

            var image = System.IO.File.OpenRead(filePath);
            var contentType = "image/" + Path.GetExtension(fileName).TrimStart('.');
            return File(image, contentType);
        }
        [HttpGet("base64/{fileName}")]
        public IActionResult GetImageByNameBase64(string fileName)
        {
            var uploadsFolder = Path.Combine(_environment.ContentRootPath, "Files\\uploads");
            var filePath = Path.Combine(uploadsFolder, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Image not found.");
            }

            var image = System.IO.File.ReadAllBytes(filePath);
            string base64Image = Convert.ToBase64String(image);
            return Ok(new { Image=base64Image });
        }
    }
}
