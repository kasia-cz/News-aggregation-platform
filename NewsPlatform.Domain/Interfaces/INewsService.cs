using NewsPlatform.Data.Entities;

namespace NewsPlatform.Domain.Interfaces
{
    public interface INewsService
    {
        Task<List<News>> GetAllNews();
    }
}
