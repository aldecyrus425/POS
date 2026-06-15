using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Interfaces.Services
{
    public interface IImageStorageService
    {
        Task<string> UploadImageAsync(IFormFile image);
        Task DeleteImageAsync(string imageUrl);
    }
}
