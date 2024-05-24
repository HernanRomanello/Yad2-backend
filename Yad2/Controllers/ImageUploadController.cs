using Microsoft.AspNetCore.Mvc;
namespace Yad2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageUploadController : ControllerBase {

    [HttpPost("UploadImage")]
    public async Task<IActionResult> UploadImage([FromForm] IFormFile photo) {
        if(photo == null  || photo.Length == 0) {
            return BadRequest("No File Uploaded");
        }
        var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        if(!Directory.Exists(uploads)) {
            Directory.CreateDirectory(uploads);
        }
        var filePath = Path.Combine(uploads, photo.FileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create)) {
            await photo.CopyToAsync(fileStream);
        }

        var fileUrl = $"{this.Request.Scheme}://{this.Request.Host}/uploads/{photo.FileName}";

        return Ok(new { fileUrl });
    }
}