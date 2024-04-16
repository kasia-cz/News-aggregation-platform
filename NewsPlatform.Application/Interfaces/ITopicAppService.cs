using NewsPlatform.Application.DTOs.TopicDTOs;


namespace NewsPlatform.Application.Interfaces
{
    public interface ITopicAppService
    {
        Task<List<ReturnTopicDTO>> GetAllTopics();
        Task<List<ReturnTopicDTO>> AddTopic(AddTopicDTO requestTopicDTO);
        Task<List<ReturnTopicDTO>> DeleteTopic(Guid id);
    }
}
