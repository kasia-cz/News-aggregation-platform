using NewsPlatform.Application.DTOs.TopicDTOs;


namespace NewsPlatform.Application.Interfaces
{
    public interface ITopicAppService
    {
        Task<List<ReturnTopicDTO>> GetAllTopics();
        Task<List<ReturnTopicDTO>> AddTopic(AddTopicDTO requestTopicDTO);
        Task<List<ReturnTopicDTO>> DeleteTopic(Guid id);
        Task<List<ReturnTopicDTO>> GetSubscribedTopics();
        Task SubscribeTopic(Guid id);
        Task UnsubscribeTopic(Guid id);
    }
}
