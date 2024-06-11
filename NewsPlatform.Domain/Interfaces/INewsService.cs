using NewsPlatform.Data.Entities;

namespace NewsPlatform.Domain.Interfaces
{
    public interface INewsService
    {
        Task<List<News>> GetAllNews();
        Task<News> GetNewsById(Guid id);
        Task<News> AddNews(News news);
        Task<List<News>> DeleteNews(Guid id);
        Task<News> UpdateNews(Guid id, News requestNews);

        Task<List<News>> AggregateNews();
    }
}
