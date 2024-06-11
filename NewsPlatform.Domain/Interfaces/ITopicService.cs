using NewsPlatform.Data.Entities;

namespace NewsPlatform.Domain.Interfaces
{
    public interface ITopicService
    {
        Task<List<Topic>> GetAllTopics();
        Task<Topic> GetTopicById(Guid id);
        Task<List<Topic>> AddTopic(Topic topic);
        Task<List<Topic>> DeleteTopic(Guid id);
        Task<List<Topic>> GetSubscribedTopics();
        Task SubscribeTopic(Guid id);
        Task UnsubscribeTopic(Guid id);
    }
}
