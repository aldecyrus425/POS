using Microsoft.AspNetCore.Http;
using POS.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Services
{
    public class ImageStorageService : IImageStorageService
    {
        private readonly IImageEnvironment _env;

        public ImageStorageService(IImageEnvironment env)
        {
            _env = env;
        }

        public Task DeleteImageAsync(string imageUrl)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadImageAsync(IFormFile image)
        {
            try
            {
                if (image == null || image.Length == 0) throw new ArgumentNullException("No image uploaded");

                string uploadsFolder = Path.Combine(
                    _env.WebRootPath,
                    "images",
                    "products");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";

                string filePath = Path.Combine(
                    uploadsFolder,
                    fileName);

                using var stream = new FileStream(
                    filePath,
                    FileMode.Create);

                await image.CopyToAsync(stream);

                return $"/uploads/products/{fileName}";
            }
            catch (Exception ex)
            {
                return "An error occurred while uploading the image: " + ex.Message;
            }
        }
    }
}
