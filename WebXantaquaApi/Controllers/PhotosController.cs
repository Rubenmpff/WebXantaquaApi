using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebKrpcApi.Services.Mapping.Dtos;
using WebKrpcApi.Services.Services.Interfaces;

namespace WebKrpcApi.Controllers
{
    [ApiController]
    [Route("WebKrpcApi/[controller]")]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotosController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PhotoDto>>> GetAllPhotos()
        {
            return Ok(await _photoService.GetAllPhotosAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoDto>> GetPhotoById(int id)
        {
            var photo = await _photoService.GetPhotoByIdAsync(id);
            if (photo == null)
            {
                return NotFound();
            }
            return Ok(photo);
        }

        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<List<PhotoDto>>> GetPhotosByProjectId(int projectId)
        {
            return Ok(await _photoService.GetPhotosByProjectIdAsync(projectId));
        }

        [HttpPost]
        public async Task<ActionResult> AddPhoto([FromBody] PhotoDto photoDto)
        {
            var addedPhoto = await _photoService.AddPhotoAsync(photoDto);
            return CreatedAtAction(nameof(GetPhotoById), new { id = addedPhoto.Id }, addedPhoto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePhoto(int id, [FromBody] PhotoDto photoDto)
        {
            if (id != photoDto.Id)
            {
                return BadRequest();
            }

            await _photoService.UpdatePhotoAsync(photoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePhoto(int id)
        {
            await _photoService.DeletePhotoAsync(id);
            return NoContent();
        }
    }
}
