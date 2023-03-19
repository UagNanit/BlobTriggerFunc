using Microsoft.AspNetCore.Mvc;
using ReenbitTestTask.Data;
using ReenbitTestTask.Models;
using ReenbitTestTask.Services;

namespace ReenbitTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        private readonly ILogger<testController> _logger;
        private readonly IAzureStorage _storage;
        private readonly ApplicationContext _applicationContext;

        public testController(ILogger<testController> logger, IAzureStorage storage, ApplicationContext applicationContext)
        {
            _logger = logger;
            _storage = storage;
            _applicationContext = applicationContext;
        }

        [Route("upload")]
        [HttpPost]
        public async Task<ActionResult> UploadAsync([FromForm] ModelDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

           await _applicationContext.DbModelDatas.AddAsync(new DbModelData { Email = model.Email, FileName = model.UploadedFile.FileName });
           await _applicationContext.SaveChangesAsync();

            BlobResponseDto? response = await _storage.UploadAsync(model.UploadedFile);

            // Check if we got an error
            if (response.Error == true)
            {
                // We got an error during upload, return an error with details to the client
                return StatusCode(StatusCodes.Status500InternalServerError, response.Status);
            }
            else
            {
                // Return a success message to the client about successfull upload
                return StatusCode(StatusCodes.Status200OK, response);
            }

        }
    }
}