using AutoMapper;
using NewsPlatform.Application.DTOs.TopicDTOs;
using NewsPlatform.Application.Interfaces;
using NewsPlatform.Data.Entities;
using NewsPlatform.Domain.Interfaces;


namespace NewsPlatform.Application.Services
{
    public class TopicAppService : ITopicAppService
    {
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;

        public TopicAppService(ITopicService topicService, IMapper mapper)
        {
            _topicService = topicService;
            _mapper = mapper;
        }

        public async Task<List<ReturnTopicDTO>> AddTopic(AddTopicDTO requestTopicDTO)
        {
            var requestTopic = _mapper.Map<Topic>(requestTopicDTO);
            var topicList = await _topicService.AddTopic(requestTopic);

            return _mapper.Map<List<ReturnTopicDTO>>(topicList);
        }

        public async Task<List<ReturnTopicDTO>> DeleteTopic(Guid id)
        {
            var topicList = await _topicService.DeleteTopic(id);

            return _mapper.Map<List<ReturnTopicDTO>>(topicList);
        }

        public async Task<List<ReturnTopicDTO>> GetAllTopics()
        {
            var topicList = await _topicService.GetAllTopics();

            return _mapper.Map<List<ReturnTopicDTO>>(topicList);
        }

        public async Task<List<ReturnTopicDTO>> GetSubscribedTopics()
        {
            var topicList = await _topicService.GetSubscribedTopics();

            return _mapper.Map<List<ReturnTopicDTO>>(topicList);
        }

        public async Task SubscribeTopic(Guid id)
        {
            await _topicService.SubscribeTopic(id);
        }

        public async Task UnsubscribeTopic(Guid id)
        {
            await _topicService.UnsubscribeTopic(id);
        }
    }
}
