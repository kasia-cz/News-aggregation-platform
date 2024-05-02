using NewsPlatform.Data.Entities;

namespace NewsPlatform.Domain.Interfaces
{
    public interface INewsService
    {
        Task<List<News>> GetAllNews(int? minPositivityRate);
        Task<News> GetNewsById(Guid id);
        Task<News> AddNews(News news);
        Task<List<News>> DeleteNews(Guid id);
        Task<News> UpdateNews(Guid id, News requestNews);
    }
}
