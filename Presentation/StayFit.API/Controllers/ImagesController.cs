using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayFit.Application.Abstracts.Storage;
using StayFit.Domain.Entities;
using StayFit.Persistence.Contexts;
using System.Formats.Tar;
using System.Security.Claims;

namespace StayFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly StayFitDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IStorageService _storageService;
        private readonly IConfiguration _configuration;

        public ImagesController(StayFitDbContext context, IWebHostEnvironment environment, IConfiguration configuration, IStorageService storageService)
        {
            _context = context;
            _webHostEnvironment = environment;
            _storageService = storageService;
            _configuration = configuration;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload()
        {
            var result = await _storageService.UploadAsync("user-images", Request.Form.Files);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _context.Users.FindAsync(Guid.Parse(userId));
            user.PhotoPath = $"{_configuration["BaseStorageUrl"]}/{result[0].PathOrContainerName}";
            await _context.SaveChangesAsync();
            return Ok(new ImageReturn()
            {
                Message = "Resim başarıyla yüklendi.",
                Success = true
            });
           
        }

        private class ImageReturn
        {
            public string Message { get; set; }
            public bool Success { get; set; }
        }

     
    }
}
