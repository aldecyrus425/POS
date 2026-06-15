using POS.Application.Interfaces.Services;

namespace POS.API
{
    public class ImageEnvironment : IImageEnvironment
    {
        private readonly IWebHostEnvironment _env;
        public ImageEnvironment(IWebHostEnvironment env)
        {
            _env = env;
        }
        public string WebRootPath => _env.WebRootPath;
    }
}
