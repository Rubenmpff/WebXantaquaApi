using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebKrpcApi.Services.Mapping.Dtos;
using WebKrpcApi.Services.Services.Interfaces;

namespace WebKrpcApi.Controllers
{
    [Route("WebKrpcApi/[controller]")]
    [ApiController]
    [Authorize] // Protege todos os métodos do controlador
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentDto commentDto)
        {
            var result = await _commentService.Save(commentDto);
            if (result == null)
            {
                return BadRequest("Não foi possível criar o comentário.");
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingComments()
        {
            var comments = await _commentService.GetCommentsByApprovalStatusAsync(false);
            return Ok(comments);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("{id}/approve")]
        public async Task<IActionResult> ApproveComment(int id)
        {
            var comment = await _commentService.GetById(id);
            if (comment == null)
            {
                return NotFound("Comentário não encontrado.");
            }

            comment.IsApproved = true;
            await _commentService.Save(comment);

            return Ok(comment);
        }

        [HttpGet]
        public async Task<ActionResult<List<CommentDto>>> GetAll()
        {
            return Ok(await _commentService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> GetById(int id)
        {
            var comment = await _commentService.GetById(id);
            if (comment == null) return NotFound("Comentário não encontrado.");
            return Ok(comment);
        }
    }
}
