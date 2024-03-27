using Microsoft.EntityFrameworkCore;
using NewsPlatform.Data.Context;
using NewsPlatform.Data.Entities;
using NewsPlatform.Domain.Interfaces;

namespace NewsPlatform.Domain.Services
{
    public class NewsService : INewsService
    {
        private readonly NewsPlatformDbContext _context;

        public NewsService(NewsPlatformDbContext context)
        {
            _context = context;
        }

        public async Task<List<News>> GetAllNews()
        {
            return await _context.News.ToListAsync();
        }
    }
}
