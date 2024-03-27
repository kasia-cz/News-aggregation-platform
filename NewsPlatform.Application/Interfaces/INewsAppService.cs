using NewsPlatform.Data.Entities;

namespace NewsPlatform.Application.Interfaces
{
    public interface INewsAppService
    {
        Task<List<News>> GetAllNews();
    }
}
