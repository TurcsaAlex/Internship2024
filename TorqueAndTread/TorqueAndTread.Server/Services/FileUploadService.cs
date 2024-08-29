using Microsoft.AspNetCore.Mvc;

namespace TorqueAndTread.Server.Services
{
    public class FileUploadService
    {
        private readonly IWebHostEnvironment _environment;

        public FileUploadService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> UploadImage(IFormFile image)
        {
            try
            {
                // Ensure the directory exists
                var uploadsFolder = Path.Combine(_environment.ContentRootPath, "Files\\uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Generate a unique file name
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

                // Full path where the file will be saved
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Save the file to the path
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                return $"/Files/uploads/{uniqueFileName}";
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

