using Microsoft.AspNetCore.Mvc;
using NewsPlatform.Application.DTOs.CommentDTOs;
using NewsPlatform.Application.Interfaces;

namespace NewsPlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentAppService _commentAppService;

        public CommentController(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;
        }

        [HttpGet("{newsId}")]
        public async Task<ActionResult<List<ReturnCommentDTO>>> GetNewsComments(Guid newsId)
        {
            var result = await _commentAppService.GetNewsComments(newsId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<ReturnCommentDTO>>> AddComment(AddCommentDTO requestCommentDTO)
        {
            var result = await _commentAppService.AddComment(requestCommentDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ReturnCommentDTO>>> DeleteComment(Guid id)
        {
            var result = await _commentAppService.DeleteComment(id);
            return Ok(result);
        }
    }
}
