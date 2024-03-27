using NewsPlatform.Application.Interfaces;
using NewsPlatform.Data.Entities;
using NewsPlatform.Domain.Interfaces;

namespace NewsPlatform.Application.Services
{
    public class NewsAppService : INewsAppService
    {
        private readonly INewsService _newsService;

        public NewsAppService(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<List<News>> GetAllNews()
        {
            return await _newsService.GetAllNews();
        }
    }
}
