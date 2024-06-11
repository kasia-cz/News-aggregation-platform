using Microsoft.AspNetCore.Mvc;
using NewsPlatform.Application.DTOs.TopicDTOs;
using NewsPlatform.Application.Interfaces;

namespace NewsPlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicAppService _topicAppService;

        public TopicController(ITopicAppService topicAppService)
        {
            _topicAppService = topicAppService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ReturnTopicDTO>>> GetAllTopics()
        {
            var result = await _topicAppService.GetAllTopics();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<ReturnTopicDTO>>> AddTopic(AddTopicDTO requestTopicDTO)
        {
            var result = await _topicAppService.AddTopic(requestTopicDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ReturnTopicDTO>>> DeleteTopic(Guid id)
        {
            var result = await _topicAppService.DeleteTopic(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ReturnTopicDTO>>> GetSubscribedTopics()
        {
            var result = await _topicAppService.GetSubscribedTopics();
            return Ok(result);
        }

        [HttpPost("subscribe/{id}")]
        public async Task<ActionResult> SubscribeTopic(Guid id)
        {
            await _topicAppService.SubscribeTopic(id);
            return NoContent();
        }

        [HttpDelete("unsubscribe/{id}")]
        public async Task<ActionResult> UnsubscribeTopic(Guid id)
        {
            await _topicAppService.UnsubscribeTopic(id);
            return NoContent();
        }
    }
}
