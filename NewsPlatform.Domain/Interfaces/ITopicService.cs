using NewsPlatform.Data.Entities;

namespace NewsPlatform.Domain.Interfaces
{
    public interface ITopicService
    {
        Task<List<Topic>> GetAllTopics();
        Task<List<Topic>> AddTopic(Topic topic);
        Task<List<Topic>> DeleteTopic(Guid id);
    }
}
