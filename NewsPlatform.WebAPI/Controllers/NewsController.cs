using Microsoft.AspNetCore.Mvc;
using NewsPlatform.Application.Interfaces;
using NewsPlatform.Data.Entities;


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
        public async Task<ActionResult<List<News>>> GetAllNews()
        {
            var result = await _newsAppService.GetAllNews();
            return Ok(result);
        }
    }
}
