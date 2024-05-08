using Microsoft.AspNetCore.Mvc;
using NewsPlatform.Application.DTOs.NewsDTOs;
using NewsPlatform.Application.Interfaces;

namespace NewsPlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsAppService _newsAppService;

        public NewsController(INewsAppService newsAppService)
        {
            _newsAppService = newsAppService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReturnNewsDTO>>> GetAllNews(int? minPositivityRate)
        {
            var result = await _newsAppService.GetAllNews(minPositivityRate);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnNewsDTO>> GetNewsById(Guid id)
        {
            var result = await _newsAppService.GetNewsById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ReturnNewsDTO>> AddNews(AddNewsDTO requestNewsDTO)
        {
            var result = await _newsAppService.AddNews(requestNewsDTO);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReturnNewsDTO>> UpdateNews(Guid id, AddNewsDTO requestNewsDTO)
        {
            var result = await _newsAppService.UpdateNews(id, requestNewsDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ReturnNewsDTO>>> DeleteNews(Guid id)
        {
            var result = await _newsAppService.DeleteNews(id);
            return Ok(result);
        }

        [HttpGet("aggregate")]
        public async Task<ActionResult<List<ReturnNewsDTO>>> AggregateNews()
        {
            var result = await _newsAppService.AggregateNews();
            return Ok(result);
        }
    }
}
