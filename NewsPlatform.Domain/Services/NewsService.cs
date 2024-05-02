using Microsoft.EntityFrameworkCore;
using NewsPlatform.Data.Context;
using NewsPlatform.Data.Entities;
using NewsPlatform.Domain.Exceptions;
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

        public async Task<News> AddNews(News news)
        {
            news.PublishTime = DateTime.Now;
            news.PositivityRate = 5; // change later when positivity rate algorithm is ready
            _context.News.Add(news);
            await _context.SaveChangesAsync();

            return news;
        }

        public async Task<List<News>> DeleteNews(Guid id)
        {
            var news = await GetNewsById(id);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();

            return await _context.News.ToListAsync();
        }

        public async Task<List<News>> GetAllNews(int? minPositivityRate)
        {
            return await _context.News
                .Where(n => minPositivityRate == null || n.PositivityRate >= minPositivityRate).ToListAsync();
        }

        public async Task<News> GetNewsById(Guid id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                throw new BadRequestException("Invalid news ID");
            }
            return news;
        }

        public async Task<News> UpdateNews(Guid id, News requestNews)
        {
            var news = await GetNewsById(id);
            news.Title = requestNews.Title;
            news.Author = requestNews.Author;
            news.Content = requestNews.Content;
            await _context.SaveChangesAsync();

            return news;
        }
    }
}
