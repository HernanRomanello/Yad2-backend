using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
namespace Yad2.Controllers;

 [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName = "file-upload198974";

        public ImageUploadController(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty.");
            }

            using var stream = file.OpenReadStream();

            var key = Guid.NewGuid().ToString();
            var fileName = file.FileName;
            var contentType = file.ContentType;

            var putRequest = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = key,
                InputStream = stream,
                ContentType = contentType
            };

            putRequest.Metadata["x-amz-meta-filename"] = fileName;
            putRequest.Metadata["x-amz-meta-description"] = "Uploaded file";

            try
            {
                await _s3Client.PutObjectAsync(putRequest);

                return Ok(new
                {
                    FileKey = key
                });
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine($"AWS S3 Exception: {ex.Message}");
                return StatusCode(500, "S3 Upload Failed: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
                return StatusCode(500, "File upload failed.");
            }
        }
    }
